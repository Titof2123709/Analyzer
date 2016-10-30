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
            this.buttonLoadEtalons = new System.Windows.Forms.Button();
            this.buttonRecognition = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "png|";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(731, 12);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(94, 23);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Load file";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // buttonLoadEtalons
            // 
            this.buttonLoadEtalons.Location = new System.Drawing.Point(731, 41);
            this.buttonLoadEtalons.Name = "buttonLoadEtalons";
            this.buttonLoadEtalons.Size = new System.Drawing.Size(93, 23);
            this.buttonLoadEtalons.TabIndex = 2;
            this.buttonLoadEtalons.Text = "Load etalons";
            this.buttonLoadEtalons.UseVisualStyleBackColor = true;
            this.buttonLoadEtalons.Click += new System.EventHandler(this.buttonLoadEtalons_Click);
            // 
            // buttonRecognition
            // 
            this.buttonRecognition.Location = new System.Drawing.Point(731, 70);
            this.buttonRecognition.Name = "buttonRecognition";
            this.buttonRecognition.Size = new System.Drawing.Size(93, 23);
            this.buttonRecognition.TabIndex = 3;
            this.buttonRecognition.Text = "Recognition";
            this.buttonRecognition.UseVisualStyleBackColor = true;
            this.buttonRecognition.Click += new System.EventHandler(this.buttonRecognition_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageColumn,
            this.ValueColumn});
            this.dataGridView.Location = new System.Drawing.Point(13, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(712, 417);
            this.dataGridView.TabIndex = 4;
            // 
            // ImageColumn
            // 
            this.ImageColumn.HeaderText = "Image";
            this.ImageColumn.Name = "ImageColumn";
            this.ImageColumn.ReadOnly = true;
            this.ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImageColumn.Width = 400;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 441);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonRecognition);
            this.Controls.Add(this.buttonLoadEtalons);
            this.Controls.Add(this.buttonLoadFile);
            this.Name = "FormTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rec";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Button buttonLoadEtalons;
        private System.Windows.Forms.Button buttonRecognition;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewImageColumn ImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
    }
}

