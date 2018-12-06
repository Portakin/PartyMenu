using System;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CharacterQuestMenu
{
    public partial class ActiveParty : Form
    {
        public List<Character> QuestParty { get; set; } //intialized in party creation.cs
        public Party P { get; set; }//intialized in party list.cs
        public string P_Name;
        public MemberBox[] members = new MemberBox[5];
        //private MemberBox[] NPCMembers = new MemberBox[NPC_LIMIT]; //NPC Limit because I Suck at accessing controls from collection
        public string damagetype = "Life-Force";
        string[] Xvalues =  {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        int[] Yvalues = new int[10];
        //private static int NPC_LIMIT = 10;

        //directory for saving parties binary
        private string PartyPath = Directory.GetCurrentDirectory() + "\\Parties\\";
        private string path = Directory.GetCurrentDirectory() + "\\Characters\\";
        
        private bool battle = false;
        private int Turn_Count = 0;
        private int Day_Count = 0;
        private int Saturization = 100;
        private int playerNumber = 0;        
        private bool ReadFromFile;

        //**************************************************************************************************************************************************************
        //**************************************************************************************************************************************************************

        public ActiveParty(string name, bool intialization)
        {            
            ReadFromFile = intialization;           
            InitializeComponent();
            Party_Name.Text += " " + name;
            P_Name = name;
        }

        private void End_Turn(object sender, EventArgs e)
        {//automatically scrolls to the bottom
            int x = 0;
            foreach(Character c in QuestParty)
            {
                if(c.NPC == false)
                {
                    members[x].END_TURN(Saturization);
                    if (members[x].Gathering)
                        Saturization -= 2;
                    if (members[x].Bursting)
                        CombatBox.Text += c.Name + " is Bursting!";
                    if(NarrowBox.Checked)
                    Saturization-=2;
                    else
                    Saturization --;                    
                    x++;
                }
                else
                {
                    foreach (TabPage T in NPC_TabControl.TabPages)
                    {
                        MemberBox M = (MemberBox)T.Controls[0];
                        M.END_TURN(Saturization);
                    }
                }
                //navigate NPC tab                           
            }

            fill_Chart();
            Turn_Count++;
            TurnCount.Text = "Turn Count: " + Turn_Count.ToString();
            //update party stats and Saturation chart...
            //update turn count            
        }

        private void ActiveParty_Load(object sender, EventArgs e)
        {
            members[0] = memberBox1;
            members[1] = memberBox2;
            members[2] = memberBox3;
            members[3] = memberBox4;
            members[4] = memberBox5;

            if (ReadFromFile == true)//*********************************************************************************************************************************
            {
                QuestParty = new List<Character>(P.Members);

                int x = 0;// gets increased for every player (Non-NPC)
                int y = 0;// gets increased for every character
                int lv = 0;// For average level of party
                int AGE = 0;
                int diff = 0;
                foreach (Character c in QuestParty)
                {
                    if (c.NPC == false)
                    {
                        //foreach (int i in P.get_MemberStats(y)) //debugging
                            //CombatLog.Text += i.ToString() + " ";
                        members[x].buildCurrentMember(c, P.get_MemberStats(y), P.get_MemberLife(y));
                        playerNumber++;
                        lv += c.Level;
                        diff += c.Difficulty;
                        AGE += c.Age;
                        x++;
                    }
                    else//Grabs NPCs from party binary using special overloaded "Add_Tab" function
                        Add_Tab(c, P.get_MemberStats(y), P.get_MemberLife(y));
                    y++;
                }//END FOREACH
                
                updateBoxes();      //populates selection items
                Average.Text += " " + (lv / QuestParty.Count()).ToString();
                Difficulty.Text += " " + (diff + (AGE/x )/100).ToString();
                //battle = P.inBattle;
                Turn_Count = P.turnCount;
                Day_Count = P.dayCount;
                Saturization = P.Environment;
                DayNumber.Text = "Day Count: " + Day_Count.ToString();
                BattleButton.Click += BattleButton_Click;
            } //party read from binary (partylist.cs) or from "Load" button ******* P is initialized ********
            else if(ReadFromFile == false)//party made in party creation
            {
                int x = 0;
                int lv = 0;
                int diff = 0;
                int AGE = 0;

                //returns party by constructing from this form
                foreach (Character c in QuestParty)
                {                    
                    if (c.NPC == false)
                    {
                        members[x].buildMember_New(c);
                        TargetBox.Items.Add(c.Name);
                        PointBox.Items.Add(c.Name);
                        RearBox.Items.Add(c.Name);
                        AGE += c.Age;
                        playerNumber++;
                        x++;
                    }
                }//END FOREACH
                foreach(TabPage T in NPC_TabControl.TabPages)
                {
                    TargetBox.Items.Add(T.Text);
                    PointBox.Items.Add(T.Text);
                    RearBox.Items.Add(T.Text);
                }//END FOREACH
                
                Average.Text += " " + (lv / QuestParty.Count()).ToString();
                Difficulty.Text += " " + (diff + (AGE / x) / 100).ToString();
            }   //transfered from party creation                      
                //End of memberbox construction

            //handles manna saturation
            MannaSaturation.ChartAreas[0].AxisY.Maximum = 100;
            MannaSaturation.ChartAreas[0].AxisX.Maximum = 10;
            MannaSaturation.ChartAreas[0].AxisX.Minimum = 1;

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 > 0)
                    Yvalues[i] = 90;
                else
                    Yvalues[i] = 100;                
            }
            try { MannaSaturation.Series[0].Points.DataBindXY(Xvalues, Yvalues); }
            catch ( Exception ex )
            {
                CombatLog.Text += ex.Message;
            }
        }
        private void Add_Tab(Character c)
        {
            TabPage New_T = new TabPage();
            MemberBox M = new MemberBox();
           // int x = 0;
           // bool B = false;
            M.buildMember_New(c);
            //while (B == false)
            //{
            //    if (NPCMembers[x] == null)
            //        B = true;
            //    x++;
            //}
          //  NPCMembers[x] = M;
            New_T.Name = c.Name;
            New_T.Text = c.Name;
            New_T.Controls.Add(M);
            NPC_TabControl.TabPages.Add(New_T);
        }
        private void Add_Tab(Character c, int[] stats, bool alive)
        {
            TabPage New_T = new TabPage();
            MemberBox M = new MemberBox();
           // int x = 0;
           // bool B = false;
            M.buildCurrentMember(c, stats, alive);
            //while (B == false)
            //{
            //    if (NPCMembers[x] == null)
            //        B = true;
            //    x++;
            //}
           // NPCMembers[x] = M;
            New_T.Name = c.Name;
            New_T.Text = c.Name;
            New_T.Controls.Add(M);
            NPC_TabControl.TabPages.Add(New_T);
        }
        private void fill_Chart()
        {
            MannaSaturation.Series[0].Points.Clear();
            MannaSaturation.ChartAreas[0].AxisY.Maximum = 100;
            MannaSaturation.ChartAreas[0].AxisX.Maximum = 10;
            MannaSaturation.ChartAreas[0].AxisX.Minimum = 1;
            
            for (int i = 0; i < 9; i++)
            {
                Yvalues[i] = Yvalues[i + 1];
                          
            }
            Yvalues[9] = Saturization;
            try { MannaSaturation.Series[0].Points.DataBindXY(Xvalues, Yvalues); }
            catch (Exception ex)
            {
                CombatLog.Text += ex.Message;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //writes out attack description
            if (TechniqueBox.SelectedIndex == 0)
                AttackDescription.Text = findMember((TargetBox.Items[TargetBox.SelectedIndex]).ToString()).host.Name + " recieved " + DamageBox.Text + " " + damagetype + " damage!\n\r";
            CombatLog.Text += "\n\r" + AttackDescription.Text;

            //deals out damage
            if (TargetBox.SelectedIndex <= playerNumber)
                findMember((TargetBox.Items[TargetBox.SelectedIndex]).ToString()).recieve_damage(Int32.Parse(DamageBox.Text, NumberStyles.AllowLeadingSign), damagetype);
            // else tab control alteration
            TechniqueBox.SelectedItem = "None";

            //if (TechniqueBox.SelectedIndex == 0)
            //    AttackDescription.Text = members[TargetBox.SelectedIndex - 1].host.Name + " recieved " + DamageBox.Text + " " + damagetype + " damage!\n\r";

            //CombatLog.Text += "\n\r" + AttackDescription.Text;      
            //if(TargetBox.SelectedIndex <= playerNumber)
            //    members[TargetBox.SelectedIndex-1].recieve_damage(Int32.Parse(DamageBox.Text, NumberStyles.AllowLeadingSign), damagetype);
            //// else tab control alteration
            //TechniqueBox.SelectedItem = "None";

        }
        private void changeType(object sender, EventArgs e)
        {
            RadioButton R = (RadioButton)sender;
            damagetype = R.Text;
        }
        private void AttackDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                //writes out attack description
                if (TechniqueBox.SelectedIndex == 0)
                    AttackDescription.Text = findMember((TargetBox.Items[TargetBox.SelectedIndex]).ToString()).host.Name + " recieved " + DamageBox.Text + " " + damagetype + " damage!\n\r";
                CombatLog.Text += "\n\r" + AttackDescription.Text;

                //deals out damage
                if (TargetBox.SelectedIndex <= playerNumber)
                    findMember((TargetBox.Items[TargetBox.SelectedIndex]).ToString()).recieve_damage(Int32.Parse(DamageBox.Text, NumberStyles.AllowLeadingSign), damagetype);
                // else tab control alteration
                TechniqueBox.SelectedItem = "None";
            }
        }

        private void status_Control(object sender, EventArgs e)
        {
            CheckBox C = (CheckBox)sender;
            //if(C.Checked)
        }
        private void Add_Status(MemberBox M)
        {

        }
        private MemberBox findMember(string name)
        {
            int x = 0;

            while (x<playerNumber)
            {                       
                if (members[x].host.Name == name)
                   return members[x];
                x++;
            }

            foreach (TabPage T in NPC_TabControl.TabPages)
            {
                if (name == T.Name)
                    return  (MemberBox)T.Controls[0];
            }
            
            return members[x];
        }

        private void TargetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TechniqueBox.Items.Clear();
            List<string> S = new List<string>();

            //MemberBox m = 
            S = findMember(TargetBox.SelectedItem.ToString()).getTechniques();
                      
            TechniqueBox.Items.Add("None");
            foreach (string T in S)
            {
                TechniqueBox.Items.Add(T);
            }
            TechniqueBox.Items.Add("Gather");
            TechniqueBox.SelectedItem = "None";
        }
        private void TechniqueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //members[TargetBox.SelectedIndex - 1].host.Name
            switch (TechniqueBox.GetItemText(TechniqueBox.SelectedItem))
                {
                case "None":
                    break;
                case "Phase Step":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Phased Step!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "10";
                    break;
                case "Phase Jump":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Phased Jump!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "10";
                    break;                
                case "Guard":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Guard!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "5";
                    break;
                case "Reflect":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Reflect!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "2";
                    break;
                case "Absorb":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Absorb!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "0";
                    break;
                case "Barrier":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Barrier!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "15";
                    break;
                case "Ether Step":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Ether Step!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "10";
                    break;
                case "Ether Jump":
                    AttackDescription.Text = TargetBox.SelectedItem.ToString() + " used Ether Jump!\n\r";
                    MannaType.Checked = true;
                    DamageBox.Text = "10";
                    break;
                case "Ether Burn":
                    if (findMember(TargetBox.SelectedItem.ToString()).Ether_Burning)
                    {
                        CombatLog.Text += "\n\r" + TargetBox.SelectedItem.ToString() + " Stopped Channeling Ether!\n\r";
                        findMember(TargetBox.SelectedItem.ToString()).Ether_Burning = false;
                    }
                    else
                    {
                        CombatLog.Text += "\n\r" + TargetBox.SelectedItem.ToString() + " is Channeling Ether!\n\r";
                        findMember(TargetBox.SelectedItem.ToString()).Ether_Burning = true;
                    }
                    break;
                case "Gather":
                    if (findMember(TargetBox.SelectedItem.ToString()).Gathering)
                    {
                        CombatLog.Text += "\n\r" + TargetBox.SelectedItem.ToString() + " Stopped Gathering Manna!\n\r";
                        findMember(TargetBox.SelectedItem.ToString()).Gathering = false;
                    }
                    else
                    {
                        CombatLog.Text += "\n\r" + TargetBox.SelectedItem.ToString() + " Started Gathering Manna!\n\r";
                        findMember(TargetBox.SelectedItem.ToString()).Gathering = true;
                    }
                    break;
            }                
        }

        private void NPCs_Click(object sender, EventArgs e)
        {
            List<Character> NPCs = new List<Character>();
            int x = 0; //track which place in Quest Party
            List<int> NPC_slots = new List<int>();

            //grab characters from party that are NPCs
            foreach(Character c in QuestParty)
            {
                if (c.NPC)
                {                    
                    NPCs.Add(c);
                    NPC_TabControl.TabPages.Clear();
                    //y++;
                    NPC_slots.Add(x);
                }
                x++;
            }
            x = 0;

            //remove NPC members from party (avoid collection alteration run time error by using NPC_slots placements)
            foreach (int i in NPC_slots)
            {
                QuestParty.RemoveAt(i-x);
                x++;
            }

            using (var form = new NPCList(NPCs))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<Character> NEW_NPCs = form.NPCs;
                    foreach (Character c in NEW_NPCs)
                    {
                        c.NPC = true;
                        QuestParty.Add(c);
                        Add_Tab(c);
                    }
                }//END IF
            }//END NAMESPACE
            
            updateBoxes();      //populates selection items
        }//END FUNCTION

        private void updateBoxes()
        {
            PointBox.Items.Clear();
            RearBox.Items.Clear();
            TargetBox.Items.Clear();

            foreach (Character c in QuestParty)
            {
                PointBox.Items.Add(c.Name);
                RearBox.Items.Add(c.Name);
                TargetBox.Items.Add(c.Name);
            }

        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Day_Count++;
            DayNumber.Text = "Day Count: " + Day_Count.ToString();
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            Saturization = 100;
            fill_Chart();
        }

        private void ActiveParty_MouseHover(object sender, EventArgs e)
        {
            DescriptionBox.Text = "I N S T R U C T I O N S\r\n" +
                  "Combat in Generation revolves around using quanties of your manna effectively.\r\n\n" +
                  "Select and Energy Catalyst for your manna get the respective values they offer.\r\n\n" +
                   "Next, chose power a power state to enhance you abilities or reduce your energy consumption at the cost of power.\r\n\n" +
                   "Keep track of your energy reserves and the Manna Saturation of the area your fighting in and decide if need to retreat or if your ready for sustained combat.\r\n\n" +
                   "Lastly, monitor your Health Bars to protect yourselves and your NPCs!";
        }

        private void MemberMouse_Over(object sender, EventArgs e)
        {
            //if (sender.GetType() == typeof(MemberBox))
            //{
            //MemberBox M;
            //    try
            //    {
            //    M = (MemberBox)sender;
            //    DescriptionBox.Text = M.host.Name + "\r\nLevel: " +
            //       M.host.Level.ToString() + "\r\n" +
            //       "STATS\r\nStrength: " +
            //       M.host.Strength.ToString() + "\r\nSkill: " +
            //       M.host.Skill.ToString() + "\r\nResistence: " +
            //       M.host.Resistence.ToString() + "\r\nIntelligence: " +
            //       M.host.intelligence.ToString() + "\r\n" +
            //       "SKILLS\r\nWeapon Arts: " +
            //       M.host.weaponArts.ToString() + "\r\nCombat Arts: " +
            //       M.host.combatArts.ToString() + "\r\nMage Tech: " +
            //       M.host.MageTech.ToString() + "\r\nTech: " +
            //       M.host.Tech.ToString() + "\r\n" +
            //       "TRAINING\r\n";

            //    foreach (string s in M.host.Training)
            //        DescriptionBox.Text += s + "\r\n";
            //    }
            //catch(Exception ex)
            //{
            //    DescriptionBox.Text = ex.Message;
            //}
            // }
            MemberBox M = (MemberBox)sender;
            DescriptionBox.Text = M.Display_Text;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(PartyPath + P_Name + ".GENPAR"))
            File.Delete(PartyPath + P_Name + ".GENPAR");

            if (!ReadFromFile)
                P = new Party();

           // int[] Reserves;
            int x = 0;
            int y = 0;
                        
            //P.constructParty(QuestParty, P_Name);
            //debugging function
            P.inBattle = battle;
            P.turnCount = Turn_Count;
            P.Environment = Saturization;
            P.dayCount = Day_Count;
            //P.Members.Clear();  //not set to instance of object //= new List<Character>();
            P.Members = QuestParty;
            P.clearMembers();

            //retrieve party energy and health information from member boxes and NPC member boxes to save into party
            foreach (Character c in QuestParty)
            {
                if(c.NPC)
                {
                    if(typeof(MemberBox) == NPC_TabControl.TabPages[y].Controls[0].GetType())
                    {
                        MemberBox NPC = (MemberBox)NPC_TabControl.TabPages[y].Controls[0];
                        //Reserves = NPC.get_energyStatus();
                        P.Save_Party_member(NPC.get_energyStatus(), NPC.get_healthStatus());
                        y++;    //cycle through NPC tabs
                    }
                }
                else
                {
                    //Reserves = members[x].get_energyStatus();
                    P.Save_Party_member(members[x].get_energyStatus(), members[x].get_healthStatus());
                    x++;     //cycle through party members
                }
            }
            //name and write party file
            P.Partyname = P_Name;
            FileStream fs = new FileStream(PartyPath + P_Name + ".GENPAR", FileMode.Create);

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
                MessageBox.Show("Quest Saved!");
            }//END TRY/CATCH
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Processing...", "Save Quest?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SaveButton.Click += SaveButton_Click;
            PartyList Load = new PartyList();
            Load.Show();
            this.Close();                
        }

        private void BattleButton_Click(object sender, EventArgs e)
        {
            if (battle)
            {
                Ender.Enabled = false;
                BattleButton.Text = "End";
                battle = false;
            }
            else if (!battle)
            {
                Ender.Enabled = true;
                BattleButton.Text = "Begin";
                battle = true;
            }
        }

        private void Ender_MouseHover(object sender, EventArgs e)
        {
            DescriptionBox.Text = "End turn for players.\r\n" +
                "Players can only use one energy type per turn and once an action is taken, they are locked into that energy for that turn.\r\n" +
                "Player can be killed and revived several times a turn if possible but are not able to recover actions.";
        }

        private void MannaSaturation_MouseHover(object sender, EventArgs e)
        {
            DescriptionBox.Text = "End turn for players.\r\n";
        }
    }
}
