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
using System.Collections;
using System.Runtime.Serialization;

namespace CharacterQuestMenu
{
    public partial class PartyList : Form
    {
        private string path = Directory.GetCurrentDirectory() + "\\Parties\\";
        List<Party> Parties = new List<Party>();
        Party Item = new Party();
        
        public PartyList()
        {
            InitializeComponent();
           // update_party_list();
        }

        public void update_List()
        {
            PartyScrollList.View = View.Details;
            PartyScrollList.GridLines = true;
            PartyScrollList.FullRowSelect = true;

            PartyScrollList.Columns.Add("Name", 100);            
            PartyScrollList.Columns.Add("Members", 60);
            PartyScrollList.Columns.Add("Ave. LV.", 60);
            PartyScrollList.Columns.Add("Celestial", 70);
            PartyScrollList.Columns.Add("Demon", 60);            
            PartyScrollList.Columns.Add("Diff.", 50);
            // Read the stream to a string that becomes file names
            string[] parties = Directory.GetFiles(path);
            //list view item string array
            string[] arr = new string[6];
            
            int lvAve = 0;
            bool celestial;
            bool demon;
            int difficulty = 0;

            foreach (string file in parties)
            {
                Item = ReadPartyFromBinary(file);
                ListViewItem P;
                celestial = false;
                demon = false;

                arr[0] = Path.GetFileNameWithoutExtension(file);
                arr[1] = Item.getMembers().Count().ToString();

                foreach (Character c in Item.getMembers())
                {
                    lvAve += c.Level;
                    difficulty += c.Difficulty;

                    if (c.Race == 7)
                        celestial = true;

                    if (c.Demon == true)
                        demon = true;
                }

                arr[2] = (lvAve / Item.getMembers().Count()).ToString();
                if (celestial == true)
                    arr[3] = "Yes";
                else
                    arr[3] = "No";
                if (demon == true)
                    arr[4] = "Yes";
                else
                    arr[4] = "No";
                arr[5] = difficulty.ToString();
                //reset for next party
                difficulty = 0;
                lvAve = 0;

                P = new ListViewItem(arr);
                P.Tag = Item;
                PartyScrollList.Items.Add(P);
            }
            }

        public Party ReadPartyFromBinary(string file)
        {
            Stream stream = File.OpenRead(file);
            BinaryFormatter bf = new BinaryFormatter();
            Party PartyItem;
            try
            {
                PartyItem = (Party)bf.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to Deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                stream.Close();
            }
            //Party PartyItem = (Party)bf.Deserialize(stream);
            return PartyItem;
        }

        private void PartyList_Load(object sender, EventArgs e)
        {
            update_List();
        }

        private void SelectParty_Click(object sender, EventArgs e)
        {
            if (PartyScrollList.SelectedItems.Count < 1)
                return;
            ActiveParty A = new ActiveParty(PartyScrollList.SelectedItems[0].SubItems[0].Text, true); //first item in list view item is part name
            A.P = (Party)PartyScrollList.SelectedItems[0].Tag;
            this.Close();
            A.Show();
        }

        private void NewParty_Click(object sender, EventArgs e)
        {
            using (var form = new PartyCreation())
            {                
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Item = form.P;          //values preserved after close
                    Parties.Add(this.Item);
                    PartyScrollList.Clear();
                    update_List();
                }
            }
        }

        private void Delete_Party_Click(object sender, EventArgs e)
        {
            if (PartyScrollList.SelectedItems.Count < 1)
                return;
            Parties.RemoveAt(PartyScrollList.SelectedItems[0].Index);
            File.Delete(path + PartyScrollList.SelectedItems[0].Text);
            PartyScrollList.Clear();
            update_List();
        }

        private void PartyScrollList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                SelectParty.PerformClick();
        }
    }
}
