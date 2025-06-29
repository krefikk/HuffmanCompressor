namespace HuffmanCompressor
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.compressFileChooseLabel = new System.Windows.Forms.Label();
            this.decompressFileChooseLabel = new System.Windows.Forms.Label();
            this.openCompressFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openDecompressFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.compressFileChooseButton = new System.Windows.Forms.Button();
            this.decompressFileChooseButton = new System.Windows.Forms.Button();
            this.keyFileChooseButton = new System.Windows.Forms.Button();
            this.chooseKeyFileLabel = new System.Windows.Forms.Label();
            this.compressFileLabel = new System.Windows.Forms.Label();
            this.compressFileTextBox = new System.Windows.Forms.TextBox();
            this.compressFileButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.decompressFileButton = new System.Windows.Forms.Button();
            this.decompressFileTextBox = new System.Windows.Forms.TextBox();
            this.decompressFileLabel = new System.Windows.Forms.Label();
            this.keyFileTextBox = new System.Windows.Forms.TextBox();
            this.keyFileLabel = new System.Windows.Forms.Label();
            this.openKeyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.footerLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // compressFileChooseLabel
            // 
            this.compressFileChooseLabel.AutoSize = true;
            this.compressFileChooseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.compressFileChooseLabel.Location = new System.Drawing.Point(68, 41);
            this.compressFileChooseLabel.Name = "compressFileChooseLabel";
            this.compressFileChooseLabel.Size = new System.Drawing.Size(286, 25);
            this.compressFileChooseLabel.TabIndex = 0;
            this.compressFileChooseLabel.Text = "Choose a file to compress";
            // 
            // decompressFileChooseLabel
            // 
            this.decompressFileChooseLabel.AutoSize = true;
            this.decompressFileChooseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.decompressFileChooseLabel.Location = new System.Drawing.Point(561, 41);
            this.decompressFileChooseLabel.Name = "decompressFileChooseLabel";
            this.decompressFileChooseLabel.Size = new System.Drawing.Size(312, 25);
            this.decompressFileChooseLabel.TabIndex = 1;
            this.decompressFileChooseLabel.Text = "Choose a file to decompress";
            // 
            // openCompressFileDialog
            // 
            this.openCompressFileDialog.Filter = "Text Files (*.txt)|*.txt";
            this.openCompressFileDialog.Title = "Choose a file to compress";
            // 
            // openDecompressFileDialog
            // 
            this.openDecompressFileDialog.Filter = "Text Files (*.txt)|*.txt";
            this.openDecompressFileDialog.Title = "Choose a file to decompress";
            // 
            // compressFileChooseButton
            // 
            this.compressFileChooseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compressFileChooseButton.Location = new System.Drawing.Point(66, 86);
            this.compressFileChooseButton.Name = "compressFileChooseButton";
            this.compressFileChooseButton.Size = new System.Drawing.Size(288, 23);
            this.compressFileChooseButton.TabIndex = 2;
            this.compressFileChooseButton.Text = "Choose";
            this.compressFileChooseButton.UseVisualStyleBackColor = true;
            this.compressFileChooseButton.Click += new System.EventHandler(this.compressFileChooseButton_Click);
            // 
            // decompressFileChooseButton
            // 
            this.decompressFileChooseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decompressFileChooseButton.Location = new System.Drawing.Point(559, 86);
            this.decompressFileChooseButton.Name = "decompressFileChooseButton";
            this.decompressFileChooseButton.Size = new System.Drawing.Size(314, 23);
            this.decompressFileChooseButton.TabIndex = 3;
            this.decompressFileChooseButton.Text = "Choose";
            this.decompressFileChooseButton.UseVisualStyleBackColor = true;
            this.decompressFileChooseButton.Click += new System.EventHandler(this.decompressFileChooseButton_Click);
            // 
            // keyFileChooseButton
            // 
            this.keyFileChooseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.keyFileChooseButton.Location = new System.Drawing.Point(559, 193);
            this.keyFileChooseButton.Name = "keyFileChooseButton";
            this.keyFileChooseButton.Size = new System.Drawing.Size(314, 23);
            this.keyFileChooseButton.TabIndex = 5;
            this.keyFileChooseButton.Text = "Choose";
            this.keyFileChooseButton.UseVisualStyleBackColor = true;
            this.keyFileChooseButton.Click += new System.EventHandler(this.keyFileChooseButton_Click);
            // 
            // chooseKeyFileLabel
            // 
            this.chooseKeyFileLabel.AutoSize = true;
            this.chooseKeyFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chooseKeyFileLabel.Location = new System.Drawing.Point(599, 148);
            this.chooseKeyFileLabel.Name = "chooseKeyFileLabel";
            this.chooseKeyFileLabel.Size = new System.Drawing.Size(228, 25);
            this.chooseKeyFileLabel.TabIndex = 4;
            this.chooseKeyFileLabel.Text = "Choose your key file";
            // 
            // compressFileLabel
            // 
            this.compressFileLabel.AutoSize = true;
            this.compressFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.compressFileLabel.Location = new System.Drawing.Point(119, 282);
            this.compressFileLabel.Name = "compressFileLabel";
            this.compressFileLabel.Size = new System.Drawing.Size(193, 25);
            this.compressFileLabel.TabIndex = 6;
            this.compressFileLabel.Text = "File to compress:";
            // 
            // compressFileTextBox
            // 
            this.compressFileTextBox.Location = new System.Drawing.Point(73, 319);
            this.compressFileTextBox.Name = "compressFileTextBox";
            this.compressFileTextBox.ReadOnly = true;
            this.compressFileTextBox.Size = new System.Drawing.Size(281, 20);
            this.compressFileTextBox.TabIndex = 7;
            // 
            // compressFileButton
            // 
            this.compressFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compressFileButton.Location = new System.Drawing.Point(178, 358);
            this.compressFileButton.Name = "compressFileButton";
            this.compressFileButton.Size = new System.Drawing.Size(68, 23);
            this.compressFileButton.TabIndex = 8;
            this.compressFileButton.Text = "Compress";
            this.compressFileButton.UseVisualStyleBackColor = true;
            this.compressFileButton.Click += new System.EventHandler(this.compressFileButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(34, 409);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(918, 123);
            this.logBox.TabIndex = 9;
            // 
            // decompressFileButton
            // 
            this.decompressFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decompressFileButton.Location = new System.Drawing.Point(680, 358);
            this.decompressFileButton.Name = "decompressFileButton";
            this.decompressFileButton.Size = new System.Drawing.Size(78, 23);
            this.decompressFileButton.TabIndex = 12;
            this.decompressFileButton.Text = "Decompress";
            this.decompressFileButton.UseVisualStyleBackColor = true;
            this.decompressFileButton.Click += new System.EventHandler(this.decompressFileButton_Click);
            // 
            // decompressFileTextBox
            // 
            this.decompressFileTextBox.Location = new System.Drawing.Point(487, 319);
            this.decompressFileTextBox.Name = "decompressFileTextBox";
            this.decompressFileTextBox.ReadOnly = true;
            this.decompressFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.decompressFileTextBox.Size = new System.Drawing.Size(221, 20);
            this.decompressFileTextBox.TabIndex = 11;
            // 
            // decompressFileLabel
            // 
            this.decompressFileLabel.AutoSize = true;
            this.decompressFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.decompressFileLabel.Location = new System.Drawing.Point(487, 282);
            this.decompressFileLabel.Name = "decompressFileLabel";
            this.decompressFileLabel.Size = new System.Drawing.Size(219, 25);
            this.decompressFileLabel.TabIndex = 10;
            this.decompressFileLabel.Text = "File to decompress:";
            // 
            // keyFileTextBox
            // 
            this.keyFileTextBox.Location = new System.Drawing.Point(730, 319);
            this.keyFileTextBox.Name = "keyFileTextBox";
            this.keyFileTextBox.ReadOnly = true;
            this.keyFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.keyFileTextBox.Size = new System.Drawing.Size(222, 20);
            this.keyFileTextBox.TabIndex = 14;
            // 
            // keyFileLabel
            // 
            this.keyFileLabel.AutoSize = true;
            this.keyFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.keyFileLabel.Location = new System.Drawing.Point(793, 282);
            this.keyFileLabel.Name = "keyFileLabel";
            this.keyFileLabel.Size = new System.Drawing.Size(98, 25);
            this.keyFileLabel.TabIndex = 13;
            this.keyFileLabel.Text = "Key file:";
            // 
            // openKeyFileDialog
            // 
            this.openKeyFileDialog.Filter = "Text Files (*.txt)|*.txt";
            this.openKeyFileDialog.Title = "Choose your key file";
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.footerLabel.LinkColor = System.Drawing.Color.Green;
            this.footerLabel.Location = new System.Drawing.Point(934, 546);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(39, 13);
            this.footerLabel.TabIndex = 16;
            this.footerLabel.TabStop = true;
            this.footerLabel.Text = "krefikk";
            this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.footerLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.footerLabel_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 568);
            this.Controls.Add(this.footerLabel);
            this.Controls.Add(this.keyFileTextBox);
            this.Controls.Add(this.keyFileLabel);
            this.Controls.Add(this.decompressFileButton);
            this.Controls.Add(this.decompressFileTextBox);
            this.Controls.Add(this.decompressFileLabel);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.compressFileButton);
            this.Controls.Add(this.compressFileTextBox);
            this.Controls.Add(this.compressFileLabel);
            this.Controls.Add(this.keyFileChooseButton);
            this.Controls.Add(this.chooseKeyFileLabel);
            this.Controls.Add(this.decompressFileChooseButton);
            this.Controls.Add(this.compressFileChooseButton);
            this.Controls.Add(this.decompressFileChooseLabel);
            this.Controls.Add(this.compressFileChooseLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1001, 607);
            this.MinimumSize = new System.Drawing.Size(1001, 607);
            this.Name = "Form1";
            this.Text = "Huffman Compressor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label compressFileChooseLabel;
        private System.Windows.Forms.Label decompressFileChooseLabel;
        private System.Windows.Forms.OpenFileDialog openCompressFileDialog;
        private System.Windows.Forms.OpenFileDialog openDecompressFileDialog;
        private System.Windows.Forms.Button compressFileChooseButton;
        private System.Windows.Forms.Button decompressFileChooseButton;
        private System.Windows.Forms.Button keyFileChooseButton;
        private System.Windows.Forms.Label chooseKeyFileLabel;
        private System.Windows.Forms.Label compressFileLabel;
        private System.Windows.Forms.TextBox compressFileTextBox;
        private System.Windows.Forms.Button compressFileButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button decompressFileButton;
        private System.Windows.Forms.TextBox decompressFileTextBox;
        private System.Windows.Forms.Label decompressFileLabel;
        private System.Windows.Forms.TextBox keyFileTextBox;
        private System.Windows.Forms.Label keyFileLabel;
        private System.Windows.Forms.OpenFileDialog openKeyFileDialog;
        private System.Windows.Forms.LinkLabel footerLabel;
    }
}

