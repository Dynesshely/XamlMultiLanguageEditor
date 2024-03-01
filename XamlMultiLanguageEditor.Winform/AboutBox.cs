using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static XamlMultiLanguageEditor.Winform.FormUtils;

namespace XamlMultiLanguageEditor.Winform
{
    partial class AboutBox : Form
    {
        public AboutBox(string theme)
        {
            InitializeComponent();

            Text = string.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelAuthors.Text = $"Authors: {AssemblyCompany}";
            textBoxDescription.Text = ((Func<string>)(
                () =>
                {
                    var lines = SplitLinesRegex().Split(AssemblyDescription);

                    var result = new StringBuilder();

                    foreach (var item in lines)
                    {
                        if (string.IsNullOrWhiteSpace(item)) continue;

                        result.AppendLine(item.Trim());
                    }

                    return result.ToString();
                }
            ))();

            LoadTheme(theme);
        }

        private void LoadTheme(string uiMode)
        {
            var controls = new List<Control>()
            {
                this, textBoxDescription
            };

            var darkTitleBar = false;

            switch (uiMode)
            {
                case "light":
                    foreach (var control in controls)
                    {
                        control.ForeColor = Color.FromArgb(47, 54, 64);
                        control.BackColor = Color.FromArgb(245, 246, 250);
                    }
                    darkTitleBar = false;
                    break;
                case "dark":
                    foreach (var control in controls)
                    {
                        control.ForeColor = Color.FromArgb(245, 246, 250);
                        control.BackColor = Color.FromArgb(47, 54, 64);
                    }
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

        [GeneratedRegex("\r\n|\r|\n")]
        private static partial Regex SplitLinesRegex();

        #region AssemblyAttributeGetter

        public static string? AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static string? AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion
    }
}
