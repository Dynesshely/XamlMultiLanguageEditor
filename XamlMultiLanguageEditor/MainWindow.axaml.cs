using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml;
using Avalonia.Controls;
using Avalonia.Data;

namespace XamlMultiLanguageEditor
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel = new();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;

            InitEvents();
        }

        private readonly Dictionary<string, XmlDocument> _languages = new();

        private void InitEvents()
        {
            LoadButton.Click += ((sender, args) =>
            {
                var path = LangsFilePathTextBox.Text;
                if (path is null) return;
                path = Path.GetFullPath(path);
                if (!Directory.Exists(path)) return;
                var dir = new DirectoryInfo(path);
                var files = dir.GetFiles();
                foreach (var file in files)
                {
                    var key = Path.GetFileNameWithoutExtension(file.FullName);
                    _languages.Add(key, new XmlDocument());
                    _languages[key].Load(file.FullName);
                }

                var index = 0;
                var langs = new Dictionary<string, Dictionary<string, string>>();
                foreach (var item in _languages)
                {
                    var nodes = item.Value.DocumentElement?.ChildNodes;
                    if (nodes is null) continue;
                    foreach (XmlNode? node in nodes)
                    {
                        try
                        {
                            var key = node?.Attributes?["x:Key"]?.InnerText;
                            if (key is null) continue;
                            if (index == 0) langs.Add(key, new Dictionary<string, string>());
                            langs[key][item.Key] = node?.InnerText ?? string.Empty;
                        }
                        catch (Exception ex)
                        {
                            // ignored
                        }
                    }

                    ++index;
                }

                ;
            });
        }
    }
}