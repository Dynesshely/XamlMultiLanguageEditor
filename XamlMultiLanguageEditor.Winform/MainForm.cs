using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XamlMultiLanguageEditor.Winform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly Dictionary<string, XmlDocument> _languages = new();
        private readonly Dictionary<string, string> _paths = new();
        private readonly Dictionary<string, Dictionary<string, string>> _langs
            = new();

        private void Button_load_Click(object sender, EventArgs e)
        {
            _languages.Clear();
            _langs.Clear();
            _paths.Clear();

            LoadFromDisk();

            RestoreUI();
            DrawUI();
        }

        private void LoadFromDisk()
        {
            var path = textBox_path.Text;
            if (path is null) return;
            path = Path.GetFullPath(path);
            if (!Directory.Exists(path)) return;
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var key = Path.GetFileNameWithoutExtension(file.FullName);
                _paths.Add(key, file.FullName);
                _languages.Add(key, new XmlDocument());
                _languages[key].Load(file.FullName);
            }

            LoadFromXmlDocuments();
        }

        private void LoadFromXmlDocuments()
        {
            var index = 0;
            foreach (var item in _languages)
            {
                var nodes = item.Value.DocumentElement?.ChildNodes;
                if (nodes is null) continue;
                foreach (XmlNode node in nodes)
                {
                    try
                    {
                        var key = node?.Attributes?["x:Key"]?.InnerText;
                        if (key is null) continue;
                        if (index == 0) _langs.Add(key, new Dictionary<string, string>());
                        _langs[key][item.Key] = node?.InnerText ?? string.Empty;
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }

                ++index;
            }
        }

        private void DrawUI()
        {
            listBox_keys.Items.Clear();
            foreach (var item in _langs)
            {
                listBox_keys.Items.Add(item.Key);
            }
        }

        private void RestoreUI()
        {
            listBox_keys.Items.Clear();
            listBox_values.Items.Clear();
        }

        private void ListBox_keys_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void LoadValues()
        {
            listBox_values.Items.Clear();
            var values = _langs[listBox_keys.SelectedItem as string];
            foreach (var item in values)
            {
                listBox_values.Items.Add($"{item.Key}:\t{item.Value}");
            }
        }

        private void ListBox_values_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_value.Text = RemoveLangKey(listBox_values.SelectedItem as string);
        }

        private string RemoveLangKey(string str)
        {
            foreach (var key in _languages.Keys)
                if (str.StartsWith(key))
                {
                    return str.Replace($"{key}:\t", "");
                }
            return string.Empty;
        }

        private string RemoveLangValue(string str)
        {
            foreach (var key in _languages.Keys)
                if (str.StartsWith(key)) return key;
            return string.Empty;
        }

        private void Button_save_value_Click(object sender, EventArgs e)
        {
            if (listBox_values.SelectedIndex >= 0)
            {
                var key = _languages.Keys.ToList()[listBox_values.SelectedIndex];
                var doc = _languages[key];
                var nodes = doc.DocumentElement?.ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["x:Key"].InnerText.Equals(listBox_keys.SelectedItem as string))
                    {
                        node.InnerText = textBox_value.Text;
                        break;
                    }
                }
                //doc.Save(_paths[key]);
                SaveXml(key, ref doc);

                _langs[listBox_keys.SelectedItem as string][key] = textBox_value.Text;
                var nowIndex = listBox_values.SelectedIndex;
                LoadValues();
                listBox_values.SelectedIndex = nowIndex;
            }
        }

        private void SaveXml(string key, ref XmlDocument doc)
        {
            using var xw = XmlWriter.Create(_paths[key], new()
            {
                Indent = true,
                Encoding = Encoding.UTF8,
                IndentChars = "    ",
                OmitXmlDeclaration = true,
            });
            doc.WriteTo(xw);
        }

        private void Button_insert_key_Click(object sender, EventArgs e)
        {
            if (listBox_keys.SelectedIndex >= 0)
            {

            }
        }
    }
}
