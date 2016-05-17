namespace ICU_FINAL
{
    partial class fileformats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileformats));
            this.formatsListBox = new System.Windows.Forms.CheckedListBox();
            this.btnAll = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNone = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOK = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // formatsListBox
            // 
            this.formatsListBox.CheckOnClick = true;
            this.formatsListBox.FormattingEnabled = true;
            this.formatsListBox.HorizontalScrollbar = true;
            this.formatsListBox.Items.AddRange(new object[] {
            "bmp BMP bitmap image",
            "dat IE History",
            "doc Microsoft Office Document",
            "exe MS Windows executable",
            "gif Graphic Interchange Format",
            "http HTTP Cache",
            "jpg JPG picture",
            "mov mov/mp4/3gp",
            "mp3 MP3 audio",
            "MYI MySQL",
            "one Microsoft OneNote",
            "pdf Portable Document Format",
            "png Portable/JPG/Multiple-Image Network Graphics",
            "psd Adobe Photoshop Image",
            "rar Rar archive",
            "tx? Text files with header: rtf,xml,xhtml,url",
            "txt Other text files: txt,html,asp,bat,C,php",
            "zip zip archive"});
            this.formatsListBox.Location = new System.Drawing.Point(12, 71);
            this.formatsListBox.Name = "formatsListBox";
            this.formatsListBox.Size = new System.Drawing.Size(185, 214);
            this.formatsListBox.Sorted = true;
            this.formatsListBox.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.Depth = 0;
            this.btnAll.Location = new System.Drawing.Point(203, 71);
            this.btnAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAll.Name = "btnAll";
            this.btnAll.Primary = true;
            this.btnAll.Size = new System.Drawing.Size(101, 27);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "Select All";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // btnNone
            // 
            this.btnNone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNone.Depth = 0;
            this.btnNone.Location = new System.Drawing.Point(203, 104);
            this.btnNone.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNone.Name = "btnNone";
            this.btnNone.Primary = true;
            this.btnNone.Size = new System.Drawing.Size(101, 27);
            this.btnNone.TabIndex = 2;
            this.btnNone.Text = "Select None";
            this.btnNone.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Depth = 0;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(203, 258);
            this.btnOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.Primary = true;
            this.btnOK.Size = new System.Drawing.Size(101, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fileformats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(316, 300);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.formatsListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fileformats";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Formats";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox formatsListBox;
        private MaterialSkin.Controls.MaterialRaisedButton btnAll;
        private MaterialSkin.Controls.MaterialRaisedButton btnNone;
        private MaterialSkin.Controls.MaterialRaisedButton btnOK;

    }
}