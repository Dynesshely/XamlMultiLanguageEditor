﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static XamlMultiLanguageEditor.Winform.FormUtils;

namespace XamlMultiLanguageEditor.Winform;

public partial class MainForm : Form
{
    private Configuration? Config { get; set; }

    public MainForm()
    {
        InitializeComponent();

        Load += MainForm_Load;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        CheckTheme();

        Parser.Default.ParseArguments<Options.Options>(Environment.GetCommandLineArgs())
            .WithParsed(options =>
            {
                textBox_path.Text = Path.GetFullPath(options.LoadTarget!);

                Button_load_Click(this, new());
            });
    }

    private void CheckTheme()
    {
        var controls = new List<Control>()
        {
            this,
            textBox_key, textBox_lang_name, textBox_path, textBox_value,
            comboBox_langs,
            listBox_keys, listBox_values,
        };

        var uiMode = Config!.AppSettings.Settings["UiMode"].Value;

        if (uiMode is null) return;

        var darkTitleBar = false;

        switch (uiMode)
        {
            case "light":
                foreach (var control in controls)
                {
                    control.ForeColor = Color.FromArgb(47, 54, 64);
                    control.BackColor = Color.FromArgb(245, 246, 250);
                }
                button_theme.Text = "🌙";
                darkTitleBar = false;
                break;
            case "dark":
                foreach (var control in controls)
                {
                    control.ForeColor = Color.FromArgb(245, 246, 250);
                    control.BackColor = Color.FromArgb(47, 54, 64);
                }
                button_theme.Text = "☀";
                darkTitleBar = true;
                break;
            default:
                break;
        }

        var preference = Convert.ToInt32(darkTitleBar);

        try
        {
            Marshal.ThrowExceptionForHR(
                DwmSetWindowAttribute(
                    Handle,
                    DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                    ref preference,
                    sizeof(uint)
                )
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.Message}\r\n{ex}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private readonly Dictionary<string, XmlDocument> _languages = [];
    private readonly Dictionary<string, string> _paths = [];
    private readonly Dictionary<string, Dictionary<string, string>> _langs = [];

    private const string ns_x = "http://schemas.microsoft.com/winfx/2006/xaml";

    private string _ex1 = string.Empty;
    private string _ex2 = string.Empty;

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

                    if (index == 0) _langs.Add(key, []);

                    _langs[key][item.Key] = node?.InnerText ?? string.Empty;
                }
                catch (Exception ex)
                {
                    _ex1 = ex.Message;
                    _ex2 = _ex1;
                }
            }

            ++index;
        }
    }

    private void DrawUI()
    {
        listBox_keys.Items.Clear();
        foreach (var item in _langs)
            listBox_keys.Items.Add(item.Key);
        comboBox_langs.Items.Clear();
        foreach (var item in _languages.Keys)
            comboBox_langs.Items.Add(item);
    }

    private void RestoreUI()
    {
        listBox_keys.Items.Clear();
        listBox_values.Items.Clear();
        comboBox_langs.Items.Clear();
    }

    private void ListBox_keys_SelectedIndexChanged(object sender, EventArgs e)
    {
        textBox_key.Text = listBox_keys.SelectedItem as string;

        if (listBox_keys.SelectedIndex >= 0)
            LoadValues();

        if (comboBox_langs.SelectedIndex >= 0)
            for (int i = 0; i < listBox_values.Items.Count; ++i)
                if (listBox_values.Items[i].ToString()!.StartsWith((comboBox_langs.SelectedItem as string)!))
                {
                    listBox_values.SelectedIndex = i;
                    break;
                }

    }

    private void LoadValues()
    {
        try
        {
            listBox_values.Items.Clear();

            var key = listBox_keys.SelectedItem as string;

            if (!_langs.TryGetValue(key!, out Dictionary<string, string>? value)) return;

            var values = value;

            foreach (var item in values)
                listBox_values.Items.Add($"{item.Key}:\t{item.Value}");
        }
        catch (Exception ex)
        {
            _ex2 = ex.Message;
            _ex1 = _ex2;
        }
    }

    private void ListBox_values_SelectedIndexChanged(object sender, EventArgs e)
    {
        var key = listBox_values.SelectedItem as string;

        if (listBox_values.SelectedIndex >= 0)
            textBox_value.Text = RemoveLangKey(key!);

        var lang = RemoveLangValue(key!);

        comboBox_langs.SelectedItem = lang;
        textBox_lang_name.Text = lang;
    }

    private string RemoveLangKey(string str)
    {
        try
        {
            foreach (var key in _languages.Keys)
                if (str.StartsWith(key))
                {
                    return str.Replace($"{key}:\t", "");
                }
            return string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    private string RemoveLangValue(string str)
    {
        try
        {
            foreach (var key in _languages.Keys)
                if (str.StartsWith(key)) return key;
            return string.Empty;
        }
        catch (Exception ex)
        {
            _ex1 = ex.Message;
            _ex2 = _ex1;
            return string.Empty;
        }
    }

    private void Button_save_value_Click(object sender, EventArgs e)
    {
        if (listBox_values.SelectedIndex >= 0)
        {
            var key = _languages.Keys.ToList()[listBox_values.SelectedIndex];
            var doc = _languages[key];
            var nodes = doc.DocumentElement!.ChildNodes;

            foreach (XmlNode node in nodes)
                if (node.Attributes!["x:Key"]!.InnerText.Equals(listBox_keys.SelectedItem as string))
                {
                    node.InnerText = textBox_value.Text;
                    break;
                }

            SaveXml(key, ref doc);

            _langs[(listBox_keys.SelectedItem as string)!][key] = textBox_value.Text;

            var nowIndex = listBox_values.SelectedIndex;

            LoadValues();

            listBox_values.SelectedIndex = nowIndex;
        }
    }

    private void SaveXml(string key, ref XmlDocument doc)
    {
        using (var xw = XmlWriter.Create(_paths[key], new()
        {
            Indent = true,
            Encoding = Encoding.UTF8,
            IndentChars = "    ",
            OmitXmlDeclaration = true,
            NamespaceHandling = NamespaceHandling.OmitDuplicates,
        }))
        {
            doc.WriteTo(xw);
        }
        File.AppendAllText(_paths[key], "\r\n");
    }

    private void SaveAllXml()
    {
        foreach (var key in _languages.Keys)
        {
            XmlDocument doc = _languages[key];
            SaveXml(key, ref doc);
        }
    }

    private void Button_insert_key_after_Click(object sender, EventArgs e)
        => InsertKeyFromUI(true);

    private void Button_insert_key_before_Click(object sender, EventArgs e)
        => InsertKeyFromUI(false);

    private void InsertKeyFromUI(bool insertAfter)
    {
        if (listBox_keys.SelectedIndex >= 0)
        {
            string key = textBox_key.Text;
            if (_langs.ContainsKey(key))
            {
                Messages.ShowDumplicatedKeyTip();
                return;
            }
            listBox_keys.Items.Insert(listBox_keys.SelectedIndex + (insertAfter ? 1 : 0), key);
            InsertKey(key, listBox_keys.SelectedIndex, insertAfter);
        }
    }

    private void InsertKey(string key, int index, bool insertAfter = true)
    {
        foreach (var lang in _languages)
        {
            var doc = lang.Value;
            var root = doc.DocumentElement;
            var nodes = root!.ChildNodes;
            var node = CreateNode(ref doc, key, key);
            if (insertAfter) root.InsertAfter(node, nodes[index]);
            else root.InsertBefore(node, nodes[index - 1]);
        }
        SaveAllXml();

        ReflactInsertation(key);
    }

    private void ReflactInsertation(string key)
    {
        var dict = new Dictionary<string, string>();

        foreach (var lang in _languages.Keys)
            dict.Add(lang, key);

        _langs.Add(key, dict);
    }

    private static XmlNode CreateNode(ref XmlDocument doc, string key, string value)
    {
        var node = doc.CreateElement("x:String", ns_x);
        var attribute = doc.CreateAttribute("x:Key", ns_x);

        attribute.InnerXml = key;
        node.Attributes.Append(attribute);
        node.InnerXml = value;

        return node;
    }

    private void Button_rename_key_Click(object sender, EventArgs e)
    {
        if (_langs.ContainsKey(textBox_key.Text))
        {
            Messages.ShowDumplicatedKeyTip();
            return;
        }

        var index = listBox_keys.SelectedIndex;

        if (index < 0) return;

        try
        {
            foreach (var lang in _languages)
            {
                var doc = lang.Value;
                var nodes = doc.DocumentElement!.ChildNodes;

                nodes[index]!.Attributes!["x:Key"]!.InnerText = textBox_key.Text;
            }

            SaveAllXml();

            var key = listBox_keys.SelectedItem as string;

            var dict = _langs[key!];

            _langs.Remove(key!);

            _langs.Add(textBox_key.Text, dict);

            listBox_keys.Items.Clear();

            foreach (var item in _langs.Keys)
                listBox_keys.Items.Add(item);

            listBox_keys.SelectedIndex = index;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.Message}\r\n{ex}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void Button_delete_key_Click(object sender, EventArgs e)
    {
        var index = listBox_keys.SelectedIndex;
        if (index < 0) return;

        try
        {
            foreach (var lang in _languages)
            {
                var doc = lang.Value;
                var root = doc.DocumentElement;
                var nodes = root!.ChildNodes;

                root.RemoveChild(nodes[index]!);
            }

            SaveAllXml();

            var key = listBox_keys.SelectedItem as string;

            _langs.Remove(key!);

            listBox_keys.SelectedIndex = -1;
            listBox_keys.Items.RemoveAt(index);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.Message}\r\n{ex}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void Button_create_lang_Click(object sender, EventArgs e)
    {
        try
        {
            var baselang = _paths[(comboBox_langs.SelectedItem as string)!];

            var destpath = $"{Path.GetDirectoryName(baselang)}/{textBox_lang_name.Text}{Path.GetExtension(baselang)}";

            destpath = Path.GetFullPath(destpath);

            File.Copy(baselang, destpath);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"{ex.Message}\r\n{ex}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void Button_delete_lang_Click(object sender, EventArgs e)
    {
        try
        {
            File.Delete(_paths[RemoveLangValue((listBox_values.SelectedItem as string)!)]);
        }
        catch (Exception ex)
        {
            _ex1 = ex.Message;
            _ex2 = _ex1;
        }
    }

    private void Button_theme_Click(object sender, EventArgs e)
    {
        var uiMode = Config!.AppSettings.Settings["UiMode"].Value;

        if (uiMode is null) return;

        switch (uiMode)
        {
            case "light":
                Config.AppSettings.Settings["UiMode"].Value = "dark";
                (sender as Button)!.Text = "☀";
                break;
            case "dark":
                Config.AppSettings.Settings["UiMode"].Value = "light";
                (sender as Button)!.Text = "🌙";
                break;
        }

        Config.Save(ConfigurationSaveMode.Full, true);
        ConfigurationManager.RefreshSection("appSettings");

        CheckTheme();
    }

    private void Button_about_Click(object sender, EventArgs e)
    {
        new AboutBox(Config!.AppSettings.Settings["UiMode"].Value).ShowDialog(this);
    }
}
