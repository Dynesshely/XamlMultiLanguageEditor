namespace XamlMultiLanguageEditor.Winform
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button_load = new System.Windows.Forms.Button();
            textBox_path = new System.Windows.Forms.TextBox();
            listBox_keys = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            listBox_values = new System.Windows.Forms.ListBox();
            textBox_value = new System.Windows.Forms.TextBox();
            button_save_value = new System.Windows.Forms.Button();
            textBox_key = new System.Windows.Forms.TextBox();
            button_insert_key_after = new System.Windows.Forms.Button();
            button_rename_key = new System.Windows.Forms.Button();
            button_delete_key = new System.Windows.Forms.Button();
            button_insert_key_before = new System.Windows.Forms.Button();
            comboBox_langs = new System.Windows.Forms.ComboBox();
            button_create_lang = new System.Windows.Forms.Button();
            textBox_lang_name = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            button_delete_lang = new System.Windows.Forms.Button();
            button_theme = new System.Windows.Forms.Button();
            button_about = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button_load
            // 
            button_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_load.Location = new System.Drawing.Point(12, 12);
            button_load.Name = "button_load";
            button_load.Size = new System.Drawing.Size(75, 23);
            button_load.TabIndex = 0;
            button_load.Text = "Load";
            button_load.UseVisualStyleBackColor = true;
            button_load.Click += Button_load_Click;
            // 
            // textBox_path
            // 
            textBox_path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_path.Location = new System.Drawing.Point(93, 12);
            textBox_path.Name = "textBox_path";
            textBox_path.Size = new System.Drawing.Size(679, 23);
            textBox_path.TabIndex = 1;
            // 
            // listBox_keys
            // 
            listBox_keys.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            listBox_keys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBox_keys.FormattingEnabled = true;
            listBox_keys.HorizontalScrollbar = true;
            listBox_keys.ItemHeight = 17;
            listBox_keys.Location = new System.Drawing.Point(12, 68);
            listBox_keys.Name = "listBox_keys";
            listBox_keys.Size = new System.Drawing.Size(300, 376);
            listBox_keys.TabIndex = 2;
            listBox_keys.SelectedIndexChanged += ListBox_keys_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 17);
            label1.TabIndex = 3;
            label1.Text = "Keys";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(318, 43);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 17);
            label2.TabIndex = 5;
            label2.Text = "Values";
            // 
            // listBox_values
            // 
            listBox_values.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listBox_values.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBox_values.FormattingEnabled = true;
            listBox_values.HorizontalScrollbar = true;
            listBox_values.ItemHeight = 17;
            listBox_values.Location = new System.Drawing.Point(318, 68);
            listBox_values.Name = "listBox_values";
            listBox_values.Size = new System.Drawing.Size(454, 376);
            listBox_values.TabIndex = 4;
            listBox_values.SelectedIndexChanged += ListBox_values_SelectedIndexChanged;
            // 
            // textBox_value
            // 
            textBox_value.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            textBox_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_value.Location = new System.Drawing.Point(318, 459);
            textBox_value.Name = "textBox_value";
            textBox_value.Size = new System.Drawing.Size(373, 23);
            textBox_value.TabIndex = 6;
            // 
            // button_save_value
            // 
            button_save_value.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_save_value.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_save_value.Location = new System.Drawing.Point(697, 459);
            button_save_value.Name = "button_save_value";
            button_save_value.Size = new System.Drawing.Size(75, 23);
            button_save_value.TabIndex = 7;
            button_save_value.Text = "Save";
            button_save_value.UseVisualStyleBackColor = true;
            button_save_value.Click += Button_save_value_Click;
            // 
            // textBox_key
            // 
            textBox_key.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            textBox_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_key.Location = new System.Drawing.Point(12, 459);
            textBox_key.Name = "textBox_key";
            textBox_key.Size = new System.Drawing.Size(300, 23);
            textBox_key.TabIndex = 8;
            // 
            // button_insert_key_after
            // 
            button_insert_key_after.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button_insert_key_after.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_insert_key_after.Location = new System.Drawing.Point(12, 488);
            button_insert_key_after.Name = "button_insert_key_after";
            button_insert_key_after.Size = new System.Drawing.Size(95, 28);
            button_insert_key_after.TabIndex = 9;
            button_insert_key_after.Text = "Insert After";
            button_insert_key_after.UseVisualStyleBackColor = true;
            button_insert_key_after.Click += Button_insert_key_after_Click;
            // 
            // button_rename_key
            // 
            button_rename_key.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button_rename_key.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_rename_key.Location = new System.Drawing.Point(113, 488);
            button_rename_key.Name = "button_rename_key";
            button_rename_key.Size = new System.Drawing.Size(75, 28);
            button_rename_key.TabIndex = 10;
            button_rename_key.Text = "Rename";
            button_rename_key.UseVisualStyleBackColor = true;
            button_rename_key.Click += Button_rename_key_Click;
            // 
            // button_delete_key
            // 
            button_delete_key.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button_delete_key.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_delete_key.Location = new System.Drawing.Point(113, 521);
            button_delete_key.Name = "button_delete_key";
            button_delete_key.Size = new System.Drawing.Size(75, 28);
            button_delete_key.TabIndex = 11;
            button_delete_key.Text = "Delete";
            button_delete_key.UseVisualStyleBackColor = true;
            button_delete_key.Click += Button_delete_key_Click;
            // 
            // button_insert_key_before
            // 
            button_insert_key_before.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button_insert_key_before.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_insert_key_before.Location = new System.Drawing.Point(12, 521);
            button_insert_key_before.Name = "button_insert_key_before";
            button_insert_key_before.Size = new System.Drawing.Size(95, 28);
            button_insert_key_before.TabIndex = 12;
            button_insert_key_before.Text = "Insert Before";
            button_insert_key_before.UseVisualStyleBackColor = true;
            button_insert_key_before.Click += Button_insert_key_before_Click;
            // 
            // comboBox_langs
            // 
            comboBox_langs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            comboBox_langs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_langs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox_langs.FormattingEnabled = true;
            comboBox_langs.Location = new System.Drawing.Point(382, 524);
            comboBox_langs.Name = "comboBox_langs";
            comboBox_langs.Size = new System.Drawing.Size(141, 25);
            comboBox_langs.TabIndex = 13;
            // 
            // button_create_lang
            // 
            button_create_lang.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_create_lang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_create_lang.Location = new System.Drawing.Point(448, 488);
            button_create_lang.Name = "button_create_lang";
            button_create_lang.Size = new System.Drawing.Size(75, 28);
            button_create_lang.TabIndex = 14;
            button_create_lang.Text = "New Lang";
            button_create_lang.UseVisualStyleBackColor = true;
            button_create_lang.Click += Button_create_lang_Click;
            // 
            // textBox_lang_name
            // 
            textBox_lang_name.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            textBox_lang_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox_lang_name.Location = new System.Drawing.Point(318, 491);
            textBox_lang_name.Name = "textBox_lang_name";
            textBox_lang_name.Size = new System.Drawing.Size(124, 23);
            textBox_lang_name.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(318, 527);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(58, 17);
            label3.TabIndex = 15;
            label3.Text = "Base on:";
            // 
            // button_delete_lang
            // 
            button_delete_lang.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_delete_lang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_delete_lang.Location = new System.Drawing.Point(651, 488);
            button_delete_lang.Name = "button_delete_lang";
            button_delete_lang.Size = new System.Drawing.Size(121, 28);
            button_delete_lang.TabIndex = 16;
            button_delete_lang.Text = "Delete Lang";
            button_delete_lang.UseVisualStyleBackColor = true;
            button_delete_lang.Click += Button_delete_lang_Click;
            // 
            // button_theme
            // 
            button_theme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_theme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_theme.Location = new System.Drawing.Point(720, 521);
            button_theme.Name = "button_theme";
            button_theme.Size = new System.Drawing.Size(52, 28);
            button_theme.TabIndex = 17;
            button_theme.Text = "☀";
            button_theme.UseVisualStyleBackColor = true;
            button_theme.Click += Button_theme_Click;
            // 
            // button_about
            // 
            button_about.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_about.Location = new System.Drawing.Point(651, 521);
            button_about.Name = "button_about";
            button_about.Size = new System.Drawing.Size(63, 28);
            button_about.TabIndex = 18;
            button_about.Text = "About";
            button_about.UseVisualStyleBackColor = true;
            button_about.Click += Button_about_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(button_about);
            Controls.Add(button_theme);
            Controls.Add(button_delete_lang);
            Controls.Add(label3);
            Controls.Add(textBox_lang_name);
            Controls.Add(button_create_lang);
            Controls.Add(comboBox_langs);
            Controls.Add(button_insert_key_before);
            Controls.Add(button_delete_key);
            Controls.Add(button_rename_key);
            Controls.Add(button_insert_key_after);
            Controls.Add(textBox_key);
            Controls.Add(button_save_value);
            Controls.Add(textBox_value);
            Controls.Add(label2);
            Controls.Add(listBox_values);
            Controls.Add(label1);
            Controls.Add(listBox_keys);
            Controls.Add(textBox_path);
            Controls.Add(button_load);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(800, 600);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "XamlMultiLanguageEditor.Winform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.ListBox listBox_keys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_values;
        private System.Windows.Forms.TextBox textBox_value;
        private System.Windows.Forms.Button button_save_value;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Button button_insert_key_after;
        private System.Windows.Forms.Button button_rename_key;
        private System.Windows.Forms.Button button_delete_key;
        private System.Windows.Forms.Button button_insert_key_before;
        private System.Windows.Forms.ComboBox comboBox_langs;
        private System.Windows.Forms.Button button_create_lang;
        private System.Windows.Forms.TextBox textBox_lang_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_delete_lang;
        private System.Windows.Forms.Button button_theme;
        private System.Windows.Forms.Button button_about;
    }
}

