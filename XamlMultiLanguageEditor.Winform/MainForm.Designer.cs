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
            this.button_load = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.listBox_keys = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_values = new System.Windows.Forms.ListBox();
            this.textBox_value = new System.Windows.Forms.TextBox();
            this.button_save_value = new System.Windows.Forms.Button();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.button_insert_key_after = new System.Windows.Forms.Button();
            this.button_rename_key = new System.Windows.Forms.Button();
            this.button_delete_key = new System.Windows.Forms.Button();
            this.button_insert_key_before = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(12, 12);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.Button_load_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_path.Location = new System.Drawing.Point(93, 12);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(679, 23);
            this.textBox_path.TabIndex = 1;
            // 
            // listBox_keys
            // 
            this.listBox_keys.FormattingEnabled = true;
            this.listBox_keys.HorizontalScrollbar = true;
            this.listBox_keys.ItemHeight = 17;
            this.listBox_keys.Location = new System.Drawing.Point(12, 58);
            this.listBox_keys.Name = "listBox_keys";
            this.listBox_keys.Size = new System.Drawing.Size(300, 395);
            this.listBox_keys.TabIndex = 2;
            this.listBox_keys.SelectedIndexChanged += new System.EventHandler(this.ListBox_keys_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Values";
            // 
            // listBox_values
            // 
            this.listBox_values.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_values.FormattingEnabled = true;
            this.listBox_values.HorizontalScrollbar = true;
            this.listBox_values.ItemHeight = 17;
            this.listBox_values.Location = new System.Drawing.Point(318, 58);
            this.listBox_values.Name = "listBox_values";
            this.listBox_values.Size = new System.Drawing.Size(454, 395);
            this.listBox_values.TabIndex = 4;
            this.listBox_values.SelectedIndexChanged += new System.EventHandler(this.ListBox_values_SelectedIndexChanged);
            // 
            // textBox_value
            // 
            this.textBox_value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_value.Location = new System.Drawing.Point(318, 468);
            this.textBox_value.Name = "textBox_value";
            this.textBox_value.Size = new System.Drawing.Size(373, 23);
            this.textBox_value.TabIndex = 6;
            // 
            // button_save_value
            // 
            this.button_save_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save_value.Location = new System.Drawing.Point(697, 468);
            this.button_save_value.Name = "button_save_value";
            this.button_save_value.Size = new System.Drawing.Size(75, 23);
            this.button_save_value.TabIndex = 7;
            this.button_save_value.Text = "Save";
            this.button_save_value.UseVisualStyleBackColor = true;
            this.button_save_value.Click += new System.EventHandler(this.Button_save_value_Click);
            // 
            // textBox_key
            // 
            this.textBox_key.Location = new System.Drawing.Point(12, 468);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(300, 23);
            this.textBox_key.TabIndex = 8;
            // 
            // button_insert_key_after
            // 
            this.button_insert_key_after.Location = new System.Drawing.Point(12, 497);
            this.button_insert_key_after.Name = "button_insert_key_after";
            this.button_insert_key_after.Size = new System.Drawing.Size(95, 23);
            this.button_insert_key_after.TabIndex = 9;
            this.button_insert_key_after.Text = "Insert After";
            this.button_insert_key_after.UseVisualStyleBackColor = true;
            this.button_insert_key_after.Click += new System.EventHandler(this.Button_insert_key_after_Click);
            // 
            // button_rename_key
            // 
            this.button_rename_key.Location = new System.Drawing.Point(113, 497);
            this.button_rename_key.Name = "button_rename_key";
            this.button_rename_key.Size = new System.Drawing.Size(75, 23);
            this.button_rename_key.TabIndex = 10;
            this.button_rename_key.Text = "Rename";
            this.button_rename_key.UseVisualStyleBackColor = true;
            this.button_rename_key.Click += new System.EventHandler(this.Button_rename_key_Click);
            // 
            // button_delete_key
            // 
            this.button_delete_key.Location = new System.Drawing.Point(113, 526);
            this.button_delete_key.Name = "button_delete_key";
            this.button_delete_key.Size = new System.Drawing.Size(75, 23);
            this.button_delete_key.TabIndex = 11;
            this.button_delete_key.Text = "Delete";
            this.button_delete_key.UseVisualStyleBackColor = true;
            this.button_delete_key.Click += new System.EventHandler(this.Button_delete_key_Click);
            // 
            // button_insert_key_before
            // 
            this.button_insert_key_before.Location = new System.Drawing.Point(12, 526);
            this.button_insert_key_before.Name = "button_insert_key_before";
            this.button_insert_key_before.Size = new System.Drawing.Size(95, 23);
            this.button_insert_key_before.TabIndex = 12;
            this.button_insert_key_before.Text = "Insert Before";
            this.button_insert_key_before.UseVisualStyleBackColor = true;
            this.button_insert_key_before.Click += new System.EventHandler(this.Button_insert_key_before_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button_insert_key_before);
            this.Controls.Add(this.button_delete_key);
            this.Controls.Add(this.button_rename_key);
            this.Controls.Add(this.button_insert_key_after);
            this.Controls.Add(this.textBox_key);
            this.Controls.Add(this.button_save_value);
            this.Controls.Add(this.textBox_value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_values);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_keys);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_load);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XamlMultiLanguageEditor.Winform";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

