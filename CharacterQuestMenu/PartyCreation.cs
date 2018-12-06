using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.Serialization;

namespace CharacterQuestMenu
{
    public partial class PartyCreation : Form
    {
        public List<Character> Party = new List<Character>();
        public List<Character> CharList = new List<Character>();
        public Party P = new Party();
        private GroupBox[] party_display = new GroupBox[MAX_PARTY_SIZE];
        private Chart[] display_Selection = new Chart[MAX_PARTY_SIZE];
        private static int MAX_PARTY_SIZE = 5;
        private static int MAX_LABEL_NUMBER = 17;
        //for adding new characters via "New" button
        private Character New = new Character();
        //for parsing data from character list into listview and back from partyview
        private string[] arr = new string[6];
        ListViewItem item;

        //directory for saving parties binary
        private string PartyPath = Directory.GetCurrentDirectory() + "\\Parties\\";
        private string path = Directory.GetCurrentDirectory() + "\\Characters\\";

        //constructor
        public PartyCreation()
        {
            InitializeComponent();                      
        }

        private void PartyList_Load(object sender, EventArgs e)
        {            
            party_display[0] = member0;
            party_display[1] = member1;
            party_display[2] = member2;
            party_display[3] = member3;
            party_display[4] = member4;
            display_Selection[0] = chart1;
            display_Selection[1] = chart2;
            display_Selection[2] = chart3;
            display_Selection[3] = chart4;
            display_Selection[4] = chart5;

            string[] characters = Directory.GetFiles(path);
            // Read the stream to a string that becomes file name
            foreach (string file in characters)
            {
                Character NEW_CHARACTER = new Character();
                //if (File.Exists(file))
                //{//only reads files
                int i = 1;
                //put file contents in string array
                string[] Character_Stats = File.ReadAllLines(file);

                NEW_CHARACTER.Name = Path.GetFileNameWithoutExtension(file);

                NEW_CHARACTER.Level = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Tag = Character_Stats[i];
                i += 2;
                NEW_CHARACTER.Race = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Difficulty = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Age = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Constitution = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Resistence = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Skill = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.intelligence = Convert.ToInt32(Character_Stats[i]);
                i += 2;               
                NEW_CHARACTER.Tech = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.MageTech = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.combatArts = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.weaponArts = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.mannaTraining = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.mannaBonus = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.LifeBonus = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Religion = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Demon = Convert.ToBoolean(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.dimensional_drifter = Convert.ToBoolean(Character_Stats[i]);
                i += 2;
                string[] training = Character_Stats[i].Split(',');
                foreach (string s in training)
                    NEW_CHARACTER.Training.Add(s);
                i += 2;               
                NEW_CHARACTER.attribute = Convert.ToBoolean(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Dark = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Light = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.Evil = Convert.ToInt32(Character_Stats[i]);
                i += 2;
                NEW_CHARACTER.info = (Character_Stats[i]);

                CharList.Add(NEW_CHARACTER);
            }
            update_List();
        }

        private void update_Party()
        {            
            int x = 0;         
            foreach (Character c in Party)
            {
                if (Party.Count() < 1)
                    Make_party.Enabled = false;
                else
                    Make_party.Enabled = true;

                party_display[x].Enabled = true;
                if (display_Selection[x].Series.IndexOf("S") == -1)
                {
                    display_Selection[x].Series.Add("S");
                    display_Selection[x].Titles.Add("T");
                    display_Selection[x].Series["S"].ChartType = SeriesChartType.Radar;
                }
                c.CalculateEnergy_party_only();
                c.PartySlot = x;
                party_display[x].Tag = c;                
                Energy_Labels_Default(party_display[x]);
                x++;
            }
            //for (x = 0; x > Party.Count && x <= MAX_PARTY_SIZE; x++)
            //    party_display[Party.Count].Enabled = false;
            PartyLogistics();
        }

        private void update_List()
        {
            CharacterView_List.Clear();
            CharacterView_List.View = View.Details;
            CharacterView_List.GridLines = true;
            CharacterView_List.FullRowSelect = true;

            CharacterView_List.Columns.Add("Name", 100);
            CharacterView_List.Columns.Add("Level", 50);            
            CharacterView_List.Columns.Add("Age", 50);
            CharacterView_List.Columns.Add("Race", 60);
            CharacterView_List.Columns.Add("Demon", 60);
            CharacterView_List.Columns.Add("Diff.", 50);

            foreach (Character c in CharList)
            {
                arr[0] = c.Name;
                arr[1] = c.Level.ToString();
                arr[2] = c.Age.ToString();

                switch (c.Race)
                {
                    case 1:
                        arr[3] = "Ciaha";
                        break;
                    case 2:
                        arr[3] = "Magian";
                        break;
                    case 3:
                        arr[3] = "Necrian";
                        break;
                    case 4:
                        arr[3] = "Arbitar";
                        break;
                    case 5:
                        arr[3] = "Adept";
                        break;
                    case 6:
                        arr[3] = "Riaha";
                        break;
                    case 7:
                        arr[3] = "Celestial";
                        break;
                }

                if (c.Demon == true)
                    arr[4] = "\u221A";
                else
                    arr[4] = "";
                arr[5] = c.Difficulty.ToString();

                item = new ListViewItem(arr);
                item.Tag = c;

                CharacterView_List.Items.Add(item);
            }
        }        

        private void Remove_Character(object sender, EventArgs e)
        {
            if (Party.Count == MAX_PARTY_SIZE)//enable add character when full party removes character
                Add_Character.Enabled = true;

            Button g;
            Character C;
            //can't remove during foreach, so loop must check for which object to remove instead (List modification error)
            bool remove = false;

            if (sender.GetType() == typeof(Button))
            {
                g = (Button)sender;
                C = (Character)g.Parent.Tag;
                                
                foreach(Character c in Party)
                {
                    if (c.PartySlot == C.PartySlot)
                        remove = true;
                }
                if(remove == true)
                {
                    //update_party() will reconstitute groupbox after character is removed unless its the first slot. 
                    //Therefore, disabling the last slot before the other are all reconstituted in order in necessary to remove it from display
                    party_display[Party.Count-1].Enabled = false;
                    display_Selection[Party.Count - 1].Series.Clear();
                    display_Selection[Party.Count - 1].Titles.Clear();
                    Party.Remove(C);
                    CharList.Add(C);
                    update_Party();
                    update_List();
                }                
            }                
        }        

        private void NewCharacter_Click(object sender, EventArgs e)
        {
            using (var form = new CharacterCreation())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.New = form.NewCharacter;          //values preserved after close
                    CharList.Add(this.New);
                    CharacterView_List.Clear();
                    update_List();
                }
            }
        }
               
        private void Stat_Labels(object sender, EventArgs e)
        {
            Button G = (Button)sender;
            Label[] L = new Label[MAX_LABEL_NUMBER];
            int LabelNUM = 0;
            Character M = (Character)G.Parent.Tag;

                foreach (Control l in G.Parent.Controls)
                {
                    if (l.GetType() == typeof(Label))
                    {
                        L[LabelNUM] = (Label)l;
                        LabelNUM++;
                    }
                }
            G.Parent.Text = M.Name;
            L[0].Text = "Lv: " + M.Level.ToString();            
            L[1].Text = M.Tag;

            switch (M.Race)
            {
                case 1:
                    L[2].Text = "Ciaha";
                    break;
                case 2:
                    L[2].Text = "Magian";
                    break;
                case 3:
                    L[2].Text = "Necrian";
                    break;
                case 4:
                    L[2].Text = "Arbitar";
                    break;
                case 5:
                    L[2].Text = "Adept";
                    break;
                case 6:
                    L[2].Text = "Riaha";
                    break;
                case 7:
                    L[2].Text = "Celestial";
                    break;
            }

            if (M.Demon == true)
                L[2].Text += " -Halfbreed";
                       

            L[3].Text = "Strength:";
            L[3].Visible = true;
            if (M.Constitution > 10)
                M.Constitution = 10;
            L[4].Text = M.Constitution.ToString() + "/10";
            L[4].Visible = true;

            L[5].Text = "Skill:";
            L[5].Visible = true;
            if (M.Skill > 10)
                M.Skill = 10;
            L[6].Text = M.Skill.ToString() + "/10";
            L[6].Visible = true;

            L[7].Text = "Resistence:";
            L[7].Visible = true;
            if (M.Resistence > 10)
                M.Resistence = 10;
            L[8].Text = M.Resistence.ToString() + "/10";
            L[8].Visible = true;

            L[9].Text = "Intelligence:";
            L[9].Visible = true;
            if (M.intelligence > 10)
                M.intelligence = 10;
            L[10].Text = M.intelligence.ToString() + "/10";
            L[10].Visible = true;

            L[11].Visible = false;
            L[12].Visible = false;

            L[13].Visible = false;
            L[14].Visible = false;

            L[15].Text = "Difficutly:";
            L[16].Text = M.Difficulty.ToString();

            //send with stats setting
            build_character_chart(M, 2);
        }

        private void Skill_Labels(object sender, EventArgs e)
        {
            Button G = (Button)sender;
            Label[] L = new Label[MAX_LABEL_NUMBER];
            int LabelNUM = 0;
            Character M = (Character)G.Parent.Tag;

            foreach (Control l in G.Parent.Controls)
            {
                if (l.GetType() == typeof(Label))
                {
                    L[LabelNUM] = (Label)l;
                    LabelNUM++;
                }
            }
            G.Parent.Text = M.Name;
            L[0].Text = "Lv: " + M.Level.ToString();
            L[1].Text = M.Tag;

            switch (M.Race)
            {
                case 1:
                    L[2].Text = "Ciaha";
                    break;
                case 2:
                    L[2].Text = "Magian";
                    break;
                case 3:
                    L[2].Text = "Necrian";
                    break;
                case 4:
                    L[2].Text = "Arbitar";
                    break;
                case 5:
                    L[2].Text = "Adept";
                    break;
                case 6:
                    L[2].Text = "Riaha";
                    break;
                case 7:
                    L[2].Text = "Celestial";
                    break;
            }

            if (M.Demon == true)
                L[2].Text += " -Halfbreed";
                       

            L[3].Text = "Weapon Arts:";
            L[3].Visible = true;
            L[4].Text = M.weaponArts.ToString() + "/100";
            L[4].Visible = true;

            L[5].Text = "Combat Arts:";
            L[5].Visible = true;
            L[6].Text = M.combatArts.ToString() + "/100";
            L[6].Visible = true;

            L[7].Text = "Tech:";
            L[7].Visible = true;
            L[8].Text = M.Tech.ToString() + "/100";
            L[8].Visible = true;

            L[9].Text = "Mage Tech:";
            L[9].Visible = true;
            L[10].Text = M.MageTech.ToString() + "/100";
            L[10].Visible = true;

            L[11].Visible = false;
            L[12].Visible = false;

            L[13].Visible = false;
            L[14].Visible = false;

            L[15].Text = "Difficutly:";
            L[16].Text = M.Difficulty.ToString();

            //send with skills setting
            build_character_chart(M, 3);
        }

        private void Energy_Labels (object sender, EventArgs e)
        {
            Button G = (Button)sender;
            Label[] L = new Label[MAX_LABEL_NUMBER];
            int LabelNUM = 0;
            Character M = (Character)G.Parent.Tag;

            foreach (Control l in G.Parent.Controls)
            {
                if (l.GetType() == typeof(Label))
                {
                    L[LabelNUM] = (Label)l;
                    LabelNUM++;
                }
            }
            G.Parent.Text = M.Name;
            L[0].Text = "Lv: " + M.Level.ToString();
            L[1].Text = M.Tag;

            switch (M.Race)
            {
                case 1:
                    L[2].Text = "Ciaha";
                    break;
                case 2:
                    L[2].Text = "Magian";
                    break;
                case 3:
                    L[2].Text = "Necrian";
                    break;
                case 4:
                    L[2].Text = "Arbitar";
                    break;
                case 5:
                    L[2].Text = "Adept";
                    break;
                case 6:
                    L[2].Text = "Riaha";
                    break;
                case 7:
                    L[2].Text = "Celestial";
                    break;
            }

            if (M.Demon == true)
                L[2].Text += " -Halfbreed";
            
            L[3].Text = "Body Energy:";
            L[4].Text = M.bodyEnergy.ToString() + "/100";

            L[5].Text = "Mental Energy:";
            L[6].Text = M.mentalEnergy.ToString() + "/100";

            L[7].Text = "Spiritual Energy:";
            L[8].Text = M.spiritualEnergy.ToString() + "/100";

            L[9].Text = "Memory Energy:";
            L[10].Text = M.memoryEnergy.ToString() + "/100";

            L[11].Visible = true;
            L[11].Text = "Manna Training:";
            L[12].Visible = true;
            L[12].Text = M.mannaTraining.ToString() + "/100";
            
            L[13].Visible = false;
            L[14].Visible = false;

            L[15].Text = "Difficutly:";
            L[16].Text = M.Difficulty.ToString();

            //send with energy setting
            build_character_chart(M, 1);
        }

        private void Energy_Labels_Default(GroupBox G)
        {           
            Label[] L = new Label[MAX_LABEL_NUMBER];
            int LabelNUM = 0;
            Character M = (Character)G.Tag;

            //PartyNameField.Text = M.PartySlot.ToString(); //debugging


            foreach (Control l in G.Controls)
            {
                if (l.GetType() == typeof(Label))
                {
                    L[LabelNUM] = (Label)l;
                    LabelNUM++;
                }
            }
            G.Text = M.Name;
            L[0].Text = "Lv: " + M.Level.ToString();
            L[1].Text = M.Tag;

            switch (M.Race)
            {
                case 1:
                    L[2].Text = "Ciaha";
                    break;
                case 2:
                    L[2].Text = "Magian";
                    break;
                case 3:
                    L[2].Text = "Necrian";
                    break;
                case 4:
                    L[2].Text = "Arbitar";
                    break;
                case 5:
                    L[2].Text = "Adept";
                    break;
                case 6:
                    L[2].Text = "Riaha";
                    break;
                case 7:
                    L[2].Text = "Celestial";
                    break;
            }

            if (M.Demon == true)
                L[2].Text += " -Halfbreed";

            L[3].Text = "Body Energy:";
            L[3].Visible = true;
            L[4].Text = M.bodyEnergy.ToString() + "/100";
            L[4].Visible = true;

            L[5].Text = "Mental Energy:";
            L[5].Visible = true;
            L[6].Text = M.mentalEnergy.ToString() + "/100";
            L[6].Visible = true;

            L[7].Text = "Spiritual Energy:";
            L[7].Visible = true;
            L[8].Text = M.spiritualEnergy.ToString() + "/100";
            L[8].Visible = true;

            L[9].Text = "Memory Energy:";
            L[9].Visible = true;
            L[10].Text = M.memoryEnergy.ToString() + "/100";
            L[10].Visible = true;

            L[11].Visible = true;
            L[11].Text = "Manna Training:";
            L[12].Visible = true;
            L[12].Text = M.mannaTraining.ToString() + "/100";

            L[13].Visible = false;
            L[14].Visible = false;

            L[15].Text = "Difficutly:";
            L[16].Text = M.Difficulty.ToString();

            //send with energy setting
            build_character_chart(M, 1);
        }

        private void Add_Character_Click(object sender, EventArgs e)
        {
            if (CharacterView_List.SelectedItems.Count > 0 && Party.Count < MAX_PARTY_SIZE)//prevent add button from out of index exception
            {                
                    Character partyMember = new Character();
                    partyMember = (Character)CharacterView_List.SelectedItems[0].Tag;
                    Party.Add(partyMember);
                    CharList.Remove(partyMember);
                    if (Party.Count == MAX_PARTY_SIZE)
                        Add_Character.Enabled = false;
                    update_Party();
                    //remove char from roster???
                    update_List();
                if (Party.Count == MAX_PARTY_SIZE)
                    Add_Character.Enabled = false;
            }
        }        

        private void build_character_chart(Character C, int type)
        {
            string[] xValues = new string[4];
            int[] yValues = new int[4];
            
            switch (type)
            {
                case 1://Energy
                    xValues[0] = "Body";
                    xValues[1] = "Mental";
                    xValues[2] = "Memory";
                    xValues[3] = "Spiritual";

                    yValues[0] = C.bodyEnergy;
                    yValues[1] = C.mentalEnergy;
                    yValues[2] = C.memoryEnergy;
                    yValues[3] = C.spiritualEnergy;

                    display_Selection[C.PartySlot].ChartAreas[0].AxisY.Maximum = 100;
                    display_Selection[C.PartySlot].Titles[0].Text = "Energy Efficientcies";
                    break;
                case 2://Stats
                    xValues[0] = "Strength";
                    xValues[1] = "Skill";
                    xValues[2] = "Resistence";
                    xValues[3] = "Intelligence";

                    yValues[0] = C.Constitution;
                    yValues[1] = C.Skill;
                    yValues[2] = C.Resistence;
                    yValues[3] = C.intelligence;

                    display_Selection[C.PartySlot].ChartAreas[0].AxisY.Maximum = 10;
                    display_Selection[C.PartySlot].Titles[0].Text = "Hard Stats";
                    break;
                case 3://skills
                    xValues[0] = "Weapon";
                    xValues[1] = "Combat";
                    xValues[2] = "Tech";
                    xValues[3] = "Mage Tech";

                    yValues[0] = C.weaponArts;
                    yValues[1] = C.combatArts;
                    yValues[2] = C.Tech;
                    yValues[3] = C.MageTech;

                    display_Selection[C.PartySlot].ChartAreas[0].AxisY.Maximum = 100;
                    display_Selection[C.PartySlot].Titles[0].Text = "Skill Aptitude";
                    break;
            }
            display_Selection[C.PartySlot].ChartAreas[0].AxisX.Maximum = 4;
            display_Selection[C.PartySlot].Series["S"].Points.DataBindXY(xValues, yValues);
        }

        private void PartyLogistics()
        {
            int maxStrength = 0;
            int maxResistence = 0;
            int maxIntelligence = 0;
            int maxSkill = 0;

            int maxW_Arts = 0;
            int maxC_Arts = 0;
            int maxTech = 0;
            int maxM_Tech = 0;

            int difficulty_total = 0;
            int levelAve = 0;
            int AgeAve = 0;
            int i = 0;

            //clear race compostion boxes before testing again.
            ciahanRaceCheck.Checked = false;
            magianRaceCheck.Checked = false;
            necrianRaceCheck.Checked = false;
            arbiterRaceCheck.Checked = false;
            AdeptRaceCheck.Checked = false;
            CelestialRaceCheck.Checked = false;
            BreedRaceCheck.Checked = false;

            //foreach(Control Check in PartyRaceDispaly.Controls)
            foreach (Character c in Party)
            {
                levelAve += c.Level;
                i++;

                if (maxStrength < c.Constitution)
                    maxStrength = c.Constitution;
                if (maxSkill < c.Skill)
                    maxSkill = c.Skill;
                if (maxIntelligence < c.intelligence)
                    maxIntelligence = c.intelligence;
                if (maxResistence < c.Resistence)
                    maxResistence = c.Resistence;
                if (maxW_Arts < c.weaponArts)
                    maxW_Arts = c.weaponArts;
                if (maxC_Arts < c.combatArts)
                    maxC_Arts = c.combatArts;
                if (maxM_Tech < c.MageTech)
                    maxM_Tech = c.MageTech;
                if (maxTech < c.Tech)
                    maxTech = c.Tech;

                switch(c.Race)
                {
                    case 1://ciaha
                        ciahanRaceCheck.Checked = true;
                        break;
                    case 2://magian
                        magianRaceCheck.Checked = true;
                        break;
                    case 3://necrian
                        necrianRaceCheck.Checked = true;
                        break;
                    case 4://arbiter
                        arbiterRaceCheck.Checked = true;
                        break;
                    case 5://adept
                        AdeptRaceCheck.Checked = true;
                        break;
                    //case 6://riaha
                    //    checkBox4.Checked = true;
                    //    break;
                    case 7://celestial
                        CelestialRaceCheck.Checked = true;
                        break;
                }
                if (c.Demon == true)
                    BreedRaceCheck.Checked = true;

                AgeAve = c.Age;
                difficulty_total += c.Difficulty;
                //add difficulty is age is greater than average limit for party size
                //if (c.Age > 80 + Party.Count() * 20)
                  //  difficulty_total++;
            }//END FOR EACH

            int[] maximsStats = { maxStrength, maxSkill, maxResistence, maxIntelligence };
            int[] maximsSkill = { maxW_Arts, maxC_Arts, maxM_Tech, maxTech};
            string[] statLabel = { "Strength", "Skill", "Resistence", "Intelligence"};
            string[] skillLabel = { "Weapon Arts", "Combat Arts", "Mage Tech", "Tech"};

            Stat_Range.Series["Series1"].Points.DataBindXY(statLabel, maximsStats);           
            Skill_Range.Series["Series1"].Points.DataBindXY(skillLabel, maximsSkill);

            if (i > 0)
                update_Difficulty(difficulty_total, levelAve / i, AgeAve/ Party.Count());
            else
                update_Difficulty(difficulty_total, levelAve, AgeAve/ Party.Count());
        }    
        
        private void update_Difficulty(int total, int ave, int AgeT)
        {
            DifficultyDisplay.Text = (total+AgeT/100).ToString();           

            if(total < 6)
            {
                DifficultyDisplay.Text = total.ToString();
                PartyRatingDisplay.Text = "Rating: Normal - Prioritize your parties diversity to stay a step ahead and plan for the worst in unfamiliar territories and you should come out alive. For beginners and casual play.";                
            }
            else if(total < 11)
            {
                DifficultyDisplay.Text = total.ToString();
                PartyRatingDisplay.Text = "Rating: Hard - Expect no mercy. Utilize your parites strength's effectively or you will die without fail. Remember, high risk - high reward. This is the intended difficulty.";
            }
            else
            {
                DifficultyDisplay.Text = total.ToString();
                PartyRatingDisplay.Text = "Rating Game Master - Be intimately familiar with Generation in all its aspects to find the perfect solutions. There will not be many methods to win. Experts and Hardcores only; you've been warned.";
            }
            PartyRatingDisplay.Text += "\r\n\r\nParty Level Average: " + ave.ToString() + "\r\nParty Size: " + Party.Count().ToString();
        }

        private void Make_party_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(PartyNameField.Text) || String.IsNullOrWhiteSpace(PartyNameField.Text))                
                MessageBox.Show("Enter Party Name");
            else
            {
                P.constructParty(Party, PartyNameField.Text);
                this.DialogResult = DialogResult.OK;
                FileStream fs = new FileStream(PartyPath + PartyNameField.Text + ".GENPAR", FileMode.Create);              
                            
                // Construct a BinaryFormatter and use it to serialize the data to the stream.
                BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        formatter.Serialize(fs, P);
                    }
                    catch (SerializationException SE)
                    {
                        Console.WriteLine("Failed to serialize. Reason: " + SE.Message);
                        //throw;
                    }
                    finally
                    {
                        fs.Close();
                    }//END TRY/CATCH
                int x = 1;
                foreach( Character c in Party)
                {//add all characters in party back to roster
                    party_display[Party.Count - x].Enabled = false;
                    display_Selection[Party.Count - x].Series.Clear();
                    display_Selection[Party.Count - x].Titles.Clear();                    
                    CharList.Add(c);
                    x++;
                }//END FOR EACH
                if (MessageBox.Show("Begin Quest ?", "Party Created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var form = new ActiveParty(PartyNameField.Text, false);
                    form.QuestParty = this.Party; //this.Party in this form is a list of characters, not a "Party" object
                    //form.P = this.P;      //creates instance of party for save function in active party.cs
                    this.Close();
                    form.Show();
                }//END IF
                else
                {
                    PartyNameField.Clear();
                    Party.Clear();
                    update_Party();
                    update_List();
                }//END ELSE                     
                }//END ELSE
            }//END FUNCTION            

        private void CharacterView_List_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && CharacterView_List.SelectedItems.Count == 1)
                Add_Character.PerformClick();
        }

        private void PartyNameField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                Make_party.PerformClick();
        }
    }
}
