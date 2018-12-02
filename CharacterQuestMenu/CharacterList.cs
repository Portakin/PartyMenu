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
    public partial class CharacterList : Form
    {
        //private object listBox1;
        public List<Character> Roster = new List<Character>();        
        private Character New = new Character();
        private string path = Directory.GetCurrentDirectory() + "\\Characters\\";
        private bool select = false;
                
        string[] arr = new string[6];
        ListViewItem item;       
        
        public CharacterList()
        {
            InitializeComponent();   
        }

        private void CharacterList_Load(object sender, EventArgs e)
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
                //string[] training;

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
                
                Roster.Add(NEW_CHARACTER);
            }           
            update_List();
        }
            
        private void NewCharacter_Click_1(object sender, EventArgs e)
        {            
            using (var form = new CharacterCreation())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.New = form.NewCharacter;          //values preserved after close
                    Roster.Add(this.New);
                    CharacterScrollList.Clear();
                    update_List();
                }
            }
        }

        private void update_List()
        {
            CharacterScrollList.View = View.Details;
            CharacterScrollList.GridLines = true;
            CharacterScrollList.FullRowSelect = true;

            CharacterScrollList.Columns.Add("Name", 100);
            CharacterScrollList.Columns.Add("Level", 50);
            CharacterScrollList.Columns.Add("Age", 50);
            CharacterScrollList.Columns.Add("Race", 60); 
            CharacterScrollList.Columns.Add("Demon", 60);
            CharacterScrollList.Columns.Add("Diff.", 50);

            foreach (Character c in Roster)
            {
                arr[0] = c.Name;
                arr[1] = c.Level.ToString();
                arr[2] = c.Age.ToString();

                switch(c.Race)
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

                CharacterScrollList.Items.Add(item);
            }
        }                
                
        private void item_select()
        {
            if(select == false)
            {
               // Add_Character.Enabled = true;
                Edit_Character.Enabled = true;
               // Remove_Character.Enabled = true;
                Delete_Character.Enabled = true;
                select = true;
            }
            else
            {
               // Add_Character.Enabled = false;
                Edit_Character.Enabled = false;
               // Remove_Character.Enabled = false;
                Delete_Character.Enabled = false;

                //when function refires the items will be unselected?
                select = false;
            }

        }       
             
        private void Finish_Selection_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Edit_Character_Click(object sender, EventArgs e)
        {
            if (CharacterScrollList.SelectedItems.Count < 1)
                return;
            using (var form = new CharacterCreation((Character)CharacterScrollList.SelectedItems[0].Tag))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.New = form.NewCharacter;          //values preserved after close
                    Roster.RemoveAt(CharacterScrollList.SelectedItems[0].Index);
                    Roster.Add(this.New);
                    CharacterScrollList.Clear();
                    update_List();
                }
            }
        }

        private void Delete_Character_Click(object sender, EventArgs e)
        {
            if (CharacterScrollList.SelectedItems.Count < 1)
                return;
            Roster.RemoveAt(CharacterScrollList.SelectedItems[0].Index);
            File.Delete(path + CharacterScrollList.SelectedItems[0].Text);
            CharacterScrollList.Clear();
            update_List();
        }

        //private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //    {
        //        return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
        //    }
        //    DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
        //    //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        //}
    }
}
