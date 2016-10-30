namespace WinForm.Temp
{
    partial class FormTest
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.pictureBoxNumber = new System.Windows.Forms.PictureBox();
            this.buttonLoadEtalons = new System.Windows.Forms.Button();
            this.buttonRecognition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "png|";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(68, 13);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(94, 23);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Load file";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // pictureBoxNumber
            // 
            this.pictureBoxNumber.Location = new System.Drawing.Point(12, 13);
            this.pictureBoxNumber.Name = "pictureBoxNumber";
            this.pictureBoxNumber.Size = new System.Drawing.Size(50, 60);
            this.pictureBoxNumber.TabIndex = 1;
            this.pictureBoxNumber.TabStop = false;
            // 
            // buttonLoadEtalons
            // 
            this.buttonLoadEtalons.Location = new System.Drawing.Point(69, 43);
            this.buttonLoadEtalons.Name = "buttonLoadEtalons";
            this.buttonLoadEtalons.Size = new System.Drawing.Size(93, 23);
            this.buttonLoadEtalons.TabIndex = 2;
            this.buttonLoadEtalons.Text = "Load etalons";
            this.buttonLoadEtalons.UseVisualStyleBackColor = true;
            this.buttonLoadEtalons.Click += new System.EventHandler(this.buttonLoadEtalons_Click);
            // 
            // buttonRecognition
            // 
            this.buttonRecognition.Location = new System.Drawing.Point(69, 73);
            this.buttonRecognition.Name = "buttonRecognition";
            this.buttonRecognition.Size = new System.Drawing.Size(93, 23);
            this.buttonRecognition.TabIndex = 3;
            this.buttonRecognition.Text = "Recognition";
            this.buttonRecognition.UseVisualStyleBackColor = true;
            this.buttonRecognition.Click += new System.EventHandler(this.buttonRecognition_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.Controls.Add(this.buttonRecognition);
            this.Controls.Add(this.buttonLoadEtalons);
            this.Controls.Add(this.pictureBoxNumber);
            this.Controls.Add(this.buttonLoadFile);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rec";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.PictureBox pictureBoxNumber;
        private System.Windows.Forms.Button buttonLoadEtalons;
        private System.Windows.Forms.Button buttonRecognition;
    }
}

