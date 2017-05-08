namespace Classifier
{
    partial class BoundaryDetection
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
            this.label1 = new System.Windows.Forms.Label();
            this.processImgBtn = new System.Windows.Forms.Button();
            this.featureExtractionBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.classifierBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.detectBtn = new System.Windows.Forms.Button();
            this.browseLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detection And Saving Dataset Images after Boundary Box Analysis";
            // 
            // processImgBtn
            // 
            this.processImgBtn.Location = new System.Drawing.Point(84, 80);
            this.processImgBtn.Name = "processImgBtn";
            this.processImgBtn.Size = new System.Drawing.Size(115, 29);
            this.processImgBtn.TabIndex = 1;
            this.processImgBtn.Text = "Process Images";
            this.processImgBtn.UseVisualStyleBackColor = true;
            this.processImgBtn.Click += new System.EventHandler(this.processImgBtn_Click);
            // 
            // featureExtractionBtn
            // 
            this.featureExtractionBtn.Location = new System.Drawing.Point(205, 80);
            this.featureExtractionBtn.Name = "featureExtractionBtn";
            this.featureExtractionBtn.Size = new System.Drawing.Size(124, 29);
            this.featureExtractionBtn.TabIndex = 2;
            this.featureExtractionBtn.Text = "Feature Extraction";
            this.featureExtractionBtn.UseVisualStyleBackColor = true;
            this.featureExtractionBtn.Click += new System.EventHandler(this.featureExtractionBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.classifierBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.featureExtractionBtn);
            this.panel1.Controls.Add(this.processImgBtn);
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 140);
            this.panel1.TabIndex = 3;
            // 
            // classifierBtn
            // 
            this.classifierBtn.Location = new System.Drawing.Point(335, 80);
            this.classifierBtn.Name = "classifierBtn";
            this.classifierBtn.Size = new System.Drawing.Size(94, 29);
            this.classifierBtn.TabIndex = 3;
            this.classifierBtn.Text = "Train Classifier";
            this.classifierBtn.UseVisualStyleBackColor = true;
            this.classifierBtn.Click += new System.EventHandler(this.classifierBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.outputLabel);
            this.panel2.Controls.Add(this.detectBtn);
            this.panel2.Controls.Add(this.browseLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.browseBtn);
            this.panel2.Location = new System.Drawing.Point(8, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 181);
            this.panel2.TabIndex = 3;
            // 
            // detectBtn
            // 
            this.detectBtn.Location = new System.Drawing.Point(293, 41);
            this.detectBtn.Name = "detectBtn";
            this.detectBtn.Size = new System.Drawing.Size(75, 23);
            this.detectBtn.TabIndex = 3;
            this.detectBtn.Text = "Detect";
            this.detectBtn.UseVisualStyleBackColor = true;
            this.detectBtn.Click += new System.EventHandler(this.detectBtn_Click);
            // 
            // browseLabel
            // 
            this.browseLabel.AutoSize = true;
            this.browseLabel.Location = new System.Drawing.Point(150, 67);
            this.browseLabel.Name = "browseLabel";
            this.browseLabel.Size = new System.Drawing.Size(0, 13);
            this.browseLabel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Browse Image You Want Characters To Be Read From";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(123, 41);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 0;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.Location = new System.Drawing.Point(313, 106);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(0, 25);
            this.outputLabel.TabIndex = 4;
            // 
            // BoundaryDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 351);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BoundaryDetection";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button processImgBtn;
        private System.Windows.Forms.Button featureExtractionBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label browseLabel;
        private System.Windows.Forms.Button detectBtn;
        private System.Windows.Forms.Button classifierBtn;
        private System.Windows.Forms.Label outputLabel;
    }
}

