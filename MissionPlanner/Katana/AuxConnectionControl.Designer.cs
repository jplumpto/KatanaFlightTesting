namespace ArdupilotMega.Katana
{
    partial class AuxConnectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CrossboxConnected = new System.Windows.Forms.RadioButton();
            this.RecordingButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // CrossboxConnected
            // 
            this.CrossboxConnected.AutoSize = true;
            this.CrossboxConnected.Enabled = false;
            this.CrossboxConnected.Location = new System.Drawing.Point(24, 16);
            this.CrossboxConnected.Name = "CrossboxConnected";
            this.CrossboxConnected.Size = new System.Drawing.Size(71, 17);
            this.CrossboxConnected.TabIndex = 0;
            this.CrossboxConnected.TabStop = true;
            this.CrossboxConnected.Text = "Crossbow";
            this.CrossboxConnected.UseVisualStyleBackColor = true;
            // 
            // RecordingButton
            // 
            this.RecordingButton.AutoSize = true;
            this.RecordingButton.Enabled = false;
            this.RecordingButton.Location = new System.Drawing.Point(24, 39);
            this.RecordingButton.Name = "RecordingButton";
            this.RecordingButton.Size = new System.Drawing.Size(111, 17);
            this.RecordingButton.TabIndex = 0;
            this.RecordingButton.TabStop = true;
            this.RecordingButton.Text = "Recording Katana";
            this.RecordingButton.UseVisualStyleBackColor = true;
            // 
            // AuxConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecordingButton);
            this.Controls.Add(this.CrossboxConnected);
            this.Name = "AuxConnectionControl";
            this.Size = new System.Drawing.Size(150, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton CrossboxConnected;
        private System.Windows.Forms.RadioButton RecordingButton;
    }
}
