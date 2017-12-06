using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using System.Windows.Forms;

namespace PortableSettingsProvider
{
    public class PortableSettingsProvider : SettingsProvider
    {
        //XML Root Node
        const string SettingsRoot = "Settings";

        public override void Initialize(string name, NameValueCollection col)
        {
            base.Initialize(ApplicationName, col);
        }

        public override string ApplicationName
        {
            get
            {
                if (Application.ProductName.Trim().Length > 0)
                {
                    return Application.ProductName;
                }

                var fi = new FileInfo(Application.ExecutablePath);
                return fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
            }
            //Do nothing
            set { }
        }

        public virtual string GetAppSettingsPath()
        {
            //Used to determine where to store the settings
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            return fi.DirectoryName;
        }

        public virtual string GetAppSettingsFilename()
        {
            //Used to determine the filename to store the settings
            return ApplicationName + ".settings";
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propvals)
        {
            //Iterate through the settings to be stored
            //Only dirty settings are included in propvals, and only ones relevant to this provider
            foreach (SettingsPropertyValue propval in propvals)
            {
                SetValue(propval);
            }

            try
            {
                SettingsXml.Save(Path.Combine(GetAppSettingsPath(), GetAppSettingsFilename()));
            }
            catch (Exception)
            {
                //Ignore if cant save, device been ejected
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection props)
        {
            //Create new collection of values
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

            //Iterate through the settings to be retrieved

            foreach (SettingsProperty setting in props)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(setting);
                value.IsDirty = false;
                value.SerializedValue = GetValue(setting);
                values.Add(value);
            }
            return values;
        }


        private XmlDocument _mSettingsXml;
        private XmlDocument SettingsXml
        {
            get
            {
                //If we dont hold an xml document, try opening one.  
                //If it doesnt exist then create a new one ready.
                if (_mSettingsXml == null)
                {
                    _mSettingsXml = new XmlDocument();

                    try
                    {
                        _mSettingsXml.Load(Path.Combine(GetAppSettingsPath(), GetAppSettingsFilename()));
                    }
                    catch (Exception)
                    {
                        //Create new document
                        XmlDeclaration dec = _mSettingsXml.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
                        _mSettingsXml.AppendChild(dec);

                        var nodeRoot = _mSettingsXml.CreateNode(XmlNodeType.Element, SettingsRoot, "");
                        _mSettingsXml.AppendChild(nodeRoot);
                    }
                }

                return _mSettingsXml;
            }
        }

        private string GetValue(SettingsProperty setting)
        {
            try
            {
                if (IsRoaming(setting))
                {
                    return SettingsXml.SelectSingleNode(SettingsRoot + "/" + setting.Name)?.InnerText 
                        ?? GetDefaultValue(setting);
                }

                return SettingsXml.SelectSingleNode(SettingsRoot + "/" + Environment.MachineName 
                    + "/" + setting.Name)?.InnerText ?? GetDefaultValue(setting);
            }
            catch (Exception)
            {
                return GetDefaultValue(setting);
            }
        }

        private static string GetDefaultValue(SettingsProperty setting)
        {
            return setting.DefaultValue?.ToString() ?? string.Empty;
        }

        private void SetValue(SettingsPropertyValue propVal)
        {
            XmlElement settingNode;

            //Determine if the setting is roaming.
            //If roaming then the value is stored as an element under the root
            //Otherwise it is stored under a machine name node 
            try
            {
                if (IsRoaming(propVal.Property))
                {
                    settingNode = (XmlElement)SettingsXml.SelectSingleNode(SettingsRoot + "/" + propVal.Name);
                }
                else
                {
                    settingNode = (XmlElement)SettingsXml.SelectSingleNode(SettingsRoot + "/" + Environment.MachineName 
                        + "/" + propVal.Name);
                }
            }
            catch (Exception)
            {
                settingNode = null;
            }

            //Check to see if the node exists, if so then set its new value
            if ((settingNode != null))
            {
                settingNode.InnerText = propVal.SerializedValue.ToString();
            }
            else
            {
                if (IsRoaming(propVal.Property))
                {
                    //Store the value as an element of the Settings Root Node
                    settingNode = SettingsXml.CreateElement(propVal.Name);
                    settingNode.InnerText = propVal.SerializedValue.ToString();
                    SettingsXml.SelectSingleNode(SettingsRoot).AppendChild(settingNode);
                }
                else
                {
                    //Its machine specific, store as an element of the machine name node,
                    //creating a new machine name node if one doesnt exist.
                    XmlElement machineNode;
                    try
                    {
                        machineNode = (XmlElement)SettingsXml.SelectSingleNode(SettingsRoot + "/" + Environment.MachineName);
                    }
                    catch (Exception)
                    {
                        machineNode = SettingsXml.CreateElement(Environment.MachineName);
                        SettingsXml.SelectSingleNode(SettingsRoot).AppendChild(machineNode);
                    }

                    if (machineNode == null)
                    {
                        machineNode = SettingsXml.CreateElement(Environment.MachineName);
                        SettingsXml.SelectSingleNode(SettingsRoot).AppendChild(machineNode);
                    }

                    settingNode = SettingsXml.CreateElement(propVal.Name);
                    settingNode.InnerText = propVal.SerializedValue.ToString();
                    machineNode.AppendChild(settingNode);
                }
            }
        }

        private bool IsRoaming(SettingsProperty prop)
        {
            //Determine if the setting is marked as Roaming
            return prop.Attributes.Cast<DictionaryEntry>().Select(x=>x.Value)
                .OfType<SettingsManageabilityAttribute>().Any();
            
            /*foreach (DictionaryEntry d in prop.Attributes)
            {
                Attribute a = (Attribute)d.Value;
                if (a is SettingsManageabilityAttribute)
                {
                    return true;
                }
            }
            return false;*/
        }
    }
}
