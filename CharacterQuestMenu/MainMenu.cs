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
    public partial class MainMenu : Form
    {
        //string path = Directory.GetCurrentDirectory();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartyCreation pCreate = new PartyCreation();
            pCreate.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CharacterList cList = new CharacterList();
            cList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PartyList pList = new PartyList();
            pList.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = new Bitmap(Directory.GetCurrentDirectory() + "derp.jpg");
            //InfoPic.Image = new Bitmap(path + "yonk!.jpg");
        }

        private void debug_Click(object sender, EventArgs e)
        {
            ActiveParty Active = new ActiveParty("name", false);
            Active.Show();
        }
    }
}
