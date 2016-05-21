using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResxTranslator.Data.Tests
{
    public class TestResource : IResource
    {
        public TestResource(IEnumerable<KeyValuePair<string, string>> localizableData)
        {
            LocalizableData =
                new ObservableDictionary<string, string>(localizableData.ToDictionary(x => x.Key, x => x.Value));
            Metadata = new Dictionary<string, object>();
            OtherData = new Dictionary<string, ResXDataNode>();
        }

        public TestResource(IDictionary<string, object> metadata, IDictionary<string, string> localizableData,
            IDictionary<string, ResXDataNode> otherData)
        {
            Metadata = metadata;
            LocalizableData = new ObservableDictionary<string, string>(localizableData);
            OtherData = otherData;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string Filename { get; set; }
        public IDictionary<string, object> Metadata { get; }
        public ObservableDictionary<string, string> LocalizableData { get; }
        public IDictionary<string, ResXDataNode> OtherData { get; }
        public event EventHandler ChangedExternally;

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class TranslatedResourceGroupTests
    {
        public TranslatedResourceGroup TestResourceGroup { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var def = new TestResource(new[]
            {
                new KeyValuePair<string, string>("key1", "Key 1"),
                new KeyValuePair<string, string>("key2", "Key 2"),
                new KeyValuePair<string, string>("key3", "Key 3")
            });
            var translations = new Dictionary<CultureInfo, IResource>
            {
                {
                    CultureInfo.GetCultureInfo("en-us"),
                    new TestResource(new[]
                    {
                        new KeyValuePair<string, string>("key1", "En 1"),
                        new KeyValuePair<string, string>("key2", "En 2"),
                        new KeyValuePair<string, string>("key3", "En 3"),
                        new KeyValuePair<string, string>("key4", "En 4")
                    })
                },
                {
                    CultureInfo.GetCultureInfo("fr-FR"),
                    new TestResource(new[]
                    {
                        new KeyValuePair<string, string>("key2", "Fr 2"),
                        new KeyValuePair<string, string>("key3", "Fr 3"),
                        new KeyValuePair<string, string>("key4", "Fr 4")
                    })
                }
            };

            TestResourceGroup = new TranslatedResourceGroup(def, translations);
        }

        [TestMethod]
        public void GetTranslatedLanguagesTest()
        {
            Assert.IsTrue(TestResourceGroup.GetTranslatedLanguages()
                .SequenceEqual(new[] {CultureInfo.GetCultureInfo("en-us"), CultureInfo.GetCultureInfo("fr-FR")}));
        }

        [TestMethod]
        public void HasDefaultTranslationTest()
        {
            Assert.IsTrue(TestResourceGroup.HasDefaultTranslation());
        }

        [TestMethod]
        public void AddLocalizableStringTest()
        {
            const string key = "key5";
            var en = CultureInfo.GetCultureInfo("en-us");
            var fr = CultureInfo.GetCultureInfo("fr-FR");
            TestResourceGroup.AddLocalizableString(key, "Test", new Dictionary<CultureInfo, string>
            {
                {en, "En 5"},
                {fr, "Fr 5"}
            });

            Assert.AreEqual("Test", TestResourceGroup.DefaultTranslation.LocalizableData[key]);
            Assert.AreEqual("En 5", TestResourceGroup.Translations[en].LocalizableData[key]);
            Assert.AreEqual("Fr 5", TestResourceGroup.Translations[fr].LocalizableData[key]);
        }

        [TestMethod]
        public void RemoveLocalizableStringTest()
        {
            TestResourceGroup.RemoveLocalizableString("key1");
            Assert.IsFalse(TestResourceGroup.DefaultTranslation.LocalizableData.ContainsKey("key1"));
            Assert.IsFalse(
                TestResourceGroup.Translations[CultureInfo.GetCultureInfo("en-us")].LocalizableData.ContainsKey("key1"));
        }

        [TestMethod]
        public void TranslatedResourceContainsLanguages()
        {
            var str = TestResourceGroup.LocalizableStrings["key1"];
            Assert.AreEqual("Key 1", str.DefaultTranslation);

            var en = str.GetTranslatedLanguages().Single();
            Assert.AreEqual(CultureInfo.GetCultureInfo("en-us"), en);
            Assert.AreEqual("En 1", str.Translations[en]);
        }

        [TestMethod]
        public void TranslatedResourceMissingDefault()
        {
            var str = TestResourceGroup.LocalizableStrings["key4"];
            Assert.AreEqual(null, str.DefaultTranslation);

            Assert.AreEqual(2, str.GetTranslatedLanguages().Count());
        }

        [TestMethod]
        public void ModifyTranslatedResourceDefault()
        {
            var str = TestResourceGroup.LocalizableStrings["key1"];
            str.DefaultTranslation = "New value";

            Assert.AreEqual("New value", TestResourceGroup.DefaultTranslation.LocalizableData["key1"]);
        }

        [TestMethod]
        public void ModifyTranslatedResourceAddMissing()
        {
            var str = TestResourceGroup.LocalizableStrings["key4"];
            str.DefaultTranslation = "New value";

            Assert.AreEqual("New value", str.DefaultTranslation);
            Assert.AreEqual("New value", TestResourceGroup.DefaultTranslation.LocalizableData["key4"]);
        }

        [TestMethod]
        public void ModifyTranslatedResourceSpecificLang()
        {
            var str = TestResourceGroup.LocalizableStrings["key2"];
            var frc = CultureInfo.GetCultureInfo("fr-FR");

            Assert.AreEqual("Fr 2", str.Translations[frc]);
            str.Translations[frc] = "New value";

            Assert.AreEqual("New value", str.Translations[frc]);
            Assert.AreEqual("New value", TestResourceGroup.Translations[frc].LocalizableData["key2"]);
        }
    }
}