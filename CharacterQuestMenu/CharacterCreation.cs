using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterQuestMenu
{
    public partial class CharacterCreation : Form
    {
        public Character NewCharacter { get; set; } = new Character();

        private string path = Directory.GetCurrentDirectory() + "\\Characters\\TEMPLATES\\CHARACTER TEMPLATE.txt";
        private bool ViewerMode = false;
        private bool demon = false;
        private bool religion = false;
        private bool raceSelect = false;
        private int Age = 20;
        
        private Random rnd = new Random();
        
        private int bStrength;
        private int bResistence;
        private int bSkill;
        private int bintelliegence;
        
        private int MAX_Strength = 6;
        private int MAX_Skill = 4;
        private int MAX_Resistence = 4;
        private int MAX_intelligence = 4;
                            
        public CharacterCreation()
        {
            InitializeComponent();
            this.NewCharacter.Race = 1;
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        public CharacterCreation(Character c)//editor constructor
        {
            //constructor for view character in active party and edit character            
            InitializeComponent();
            NewCharacter = c;
            NameDisplay.Text = c.Name;
            LevelValue.Text = c.Level.ToString();
            ResetLabels();
            //disable race edit
            groupBox1.Enabled = false;

            MannaBar.Value = NewCharacter.mannaBonus;
            MannaBonus.Text = "Manna Bonus: " + NewCharacter.mannaBonus.ToString() + "%";
            LifeBar.Value = NewCharacter.LifeBonus;
            LifeBonus.Text = "Life Bonus: " + NewCharacter.LifeBonus.ToString() + "%";                       

            int[] stats = new int[4];
            stats[0] = c.Constitution;
            stats[1] = c.Skill;
            stats[2] = c.Resistence;
            stats[3] = c.intelligence;

            List<string> TRAINING = new List<string>();

            foreach (string S in NewCharacter.Training)
                TRAINING.Add(S);
            NewCharacter.Training.Clear();            

            //set up displays once before disabling
            c.CalculateStats();
           
            foreach (string S in TRAINING)
            {
                switch (S)
                {
                    case "Ciaha":
                        C_Train.Checked = true;
                        break;
                    case "Adept":
                        A_Train.Checked = true;
                        break;
                    case "Magian":
                        M_Train.Checked = true;
                        break;
                    case "Arbitian":
                        Ar_Train.Checked = true;
                        break;
                    case "Transcendence":
                        Transcendence.Checked = true;
                        break;
                    case "Ether Attunement":
                        Ether_Attunement.Checked = true;
                        break;
                    case "Demonic":
                        DemonCheck.Checked = true;
                        break;
                    case "Alchemy":
                        Alchemy.Checked = true;
                        break;
                    case "Ghosting":
                        Ghosting.Checked = true;
                        break;
                    case "Sorcery":
                        Sorcery.Checked = true;
                        break;
                }
            }

            if (NewCharacter.Religion > 0)
            {
                if (NewCharacter.Religion == 1)
                    Elementalism.Checked = true;
                else if (NewCharacter.Religion == 2)
                    Prayer.Checked = true;
                else
                    Arcane.Checked = true;
            }

            StrengthDisplay.Text = (stats[0] - c.Constitution).ToString();
            SkillDisplay.Text = (stats[1] - c.Skill).ToString();
            ResistenceDisplay.Text = (stats[2] - c.Resistence).ToString();
            IntelligenceDisplay.Text = (stats[3] - c.intelligence).ToString();
            NewCharacter.AddStatRoll((stats[3] - c.intelligence), (stats[1] - c.Skill), (stats[0] - c.Constitution), (stats[2] - c.Resistence));
            NewCharacter.StatRoll = true;

            StatChart.Series.Clear();
            DifficultyChart.Series.Clear();
            SkillChart.Series.Clear();
            EnergyChart.Series.Clear();
            fillCharts();
        }
         
        public CharacterCreation(Character c, bool mode)//viewer constructor//debug
        {
            //constructor for view character in active party and edit character
            InitializeComponent();
            NewCharacter = c;
            NameDisplay.Text = c.Name;
            LevelValue.Text = c.Level.ToString();
            ResetLabels();
            //differenc between constructors****************************************************************
            ViewerMode = mode;
            //disable race edit
            groupBox1.Enabled = false;

            MannaBar.Value = NewCharacter.mannaBonus;
            MannaBonus.Text = "Manna Bonus: " + NewCharacter.mannaBonus.ToString() + "%";
            LifeBar.Value = NewCharacter.LifeBonus;
            LifeBonus.Text = "Life Bonus: " + NewCharacter.LifeBonus.ToString() + "%";

            int[] stats = new int[4];
            stats[0] = c.Constitution;
            stats[1] = c.Skill;
            stats[2] = c.Resistence;
            stats[3] = c.intelligence;

            List<string> TRAINING = new List<string>();

            foreach (string S in NewCharacter.Training)
                TRAINING.Add(S);
            NewCharacter.Training.Clear();

            //set up displays once before disabling
            c.CalculateStats();

            foreach (string S in TRAINING)
            {
                switch (S)
                {
                    case "Ciaha":
                        C_Train.Checked = true;
                        break;
                    case "Adept":
                        A_Train.Checked = true;
                        break;
                    case "Magian":
                        M_Train.Checked = true;
                        break;
                    case "Arbitian":
                        Ar_Train.Checked = true;
                        break;
                    case "Transcendence":
                        Transcendence.Checked = true;
                        break;
                    case "Ether Attunement":
                        Ether_Attunement.Checked = true;
                        break;
                    case "Demonic":
                        DemonCheck.Checked = true;
                        break;
                    case "Alchemy":
                        Alchemy.Checked = true;
                        break;
                    case "Ghosting":
                        Ghosting.Checked = true;
                        break;
                    case "Sorcery":
                        Sorcery.Checked = true;
                        break;
                }
            }

            if (NewCharacter.Religion > 0)
            {
                if (NewCharacter.Religion == 1)
                    Elementalism.Checked = true;
                else if (NewCharacter.Religion == 2)
                    Prayer.Checked = true;
                else
                    Arcane.Checked = true;
            }

            StrengthDisplay.Text = (stats[0] - c.Constitution).ToString();
            SkillDisplay.Text = (stats[1] - c.Skill).ToString();
            ResistenceDisplay.Text = (stats[2] - c.Resistence).ToString();
            IntelligenceDisplay.Text = (stats[3] - c.intelligence).ToString();
            NewCharacter.AddStatRoll((stats[3] - c.intelligence), (stats[1] - c.Skill), (stats[0] - c.Constitution), (stats[2] - c.Resistence));
            NewCharacter.StatRoll = true;

            StatChart.Series.Clear();
            DifficultyChart.Series.Clear();
            SkillChart.Series.Clear();
            EnergyChart.Series.Clear();
            fillCharts();
        }

        private void CharacterCreation_Load(object sender, EventArgs e)
        {                       
            if(ViewerMode)
            {                
                StatRoll.Enabled = false;
                groupBox1.Enabled = false;
            }
        }

        private void fillCharts()
        {
            StatChart.Series.Add("Stat"); 
            StatChart.ChartAreas[0].AxisY.Maximum = 10;
            StatChart.ChartAreas[0].AxisY.Minimum = 0;
            StatChart.ChartAreas[0].AxisX.Maximum = 4;
            StatChart.ChartAreas[0].AxisX.Minimum = 0;
            StatChart.Series[0].Color = Color.Red;

            SkillChart.Series.Add("Skill");
            SkillChart.ChartAreas[0].AxisY.Maximum = 100;
            SkillChart.ChartAreas[0].AxisX.Maximum = 4;
            SkillChart.ChartAreas[0].AxisY.Minimum = 0;
            SkillChart.ChartAreas[0].AxisY.Minimum = 0;
            SkillChart.Series[0].Color = Color.Orange;

            EnergyChart.Series.Add("Energy");
            EnergyChart.ChartAreas[0].AxisY.Maximum = 100;
            EnergyChart.ChartAreas[0].AxisY.Minimum = 0;
            EnergyChart.ChartAreas[0].AxisX.Maximum = 8;
            EnergyChart.ChartAreas[0].AxisX.Minimum = 0;
            EnergyChart.Series[0].Color = Color.Lime;
                        
            StatChart.Series["Stat"].Points.AddXY("Constitution", NewCharacter.Constitution);
            StatChart.Series["Stat"].Points.AddXY("Resistance", NewCharacter.Resistence);
            StatChart.Series["Stat"].Points.AddXY("Skill", NewCharacter.Skill);
            StatChart.Series["Stat"].Points.AddXY("Intelligence", NewCharacter.intelligence);            

            SkillChart.Series["Skill"].Points.AddXY("Weapon Arts", NewCharacter.weaponArts);
            SkillChart.Series["Skill"].Points.AddXY("Combat Arts", NewCharacter.combatArts);
            SkillChart.Series["Skill"].Points.AddXY("Tech", NewCharacter.Tech);
            SkillChart.Series["Skill"].Points.AddXY("Mage Tech", NewCharacter.MageTech);

            EnergyChart.Series["Energy"].Points.AddXY("Life-Force", NewCharacter.Constitution*5 + NewCharacter.Level/2);
            EnergyChart.Series["Energy"].Points.AddXY("Manna", NewCharacter.mannaTraining);
            EnergyChart.Series["Energy"].Points.AddXY("Mental", NewCharacter.mentalEnergy);
            EnergyChart.Series["Energy"].Points.AddXY("Body", NewCharacter.bodyEnergy);
            EnergyChart.Series["Energy"].Points.AddXY("Spiritual", NewCharacter.spiritualEnergy);
            EnergyChart.Series["Energy"].Points.AddXY("Memory", NewCharacter.memoryEnergy);
            EnergyChart.Series["Energy"].Points.AddXY("Demonic", NewCharacter.demonicEnergy);

        }
        //Race selections
        private void CiahaSelect_CheckedChanged(object sender, EventArgs e)
        {
            //ciaha base stats                      
            this.NewCharacter.Race = 1;

            if (this.demon == true)
                this.NewCharacter.Demon = true;
            else
                this.NewCharacter.Demon = false;

            //replace chart with updated base stats
            ResetTraining();
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        private void MagianSelect_CheckedChanged(object sender, EventArgs e)
        {
            //magian base stats                      
            this.NewCharacter.Race = 2;

            if (this.demon == true)
                this.NewCharacter.Demon = true;
            else
                this.NewCharacter.Demon = false;

            //replace chart with updated base stats
            ResetTraining();
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        private void NecrianSelect_CheckedChanged(object sender, EventArgs e)
        {
            //necrain base stats
            this.NewCharacter.Race = 3;
            
            if (this.demon == true)
                this.NewCharacter.Demon = true;
            else
                this.NewCharacter.Demon = false;

            //replace chart with updated base stats           
            ResetTraining();
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        private void ArbiterSelect_CheckedChanged(object sender, EventArgs e)
        {
            //Arbiter base stats          
            this.NewCharacter.Race = 4;

            if (this.demon == true)
                this.NewCharacter.Demon = true;
            else
                this.NewCharacter.Demon = false;

            //replace chart with updated base stats
            ResetTraining();
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        private void AdeptSelect_CheckedChanged(object sender, EventArgs e)
        {
            //Adepts base stats     
            this.NewCharacter.Race = 5;

            if (this.demon == true)
                this.NewCharacter.Demon = true;
            else
                this.NewCharacter.Demon = false;

            //replace chart with updated base stats
            ResetTraining();
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        private void RiahaSelect_CheckedChanged(object sender, EventArgs e)
        {
            //Riaha base stats 
            //***************copy of adepts right now !!!************************
            this.NewCharacter.Race = 6;

            if (this.demon == true)
                this.NewCharacter.Demon = true;
            else
                this.NewCharacter.Demon = false;

            //replace chart with updated base stats
            ResetTraining();
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }

        private void CelestialSelect_CheckedChanged(object sender, EventArgs e)
        {
            //celestial base stats         
            NewCharacter.Race = 7;
            religion = false;
            ResetTraining();

            //if (this.ShifterCheck.Checked)
            //{ this.shifter = false; ShifterCheck.Checked = false; }
            if (this.DemonCheck.Checked)
            { this.demon = false; DemonCheck.Checked = false; }
            NewCharacter.demonicEnergy = 0;

            //replace chart with updated base stats
            this.NewCharacter.Level = Int32.Parse(LevelValue.Text);
            this.NewCharacter.CalculateStats();
            update_Charts();
        }
        //Buttons and Functions
        private void StatRoll_Click(object sender, EventArgs e)
        {
            //undo previous bonuses before adding new ones
            if (this.NewCharacter.StatRoll == true)
            {
                this.NewCharacter.Constitution -= this.bStrength;
                this.NewCharacter.Skill -= this.bSkill;
                this.NewCharacter.Resistence -= this.bResistence;
                this.NewCharacter.intelligence -= this.bintelliegence;
                this.NewCharacter.weaponArts -= this.bSkill * 5;
                this.NewCharacter.combatArts -= this.bSkill * 5;
                this.NewCharacter.Tech -= this.bintelliegence * 5;
                this.NewCharacter.MageTech -= this.bintelliegence * 5;
            }
            //calculate new bonuses
            this.bStrength = rnd.Next(1, MAX_Strength +1);
            this.bSkill = rnd.Next(1, MAX_Skill +1);
            this.bResistence = rnd.Next(1, MAX_Resistence +1);
            this.bintelliegence = rnd.Next(1, MAX_intelligence +1);
            //update labels
            this.StrengthDisplay.Text = this.bStrength.ToString();
            this.SkillDisplay.Text = this.bSkill.ToString();
            this.ResistenceDisplay.Text = this.bResistence.ToString();
            this.IntelligenceDisplay.Text = this.bintelliegence.ToString();
            //Increase Stats
            this.NewCharacter.AddStatRoll(this.bintelliegence, this.bSkill, this.bStrength, this.bResistence);
            this.NewCharacter.StatRoll = true;
            
            StatChart.Series.Clear();
            EnergyChart.Series.Clear();
            SkillChart.Series.Clear();
            fillCharts();
        }    
        
        private void Finish_Click(object sender, EventArgs e)
        {
            if (!NewCharacter.StatRoll || !(NewCharacter.Race > 0) || String.IsNullOrEmpty(NameDisplay.Text) || String.IsNullOrWhiteSpace(NameDisplay.Text))
                MessageBox.Show("Please select Race, add Manna Roll, add Stat Roll, and create a name before finalization.");
            else if(ViewerMode)
            {                
                this.DialogResult = DialogResult.OK;
                this.NewCharacter.Name = NameDisplay.Text;
                this.NewCharacter.Tag = TagDisplay.Text;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                //this.NewCharacter.Age = Age;
                this.NewCharacter.Name = NameDisplay.Text;
                this.NewCharacter.Tag = TagDisplay.Text;
                string[] template = File.ReadAllLines(path);
                int x = 0;

                // ***************** W A R N I N G !   C H A R A C T E R S   A R E   O V E R W R I T T E N    W A R N I N G ! ***********************//
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Characters\\" + NewCharacter.Name + ".txt"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\Characters\\" + NewCharacter.Name + ".txt");

                if (NewCharacter.Age > 100)//final age difficulty check
                    NewCharacter.Difficulty++;

                    using (TextWriter writer = File.CreateText(Directory.GetCurrentDirectory() + "\\Characters\\" + NewCharacter.Name + ".txt"))
                {
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Level.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Tag);
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Race.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Difficulty.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Age.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Constitution.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Resistence.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Skill.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.intelligence.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Tech.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.MageTech.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.combatArts.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.weaponArts.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.mannaTraining.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.mannaBonus.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.LifeBonus.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Religion.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;                    
                    writer.WriteLine(NewCharacter.Demon.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.dimensional_drifter.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    //turn training into one line of text
                    string training = "";
                    foreach (string s in NewCharacter.Training)
                        training += s + ",";
                    writer.WriteLine(training);
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.attribute.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Dark.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Light.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.Evil.ToString());
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.WriteLine(NewCharacter.info);
                    writer.WriteLine(template[x]);
                    x += 2;
                    writer.Close();
                }
                this.Close();
            }
        }

        private void LevelUp_Click(object sender, EventArgs e)
        {
            if (NewCharacter.Level < 100)
            {
                NewCharacter.Level++;

                if(NewCharacter.Level%2==0)
                {
                    NewCharacter.bodyEnergy++;
                    NewCharacter.mentalEnergy++;
                    NewCharacter.memoryEnergy++;
                    NewCharacter.spiritualEnergy++;
                }              
                
                if (NewCharacter.Demon)
                    NewCharacter.demonicEnergy = NewCharacter.Level / 2;
                LevelValue.Text = NewCharacter.Level.ToString();

                StatChart.Series.Clear();
                StatChart.Series.Add("Stat");
                StatChart.ChartAreas[0].AxisY.Maximum = 10;
                StatChart.ChartAreas[0].AxisY.Minimum = 0;
                StatChart.ChartAreas[0].AxisX.Maximum = 4;
                StatChart.ChartAreas[0].AxisX.Minimum = 0;
                StatChart.Series[0].Color = Color.Red;

                SkillChart.Series.Clear();
                SkillChart.Series.Add("Skill");
                SkillChart.ChartAreas[0].AxisY.Maximum = 100;
                SkillChart.ChartAreas[0].AxisX.Maximum = 4;
                SkillChart.ChartAreas[0].AxisY.Minimum = 0;
                SkillChart.ChartAreas[0].AxisY.Minimum = 0;
                SkillChart.Series[0].Color = Color.Orange;

                EnergyChart.Series.Clear();
                EnergyChart.Series.Add("Energy");
                EnergyChart.ChartAreas[0].AxisY.Maximum = 100;
                EnergyChart.ChartAreas[0].AxisY.Minimum = 0;
                EnergyChart.ChartAreas[0].AxisX.Maximum = 8;
                EnergyChart.ChartAreas[0].AxisX.Minimum = 0;
                EnergyChart.Series[0].Color = Color.Lime;

                StatChart.Series["Stat"].Points.AddXY("Constitution", NewCharacter.Constitution);
                StatChart.Series["Stat"].Points.AddXY("Resistance", NewCharacter.Resistence);
                StatChart.Series["Stat"].Points.AddXY("Skill", NewCharacter.Skill);
                StatChart.Series["Stat"].Points.AddXY("Intelligence", NewCharacter.intelligence);

                SkillChart.Series["Skill"].Points.AddXY("Weapon Arts", NewCharacter.weaponArts);
                SkillChart.Series["Skill"].Points.AddXY("Combat Arts", NewCharacter.combatArts);
                SkillChart.Series["Skill"].Points.AddXY("Tech", NewCharacter.Tech);
                SkillChart.Series["Skill"].Points.AddXY("Mage Tech", NewCharacter.MageTech);

                EnergyChart.Series["Energy"].Points.AddXY("Life-Force", NewCharacter.Constitution * 5 + NewCharacter.Level / 2);
                EnergyChart.Series["Energy"].Points.AddXY("Manna", NewCharacter.mannaTraining);
                EnergyChart.Series["Energy"].Points.AddXY("Mental", NewCharacter.mentalEnergy);
                EnergyChart.Series["Energy"].Points.AddXY("Body", NewCharacter.bodyEnergy);
                EnergyChart.Series["Energy"].Points.AddXY("Spiritual", NewCharacter.spiritualEnergy);
                EnergyChart.Series["Energy"].Points.AddXY("Memory", NewCharacter.memoryEnergy);
                EnergyChart.Series["Energy"].Points.AddXY("Demonic", NewCharacter.demonicEnergy);
            }
        }//level up button disabled

        private void ResetLabels()
        {
            this.StrengthDisplay.Clear();
            this.SkillDisplay.Clear();
            this.ResistenceDisplay.Clear();
            this.IntelligenceDisplay.Clear(); 
            //clear stat and manna labels
            switch (this.NewCharacter.Race)
            {
                case 1: //Ciaha
                    this.MAX_intelligence = 4;
                    this.MAX_Resistence = 4;
                    this.MAX_Strength = 6;
                    this.MAX_Skill = 4;

                    this.mStrengthLabel.Text = "(6)MAX";
                    this.mSkillLabel.Text = "(4)MAX";
                    this.mResistenceLabel.Text = "(4)MAX";
                    this.mIntelligenceLabel.Text = "(4)MAX";
                    break;
                case 2: //Magian
                    this.MAX_intelligence = 6;
                    this.MAX_Resistence = 4;
                    this.MAX_Strength = 4;
                    this.MAX_Skill = 4;

                    this.mStrengthLabel.Text = "(4)MAX";
                    this.mSkillLabel.Text = "(4)MAX";
                    this.mResistenceLabel.Text = "(4)MAX";
                    this.mIntelligenceLabel.Text = "(6)MAX";
                    break;
                case 3: //Necrian
                    this.MAX_intelligence = 4;
                    this.MAX_Resistence = 6;
                    this.MAX_Strength = 4;
                    this.MAX_Skill = 4;

                    this.mStrengthLabel.Text = "(4)MAX";
                    this.mSkillLabel.Text = "(4)MAX";
                    this.mResistenceLabel.Text = "(6)MAX";
                    this.mIntelligenceLabel.Text = "(4)MAX";
                    break;
                case 4: //Arbiter
                    this.MAX_intelligence = 6;
                    this.MAX_Resistence = 6;
                    this.MAX_Strength = 6;
                    this.MAX_Skill = 6;

                    this.mStrengthLabel.Text = "(6)MAX";
                    this.mSkillLabel.Text = "(6)MAX";
                    this.mResistenceLabel.Text = "(6)MAX";
                    this.mIntelligenceLabel.Text = "(6)MAX";
                    break;
                case 5: //Adept
                    this.MAX_intelligence = 4;
                    this.MAX_Resistence = 4;
                    this.MAX_Strength = 4;
                    this.MAX_Skill = 6;

                    this.mStrengthLabel.Text = "(4)MAX";
                    this.mSkillLabel.Text = "(6)MAX";
                    this.mResistenceLabel.Text = "(4)MAX";
                    this.mIntelligenceLabel.Text = "(4)MAX";
                    break;
                case 6: //Riaha
                    this.MAX_intelligence = 2;
                    this.MAX_Resistence = 2;
                    this.MAX_Strength = 2;
                    this.MAX_Skill = 2;

                    this.mStrengthLabel.Text = "(2)MAX";
                    this.mSkillLabel.Text = "(2)MAX";
                    this.mResistenceLabel.Text = "(2)MAX";
                    this.mIntelligenceLabel.Text = "(2)MAX";
                    break;
                case 7: //Celestial
                    this.MAX_intelligence = 2;
                    this.MAX_Resistence = 2;
                    this.MAX_Strength = 2;
                    this.MAX_Skill = 2;

                    this.mStrengthLabel.Text = "(2)MAX";
                    this.mSkillLabel.Text = "(2)MAX";
                    this.mResistenceLabel.Text = "(2)MAX";
                    this.mIntelligenceLabel.Text = "(2)MAX";
                    break;
            }
            //clear training checks
           
        }

        private void ResetTraining()
        {
            demon = false;
            if (NewCharacter.Race == 7)
                Age = 0;
            else
                Age = 20;
            NewCharacter.Age = Age;
            NewCharacter.Training.Clear();
            raceSelect = true;//prevent any of the following events from running
            None.Checked = true;
            C_Train.Checked = false;
            A_Train.Checked = false;
            M_Train.Checked = false;
            Ar_Train.Checked = false;
            Alchemy.Checked = false;
            Sorcery.Checked = false;
            Ghosting.Checked = false;
            DemonCheck.Checked = false;
            raceSelect = false;//resume normal function

        }

        private void update_Charts()
        {
            ResetLabels();
            NewCharacter.Level = Convert.ToInt32(LevelValue.Text);
            StatChart.Series.Clear();
            SkillChart.Series.Clear();
            EnergyChart.Series.Clear();
            adjust_Age();
            fillCharts();
        }

        private void adjust_Age()
        {
            NewCharacter.Age = Age;
            if (demon)
                NewCharacter.Age = (int)(NewCharacter.Age * 1.5);
            if (religion)
                NewCharacter.Age = (int)(NewCharacter.Age * 1.2);
            
            DifficultyChart.Series.Clear();

            DifficultyChart.Series.Add("Difficulty");
            DifficultyChart.ChartAreas[0].AxisY.Maximum = 1;
            DifficultyChart.ChartAreas[0].AxisY.Minimum = 0;
            DifficultyChart.ChartAreas[0].AxisX.Maximum = 5;
            DifficultyChart.ChartAreas[0].AxisX.Minimum = 1;
            DifficultyChart.Series[0].Color = Color.Purple;
            DifficultyChart.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            DifficultyChart.Series["Difficulty"]["PointWidth"] = "1";

            Age_label.Text = "Age: " + NewCharacter.Age.ToString() + "/100";
            if (NewCharacter.Age > 100)
            {
                //adjust difficulty display without incrementing it avoid increasing it everytime extra bonus is added over 100 age
                //over 100 difficult curve is only supposed to added once
                AgeBar.Value = 100;
                for (int i = 0; i < NewCharacter.Difficulty+1; i++)
                    DifficultyChart.Series["Difficulty"].Points.AddXY("", 1);
            }
            else
            {
                AgeBar.Value = NewCharacter.Age;
                for (int i = 0; i < NewCharacter.Difficulty; i++)
                    DifficultyChart.Series["Difficulty"].Points.AddXY("", 1);
            }

        }

        private void LevelValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }//level up button disabled
        //Mouse-over descriptions
        private void CiahaSelect_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Ciaha - A race born to a young system and homeworld wrought with natural devistation. " +
                "\r\n" + "\r\n" +
                "Hiding from the for hundreds of years from meteor storms that leveled mountains" +
                " and posioned the atmospshere, the race was eventually united towards the common goal of mere survival." +
                " The celestials gifted them with manna and they harnessed it to fight thier way back to the surface, nearly blinded by the hundreds of years of subterraining mining." +
                " They mastered thier arts to the purpose of thwarting impending dangers from orbit that would threaten to send back underground." +
                " But, as a testament to thier perserverence, they emerged to the intragalactic stage with great power and armaments crafted from rare earth to which no other race can replicate" +
                " and all of which has been lost with the aftermath of the Celestial Wars." +
                "\r\n" + "\r\n" +
                "Home World: Ciaha\r\n" +
                "Specialties: Strength, Body energy, Weapon Arts";                
        }

        private void MagianSelect_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Magians - A race of compassionate rationalists native to an elder system whose star has been kept alive artifically by only the breifest glimpse of their magical prowess. " +
                "\r\n" + "\r\n" +
                "Able to reach Global Unification early in thier race's history, before contentenal drift was divided their ilk to widely." +
                " With a tremendous and rare display of diplomacy and philosophy, their kingdom quickly yielded power to democracy once the world had settled and its provinces became a part of a single nation." +
                " The celestials were quick to admire and reward this effort with the gift of manna and to which the Magians were equally pledged to use to bolster thier collective race's prosperity." +
                " Soon, they enter the many eras of Magic to which they alone are the true guardians of." +
                " Held closely in Royal archives where thier legacy is pushed ever onward in the center of thier utopia with limitelsss resources." +
                "They serves as the Galaxy's greatest race and have contributed more to the celestials and thier other children than any other." +                
                "\r\n" + "\r\n" +
                "Home World: Magi\r\n" +
                "Specialitise: Intelligence, Magic, Mage Arts";
        }

        private void NecrianSelect_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Necirans - The first sentient race of the galaxy. " +
                "\r\n" + "\r\n" +
                "They have lived since very early periods in the universe's existence and were met in prehistory by the celestials with a proclamation: " +
                "Become the shepards to the departed lost and keepers of dead in acceptence our divine grace. " +
                "The Necrians are the reapers of immortal souls and the keepers of all the secrets of the dead and hold power over them as members by birth of the Covenant of the Void. " +
                "They are isolationists who are in place by thier close releationship with the celestials whom they unquestioningly serve. " +
                "They have profound understanding of Manna and all of its derivatives but because of thier conservative ideologies lack the commonplace to practice these arts of invent innovation in a theocracy that does not fear death. " +
                "\r\n" + "\r\n" +
                "Home World: Necria\r\n" +
                "Specialites: Resistence, Necroforce";
        }

        private void ArbiterSelect_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Arbitars - The arbitars were the first and only race to be interefered with before the advent of its own destruction in an attempt to save their potential. " +
                "\r\n" + "\r\n" +
                "The celestials appeared before the race had reached Global Unification and instead helped to try to foster thier relations in an effort of preserve thier lives and hopefully be worthy of the gift of manna." +
                " The Arbitars worked closely with the celestials to restore thier homeworld, once riddled with the residue of war after having been forced to relocate and live on a their nearest sister planets. " +
                " The Arbitars were eternally gratefule for the aid of the celestials and the gift of manna " +
                "and thus were all the more lost when they left, giving the Arbitars the task of proving once more that they can live up to thes standard of Global Unification without their interference. " +
                "An thus began the Arbitan Empire, an expansionist authoritarian regime that sought to find blasphemers across the cosmos and assimilate them in the same way the celestials had correced their behavior in the past. " +
                "They have since had their blood diluted and culture left behind along with their hidden potential and hold few remarkable proficiencies in the pursuit of the fullfilment of thier pledge. " +
                "\r\n" + "\r\n" +
                "Home World: Contineo Nova\r\n" +
                "Specialies: Mental Energy, Tech";
        }

        private void AdeptSelect_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Adepts - The race of mystics. " +
                "\r\n" + "\r\n" +
                "The adepts, are were the youngest race to recieve the gift of manna, a consequence of an early adoption of low tolerance for bloodshed, even in thier wars. " +
                "Despite this, they value battle and combat more than any other race and have use the discipline of thier most determined fighters to lead thier meritocracy. " +
                "But, as a cost of thier youth, the Adepts genrally see technology as fey and unapproachable and though they admire closely the combat prowess of other races, " +
                "they distaste the weapons of death that rob battle of its honor and discipline to the mind. " +
                "Still, the desire to fight is insatiable and the adepts openly welcome commerce and hold tourneys in the unique terrain of thier planet full of residual products of thier vast command of the spirit. " +
                "\r\n" + "\r\n" +
                "Home World: Adept\r\n" +
                "Specialties: Skill, Spiritual Energy, Combat Arts.";
        }

        private void CelestialSelect_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Celestials - The gods of the realm that command respect from all. " +
                "\r\n" + "\r\n" +
                "They commune with the will of Cacealeos and bestow the power of manna on those they see as worthy in thier lives spent amongst the still growing race." +
                " They omiscient understanding of manna and its applications to which they rejoice in seeing utilized by the races they help to foster as is aligned with thier ultimate goal. " +
                "The celestials seek to see the will of Cacealeos, and perserve the balance hidden in its nature that will determine the fate of the universe. " +
                "\r\n" + "\r\n" +
                "Home World: Celestial system\r\n" +
                "Specialties: All";
        }

        private void ShifterCheck_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Shifter Breed - Those who have enacted the covenant of the primordial. " +
                "\r\n" + "\r\n" +
                "They have the ability shift thier forms into those of an animal they have sacrificed. " +
                "Those of the primodial covenant gain +1 to all stats and the ability to shift form in and out of battle. " +
                "But beware, this advantage comes at the price of increased difficulty." +
                "\r\n" + "\r\n" +
                "Primal covenant\r\n" +
                "+1 to all stats\r\n" +
                "+1 Difficulty";
        }

        private void DemonCheck_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Demon Half Breed - Those who have either been cursed or willingly welcomed demonic essence into themselves. " +
                "\r\n" + "\r\n" +
                "Half Breeds can channel demonic energy for sheer strength and power of the purpose of resistence to further curses and  partial immunity to demonic influence. " +
                "Those cursed with demonic blood aquire +1 to all stats and the ability to channel demonic energy and possibly absorb demons." +
                "But beware, this advantage comes at the price of increased difficulty" +
                "\r\n" + "\r\n" +
                "Choose covenant\r\n" +
                "+1 to all stats\r\n" +
                "+1 Difficulty";
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {//Strength
            this.Description.Text = "Base Strength determines weapon and equipment requirements";
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {//Resistence
            this.Description.Text = "Base Resistence determines resilience to magic effects such as manna disruption, mind control, possession, curses,  instant death, etc.";
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {//Skill
            this.Description.Text = "Base Skill determines weapon and technique requirements as well as establish weapon and combat arts in combination to race. " +
                "In additon, skill determines growth rate for learning techniques.";
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {//Intelligence
            this.Description.Text = "Base Intelligence determines equipment and spell requirements as well as establish Tech and Mage tech in combination to race. " +
                "In addition, Intelligence determines growth rate for learning spells.";
        }

        private void StatRoll_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Character stats do not change after making characters or growing levels they are generally permanant with few exceptions. " +
                "Skill and Intelligence help decide what the Character Techniques are as well. " +
                "These also do not generally change after character creation but are also more loose. Finally, most stats are used often during in-game checks.";              
                 }
               
        private void C_Train_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Ciahian Training -" +
                "\r\nThe main tools of ciaha include their weapon disciplines, their rare craftsmenship, and their use of body energy tempered by their large stature." +
                "\r\nCiahian Training adds: " +
                "\r\n\r\n+1 Constitution" +
                "\r\n\r\n+15 weapon skill" +
                "\r\n\r\n+15 body energy" +
                "\r\n\r\n+1 rare weapon or style" +
                "\r\n\r\nUnlocks unique body techniques: Hypermind etc..." +
                "\r\n+15 manna Training" +
                "\r\n\r\n+20 Age";
        }

        private void A_Train_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Adept Training -" +
                "\r\nAdepts employ close combat facilitated by their speed as a property of their avid use of spiritual energy." +
                "Naturally, this leads them to excell in fighting styles of all kind and is further supported by their very culture." +
                "\r\nAdept Training adds: " +
                "\r\n\r\n+1 Skill" +
                "\r\n\r\n+15 Combat skill" +
                "\r\n\r\n+15 Spiritual energy" +
                "\r\n\r\n+1 spiritual familiar" +
                "\r\n\r\nUnlocks unique spiritual techniques: Spiritualization etc..." +
                "\r\n+15 manna Training" +
                "\r\n\r\n+20 Age";
        }

        private void M_Train_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Magian Training -" +
               "\r\nMagi trains mages of all kinds and is the home of the well stocked achieved fearturing spells and instructors of the highest potency." +
               "But before concentration into higher magics, the magians have their students undergo signature mental training to better prepare themselves for the strain of comprehension required for the most commanding spells." +
               "\r\nMagian Training adds: " +
               "\r\n\r\n+1 Int" +
               "\r\n\r\n+15 Mage Tech" +
               "\r\n\r\n+3 default spell abilities" +
               "\r\n\r\nUnlocks unique spell abilities: Hyper spell etc..." +
               "\r\n+20 manna Training" +
               "\r\n\r\n+20 Age";
        }

        private void Ar_Train_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Aritar Training -" +
               "\r\nArbitain training includes multi-focused mental curriculum that centers itself towards negotiations and technological insight." +
               "\r\nMagian Training adds: " +
               "\r\n\r\n+15 mental energy" +
               "\r\n\r\n+15 Tech" +
               "\r\n\r\n+1 small spacecraft or sanctuary" +
               "\r\n+10 manna Training" +
               "\r\n\r\n+10 Age";
        }

        private void Transcendence_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Transcendence is the phenomenom of being able to percieve yourself from the view point of your spiritual avatar in Cacealeos that transpires only when you have succumbed to death." +
                "However, this naturally posses a pratical problem for those who are not immediately revived." +
                "\r\n\r\nTranscendence has the passive effect of elivating the conciousness and enables better precision for high precision techniques. (Ghosting, Sorcery, Alchemy)" +
                "\r\n\r\nNecrians start with Transcendence by default." +
                "Age + 10;";
        }

        private void Alchemy_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Alchemy is the highest magic art in Cacealeos and entails the process of manipulating celestial character with which the universal is assembled from and changing values to alter reality directly." +
                "\r\n\r\nAlchemy branches are:" +
                "\r\n\r\nCorporeal - Alteration of baryonic matter in adjusted quantities and general shapes and densities." +
                "\r\n\r\nMetaphysical - Alteration of non-baryonic particles, including manna, and the general state of entropy and interia." +
                "\r\n\r\nStructured - Detailed Alterations of minute baryonic matter designs stipulating the generation of organic material, biogenesis, and conciousness." +
                "\r\n\r\nDimensional - Detailed Alterations of minute non - baryonic properties of the universe gravity, time-space, light, etc." +
                "\r\n+25 Manna Training" +
                "\r\n+40 Age";
        }

        private void Sorcery_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Sorcery is ultimate form of Macro manna structure control and is used most commonly for mind control and subjugation and is mostly commonly used in conjuction with seals." +
               "\r\n\r\nSorcery braches are:" +
               "\r\n\r\nPossesion - Attempted control over energy exchages and responsiveness of receptors." +
               "\r\n\r\nDomination - Attempted exclusive control of manna structures and integrated disruption of conjuctions with it." +
               "\r\n\r\nAssimilation - Attempted permanent changes to controlled manna structures, usually with the intention of subjugation towards goals of the caster. Must be purified to correct." +
               "\r\n\r\nAnimation - Animation of non receptive structures via the implementation often fully fledge dummy conciousnesses that have either been previously Assimilated or are suceptable to it."+
               "\r\n+20 Manna Training" +
               "\r\n+20 Age";
        }

        private void Ghosting_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Ghosting is ultimate form of Mirco manna structure control and is used most commonly for iluusion and Phasing" +
               "\r\n\r\nGhosting braches are:" +
               "\r\n\r\nIllusion - Imposition of tailored sensory information of any type for practically and length." +
               "\r\n\r\nDisruption - Imposition of injected manna into isolated energy structurse to temporarly alter properties that scales with the target planes of Cacealeos like mass, transparency, physcial form etc." +
               "\r\n\r\nCorruption - Imposition of permanent changes to energy structures that change the alters manner in which Cacealeos fundementally interacts with it to creat abstrat effects. " +
               "Polymorphism, self destruction, metaphyscial composition etc."+
                "\r\n+20 Manna Training" +
               "\r\n+20 Age";
        }

        private void Demonic_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Demonic is process of amalgamation of demonic essence with other energies to create often more powerful and chaotic versions of others and techniques." +
              "\r\n\r\nDemonic magic is not innate to mortals and all demonic magic used exhuasts demonic essence reserves of the caster and always places them at risk.";
        }

        private void Ether_Attunement_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Ether Attunement enables the use of Ether by characters. " +
                "Ether is a more dense form of Manna and allows for higher stats and is a prestigous hallmark for all warriors. " +
                "\r\nManna Training +40" +
                "\r\nAge +30";
        }

        private void Elementalism_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Elementalism is achieved through service to one or more of the four elemental gods: Fire, Water, Earth, Wind." +
              "Upon choosing an of the elemental god there are three tiers of religious achievement that enable more alloted power. " +
              "\r\n\r\nFledgeling: basic animation and manipulation powers with slight resistence." +
              "\r\n\r\nAcolyte: profound control and immunity as well as the ability to create elementals and used the Tapped form of the element." +
              "\r\n\r\nMaster: emaculate control of total physical embodiment of the element as well as the recepient of passive stat boosts and equiped with more leverage when enacting covenants." +
              "\r\n\r\nElement Type Tapped potential: \r\nFire-Lightning\r\nWater-Ice\r\nEarth-Gravity\r\nWind-Acceleration" +
              "\r\n\r\n\r\n\r\nONLY ONE RELIGION MAY BE CHOSEN AT A TIME";
        }

        private void Prayer_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Prayer is power granted by those habitualy loyal to the celestials." +
                "Powers affored to the devote include the ability to ward off demons, purfiy manna disruption, exercise demons and curses, and offer protection and respite from danger." +
                "\r\n\r\n\r\n\r\nONLY ONE RELIGION MAY BE CHOSEN AT A TIME";
        }

        private void Arcane_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Arcane is power granted by those willing to make sacrifices on offer by the Overseer of hell in exchange for ultimate damnation." +
               "Rewards for these accords scale with the sacrifice and include demonic power, performing MEPHISTO, and more generally to cast curses, fausts, and tributes." +
               "\r\n\r\n\r\n\r\nONLY ONE RELIGION MAY BE CHOSEN AT A TIME";
        }

        private void None_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "All religions come at the cost of 20% extra age. Remember, age over a hundred adds extra difficulty and might make the character unsually for certain quests." +
              "\r\n\r\n\r\n\r\nONLY ONE RELIGION MAY BE CHOSEN AT A TIME";
        }

        private void AgeBar_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "All characters start with a default age of 30. Adding extra training or perks and covenants adds extra age. " +
                "Age is directly related to difficulty your character adds to the quest difficulty mode.";
        }      

        private void SkillChart_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Weapon Arts: " + NewCharacter.weaponArts.ToString() + "\r\nThe ability to use different weapons at different skill levels and how well you fight against other with weapons.\r\n\r\n" +
                "Combat Arts: " + NewCharacter.combatArts.ToString() + "\r\nThe ability to use different techniques and how well you perform them in combat.\r\n\r\n" +
                "Tech:" + NewCharacter.Tech.ToString() + "\r\nHow familiar your character is with technology and the ability to augment/repair/utilize\r\n\r\n" +
                "Mage " + NewCharacter.MageTech.ToString() + "\r\nTech: How familiar your character is with Mage tech and magic. " +
                "Affects the ability to cast spells find weaknesses in other spells, produce counter spells, and augment/repair/utilize magic devices.";
        }

        private void StatChart_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Constitution: " + NewCharacter.Constitution.ToString() + "\r\nConstitution determines if you meet the requirements to effecively wield equipment related to combat and increases base unarmed (Combat Arts) damage: 5 + CONSTITUTION.\r\n" +
                "Constitution also determines maximum total base life-force. Every point of Constitution give an additional 10%." +
                "\r\nIt is not usually used for in-game checks. " +
                "\r\n\r\nResistence: " + NewCharacter.Resistence.ToString() + "\r\nResistence determines the sturdyness of the character and their susceptibility to Manna disruption, being possesed, having spells canceled, or mind put under illusions." +
                "\r\nIt is commonly used for in-game checks." +
                "\r\n\r\nSkill: " + NewCharacter.Skill.ToString() + "\r\nSkill determines if you meet the requirements to effecively energy techniques. It also determines evasion and accuracy as well as crit bonues and mastery rates." +
                "\r\nIt is commonly used for in-game checks." +
                "\r\n\r\nIntelligence: " + NewCharacter.intelligence.ToString() + "\r\nIntelligence determines if you meet the requirements to effecively master and cast magic as well as use magic related equipment." +
                "Additionally it determines how many spells you character can use and their mastery rate." +
                "\r\nIt is quite often used for in-game checks.";

        }

        private void EnergyChart_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Manna Training: " + NewCharacter.mannaTraining.ToString() +
                "\r\nManna: " + (NewCharacter.mannaTraining + NewCharacter.Level + 100).ToString() +
                "\r\nManna Bonus: " + (NewCharacter.mannaBonus) + "%" +
                "\r\nManna is the prime energy from which all others derive. It is used as the catalyst for all manna composities as well as the fuel for spells and most energy based techniques." +
                "Battles will hinge on how much manna the party can use and handle. Manna Training (MAX IS 100 )affects total maximum manna pool and is calulated by: \r\n\r\n" +
                "(Level + Training + 100) x Manna Bonus (From Enchantments up to 50%)" +

                "\r\n\r\nLife Force: " + (NewCharacter.Constitution*10 + NewCharacter.Level + 100).ToString() +
                "\r\nLife Force Bonus: " + (NewCharacter.LifeBonus) + "%" +
                "\r\nLife Force serves as your normal health pool and is used to take damage without experiencing normal death. In Generation, every 'human' character has three health pools." +
                "One for Normal health and Death, one for spirit health and death, and one for soul health and death." +
                "These all have differing utility and consequences depending on the character using them and thier opponents expect for Soul death. Soul death never changes and is 'perma-death' that supersedes all other effects." +
                "Spirit base value is 200, Soul base value is 300, and Life-Force is calculated by: \r\n\r\n" +
                "(Level + Constitution x 10 + 100)x Life Bonus (From Enchantments up to 50%)" +

                "\r\n\r\nBody Energy: " + NewCharacter.bodyEnergy.ToString() + 
                "\r\nBody Energy is a manna-based energy form in relation to the phsical fitness of a character. The more body mass the more body energy they can muster." +
                "Body energy is inherently unstable and causes reactions in the form of explosions and is difficulty condense. It is hot to the touch and emits great amounts of yellow light." +

                "\r\n\r\nMental Energy: " + NewCharacter.mentalEnergy.ToString() + 
                "\r\nMental Energy is a manna-based energy formed in relation to the mental intellect and willpower of a character. The more willpower demonstrated by the user, the more mental energy they can muster." +
                "Mental energy is inherently unstable and will fade away quickly after use. It doesnt emit much heat or force and is difficult to condense and therefore hard to see its otherwise magenta hue."+

                "\r\n\r\nSpiritual Energy: " + NewCharacter.spiritualEnergy.ToString() + 
                "\r\nSpirit Energy is a manna-based energy formed in relation to the spiritual sentience of a character. The more spiritual the user, the more spiritual energy they can muster." +
                "Spiritual energy is inherently very stable and will not fade away soon after use. It emits little heat but is brightly turqoise and is easy to condense and form shapes with." +
                                         
                "\r\n\r\nMemory Energy: " + NewCharacter.memoryEnergy.ToString() + 
                "\r\nMemory Energy is a manna-based energy formed in relation to the mental intellect and willpower of a character. The more willpower demonstrated by the user, the more mental energy they can muster." +
                "Memory energy is inherently stable and will fade away normally after use. It doesnt emit much heat but packs the most force of the manna based energies and is easy to condense and concentrates into its white light.";
        }

        private void DifficultyChart_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Difficulty: " + NewCharacter.Difficulty.ToString() + "\r\nAlmost every event in every quest has different difficulty elements that take the form of additional enemies, traps, checks, side quests, NPC's, treasure, etc." +
                "\r\n\r\nAt party difficulty total of 6 and up, the game will enter hard mode in which you will encounter difficult threats." +
                "\r\n\r\nAt party difficulty total of 11 and up, the game will enter Game Master Mode in which you will threats designed to put even experienced game masters to the test." +
                "\r\n\r\nNaturally, total difficulty is determined by party size and character aspects. All character are worth 1 difficulty point to a max party size of 5 except CELESTIALS, which are worth:  5 EACH" +
                "\r\nLastly, difficulty per character can be increased by selecting the shifter or demon aspects which increase difficulty by 1 and 2 respectively for that character and are not available to celestial characters." +
                "\r\n\r\n\r\n\r\nBE ADVISED: RARE DIFFICULTY MODIFIERS EXIST AS IN-GAME EVENTS THAT CAN PUSH A PARTY BEYOND OR BELOW AN INTENDED THRESHOLD.";
        }

        private void MannaBar_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Total Manna bonus meant to reflect buffs and adjustments from equipment." +
                "\r\nMAXIMUM MANNA BONUS IS 50%, EVEN IF MANNA BONUS EXCEEDS 100." +
                "\r\nMAXIMUM MANNA TRAINING IS 100, EVEN IF MANNA TRAINING EXCEEDS 100";
        }

        private void LifeBar_MouseHover(object sender, EventArgs e)
        {
            this.Description.Text = "Total life bonus meant to reflect buffs and adjustments from equipment." +
                "\r\nMAXIMUM LIFE BONUS IS 50%, EVEN IF LIFE BONUS EXCEEDS 100.";
        }
        //Religions
        private void Elementalism_CheckedChanged(object sender, EventArgs e)
        {
            if (NewCharacter.Race == 7)
                return;
            NewCharacter.Religion = 1;
            religion = true;
            adjust_Age();
        }

        private void Prayer_CheckedChanged(object sender, EventArgs e)
        {
            if (NewCharacter.Race == 7)
                return;
            NewCharacter.Religion = 2;
            religion = true;
            adjust_Age();
        }

        private void Arcane_CheckedChanged(object sender, EventArgs e)
        {
            if (NewCharacter.Race == 7)
                return;
            NewCharacter.Religion = 3;
            religion = true;
            adjust_Age();
        }

        private void None_CheckedChanged(object sender, EventArgs e)
        {
            if (!raceSelect)
            {
                NewCharacter.Religion = 0;
                religion = false;
                adjust_Age();
            }
        }
        //Forbidden Magics
        private void Alchemy_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (Alchemy.Checked)
                {
                    Age += 40;
                    NewCharacter.Training.Add("Alchemy");
                    NewCharacter.mannaTraining += 25;
                }
                else if (!Alchemy.Checked)
                {
                    Age -= 40;
                    NewCharacter.Training.Remove("Alchemy");
                    NewCharacter.mannaTraining -= 25;
                }
                update_Charts();
            }
        }

        private void Sorcery_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (Sorcery.Checked)
                {
                    Age += 20;
                    NewCharacter.Training.Add("Sorcery");
                    NewCharacter.mannaTraining += 20;
                }
                else if (!Sorcery.Checked)
                {
                    Age -= 20;
                    NewCharacter.Training.Remove("Sorcery");
                    NewCharacter.mannaTraining -= 20;
                }
                update_Charts();
            }
        }

        private void Ghosting_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (Ghosting.Checked)
                {
                    Age += 20;
                    NewCharacter.Training.Add("Ghosting");
                    NewCharacter.mannaTraining += 20;
                }
                else if (!Ghosting.Checked)
                {
                    Age -= 20;
                    NewCharacter.Training.Remove("Ghosting");
                    NewCharacter.mannaTraining -= 20;
                }
                update_Charts();
            }
        }
        //Training
        private void Demonic_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && NewCharacter.Race != 7 && !raceSelect)
            {
                if (Demonic.Checked)
                {
                    Age += 20;
                    NewCharacter.Training.Add("Demonic");
                }
                else if (!Demonic.Checked)
                {
                    Age -= 20;
                    NewCharacter.Training.Remove("Demonic");
                }
                update_Charts();
            }
        }
       
        private void C_Train_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (C_Train.Checked)
                {
                    Age += 20;
                    NewCharacter.Constitution++;
                    NewCharacter.weaponArts += 15;
                    NewCharacter.bodyEnergy += 15;
                    NewCharacter.mannaTraining += 15;
                    NewCharacter.Training.Add("Ciaha");
                }
                else if(!C_Train.Checked)
                {
                    Age -= 20;
                    NewCharacter.Constitution--;
                    NewCharacter.weaponArts -= 15;
                    NewCharacter.bodyEnergy -= 15;
                    NewCharacter.mannaTraining -= 15;
                    NewCharacter.Training.Remove("Ciaha");
                }
                update_Charts();
            }
                
        }

        private void A_Train_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (A_Train.Checked)
                {
                    Age += 20;
                    NewCharacter.Skill++;
                    NewCharacter.combatArts += 15;
                    NewCharacter.spiritualEnergy += 15;
                    NewCharacter.mannaTraining += 15;
                    NewCharacter.Training.Add("Adept");
                }
                else if (!A_Train.Checked)
                {
                    Age -= 20;
                    NewCharacter.Skill--;
                    NewCharacter.combatArts -= 15;
                    NewCharacter.spiritualEnergy -= 15;
                    NewCharacter.mannaTraining -= 15;
                    NewCharacter.Training.Remove("Adept");
                }
                update_Charts();
            }
        }

        private void M_Train_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (M_Train.Checked)
                {
                    Age += 20;
                    NewCharacter.intelligence++;
                    NewCharacter.MageTech += 15;
                    NewCharacter.mannaTraining += 20;
                    NewCharacter.Training.Add("Magian");
                }
                else if (!A_Train.Checked)
                {
                    Age -= 20;
                    NewCharacter.intelligence--;
                    NewCharacter.MageTech -= 15;
                    NewCharacter.mannaTraining -= 20;
                    NewCharacter.Training.Remove("Magian");
                }
                update_Charts();
            }
        }

        private void Ar_Train_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && !raceSelect)
            {
                if (Ar_Train.Checked)
                {
                    Age += 20;
                    NewCharacter.Tech += 15;
                    NewCharacter.mentalEnergy += 15;
                    NewCharacter.mannaTraining += 10;
                    NewCharacter.Training.Add("Arbitian");
                }
                else if (!Ar_Train.Checked)
                {
                    Age -= 20;
                    NewCharacter.Tech -= 15;
                    NewCharacter.mentalEnergy -= 15;
                    NewCharacter.mannaTraining -= 10;
                    NewCharacter.Training.Remove("Arbitian");
                }
                update_Charts();
            }
        }

        private void Transcendence_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && NewCharacter.Race != 7 && NewCharacter.Race != 3 && !raceSelect)//make certain race is not necrian or celestial
            {
                if (Transcendence.Checked)
                {
                    Age += 10;
                    NewCharacter.Training.Add("Transcendence");
                }
                else if (!Transcendence.Checked)
                {
                    Age -= 10;
                    NewCharacter.Training.Remove("Transcendence");
                }
                adjust_Age();
            }
        }

        private void DemonCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.NewCharacter.Race < 7 && !raceSelect)
            {
                if (this.DemonCheck.Checked)
                {
                    this.demon = true;
                    this.NewCharacter.Demon = true;
                    SkillDisplay.Clear();
                    StrengthDisplay.Clear();
                    IntelligenceDisplay.Clear();
                    ResistenceDisplay.Clear();

                    this.NewCharacter.CalculateStats();
                    StatChart.Series.Clear();
                    SkillChart.Series.Clear();
                    EnergyChart.Series.Clear();
                    fillCharts();
                }
                else if (!this.DemonCheck.Checked)
                {
                    this.demon = false;
                    this.NewCharacter.Demon = false;
                    SkillDisplay.Clear();
                    StrengthDisplay.Clear();
                    IntelligenceDisplay.Clear();
                    ResistenceDisplay.Clear();

                    this.NewCharacter.CalculateStats();
                    StatChart.Series.Clear();
                    SkillChart.Series.Clear();
                    EnergyChart.Series.Clear();
                    fillCharts();
                }//END IF ELSE
                adjust_Age();
            }//END IF
        }//END FUNCTION       

        private void Ether_Attunement_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox) && NewCharacter.Race != 7 && NewCharacter.Race != 3 && !raceSelect)
            {
                if (Ether_Attunement.Checked)
                {
                    Age += 30;
                    NewCharacter.mannaTraining += 40;
                    NewCharacter.Training.Add("Ether Attunement");
                    NewCharacter.Ether = true;
                }
                else if (!Ether_Attunement.Checked)
                {
                    Age -= 30;
                    NewCharacter.mannaTraining -= 40;
                    NewCharacter.Training.Remove("Ether Attunement");
                    NewCharacter.Ether = false;
                }
            }
            adjust_Age();
        }

        private void MannaBar_Scroll(object sender, EventArgs e)
        {
            MannaBonus.Text = "Manna Bonus: " + MannaBar.Value.ToString() + "%";
            NewCharacter.mannaBonus = MannaBar.Value;
        }

        private void LifeBar_Scroll(object sender, EventArgs e)
        {
            LifeBonus.Text = "Life Bonus: " + LifeBar.Value.ToString() + "%";
            NewCharacter.LifeBonus = LifeBar.Value;
        }      
    }//END CLASS  

    //TO DO LIST:
    //covenants
    //Attributes
    //dimensional drifters
}
