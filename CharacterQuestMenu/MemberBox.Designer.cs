namespace CharacterQuestMenu
{
    partial class MemberBox
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
            this.H_display = new System.Windows.Forms.Label();
            this.M_display = new System.Windows.Forms.Label();
            this.Residual_display = new System.Windows.Forms.Label();
            this.HealthBox = new System.Windows.Forms.ComboBox();
            this.EnergyBox = new System.Windows.Forms.ComboBox();
            this.HalfPower = new System.Windows.Forms.RadioButton();
            this.Normalize = new System.Windows.Forms.RadioButton();
            this.FullPower = new System.Windows.Forms.RadioButton();
            this.TechniqueBox = new System.Windows.Forms.CheckedListBox();
            this.Viewer = new System.Windows.Forms.Button();
            this.P_display = new System.Windows.Forms.Label();
            this.E_display = new System.Windows.Forms.Label();
            this.S_display = new System.Windows.Forms.Label();
            this.F_display = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EtherBurnBox = new System.Windows.Forms.CheckBox();
            this.SpeedBurstBox = new System.Windows.Forms.CheckBox();
            this.Residual_Cost = new System.Windows.Forms.TextBox();
            this.FlightBar = new CharacterQuestMenu.StatBar();
            this.SpeedBar = new CharacterQuestMenu.StatBar();
            this.EndBar = new CharacterQuestMenu.StatBar();
            this.MannaBar = new CharacterQuestMenu.StatBar();
            this.PowerBar = new CharacterQuestMenu.StatBar();
            this.HealthBar = new CharacterQuestMenu.StatBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // H_display
            // 
            this.H_display.AutoSize = true;
            this.H_display.Location = new System.Drawing.Point(7, 28);
            this.H_display.Name = "H_display";
            this.H_display.Size = new System.Drawing.Size(41, 13);
            this.H_display.TabIndex = 0;
            this.H_display.Text = "Health:";
            // 
            // M_display
            // 
            this.M_display.AutoSize = true;
            this.M_display.Location = new System.Drawing.Point(7, 55);
            this.M_display.Name = "M_display";
            this.M_display.Size = new System.Drawing.Size(43, 13);
            this.M_display.TabIndex = 1;
            this.M_display.Text = "Manna:";
            // 
            // Residual_display
            // 
            this.Residual_display.AutoSize = true;
            this.Residual_display.Location = new System.Drawing.Point(7, 81);
            this.Residual_display.Name = "Residual_display";
            this.Residual_display.Size = new System.Drawing.Size(51, 13);
            this.Residual_display.TabIndex = 2;
            this.Residual_display.Text = "Residual:";
            // 
            // HealthBox
            // 
            this.HealthBox.FormattingEnabled = true;
            this.HealthBox.Items.AddRange(new object[] {
            "Life-Force",
            "Spirit",
            "Soul"});
            this.HealthBox.Location = new System.Drawing.Point(62, 20);
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(83, 21);
            this.HealthBox.TabIndex = 3;
            this.HealthBox.Text = "Life-Force";
            this.HealthBox.SelectedIndexChanged += new System.EventHandler(this.HealthBox_SelectedIndexChanged);
            // 
            // EnergyBox
            // 
            this.EnergyBox.FormattingEnabled = true;
            this.EnergyBox.Items.AddRange(new object[] {
            "Body",
            "Mental",
            "Spirit",
            "Memory"});
            this.EnergyBox.Location = new System.Drawing.Point(62, 47);
            this.EnergyBox.Name = "EnergyBox";
            this.EnergyBox.Size = new System.Drawing.Size(83, 21);
            this.EnergyBox.TabIndex = 4;
            this.EnergyBox.SelectedIndexChanged += new System.EventHandler(this.EnergyBox_SelectedIndexChanged);
            // 
            // HalfPower
            // 
            this.HalfPower.AutoSize = true;
            this.HalfPower.Location = new System.Drawing.Point(154, 79);
            this.HalfPower.Name = "HalfPower";
            this.HalfPower.Size = new System.Drawing.Size(77, 17);
            this.HalfPower.TabIndex = 11;
            this.HalfPower.TabStop = true;
            this.HalfPower.Text = "Half Power";
            this.HalfPower.UseVisualStyleBackColor = true;
            this.HalfPower.CheckedChanged += new System.EventHandler(this.HalfPower_CheckedChanged);
            // 
            // Normalize
            // 
            this.Normalize.AutoSize = true;
            this.Normalize.Location = new System.Drawing.Point(237, 79);
            this.Normalize.Name = "Normalize";
            this.Normalize.Size = new System.Drawing.Size(71, 17);
            this.Normalize.TabIndex = 12;
            this.Normalize.TabStop = true;
            this.Normalize.Text = "Normalize";
            this.Normalize.UseVisualStyleBackColor = true;
            this.Normalize.CheckedChanged += new System.EventHandler(this.Normalize_CheckedChanged);
            // 
            // FullPower
            // 
            this.FullPower.AutoSize = true;
            this.FullPower.Location = new System.Drawing.Point(314, 79);
            this.FullPower.Name = "FullPower";
            this.FullPower.Size = new System.Drawing.Size(74, 17);
            this.FullPower.TabIndex = 13;
            this.FullPower.TabStop = true;
            this.FullPower.Text = "Full Power";
            this.FullPower.UseVisualStyleBackColor = true;
            this.FullPower.CheckedChanged += new System.EventHandler(this.FullPower_CheckedChanged);
            // 
            // TechniqueBox
            // 
            this.TechniqueBox.FormattingEnabled = true;
            this.TechniqueBox.Location = new System.Drawing.Point(10, 147);
            this.TechniqueBox.Name = "TechniqueBox";
            this.TechniqueBox.Size = new System.Drawing.Size(135, 64);
            this.TechniqueBox.TabIndex = 14;
            // 
            // Viewer
            // 
            this.Viewer.Location = new System.Drawing.Point(10, 211);
            this.Viewer.Name = "Viewer";
            this.Viewer.Size = new System.Drawing.Size(135, 23);
            this.Viewer.TabIndex = 15;
            this.Viewer.Text = "View";
            this.Viewer.UseVisualStyleBackColor = true;
            this.Viewer.Click += new System.EventHandler(this.Viewer_Click);
            // 
            // P_display
            // 
            this.P_display.AutoSize = true;
            this.P_display.Location = new System.Drawing.Point(151, 114);
            this.P_display.Name = "P_display";
            this.P_display.Size = new System.Drawing.Size(37, 13);
            this.P_display.TabIndex = 16;
            this.P_display.Text = "Power";
            // 
            // E_display
            // 
            this.E_display.AutoSize = true;
            this.E_display.Location = new System.Drawing.Point(151, 145);
            this.E_display.Name = "E_display";
            this.E_display.Size = new System.Drawing.Size(59, 13);
            this.E_display.TabIndex = 17;
            this.E_display.Text = "Endurance";
            // 
            // S_display
            // 
            this.S_display.AutoSize = true;
            this.S_display.Location = new System.Drawing.Point(151, 183);
            this.S_display.Name = "S_display";
            this.S_display.Size = new System.Drawing.Size(38, 13);
            this.S_display.TabIndex = 18;
            this.S_display.Text = "Speed";
            // 
            // F_display
            // 
            this.F_display.AutoSize = true;
            this.F_display.Location = new System.Drawing.Point(151, 210);
            this.F_display.Name = "F_display";
            this.F_display.Size = new System.Drawing.Size(32, 13);
            this.F_display.TabIndex = 19;
            this.F_display.Text = "Flight";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EtherBurnBox);
            this.groupBox1.Controls.Add(this.SpeedBurstBox);
            this.groupBox1.Controls.Add(this.Residual_Cost);
            this.groupBox1.Controls.Add(this.FlightBar);
            this.groupBox1.Controls.Add(this.SpeedBar);
            this.groupBox1.Controls.Add(this.EndBar);
            this.groupBox1.Controls.Add(this.F_display);
            this.groupBox1.Controls.Add(this.S_display);
            this.groupBox1.Controls.Add(this.E_display);
            this.groupBox1.Controls.Add(this.P_display);
            this.groupBox1.Controls.Add(this.Viewer);
            this.groupBox1.Controls.Add(this.TechniqueBox);
            this.groupBox1.Controls.Add(this.FullPower);
            this.groupBox1.Controls.Add(this.Normalize);
            this.groupBox1.Controls.Add(this.HalfPower);
            this.groupBox1.Controls.Add(this.MannaBar);
            this.groupBox1.Controls.Add(this.PowerBar);
            this.groupBox1.Controls.Add(this.HealthBar);
            this.groupBox1.Controls.Add(this.EnergyBox);
            this.groupBox1.Controls.Add(this.HealthBox);
            this.groupBox1.Controls.Add(this.Residual_display);
            this.groupBox1.Controls.Add(this.M_display);
            this.groupBox1.Controls.Add(this.H_display);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Slot";
            // 
            // EtherBurnBox
            // 
            this.EtherBurnBox.AutoSize = true;
            this.EtherBurnBox.Enabled = false;
            this.EtherBurnBox.Location = new System.Drawing.Point(10, 124);
            this.EtherBurnBox.Name = "EtherBurnBox";
            this.EtherBurnBox.Size = new System.Drawing.Size(76, 17);
            this.EtherBurnBox.TabIndex = 25;
            this.EtherBurnBox.Text = "Ether Burn";
            this.EtherBurnBox.UseVisualStyleBackColor = true;
            this.EtherBurnBox.CheckedChanged += new System.EventHandler(this.EtherBurnBox_CheckedChanged);
            // 
            // SpeedBurstBox
            // 
            this.SpeedBurstBox.AutoSize = true;
            this.SpeedBurstBox.Enabled = false;
            this.SpeedBurstBox.Location = new System.Drawing.Point(10, 102);
            this.SpeedBurstBox.Name = "SpeedBurstBox";
            this.SpeedBurstBox.Size = new System.Drawing.Size(84, 17);
            this.SpeedBurstBox.TabIndex = 24;
            this.SpeedBurstBox.Text = "Speed Burst";
            this.SpeedBurstBox.UseVisualStyleBackColor = true;
            this.SpeedBurstBox.CheckedChanged += new System.EventHandler(this.SpeedBurstBox_CheckedChanged);
            // 
            // Residual_Cost
            // 
            this.Residual_Cost.Location = new System.Drawing.Point(62, 76);
            this.Residual_Cost.MaxLength = 100;
            this.Residual_Cost.Name = "Residual_Cost";
            this.Residual_Cost.Size = new System.Drawing.Size(83, 20);
            this.Residual_Cost.TabIndex = 23;
            this.Residual_Cost.Text = "3";
            this.Residual_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Residual_Cost.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Residual_Cost_MouseClick);
            this.Residual_Cost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Residual_Cost_KeyPress);
            // 
            // FlightBar
            // 
            this.FlightBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FlightBar.Location = new System.Drawing.Point(211, 202);
            this.FlightBar.Name = "FlightBar";
            this.FlightBar.Size = new System.Drawing.Size(195, 25);
            this.FlightBar.TabIndex = 22;
            this.FlightBar.Value = 0F;
            // 
            // SpeedBar
            // 
            this.SpeedBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.SpeedBar.Location = new System.Drawing.Point(211, 171);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(195, 25);
            this.SpeedBar.TabIndex = 21;
            this.SpeedBar.Value = 0F;
            // 
            // EndBar
            // 
            this.EndBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.EndBar.Location = new System.Drawing.Point(211, 133);
            this.EndBar.Name = "EndBar";
            this.EndBar.Size = new System.Drawing.Size(195, 25);
            this.EndBar.TabIndex = 20;
            this.EndBar.Value = 0F;
            // 
            // MannaBar
            // 
            this.MannaBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MannaBar.Location = new System.Drawing.Point(151, 47);
            this.MannaBar.Name = "MannaBar";
            this.MannaBar.Size = new System.Drawing.Size(255, 21);
            this.MannaBar.TabIndex = 7;
            this.MannaBar.Value = 0F;
            // 
            // PowerBar
            // 
            this.PowerBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PowerBar.Location = new System.Drawing.Point(211, 102);
            this.PowerBar.Name = "PowerBar";
            this.PowerBar.Size = new System.Drawing.Size(195, 25);
            this.PowerBar.TabIndex = 6;
            this.PowerBar.Value = 0F;
            // 
            // HealthBar
            // 
            this.HealthBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HealthBar.Location = new System.Drawing.Point(151, 20);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(255, 22);
            this.HealthBar.TabIndex = 5;
            this.HealthBar.Value = 0F;
            // 
            // MemberBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberBox";
            this.Size = new System.Drawing.Size(412, 243);
            this.MouseHover += new System.EventHandler(this.MemberBox_MouseHover);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label H_display;
        private System.Windows.Forms.Label M_display;
        private System.Windows.Forms.Label Residual_display;
        private System.Windows.Forms.ComboBox HealthBox;
        private System.Windows.Forms.ComboBox EnergyBox;
        private StatBar HealthBar;
        private StatBar PowerBar;
        private StatBar MannaBar;
        private System.Windows.Forms.RadioButton HalfPower;
        private System.Windows.Forms.RadioButton Normalize;
        private System.Windows.Forms.RadioButton FullPower;
        private System.Windows.Forms.CheckedListBox TechniqueBox;
        private System.Windows.Forms.Button Viewer;
        private System.Windows.Forms.Label P_display;
        private System.Windows.Forms.Label E_display;
        private System.Windows.Forms.Label S_display;
        private System.Windows.Forms.Label F_display;
        private System.Windows.Forms.GroupBox groupBox1;
        private StatBar FlightBar;
        private StatBar SpeedBar;
        private StatBar EndBar;
        private System.Windows.Forms.CheckBox EtherBurnBox;
        private System.Windows.Forms.CheckBox SpeedBurstBox;
        private System.Windows.Forms.TextBox Residual_Cost;
    }
}
