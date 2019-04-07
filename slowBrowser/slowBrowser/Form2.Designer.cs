namespace slowBrowser
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.homeUrlTextBox = new System.Windows.Forms.TextBox();
            this.homeLabel = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            this.searchEngineLabel = new System.Windows.Forms.Label();
            this.searchEngineBox = new System.Windows.Forms.ComboBox();
            this.darkModeLabel = new System.Windows.Forms.Label();
            this.darkModeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // homeUrlTextBox
            // 
            this.homeUrlTextBox.Location = new System.Drawing.Point(160, 35);
            this.homeUrlTextBox.Name = "homeUrlTextBox";
            this.homeUrlTextBox.Size = new System.Drawing.Size(100, 20);
            this.homeUrlTextBox.TabIndex = 0;
            // 
            // homeLabel
            // 
            this.homeLabel.AutoSize = true;
            this.homeLabel.Location = new System.Drawing.Point(35, 38);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(96, 13);
            this.homeLabel.TabIndex = 1;
            this.homeLabel.Text = "Domovská stránka";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(128, 402);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(75, 23);
            this.commitButton.TabIndex = 2;
            this.commitButton.Text = "Uložit změny";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // searchEngineLabel
            // 
            this.searchEngineLabel.AutoSize = true;
            this.searchEngineLabel.Location = new System.Drawing.Point(35, 76);
            this.searchEngineLabel.Name = "searchEngineLabel";
            this.searchEngineLabel.Size = new System.Drawing.Size(63, 13);
            this.searchEngineLabel.TabIndex = 3;
            this.searchEngineLabel.Text = "Vyhledávač";
            // 
            // searchEngineBox
            // 
            this.searchEngineBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchEngineBox.FormattingEnabled = true;
            this.searchEngineBox.Items.AddRange(new object[] {
            "Google",
            "Yahoo",
            "Bing",
            "DuckDuckGo"});
            this.searchEngineBox.Location = new System.Drawing.Point(160, 76);
            this.searchEngineBox.Name = "searchEngineBox";
            this.searchEngineBox.Size = new System.Drawing.Size(121, 21);
            this.searchEngineBox.TabIndex = 4;
            // 
            // darkModeLabel
            // 
            this.darkModeLabel.AutoSize = true;
            this.darkModeLabel.Location = new System.Drawing.Point(35, 116);
            this.darkModeLabel.Name = "darkModeLabel";
            this.darkModeLabel.Size = new System.Drawing.Size(66, 13);
            this.darkModeLabel.TabIndex = 5;
            this.darkModeLabel.Text = "Tmavý režim";
            // 
            // darkModeCheckBox
            // 
            this.darkModeCheckBox.AutoSize = true;
            this.darkModeCheckBox.Location = new System.Drawing.Point(160, 116);
            this.darkModeCheckBox.Name = "darkModeCheckBox";
            this.darkModeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.darkModeCheckBox.TabIndex = 6;
            this.darkModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 450);
            this.Controls.Add(this.darkModeCheckBox);
            this.Controls.Add(this.darkModeLabel);
            this.Controls.Add(this.searchEngineBox);
            this.Controls.Add(this.searchEngineLabel);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.homeLabel);
            this.Controls.Add(this.homeUrlTextBox);
            this.Name = "Form2";
            this.Text = "Nastavení";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox homeUrlTextBox;
        private System.Windows.Forms.Label homeLabel;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.Label searchEngineLabel;
        private System.Windows.Forms.ComboBox searchEngineBox;
        private System.Windows.Forms.Label darkModeLabel;
        private System.Windows.Forms.CheckBox darkModeCheckBox;
    }
}