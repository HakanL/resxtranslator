using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResxTranslator.Data.Tests
{
    [TestClass]
    public class ResxResourceTests
    {
        private static readonly string WorkDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [TestInitialize]
        public void Setup()
        {
            // Need to set CurrentDirectory for GetValue to find the icon file
            // It looks in ../Resources, but doesn't care for the path that the resource was loaded from, and instead uses CurrentDirectory
            Environment.CurrentDirectory = Path.Combine(WorkDirectory, "Data");
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete("WriteTest.resx");
        }

        [TestMethod]
        public void ReadTest()
        {
            using (var res = new ResxResource())
            {
                res.Filename = "TestResource.resx";
                res.Read();

                Assert.AreEqual(3, res.LocalizableData.Count);
                Assert.AreEqual(1, res.OtherData.Count);
                Assert.AreEqual("Test 1", res.LocalizableData["String1"]);
                Assert.AreEqual("Test 2", res.LocalizableData["String2"]);
                Assert.AreEqual("Test 3", res.LocalizableData["String3"]);
                Assert.IsInstanceOfType(res.OtherData.Single().Value.
                    GetValue(AppDomain.CurrentDomain.GetAssemblies().Select(x => x.GetName()).ToArray()),
                    typeof(Icon));
            }
        }

        [TestMethod]
        public void WriteTest()
        {
            using (var res = new ResxResource("TestResource.resx"))
            {
                Assert.AreEqual(3, res.LocalizableData.Count);
                Assert.AreEqual(1, res.OtherData.Count);
                Assert.AreEqual("Test 1", res.LocalizableData["String1"]);
                Assert.AreEqual("Test 2", res.LocalizableData["String2"]);
                Assert.AreEqual("Test 3", res.LocalizableData["String3"]);

                res.Filename = "WriteTest.resx";
                res.Write();

                Assert.IsTrue(File.Exists("WriteTest.resx"));
            }

            using (var res = new ResxResource("WriteTest.resx"))
            {
                Assert.AreEqual(3, res.LocalizableData.Count);
                Assert.AreEqual(1, res.OtherData.Count);
                Assert.AreEqual("Test 1", res.LocalizableData["String1"]);
                Assert.AreEqual("Test 2", res.LocalizableData["String2"]);
                Assert.AreEqual("Test 3", res.LocalizableData["String3"]);
            }
        }
    }
}