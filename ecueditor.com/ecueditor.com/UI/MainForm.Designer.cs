namespace ecueditor.com.UI
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
            this.btnFuelMaps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFuelMaps
            // 
            this.btnFuelMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuelMaps.Location = new System.Drawing.Point(323, 37);
            this.btnFuelMaps.Name = "btnFuelMaps";
            this.btnFuelMaps.Size = new System.Drawing.Size(106, 55);
            this.btnFuelMaps.TabIndex = 0;
            this.btnFuelMaps.Text = "Fuel Maps";
            this.btnFuelMaps.UseVisualStyleBackColor = true;
            this.btnFuelMaps.Click += new System.EventHandler(this.btnFuelMaps_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 343);
            this.Controls.Add(this.btnFuelMaps);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "ecueditor.com";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFuelMaps;
    }
}