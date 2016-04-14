namespace Query
{
    partial class MainForm
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
            this._output = new System.Windows.Forms.RichTextBox();
            this._btnQueryDistinctProns = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _output
            // 
            this._output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._output.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._output.Location = new System.Drawing.Point(12, 12);
            this._output.Name = "_output";
            this._output.Size = new System.Drawing.Size(1034, 497);
            this._output.TabIndex = 0;
            this._output.Text = "";
            // 
            // _btnQueryDistinctProns
            // 
            this._btnQueryDistinctProns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnQueryDistinctProns.Location = new System.Drawing.Point(12, 525);
            this._btnQueryDistinctProns.Name = "_btnQueryDistinctProns";
            this._btnQueryDistinctProns.Size = new System.Drawing.Size(114, 23);
            this._btnQueryDistinctProns.TabIndex = 1;
            this._btnQueryDistinctProns.Text = "Pron Char Array";
            this._btnQueryDistinctProns.UseVisualStyleBackColor = true;
            this._btnQueryDistinctProns.Click += new System.EventHandler(this._btnQueryDistinctProns_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 560);
            this.Controls.Add(this._btnQueryDistinctProns);
            this.Controls.Add(this._output);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _output;
        private System.Windows.Forms.Button _btnQueryDistinctProns;
    }
}

