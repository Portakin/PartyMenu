using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterQuestMenu
{
    public partial class NPCList : Form
    {
        public List<Character> NPCs { get; set; } = new List<Character>();
        private List<Character> FULL_Roster = new List<Character>();
        private string path = Directory.GetCurrentDirectory() + "\\NPCs\\";
        private string[] arr = new string[7];
        private ListViewItem item;

        public NPCList()
        {
            InitializeComponent();
        }

        public NPCList(List<Character> partyMembers)
        {
            InitializeComponent();
            NPCs = partyMembers;
            update_Party();
        }
        private void update_Party()
        {
            PartyRoster.Clear();
            PartyRoster.View = View.Details;
            PartyRoster.GridLines = true;
            PartyRoster.FullRowSelect = true;
            PartyRoster.Columns.Add("Name", 100);
            PartyRoster.Columns.Add("Level", 50);
            PartyRoster.Columns.Add("I.D.", 25);
            PartyRoster.Columns.Add("Age", 50);
            PartyRoster.Columns.Add("Race", 60);
            PartyRoster.Columns.Add("Demon", 60);
            PartyRoster.Columns.Add("Diff.", 50);
            int x = 0;

            foreach (Character c in NPCs)
            {
                c.CalculateEnergy_party_only();
                arr[0] = c.Name;
                arr[1] = c.Level.ToString();
                arr[2] = x.ToString();
                arr[3] = c.Age.ToString();

                switch (c.Race)
                {
                    case 1:
                        arr[4] = "Ciaha";
                        break;
                    case 2:
                        arr[4] = "Magian";
                        break;
                    case 3:
                        arr[4] = "Necrian";
                        break;
                    case 4:
                        arr[4] = "Arbitar";
                        break;
                    case 5:
                        arr[4] = "Adept";
                        break;
                    case 6:
                        arr[4] = "Riaha";
                        break;
                    case 7:
                        arr[4] = "Celestial";
                        break;
                }
                if (c.Demon == true)
                    arr[5] = "\u221A";
                else
                    arr[5] = "";
                arr[6] = c.Difficulty.ToString();
                x++;

                item = new ListViewItem(arr);
                item.Tag = c;
                PartyRoster.Items.Add(item);
            }
        }//displays party NPCs currently in party

        private void update_List()
        {
            NPCRoster.Clear();
            NPCRoster.View = View.Details;
            NPCRoster.GridLines = true;
            NPCRoster.FullRowSelect = true;
            NPCRoster.Columns.Add("Name", 150);
            NPCRoster.Columns.Add("Level", 50);
            NPCRoster.Columns.Add("I.D.", 25);
            NPCRoster.Columns.Add("Age", 50);
            NPCRoster.Columns.Add("Race", 60);
            NPCRoster.Columns.Add("Demon", 50);
            NPCRoster.Columns.Add("Shifter", 50);
            NPCRoster.Columns.Add("Difficulty", 50);
            int x = 0;

            foreach (Character c in FULL_Roster)
            {
                c.CalculateEnergy_party_only();
                arr[0] = c.Name;
                arr[1] = c.Level.ToString();
                arr[2] = x.ToString();
                arr[3] = c.Age.ToString();
                switch (c.Race)
                {
                    case 1:
                        arr[4] = "Ciaha";
                        break;
                    case 2:
                        arr[4] = "Magian";
                        break;
                    case 3:
                        arr[4] = "Necrian";
                        break;
                    case 4:
                        arr[4] = "Arbitar";
                        break;
                    case 5:
                        arr[4] = "Adept";
                        break;
                    case 6:
                        arr[4] = "Riaha";
                        break;
                    case 7:
                        arr[4] = "Celestial";
                        break;
                }
                if (c.Demon == true)
                    arr[5] = "\u221A";
                else
                    arr[5] = "";               
                arr[6] = c.Difficulty.ToString();
                x++;

                item = new ListViewItem(arr);
                item.Tag = c;
                NPCRoster.Items.Add(item);
            }
        }//displays roster

        private void NPCList_Load(object sender, EventArgs e)//populates roster
        {
            //debug = Directory.GetFiles(path);
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
                string [] training = Character_Stats[i].Split(',');
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

                FULL_Roster.Add(NEW_CHARACTER);// **** R O S T E R ****
            }
            update_List();            
        }
               
        private void Delete_NPC_Click(object sender, EventArgs e)
        {
            if (PartyRoster.SelectedItems != null)
            {                
                FULL_Roster.Remove((Character)PartyRoster.SelectedItems[0].Tag);
                update_Party();
                //add file deletion laterz...
            }
        }

        private void NewNPC_Click(object sender, EventArgs e)
        {
            using (var form = new CharacterCreation())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Character C = form.NewCharacter;          //values preserved after close
                    FULL_Roster.Add(C);
                    PartyRoster.Clear();
                    update_List();
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (PartyRoster.SelectedItems.Count < 1)
                return;
            FULL_Roster.Add((Character)PartyRoster.SelectedItems[0].Tag);//add character from NPC in party to Full roster
            NPCs.RemoveAt(Convert.ToInt32(PartyRoster.SelectedItems[0].SubItems[2].Text));//remove NPC from Party          
            update_Party();
            update_List();
        }

        private void Add_Character_Click(object sender, EventArgs e)
        {
            if (NPCRoster.SelectedItems.Count < 1)
                return;
            NPCs.Add((Character)NPCRoster.SelectedItems[0].Tag);//add character from Full roster (NPCRoster) to party
            FULL_Roster.RemoveAt(Convert.ToInt32(NPCRoster.SelectedItems[0].SubItems[2].Text));//remove NPC from Full roster 
            update_Party();
            update_List();
        }

        private void Finish_Selection_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Edit_character_Click(object sender, EventArgs e)
        {
            //not implemented
        }
    }
}
