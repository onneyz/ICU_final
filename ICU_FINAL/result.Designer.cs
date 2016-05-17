namespace ICU_FINAL
{
    partial class result
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(result));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.filelistBox = new System.Windows.Forms.ListBox();
            this.btnSearch = new MaterialSkin.Controls.MaterialFlatButton();
            this.foundLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 95);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(472, 23);
            this.progressBar.TabIndex = 0;
            // 
            // filelistBox
            // 
            this.filelistBox.FormattingEnabled = true;
            this.filelistBox.Location = new System.Drawing.Point(12, 151);
            this.filelistBox.Name = "filelistBox";
            this.filelistBox.Size = new System.Drawing.Size(472, 95);
            this.filelistBox.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(182, 260);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = false;
            this.btnSearch.Size = new System.Drawing.Size(132, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search keyword";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // foundLabel
            // 
            this.foundLabel.AutoSize = true;
            this.foundLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.foundLabel.Location = new System.Drawing.Point(429, 135);
            this.foundLabel.Name = "foundLabel";
            this.foundLabel.Size = new System.Drawing.Size(55, 13);
            this.foundLabel.TabIndex = 4;
            this.foundLabel.Text = "files found";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.progressLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.progressLabel.Location = new System.Drawing.Point(9, 79);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(54, 13);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.Text = "Progress :";
            // 
            // result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 311);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.foundLabel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.filelistBox);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "result";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox filelistBox;
        private MaterialSkin.Controls.MaterialFlatButton btnSearch;
        private System.Windows.Forms.Label foundLabel;
        private System.Windows.Forms.Label progressLabel;
    }
}