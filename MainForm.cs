using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Windows.Forms;


namespace ResxTranslator
{
	public partial class MainForm : Form
	{
		private string rootPath;
		private Dictionary<string, ResourceHolder> resources;
		private ResourceHolder currentResource;

		public MainForm()
		{
			InitializeComponent();
#if DEBUG
			rootPath = @"C:\Projects\Kick\KickP4\Client";
#endif

			resources = new Dictionary<string, ResourceHolder>();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.SelectedPath = rootPath;
			folderDialog.Description = "Browse to the root of the project, typically where the sln file is";
			if (folderDialog.ShowDialog(this) != DialogResult.OK)
				return;

			rootPath = folderDialog.SelectedPath;

			FindResx(rootPath);

			treeViewResx.Nodes.Clear();
			foreach (ResourceHolder resource in resources.Values)
			{
				BuildTreeView(resource);
			}

			treeViewResx.ExpandAll();

			openToolStripMenuItem.Enabled = false;
		}

		private void BuildTreeView(ResourceHolder resource)
		{
			TreeNode parentNode = null;
			string[] topFolders = resource.DisplayFolder.Split('\\');
			foreach (string subFolder in topFolders)
			{
				TreeNodeCollection searchNodes =
					parentNode == null ? treeViewResx.Nodes : parentNode.Nodes;
				bool found = false;
				foreach (TreeNode treeNode in searchNodes)
				{
					if (treeNode.Tag is PathHolder &&
						(treeNode.Tag as PathHolder).Id.Equals(
						subFolder, StringComparison.InvariantCultureIgnoreCase))
					{
						found = true;
						parentNode = treeNode;
						break;
					}
				}
				if (!found)
				{
					TreeNode pathTreeNode = new TreeNode("[" + subFolder + "]");
					PathHolder pathHolder = new PathHolder();
					pathHolder.Id = subFolder;
					pathTreeNode.Tag = pathHolder;
					searchNodes.Add(pathTreeNode);

					parentNode = pathTreeNode;
				}
			}

			TreeNode leafNode = new TreeNode(resource.Id);
			leafNode.Tag = resource;
			parentNode.Nodes.Add(leafNode);
		}

		private void FindResx(string folder)
		{
			string displayFolder = "";
			if (folder.StartsWith(rootPath, StringComparison.InvariantCultureIgnoreCase))
				displayFolder = folder.Substring(rootPath.Length);
			if (displayFolder.StartsWith("\\"))
				displayFolder = displayFolder.Remove(0, 1);

			string[] files = Directory.GetFiles(folder, "*.resx");

			foreach (string file in files)
			{
				string filename = Path.GetFileName(file);
				string filenameNoExt = Path.GetFileNameWithoutExtension(file);
				string[] fileParts = filenameNoExt.Split('.');
				if (fileParts.Length == 0)
					continue;

				string language = "";
				if (fileParts[fileParts.Length - 1].Length == 5 && fileParts[fileParts.Length - 1][2] == '-')
					language = fileParts[fileParts.Length - 1];
				else if (fileParts[fileParts.Length - 1].Length == 2)
					language = fileParts[fileParts.Length - 1];
				if (!string.IsNullOrEmpty(language))
					filenameNoExt = Path.GetFileNameWithoutExtension(filenameNoExt);

				ResourceHolder resourceHolder;
				string key = (displayFolder + "\\" + filenameNoExt).ToLower();
				if (!resources.TryGetValue(key, out resourceHolder))
				{
					resourceHolder = new ResourceHolder();
					resourceHolder.DisplayFolder = displayFolder;
					if (string.IsNullOrEmpty(language))
						resourceHolder.Filename = file;
					resourceHolder.Id = filenameNoExt;

					resources.Add(key, resourceHolder);
				}

				if (!string.IsNullOrEmpty(language))
				{
					if (!resourceHolder.Languages.ContainsKey(language.ToLower()))
					{
						LanguageHolder languageHolder = new LanguageHolder();
						languageHolder.Filename = file;
						languageHolder.Id = language;
						resourceHolder.Languages.Add(language.ToLower(), languageHolder);
					}
				}
				else
					resourceHolder.Filename = file;

			}

			string[] subfolders = Directory.GetDirectories(folder);
			foreach (string subfolder in subfolders)
			{
				FindResx(subfolder);
			}
		}

		private void treeViewResx_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedTreeNode = treeViewResx.SelectedNode;
			if (selectedTreeNode == null)
				return;

			if (selectedTreeNode.Tag is PathHolder)
				return;

			if (!(selectedTreeNode.Tag is ResourceHolder))
				// Shouldn't happen
				return;

			ResourceHolder resource = selectedTreeNode.Tag as ResourceHolder;

			OpenResource(resource);
			currentResource = resource;
		}

		private void OpenResource(ResourceHolder resource)
		{
			labelTitle.Text = resource.Id;
			checkedListBoxLanguages.Items.Clear();

			foreach (LanguageHolder languageHolder in resource.Languages.Values)
			{
				checkedListBoxLanguages.Items.Add(languageHolder, true);
			}

			gridEXStrings.DataSource = resource.StringsTable;
			gridEXStrings.RetrieveStructure();
			gridEXStrings.RootTable.Columns["Translated"].Visible = false;
			gridEXStrings.RootTable.Columns["Error"].Visible = false;
			Janus.Windows.GridEX.GridEXFormatCondition formatCondition =
				new Janus.Windows.GridEX.GridEXFormatCondition(
					gridEXStrings.RootTable.Columns["Error"], Janus.Windows.GridEX.ConditionOperator.Equal, true);
			gridEXStrings.RootTable.FormatConditions.Add(formatCondition);
			formatCondition.FormatStyle.ForeColor = Color.Red;

			ApplyFilterCondition();

			gridEXStrings.RootTable.Columns["Key"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
			gridEXStrings.RootTable.SortKeys.Add(gridEXStrings.RootTable.Columns["Key"]);
		}

		private void checkedListBoxLanguages_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			LanguageHolder languageHolder = checkedListBoxLanguages.Items[e.Index] as LanguageHolder;
			if (languageHolder == null)
				return;

			if (gridEXStrings.RootTable == null)
				// Not populated yet
				return;

			if (gridEXStrings.RootTable.Columns.Contains(languageHolder.Id))
				gridEXStrings.RootTable.Columns[languageHolder.Id].Visible = e.NewValue == CheckState.Checked;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Save

			foreach (ResourceHolder resource in resources.Values)
			{
				try
				{
					if (!resource.IsDirty)
						continue;

					resource.Save();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Exception while saving: " + resource.Id);
				}
			}
		}

		private void ApplyFilterCondition()
		{
            if (gridEXStrings.RootTable == null)
                return;

			if (hideNontranslatedToolStripMenuItem.Checked)
			{
				Janus.Windows.GridEX.GridEXFilterCondition filter =
					new Janus.Windows.GridEX.GridEXFilterCondition(
						gridEXStrings.RootTable.Columns["Translated"],
						Janus.Windows.GridEX.ConditionOperator.Equal, true);
				gridEXStrings.RootTable.FilterCondition = filter;
			}
			else
				gridEXStrings.RootTable.RemoveFilter();
		}

		private void hideNontranslatedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			hideNontranslatedToolStripMenuItem.Checked = !hideNontranslatedToolStripMenuItem.Checked;

			ApplyFilterCondition();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool isDirty = false;
			foreach (ResourceHolder resource in resources.Values)
			{
				if (resource.IsDirty)
				{
					isDirty = true;
					break;
				}
			}

			if (isDirty)
			{
				if (MessageBox.Show("Are you sure you want to quit without saving?", "Quit?", MessageBoxButtons.YesNoCancel) ==
					DialogResult.Yes)
					return;

				e.Cancel = true;
			}
		}

        private void gridEXStrings_DoubleClick(object sender, EventArgs e)
        {
            if (gridEXStrings.RowCount == 0)
                return;

            ZoomWindow frm = new ZoomWindow();
            object value = gridEXStrings.GetValue(gridEXStrings.Col);
            frm.textBoxString.Text = (string)value;
            frm.ShowDialog();
            gridEXStrings.SetValue(gridEXStrings.Col, frm.textBoxString.Text);
        }


	}


	public class LanguageHolder
	{
		public string Id { get; set; }
		public string Filename { get; set; }

		public override string ToString()
		{
			return Id;
		}
	}


	public class ResourceHolder
	{
		private DataTable stringsTable;
		private bool dirty;

		public string Filename { get; set; }
		public string DisplayFolder { get; set; }
		public string Id { get; set; }
		public Dictionary<string, LanguageHolder> Languages { get; private set; }
		public DataTable StringsTable
		{
			get
			{
				if (stringsTable == null)
					LoadResource();
				return stringsTable;
			}
			private set
			{
				stringsTable = value;
			}
		}

		public ResourceHolder()
		{
			Languages = new Dictionary<string, LanguageHolder>();
			dirty = false;
		}

		public bool IsDirty
		{
			get
			{
				if (stringsTable == null)
					return false;

				return dirty;
			}
		}

		private void UpdateFile(string filename, string valueColumn)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filename);

			HashSet<string> usedKeys = new HashSet<string>();
			List<XmlNode> nodesToBeDeleted = new List<XmlNode>();
			foreach (XmlNode dataNode in xmlDoc.SelectNodes("/root/data"))
			{
				if (dataNode.Attributes["type"] != null)
					// Only support strings
					continue;

				if (dataNode.Attributes["name"] == null)
					// Missing name
					continue;

				string key = dataNode.Attributes["name"].Value;
				DataRow[] rows = stringsTable.Select("Key = '" + key + "'");
				if (rows.Length > 0)
				{
					bool anyData = false;
					if (rows[0][valueColumn] == DBNull.Value || string.IsNullOrEmpty((string)rows[0][valueColumn]))
					{
						// Delete value
						foreach (XmlNode childNode in dataNode.ChildNodes)
							if (childNode.Name == "value")
							{
								childNode.InnerText = "";
								break;
							}
					}
					else
					{
						// Add/update
						anyData = true;
						bool found = false;
						foreach (XmlNode childNode in dataNode.ChildNodes)
							if (childNode.Name == "value")
							{
								childNode.InnerText = (string)rows[0][valueColumn];
								found = true;
								break;
							}
						if (!found)
						{
							// Add
							XmlNode newNode = xmlDoc.CreateElement("value");
							newNode.InnerText = (string)rows[0][valueColumn];
							dataNode.AppendChild(newNode);
						}
					}


					if (rows[0]["Comment"] == DBNull.Value || string.IsNullOrEmpty((string)rows[0]["Comment"]))
					{
						// Delete comment
						foreach (XmlNode childNode in dataNode.ChildNodes)
							if (childNode.Name == "comment")
							{
								dataNode.RemoveChild(childNode);
								break;
							}
					}
					else
					{
						// Add/update
						anyData = true;
						bool found = false;
						foreach (XmlNode childNode in dataNode.ChildNodes)
							if (childNode.Name == "comment")
							{
								childNode.InnerText = (string)rows[0]["Comment"];
								found = true;
								break;
							}
						if (!found)
						{
							// Add
							XmlNode newNode = xmlDoc.CreateElement("comment");
							newNode.InnerText = (string)rows[0]["Comment"];
							dataNode.AppendChild(newNode);
						}
					}

					if (!anyData)
					{
						// Remove
						nodesToBeDeleted.Add(dataNode);
					}

					usedKeys.Add(key);
				}
			}

			XmlNode rootNode = xmlDoc.SelectSingleNode("/root");
			foreach (XmlNode deleteNode in nodesToBeDeleted)
			{
				rootNode.RemoveChild(deleteNode);
			}

			foreach (DataRow row in stringsTable.Rows)
			{
				string key = (string)row["Key"];
				if (!usedKeys.Contains(key))
				{
					// Add
					XmlNode newNode = xmlDoc.CreateElement("data");
					XmlAttribute newAttribute = xmlDoc.CreateAttribute("name");
					newAttribute.Value = key;
					newNode.Attributes.Append(newAttribute);

					newAttribute = xmlDoc.CreateAttribute("xml:space");
					newAttribute.Value = "preserve";
					newNode.Attributes.Append(newAttribute);

					bool anyData = false;
					if (row["Comment"] != DBNull.Value && !string.IsNullOrEmpty((string)row["Comment"]))
					{
						XmlNode newComment = xmlDoc.CreateElement("comment");
						newComment.InnerText = (string)row["Comment"];
						newNode.AppendChild(newComment);
						anyData = true;
					}

					if (row[valueColumn] != DBNull.Value && !string.IsNullOrEmpty((string)row[valueColumn]))
					{
						XmlNode newValue = xmlDoc.CreateElement("value");
						newValue.InnerText = (string)row[valueColumn];
						newNode.AppendChild(newValue);
						anyData = true;
					}
					else if (anyData)
					{
						XmlNode newValue = xmlDoc.CreateElement("value");
						newValue.InnerText = "";
						newNode.AppendChild(newValue);
					}

					if (anyData)
						xmlDoc.SelectSingleNode("/root").AppendChild(newNode);
				}
			}

			xmlDoc.Save(filename);
		}

		public void Save()
		{
			UpdateFile(Filename, "NoLanguageValue");

			foreach (LanguageHolder languageHolder in Languages.Values)
			{
				UpdateFile(languageHolder.Filename, languageHolder.Id);
			}
			dirty = false;
		}

		private void ReadResourceFile(string filename, DataTable stringsTable,
			string valueColumn, bool isTranslated)
		{
			using (System.Resources.ResXResourceReader reader =
				new System.Resources.ResXResourceReader(filename))
			{
				reader.UseResXDataNodes = true;
				foreach (DictionaryEntry de in reader)
				{
					string key = (string)de.Key;
					if (key.StartsWith(">>") || key.StartsWith("$"))
						continue;

					System.Resources.ResXDataNode dataNode = de.Value as System.Resources.ResXDataNode;
					if (dataNode == null)
						continue;
					if (dataNode.FileRef != null)
						continue;

					string valueType = dataNode.GetValueTypeName((System.ComponentModel.Design.ITypeResolutionService)null);
					if (!valueType.StartsWith("System.String, "))
						continue;

					object valueObject = dataNode.GetValue((System.ComponentModel.Design.ITypeResolutionService)null);
					string value = valueObject == null ? "" : valueObject.ToString();

					DataRow[] existingRows = stringsTable.Select("Key = '" + key + "'");
					if (existingRows.Length == 0)
					{
						DataRow newRow = stringsTable.NewRow();
						newRow["Key"] = key;
						newRow[valueColumn] = value;
						newRow["Comment"] = dataNode.Comment;
						newRow["Error"] = false;
						newRow["Translated"] = isTranslated && !string.IsNullOrEmpty(value);
						stringsTable.Rows.Add(newRow);
					}
					else
					{
						existingRows[0][valueColumn] = value;
						if (string.IsNullOrEmpty((string)existingRows[0]["Comment"]) &&
							!string.IsNullOrEmpty(dataNode.Comment))
							existingRows[0]["Comment"] = dataNode.Comment;
						if (isTranslated && !string.IsNullOrEmpty(value))
							existingRows[0]["Translated"] = true;
					}
				}
			}
		}

		public void EvaluateRow(DataRow row)
		{
			bool foundOne = false;
			bool oneMissing = false;
			foreach (LanguageHolder languageHolder in Languages.Values)
			{
				string value = null;
				if (row[languageHolder.Id] != DBNull.Value)
					value = (string)row[languageHolder.Id];
				if (!string.IsNullOrEmpty(value))
					foundOne = true;
				if (string.IsNullOrEmpty(value) || value.StartsWith("[") && value.Contains("]"))
					oneMissing = true;
			}

			if (foundOne && oneMissing)
			{
				row["Error"] = true;
				return;
			}

			if (foundOne && (row["NoLanguageValue"] == DBNull.Value ||
				string.IsNullOrEmpty((string)row["NoLanguageValue"])))
			{
				row["Error"] = true;
				return;
			}

			row["Error"] = false;
		}

		public void LoadResource()
		{
			stringsTable = new DataTable("Strings");

			stringsTable.Columns.Add("Key");
			stringsTable.Columns.Add("NoLanguageValue");
			foreach (LanguageHolder languageHolder in Languages.Values)
			{
				stringsTable.Columns.Add(languageHolder.Id);
			}
			stringsTable.Columns.Add("Comment");
			stringsTable.Columns.Add("Translated", typeof(bool));
			stringsTable.Columns.Add("Error", typeof(bool));

			if (!string.IsNullOrEmpty(Filename))
				ReadResourceFile(Filename, stringsTable, "NoLanguageValue", false);
			foreach (LanguageHolder languageHolder in Languages.Values)
			{
				ReadResourceFile(languageHolder.Filename, stringsTable, languageHolder.Id, true);
			}

			if (Languages.Count > 0)
			{
				foreach (DataRow row in stringsTable.Rows)
					EvaluateRow(row);
			}

			stringsTable.ColumnChanged += new DataColumnChangeEventHandler(stringsTable_ColumnChanged);
		}

		void stringsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (e.Column != e.Column.Table.Columns["Error"])
			{
				dirty = true;
				EvaluateRow(e.Row);
			}
		}

	}


	public class PathHolder
	{
		public string Id { get; set; }
	}
}
