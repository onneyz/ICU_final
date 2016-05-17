namespace ICU_FINAL
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.HDDLabel = new MaterialSkin.Controls.MaterialLabel();
            this.HDDcomboBox = new System.Windows.Forms.ComboBox();
            this.DestLabel = new MaterialSkin.Controls.MaterialLabel();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnFormats = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnOK = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // HDDLabel
            // 
            this.HDDLabel.AutoSize = true;
            this.HDDLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HDDLabel.Depth = 0;
            this.HDDLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.HDDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HDDLabel.Location = new System.Drawing.Point(12, 77);
            this.HDDLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.HDDLabel.Name = "HDDLabel";
            this.HDDLabel.Size = new System.Drawing.Size(161, 19);
            this.HDDLabel.TabIndex = 0;
            this.HDDLabel.Text = "Select a disk to carve :";
            // 
            // HDDcomboBox
            // 
            this.HDDcomboBox.FormattingEnabled = true;
            this.HDDcomboBox.Location = new System.Drawing.Point(179, 78);
            this.HDDcomboBox.Name = "HDDcomboBox";
            this.HDDcomboBox.Size = new System.Drawing.Size(321, 21);
            this.HDDcomboBox.TabIndex = 1;
            this.HDDcomboBox.SelectedIndexChanged += new System.EventHandler(this.HDDcomboBox_SelectedIndexChanged);
            // 
            // DestLabel
            // 
            this.DestLabel.AutoSize = true;
            this.DestLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DestLabel.Depth = 0;
            this.DestLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.DestLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DestLabel.Location = new System.Drawing.Point(12, 117);
            this.DestLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.DestLabel.Name = "DestLabel";
            this.DestLabel.Size = new System.Drawing.Size(214, 19);
            this.DestLabel.TabIndex = 2;
            this.DestLabel.Text = "Set a destination folder name :";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(232, 118);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(268, 20);
            this.txtFolder.TabIndex = 3;
            // 
            // btnFormats
            // 
            this.btnFormats.AutoSize = true;
            this.btnFormats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormats.Depth = 0;
            this.btnFormats.Location = new System.Drawing.Point(16, 154);
            this.btnFormats.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormats.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormats.Name = "btnFormats";
            this.btnFormats.Primary = false;
            this.btnFormats.Size = new System.Drawing.Size(84, 36);
            this.btnFormats.TabIndex = 4;
            this.btnFormats.Text = "File Types";
            this.btnFormats.UseVisualStyleBackColor = true;
            this.btnFormats.Click += new System.EventHandler(this.btnFormats_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Depth = 0;
            this.btnOK.Location = new System.Drawing.Point(416, 157);
            this.btnOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.Primary = true;
            this.btnOK.Size = new System.Drawing.Size(84, 36);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // main
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 205);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFormats);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.DestLabel);
            this.Controls.Add(this.HDDcomboBox);
            this.Controls.Add(this.HDDLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICU : File Carving Tool";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel HDDLabel;
        private System.Windows.Forms.ComboBox HDDcomboBox;
        private MaterialSkin.Controls.MaterialLabel DestLabel;
        private System.Windows.Forms.TextBox txtFolder;
        private MaterialSkin.Controls.MaterialFlatButton btnFormats;
        private MaterialSkin.Controls.MaterialRaisedButton btnOK;
    }
}

