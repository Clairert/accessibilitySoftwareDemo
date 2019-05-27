namespace GazeToolBar
{
    partial class SimplePaint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimplePaint));
            this.behaviorMap = new EyeXFramework.Forms.BehaviorMap(this.components);
            this.components = new System.ComponentModel.Container();
            this.backPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.redPanel = new System.Windows.Forms.Panel();
            this.redButton = new System.Windows.Forms.Button();
            this.bluePanel = new System.Windows.Forms.Panel();
            this.blueButton = new System.Windows.Forms.Button();
            this.yellowPanel = new System.Windows.Forms.Panel();
            this.yellowButton = new System.Windows.Forms.Button();
            this.greenPanel = new System.Windows.Forms.Panel();
            this.greenButton = new System.Windows.Forms.Button();
            this.purplePanel = new System.Windows.Forms.Panel();
            this.purpleButton = new System.Windows.Forms.Button();
            this.orangePanel = new System.Windows.Forms.Panel();
            this.orangeButton = new System.Windows.Forms.Button();
            this.blackPanel = new System.Windows.Forms.Panel();
            this.blackButton = new System.Windows.Forms.Button();
            this.whitePanel = new System.Windows.Forms.Panel();
            this.whiteButton = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.trackingTimer = new System.Windows.Forms.Timer(this.components);
            this.backPanel.SuspendLayout();
            this.redPanel.SuspendLayout();
            this.bluePanel.SuspendLayout();
            this.yellowPanel.SuspendLayout();
            this.greenPanel.SuspendLayout();
            this.purplePanel.SuspendLayout();
            this.orangePanel.SuspendLayout();
            this.blackPanel.SuspendLayout();
            this.whitePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backPanel
            // 
            this.backPanel.Controls.Add(this.backButton);
            this.backPanel.Location = new System.Drawing.Point(12, 12);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(128, 80);
            this.backPanel.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // redPanel
            // 
            this.redPanel.Controls.Add(this.redButton);
            this.redPanel.Location = new System.Drawing.Point(960, 25);
            this.redPanel.Name = "redPanel";
            this.redPanel.Size = new System.Drawing.Size(64, 54);
            this.redPanel.TabIndex = 1;
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.Red;
            this.redButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redButton.Location = new System.Drawing.Point(3, 3);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(52, 41);
            this.redButton.TabIndex = 0;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // bluePanel
            // 
            this.bluePanel.Controls.Add(this.blueButton);
            this.bluePanel.Location = new System.Drawing.Point(1085, 25);
            this.bluePanel.Name = "bluePanel";
            this.bluePanel.Size = new System.Drawing.Size(88, 33);
            this.bluePanel.TabIndex = 2;
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.Blue;
            this.blueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blueButton.Location = new System.Drawing.Point(3, 3);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(75, 23);
            this.blueButton.TabIndex = 0;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // yellowPanel
            // 
            this.yellowPanel.Controls.Add(this.yellowButton);
            this.yellowPanel.Location = new System.Drawing.Point(960, 108);
            this.yellowPanel.Name = "yellowPanel";
            this.yellowPanel.Size = new System.Drawing.Size(94, 37);
            this.yellowPanel.TabIndex = 3;
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Yellow;
            this.yellowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellowButton.Location = new System.Drawing.Point(3, 3);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(75, 23);
            this.yellowButton.TabIndex = 0;
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.yellowButton_Click);
            // 
            // greenPanel
            // 
            this.greenPanel.Controls.Add(this.greenButton);
            this.greenPanel.Location = new System.Drawing.Point(1085, 108);
            this.greenPanel.Name = "greenPanel";
            this.greenPanel.Size = new System.Drawing.Size(88, 37);
            this.greenPanel.TabIndex = 4;
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.SeaGreen;
            this.greenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.greenButton.Location = new System.Drawing.Point(3, 3);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(75, 23);
            this.greenButton.TabIndex = 0;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // purplePanel
            // 
            this.purplePanel.Controls.Add(this.purpleButton);
            this.purplePanel.Location = new System.Drawing.Point(960, 174);
            this.purplePanel.Name = "purplePanel";
            this.purplePanel.Size = new System.Drawing.Size(94, 36);
            this.purplePanel.TabIndex = 5;
            // 
            // purpleButton
            // 
            this.purpleButton.BackColor = System.Drawing.Color.Purple;
            this.purpleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purpleButton.Location = new System.Drawing.Point(3, 3);
            this.purpleButton.Name = "purpleButton";
            this.purpleButton.Size = new System.Drawing.Size(75, 23);
            this.purpleButton.TabIndex = 0;
            this.purpleButton.UseVisualStyleBackColor = false;
            this.purpleButton.Click += new System.EventHandler(this.purpleButton_Click);
            // 
            // orangePanel
            // 
            this.orangePanel.Controls.Add(this.orangeButton);
            this.orangePanel.Location = new System.Drawing.Point(1085, 174);
            this.orangePanel.Name = "orangePanel";
            this.orangePanel.Size = new System.Drawing.Size(88, 36);
            this.orangePanel.TabIndex = 6;
            // 
            // orangeButton
            // 
            this.orangeButton.BackColor = System.Drawing.Color.Orange;
            this.orangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orangeButton.Location = new System.Drawing.Point(3, 3);
            this.orangeButton.Name = "orangeButton";
            this.orangeButton.Size = new System.Drawing.Size(75, 23);
            this.orangeButton.TabIndex = 0;
            this.orangeButton.UseVisualStyleBackColor = false;
            this.orangeButton.Click += new System.EventHandler(this.orangeButton_Click);
            // 
            // blackPanel
            // 
            this.blackPanel.Controls.Add(this.blackButton);
            this.blackPanel.Location = new System.Drawing.Point(963, 243);
            this.blackPanel.Name = "blackPanel";
            this.blackPanel.Size = new System.Drawing.Size(94, 37);
            this.blackPanel.TabIndex = 7;
            // 
            // blackButton
            // 
            this.blackButton.BackColor = System.Drawing.Color.Black;
            this.blackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blackButton.Location = new System.Drawing.Point(3, 3);
            this.blackButton.Name = "blackButton";
            this.blackButton.Size = new System.Drawing.Size(75, 23);
            this.blackButton.TabIndex = 0;
            this.blackButton.UseVisualStyleBackColor = false;
            this.blackButton.Click += new System.EventHandler(this.blackButton_Click);
            // 
            // whitePanel
            // 
            this.whitePanel.Controls.Add(this.whiteButton);
            this.whitePanel.Location = new System.Drawing.Point(1088, 243);
            this.whitePanel.Name = "whitePanel";
            this.whitePanel.Size = new System.Drawing.Size(88, 37);
            this.whitePanel.TabIndex = 8;
            // 
            // whiteButton
            // 
            this.whiteButton.BackColor = System.Drawing.Color.White;
            this.whiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.whiteButton.Location = new System.Drawing.Point(3, 3);
            this.whiteButton.Name = "whiteButton";
            this.whiteButton.Size = new System.Drawing.Size(75, 23);
            this.whiteButton.TabIndex = 0;
            this.whiteButton.UseVisualStyleBackColor = false;
            this.whiteButton.Click += new System.EventHandler(this.whiteButton_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // trackingTimer
            // 
            this.trackingTimer.Enabled = true;
            this.trackingTimer.Interval = 1;
            this.trackingTimer.Tick += new System.EventHandler(this.trackingTimer_Tick);
            // 
            // SimplePaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1203, 621);
            this.ControlBox = false;
            this.Controls.Add(this.whitePanel);
            this.Controls.Add(this.blackPanel);
            this.Controls.Add(this.orangePanel);
            this.Controls.Add(this.purplePanel);
            this.Controls.Add(this.greenPanel);
            this.Controls.Add(this.yellowPanel);
            this.Controls.Add(this.bluePanel);
            this.Controls.Add(this.redPanel);
            this.Controls.Add(this.backPanel);
            this.Name = "SimplePaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.backPanel.ResumeLayout(false);
            this.redPanel.ResumeLayout(false);
            this.bluePanel.ResumeLayout(false);
            this.yellowPanel.ResumeLayout(false);
            this.greenPanel.ResumeLayout(false);
            this.purplePanel.ResumeLayout(false);
            this.orangePanel.ResumeLayout(false);
            this.blackPanel.ResumeLayout(false);
            this.whitePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel redPanel;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Panel bluePanel;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Panel yellowPanel;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Panel greenPanel;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Panel purplePanel;
        private System.Windows.Forms.Button purpleButton;
        private System.Windows.Forms.Panel orangePanel;
        private System.Windows.Forms.Button orangeButton;
        private System.Windows.Forms.Panel blackPanel;
        private System.Windows.Forms.Button blackButton;
        private System.Windows.Forms.Panel whitePanel;
        private System.Windows.Forms.Button whiteButton;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer trackingTimer;
        private EyeXFramework.Forms.BehaviorMap behaviorMap;
    }
}