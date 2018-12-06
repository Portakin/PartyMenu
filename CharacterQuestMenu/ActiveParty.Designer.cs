namespace CharacterQuestMenu
{
    partial class ActiveParty
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(8D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(9D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 25D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveParty));
            this.NPC_TabControl = new System.Windows.Forms.TabControl();
            this.CombatLog = new System.Windows.Forms.TextBox();
            this.Ender = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AttackDescription = new System.Windows.Forms.TextBox();
            this.DamageBox = new System.Windows.Forms.TextBox();
            this.TargetDesignator = new System.Windows.Forms.Label();
            this.DamageDealer = new System.Windows.Forms.Label();
            this.EffectDesignator = new System.Windows.Forms.Label();
            this.TargetBox = new System.Windows.Forms.ComboBox();
            this.CombatBox = new System.Windows.Forms.GroupBox();
            this.EffectsBox = new System.Windows.Forms.ComboBox();
            this.Effects = new System.Windows.Forms.Label();
            this.TechniqueBox = new System.Windows.Forms.ComboBox();
            this.Technique = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SoulType = new System.Windows.Forms.RadioButton();
            this.SpiritType = new System.Windows.Forms.RadioButton();
            this.MannaType = new System.Windows.Forms.RadioButton();
            this.HealthType = new System.Windows.Forms.RadioButton();
            this.openBox = new System.Windows.Forms.CheckBox();
            this.NarrowBox = new System.Windows.Forms.CheckBox();
            this.RearPosition = new System.Windows.Forms.Label();
            this.PointPosition = new System.Windows.Forms.Label();
            this.RearBox = new System.Windows.Forms.ComboBox();
            this.PointBox = new System.Windows.Forms.ComboBox();
            this.MannaSaturation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NPCs = new System.Windows.Forms.Button();
            this.DescriptionBox = new System.Windows.Forms.RichTextBox();
            this.Party_Name = new System.Windows.Forms.Label();
            this.Difficulty = new System.Windows.Forms.Label();
            this.TurnCount = new System.Windows.Forms.Label();
            this.BattleButton = new System.Windows.Forms.Button();
            this.Average = new System.Windows.Forms.Label();
            this.DayButton = new System.Windows.Forms.Button();
            this.DayNumber = new System.Windows.Forms.Label();
            this.LocationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.memberBox5 = new CharacterQuestMenu.MemberBox();
            this.memberBox4 = new CharacterQuestMenu.MemberBox();
            this.memberBox3 = new CharacterQuestMenu.MemberBox();
            this.memberBox2 = new CharacterQuestMenu.MemberBox();
            this.memberBox1 = new CharacterQuestMenu.MemberBox();
            this.CombatBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MannaSaturation)).BeginInit();
            this.SuspendLayout();
            // 
            // NPC_TabControl
            // 
            this.NPC_TabControl.Location = new System.Drawing.Point(1201, 49);
            this.NPC_TabControl.Name = "NPC_TabControl";
            this.NPC_TabControl.SelectedIndex = 0;
            this.NPC_TabControl.Size = new System.Drawing.Size(413, 406);
            this.NPC_TabControl.TabIndex = 0;
            // 
            // CombatLog
            // 
            this.CombatLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombatLog.Location = new System.Drawing.Point(426, 81);
            this.CombatLog.Multiline = true;
            this.CombatLog.Name = "CombatLog";
            this.CombatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CombatLog.Size = new System.Drawing.Size(355, 306);
            this.CombatLog.TabIndex = 3;
            // 
            // Ender
            // 
            this.Ender.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ender.Location = new System.Drawing.Point(426, 12);
            this.Ender.Name = "Ender";
            this.Ender.Size = new System.Drawing.Size(355, 63);
            this.Ender.TabIndex = 4;
            this.Ender.Text = "End Turn";
            this.Ender.UseVisualStyleBackColor = true;
            this.Ender.Click += new System.EventHandler(this.End_Turn);
            this.Ender.MouseHover += new System.EventHandler(this.Ender_MouseHover);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(336, 54);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(336, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 23;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AttackDescription
            // 
            this.AttackDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackDescription.Location = new System.Drawing.Point(78, 84);
            this.AttackDescription.Multiline = true;
            this.AttackDescription.Name = "AttackDescription";
            this.AttackDescription.Size = new System.Drawing.Size(510, 32);
            this.AttackDescription.TabIndex = 26;
            this.AttackDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AttackDescription_KeyPress);
            // 
            // DamageBox
            // 
            this.DamageBox.Location = new System.Drawing.Point(78, 45);
            this.DamageBox.Name = "DamageBox";
            this.DamageBox.Size = new System.Drawing.Size(100, 20);
            this.DamageBox.TabIndex = 28;
            this.DamageBox.Text = "0";
            this.DamageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TargetDesignator
            // 
            this.TargetDesignator.AutoSize = true;
            this.TargetDesignator.Location = new System.Drawing.Point(17, 26);
            this.TargetDesignator.Name = "TargetDesignator";
            this.TargetDesignator.Size = new System.Drawing.Size(41, 13);
            this.TargetDesignator.TabIndex = 29;
            this.TargetDesignator.Text = "Target:";
            // 
            // DamageDealer
            // 
            this.DamageDealer.AutoSize = true;
            this.DamageDealer.Location = new System.Drawing.Point(17, 53);
            this.DamageDealer.Name = "DamageDealer";
            this.DamageDealer.Size = new System.Drawing.Size(50, 13);
            this.DamageDealer.TabIndex = 30;
            this.DamageDealer.Text = "Damage:";
            // 
            // EffectDesignator
            // 
            this.EffectDesignator.AutoSize = true;
            this.EffectDesignator.Location = new System.Drawing.Point(17, 103);
            this.EffectDesignator.Name = "EffectDesignator";
            this.EffectDesignator.Size = new System.Drawing.Size(31, 13);
            this.EffectDesignator.TabIndex = 31;
            this.EffectDesignator.Text = "Text:";
            // 
            // TargetBox
            // 
            this.TargetBox.FormattingEnabled = true;
            this.TargetBox.Items.AddRange(new object[] {
            "None"});
            this.TargetBox.Location = new System.Drawing.Point(78, 18);
            this.TargetBox.Name = "TargetBox";
            this.TargetBox.Size = new System.Drawing.Size(100, 21);
            this.TargetBox.TabIndex = 32;
            this.TargetBox.SelectedIndexChanged += new System.EventHandler(this.TargetBox_SelectedIndexChanged);
            // 
            // CombatBox
            // 
            this.CombatBox.Controls.Add(this.EffectsBox);
            this.CombatBox.Controls.Add(this.Effects);
            this.CombatBox.Controls.Add(this.TechniqueBox);
            this.CombatBox.Controls.Add(this.Technique);
            this.CombatBox.Controls.Add(this.ConfirmButton);
            this.CombatBox.Controls.Add(this.SoulType);
            this.CombatBox.Controls.Add(this.SpiritType);
            this.CombatBox.Controls.Add(this.MannaType);
            this.CombatBox.Controls.Add(this.HealthType);
            this.CombatBox.Controls.Add(this.TargetBox);
            this.CombatBox.Controls.Add(this.TargetDesignator);
            this.CombatBox.Controls.Add(this.DamageBox);
            this.CombatBox.Controls.Add(this.DamageDealer);
            this.CombatBox.Controls.Add(this.EffectDesignator);
            this.CombatBox.Controls.Add(this.AttackDescription);
            this.CombatBox.Location = new System.Drawing.Point(1012, 461);
            this.CombatBox.Name = "CombatBox";
            this.CombatBox.Size = new System.Drawing.Size(594, 175);
            this.CombatBox.TabIndex = 38;
            this.CombatBox.TabStop = false;
            this.CombatBox.Text = "Combat";
            // 
            // EffectsBox
            // 
            this.EffectsBox.Enabled = false;
            this.EffectsBox.FormattingEnabled = true;
            this.EffectsBox.Items.AddRange(new object[] {
            "Revive",
            "Resurrect",
            "Manna (per turn)",
            "Health (per turn)",
            "Saturation"});
            this.EffectsBox.Location = new System.Drawing.Point(258, 45);
            this.EffectsBox.Name = "EffectsBox";
            this.EffectsBox.Size = new System.Drawing.Size(100, 21);
            this.EffectsBox.TabIndex = 56;
            // 
            // Effects
            // 
            this.Effects.AutoSize = true;
            this.Effects.Location = new System.Drawing.Point(186, 53);
            this.Effects.Name = "Effects";
            this.Effects.Size = new System.Drawing.Size(43, 13);
            this.Effects.TabIndex = 55;
            this.Effects.Text = "Effects:";
            // 
            // TechniqueBox
            // 
            this.TechniqueBox.FormattingEnabled = true;
            this.TechniqueBox.Items.AddRange(new object[] {
            "None"});
            this.TechniqueBox.Location = new System.Drawing.Point(258, 18);
            this.TechniqueBox.Name = "TechniqueBox";
            this.TechniqueBox.Size = new System.Drawing.Size(100, 21);
            this.TechniqueBox.TabIndex = 53;
            this.TechniqueBox.SelectedIndexChanged += new System.EventHandler(this.TechniqueBox_SelectedIndexChanged);
            // 
            // Technique
            // 
            this.Technique.AutoSize = true;
            this.Technique.Location = new System.Drawing.Point(186, 26);
            this.Technique.Name = "Technique";
            this.Technique.Size = new System.Drawing.Size(66, 13);
            this.Technique.TabIndex = 52;
            this.Technique.Text = "Techniques:";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(470, 122);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(118, 41);
            this.ConfirmButton.TabIndex = 46;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // SoulType
            // 
            this.SoulType.AutoSize = true;
            this.SoulType.Location = new System.Drawing.Point(540, 45);
            this.SoulType.Name = "SoulType";
            this.SoulType.Size = new System.Drawing.Size(46, 17);
            this.SoulType.TabIndex = 36;
            this.SoulType.TabStop = true;
            this.SoulType.Text = "Soul";
            this.SoulType.UseVisualStyleBackColor = true;
            this.SoulType.CheckedChanged += new System.EventHandler(this.changeType);
            // 
            // SpiritType
            // 
            this.SpiritType.AutoSize = true;
            this.SpiritType.Location = new System.Drawing.Point(540, 18);
            this.SpiritType.Name = "SpiritType";
            this.SpiritType.Size = new System.Drawing.Size(48, 17);
            this.SpiritType.TabIndex = 35;
            this.SpiritType.TabStop = true;
            this.SpiritType.Text = "Spirit";
            this.SpiritType.UseVisualStyleBackColor = true;
            this.SpiritType.CheckedChanged += new System.EventHandler(this.changeType);
            // 
            // MannaType
            // 
            this.MannaType.AutoSize = true;
            this.MannaType.Location = new System.Drawing.Point(462, 46);
            this.MannaType.Name = "MannaType";
            this.MannaType.Size = new System.Drawing.Size(58, 17);
            this.MannaType.TabIndex = 34;
            this.MannaType.TabStop = true;
            this.MannaType.Text = "Manna";
            this.MannaType.UseVisualStyleBackColor = true;
            this.MannaType.CheckedChanged += new System.EventHandler(this.changeType);
            // 
            // HealthType
            // 
            this.HealthType.AutoSize = true;
            this.HealthType.Checked = true;
            this.HealthType.Location = new System.Drawing.Point(462, 19);
            this.HealthType.Name = "HealthType";
            this.HealthType.Size = new System.Drawing.Size(72, 17);
            this.HealthType.TabIndex = 33;
            this.HealthType.TabStop = true;
            this.HealthType.Text = "Life-Force";
            this.HealthType.UseVisualStyleBackColor = true;
            this.HealthType.CheckedChanged += new System.EventHandler(this.changeType);
            // 
            // openBox
            // 
            this.openBox.AutoSize = true;
            this.openBox.Location = new System.Drawing.Point(1034, 118);
            this.openBox.Name = "openBox";
            this.openBox.Size = new System.Drawing.Size(52, 17);
            this.openBox.TabIndex = 48;
            this.openBox.Text = "Open";
            this.openBox.UseVisualStyleBackColor = true;
            // 
            // NarrowBox
            // 
            this.NarrowBox.AutoSize = true;
            this.NarrowBox.Location = new System.Drawing.Point(1034, 93);
            this.NarrowBox.Name = "NarrowBox";
            this.NarrowBox.Size = new System.Drawing.Size(70, 17);
            this.NarrowBox.TabIndex = 47;
            this.NarrowBox.Text = "Enclosed";
            this.NarrowBox.UseVisualStyleBackColor = true;
            // 
            // RearPosition
            // 
            this.RearPosition.AutoSize = true;
            this.RearPosition.Location = new System.Drawing.Point(1101, 120);
            this.RearPosition.Name = "RearPosition";
            this.RearPosition.Size = new System.Drawing.Size(33, 13);
            this.RearPosition.TabIndex = 45;
            this.RearPosition.Text = "Rear:";
            // 
            // PointPosition
            // 
            this.PointPosition.AutoSize = true;
            this.PointPosition.Location = new System.Drawing.Point(1101, 93);
            this.PointPosition.Name = "PointPosition";
            this.PointPosition.Size = new System.Drawing.Size(36, 13);
            this.PointPosition.TabIndex = 44;
            this.PointPosition.Text = "Head:";
            // 
            // RearBox
            // 
            this.RearBox.FormattingEnabled = true;
            this.RearBox.Location = new System.Drawing.Point(1134, 116);
            this.RearBox.Name = "RearBox";
            this.RearBox.Size = new System.Drawing.Size(58, 21);
            this.RearBox.TabIndex = 42;
            // 
            // PointBox
            // 
            this.PointBox.FormattingEnabled = true;
            this.PointBox.Location = new System.Drawing.Point(1134, 87);
            this.PointBox.Name = "PointBox";
            this.PointBox.Size = new System.Drawing.Size(58, 21);
            this.PointBox.TabIndex = 41;
            // 
            // MannaSaturation
            // 
            chartArea1.Name = "ChartArea1";
            this.MannaSaturation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MannaSaturation.Legends.Add(legend1);
            this.MannaSaturation.Location = new System.Drawing.Point(809, 637);
            this.MannaSaturation.Name = "MannaSaturation";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Legend = "Legend1";
            series1.Name = "Saturation";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Critical";
            series2.Points.Add(dataPoint1);
            series2.Points.Add(dataPoint2);
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            series2.Points.Add(dataPoint7);
            series2.Points.Add(dataPoint8);
            series2.Points.Add(dataPoint9);
            series2.Points.Add(dataPoint10);
            this.MannaSaturation.Series.Add(series1);
            this.MannaSaturation.Series.Add(series2);
            this.MannaSaturation.Size = new System.Drawing.Size(797, 240);
            this.MannaSaturation.TabIndex = 41;
            this.MannaSaturation.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            title1.Name = "Saturation";
            title1.Text = "Manna Saturation";
            this.MannaSaturation.Titles.Add(title1);
            this.MannaSaturation.MouseHover += new System.EventHandler(this.MannaSaturation_MouseHover);
            // 
            // NPCs
            // 
            this.NPCs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NPCs.Location = new System.Drawing.Point(1201, 12);
            this.NPCs.Name = "NPCs";
            this.NPCs.Size = new System.Drawing.Size(413, 37);
            this.NPCs.TabIndex = 42;
            this.NPCs.Text = "NPC\'S";
            this.NPCs.UseVisualStyleBackColor = true;
            this.NPCs.Click += new System.EventHandler(this.NPCs_Click);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(12, 663);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(373, 217);
            this.DescriptionBox.TabIndex = 49;
            this.DescriptionBox.Text = resources.GetString("DescriptionBox.Text");
            // 
            // Party_Name
            // 
            this.Party_Name.AutoSize = true;
            this.Party_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Party_Name.Location = new System.Drawing.Point(787, 11);
            this.Party_Name.Name = "Party_Name";
            this.Party_Name.Size = new System.Drawing.Size(56, 24);
            this.Party_Name.TabIndex = 50;
            this.Party_Name.Text = "Party:";
            // 
            // Difficulty
            // 
            this.Difficulty.AutoSize = true;
            this.Difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Difficulty.Location = new System.Drawing.Point(787, 35);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(82, 24);
            this.Difficulty.TabIndex = 51;
            this.Difficulty.Text = "Difficulty:";
            // 
            // TurnCount
            // 
            this.TurnCount.AutoSize = true;
            this.TurnCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnCount.Location = new System.Drawing.Point(783, 87);
            this.TurnCount.Name = "TurnCount";
            this.TurnCount.Size = new System.Drawing.Size(125, 24);
            this.TurnCount.TabIndex = 52;
            this.TurnCount.Text = "Turn Count: 0";
            // 
            // BattleButton
            // 
            this.BattleButton.Enabled = false;
            this.BattleButton.Location = new System.Drawing.Point(336, 92);
            this.BattleButton.Name = "BattleButton";
            this.BattleButton.Size = new System.Drawing.Size(75, 23);
            this.BattleButton.TabIndex = 56;
            this.BattleButton.Text = "Begin";
            this.BattleButton.UseVisualStyleBackColor = true;
            this.BattleButton.Click += new System.EventHandler(this.BattleButton_Click);
            // 
            // Average
            // 
            this.Average.AutoSize = true;
            this.Average.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Average.Location = new System.Drawing.Point(787, 59);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(110, 24);
            this.Average.TabIndex = 57;
            this.Average.Text = "Lv Average:";
            // 
            // DayButton
            // 
            this.DayButton.Location = new System.Drawing.Point(1115, 20);
            this.DayButton.Name = "DayButton";
            this.DayButton.Size = new System.Drawing.Size(75, 23);
            this.DayButton.TabIndex = 58;
            this.DayButton.Text = "End Day";
            this.DayButton.UseVisualStyleBackColor = true;
            this.DayButton.Click += new System.EventHandler(this.DayButton_Click);
            // 
            // DayNumber
            // 
            this.DayNumber.AutoSize = true;
            this.DayNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayNumber.Location = new System.Drawing.Point(783, 115);
            this.DayNumber.Name = "DayNumber";
            this.DayNumber.Size = new System.Drawing.Size(117, 24);
            this.DayNumber.TabIndex = 59;
            this.DayNumber.Text = "Day Count: 0";
            // 
            // LocationButton
            // 
            this.LocationButton.Location = new System.Drawing.Point(1115, 49);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.Size = new System.Drawing.Size(75, 23);
            this.LocationButton.TabIndex = 60;
            this.LocationButton.Text = "Locale";
            this.LocationButton.UseVisualStyleBackColor = true;
            this.LocationButton.Click += new System.EventHandler(this.LocationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 39);
            this.label1.TabIndex = 61;
            this.label1.Text = "Load and Save Parties and start and finish battles. \r\nRemember to refresh the loc" +
    "ale when changing locations.\r\nUpdate the day count when training of traveling!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memberBox5
            // 
            this.memberBox5.Bursting = false;
            this.memberBox5.Display_Text = null;
            this.memberBox5.Ether_Burning = false;
            this.memberBox5.Gathering = false;
            this.memberBox5.Location = new System.Drawing.Point(391, 637);
            this.memberBox5.Name = "memberBox5";
            this.memberBox5.Size = new System.Drawing.Size(412, 243);
            this.memberBox5.TabIndex = 37;
            this.memberBox5.MouseHover += new System.EventHandler(this.MemberMouse_Over);
            // 
            // memberBox4
            // 
            this.memberBox4.Bursting = false;
            this.memberBox4.Display_Text = null;
            this.memberBox4.Ether_Burning = false;
            this.memberBox4.Gathering = false;
            this.memberBox4.Location = new System.Drawing.Point(594, 393);
            this.memberBox4.Name = "memberBox4";
            this.memberBox4.Size = new System.Drawing.Size(412, 243);
            this.memberBox4.TabIndex = 36;
            this.memberBox4.MouseHover += new System.EventHandler(this.MemberMouse_Over);
            // 
            // memberBox3
            // 
            this.memberBox3.Bursting = false;
            this.memberBox3.Display_Text = null;
            this.memberBox3.Ether_Burning = false;
            this.memberBox3.Gathering = false;
            this.memberBox3.Location = new System.Drawing.Point(787, 144);
            this.memberBox3.Name = "memberBox3";
            this.memberBox3.Size = new System.Drawing.Size(412, 243);
            this.memberBox3.TabIndex = 35;
            this.memberBox3.MouseHover += new System.EventHandler(this.MemberMouse_Over);
            // 
            // memberBox2
            // 
            this.memberBox2.Bursting = false;
            this.memberBox2.Display_Text = null;
            this.memberBox2.Ether_Burning = false;
            this.memberBox2.Gathering = false;
            this.memberBox2.Location = new System.Drawing.Point(176, 393);
            this.memberBox2.Name = "memberBox2";
            this.memberBox2.Size = new System.Drawing.Size(412, 243);
            this.memberBox2.TabIndex = 34;
            this.memberBox2.MouseHover += new System.EventHandler(this.MemberMouse_Over);
            // 
            // memberBox1
            // 
            this.memberBox1.Bursting = false;
            this.memberBox1.Display_Text = null;
            this.memberBox1.Ether_Burning = false;
            this.memberBox1.Gathering = false;
            this.memberBox1.Location = new System.Drawing.Point(8, 144);
            this.memberBox1.Name = "memberBox1";
            this.memberBox1.Size = new System.Drawing.Size(412, 243);
            this.memberBox1.TabIndex = 33;
            this.memberBox1.MouseHover += new System.EventHandler(this.MemberMouse_Over);
            // 
            // ActiveParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1618, 889);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocationButton);
            this.Controls.Add(this.DayNumber);
            this.Controls.Add(this.DayButton);
            this.Controls.Add(this.Average);
            this.Controls.Add(this.BattleButton);
            this.Controls.Add(this.TurnCount);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.Party_Name);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.NPCs);
            this.Controls.Add(this.MannaSaturation);
            this.Controls.Add(this.CombatBox);
            this.Controls.Add(this.openBox);
            this.Controls.Add(this.memberBox5);
            this.Controls.Add(this.NarrowBox);
            this.Controls.Add(this.memberBox4);
            this.Controls.Add(this.memberBox3);
            this.Controls.Add(this.RearPosition);
            this.Controls.Add(this.memberBox2);
            this.Controls.Add(this.memberBox1);
            this.Controls.Add(this.PointPosition);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RearBox);
            this.Controls.Add(this.PointBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.Ender);
            this.Controls.Add(this.CombatLog);
            this.Controls.Add(this.NPC_TabControl);
            this.Name = "ActiveParty";
            this.Text = "ActiveParty";
            this.Load += new System.EventHandler(this.ActiveParty_Load);
            this.MouseHover += new System.EventHandler(this.ActiveParty_MouseHover);
            this.CombatBox.ResumeLayout(false);
            this.CombatBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MannaSaturation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CombatLog;
        private System.Windows.Forms.Button Ender;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox AttackDescription;
        private System.Windows.Forms.TextBox DamageBox;
        private System.Windows.Forms.Label TargetDesignator;
        private System.Windows.Forms.Label DamageDealer;
        private System.Windows.Forms.Label EffectDesignator;
        private System.Windows.Forms.ComboBox TargetBox;
        private MemberBox memberBox1;
        private MemberBox memberBox2;
        private MemberBox memberBox3;
        private MemberBox memberBox4;
        private MemberBox memberBox5;
        private System.Windows.Forms.GroupBox CombatBox;
        private System.Windows.Forms.RadioButton SoulType;
        private System.Windows.Forms.RadioButton SpiritType;
        private System.Windows.Forms.RadioButton MannaType;
        private System.Windows.Forms.RadioButton HealthType;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label RearPosition;
        private System.Windows.Forms.Label PointPosition;
        private System.Windows.Forms.ComboBox RearBox;
        private System.Windows.Forms.ComboBox PointBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart MannaSaturation;
        private System.Windows.Forms.CheckBox openBox;
        private System.Windows.Forms.CheckBox NarrowBox;
        private System.Windows.Forms.Button NPCs;
        private System.Windows.Forms.ComboBox TechniqueBox;
        private System.Windows.Forms.Label Technique;
        private System.Windows.Forms.ComboBox EffectsBox;
        private System.Windows.Forms.Label Effects;
        private System.Windows.Forms.RichTextBox DescriptionBox;
        private System.Windows.Forms.Label Party_Name;
        private System.Windows.Forms.Label Difficulty;
        private System.Windows.Forms.Label TurnCount;
        private System.Windows.Forms.Button BattleButton;
        private System.Windows.Forms.Label Average;
        private System.Windows.Forms.Button DayButton;
        private System.Windows.Forms.Label DayNumber;
        private System.Windows.Forms.Button LocationButton;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabControl NPC_TabControl;
    }
}