using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterQuestMenu
{
    public partial class MemberBox : UserControl
    {
        public Character host;//lowercase tag to prevent from needing to cast every Tag into character
        //public string CurrentEnergy;
        public string Display_Text { get; set; }
        public bool Bursting { get; set; }
        public bool Gathering { get; set; }
        public bool Ether_Burning { get; set; }
        private bool currentEnergy_efficency;
        private int Residual = 3;
        private int R_Modifiers = 0;
        int health;
        int spirit;
        int soul;
        int manna;

        public MemberBox()
        {
            InitializeComponent();
        }

        public void Viewer_Click(object sender, EventArgs e)
        {           
            using (var form = new CharacterCreation(host, true))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    EnergyBox.Items.Clear();
                    buildMember_New(form.NewCharacter);
                    
                }
            }

        }

        public void buildMember_New(Character c)
        {
            host = c;
            groupBox1.Text = host.Name + " Lv: " + host.Level.ToString();

            if (c.Demon)
                EnergyBox.Items.Add("Demon");
            if (c.attribute)
            {
                if (c.Dark != 0)
                    EnergyBox.Items.Add("Dark");
                if (c.Light != 0)
                    EnergyBox.Items.Add("Light");
                if (c.Evil != 0)
                    EnergyBox.Items.Add("Evil");
            }
            
            Normalize.Checked = true;//normalized
            health = (int)((host.Level + host.Constitution * 10 + 100) * (double)(1 + host.LifeBonus / 100));
            // health max is Con x 10 + 100 + level + a bonus up to 50%
            HealthBar.MAXIMUM_VALUE = (int)((host.Level + host.Constitution * 10 + 100) * (double)(1 + host.LifeBonus / 100));
            manna = (int)((100 + host.mannaTraining + host.Level) * (double)(1 + host.mannaBonus / 100));
            // manna max is level + 100 + training + a bonus up to 50%
            MannaBar.MAXIMUM_VALUE = (int)((100 + host.mannaTraining + host.Level) * (double)(1 + host.mannaBonus / 100));
            spirit = 200;
            soul = 300;
            HealthBar.buildBar(health, Color.Red);
            MannaBar.buildBar(manna, Color.Turquoise);

            foreach(string S in c.Training)
                if (S == "Ether Attunement")
                    EtherBurnBox.Enabled = true;
            bodyScaling(c.bodyEnergy);
            //EnergyBox.SelectedIndex = 0; //Body Energy Defualt
        }
        public void buildCurrentMember(Character c, int[] i, bool alive)
        {
            host = c;
            groupBox1.Text = host.Name + "Lv: " + host.Level.ToString();
            if (c.Demon)
                EnergyBox.Items.Add("Demon");
            if (c.attribute)
            {
                if (c.Dark != 0)
                    EnergyBox.Items.Add("Dark");
                if (c.Light != 0)
                    EnergyBox.Items.Add("Light");
                if (c.Evil != 0)
                    EnergyBox.Items.Add("Evil");
            }
            if (i[5] > 0)
                HalfPower.Checked = true;
            else if (i[5] == 0)
                Normalize.Checked = true;
            else
                FullPower.Checked = true;

            health = i[0];
            // health is con x 10 + 100 + level + a bonus up to 50%
            HealthBar.MAXIMUM_VALUE = (int)((host.Level + host.Constitution * 10 + 100) * (double)(1 + host.LifeBonus / 100));
            manna = i[3];
            // manna max is level + 100 + training + a bonus up to 50%
            MannaBar.MAXIMUM_VALUE = (int)((100 + host.mannaTraining + host.Level) * (double)(1 + host.mannaBonus / 100));
            spirit = i[1];
            soul = i[2];
            TechniqueBox.Enabled = true;
            switch (i[4])
            {
                case 1:
                    currentEnergy_efficency = true;
                    EnergyBox.SelectedIndex = 0; //Body Energy
                    break;
                case 2:
                    currentEnergy_efficency = true;
                    EnergyBox.SelectedIndex = 1; //Mental Energy
                    break;
                case 3:
                    currentEnergy_efficency = true;
                    EnergyBox.SelectedIndex = 2; //Memory Energy
                    break;
                case 4:
                    currentEnergy_efficency = true;
                    EnergyBox.SelectedIndex = 3; //Spirit Energy
                    break;
                case 5:
                    currentEnergy_efficency = true;
                    DemonScaling(host.Level);
                    break;
                case 6:
                    currentEnergy_efficency = false;
                    SoulScaling(host.Dark, Color.Gray);
                    break;
                case 7:
                    currentEnergy_efficency = false;
                    SoulScaling(host.Light, Color.FloralWhite);
                    break;
                case 8:
                    currentEnergy_efficency = false;
                    SoulScaling(host.Evil, Color.Firebrick);
                    break;
                case 9:
                    currentEnergy_efficency = false;
                    SoulScaling(host.soulEnergy, Color.Green);
                    break;
            }//END SWITCH

            foreach (string S in c.Training)
                if (S == "Ether Attunement")
                    EtherBurnBox.Enabled = true;

            HealthBar.buildBar(health, Color.Red);
            MannaBar.buildBar(manna, Color.Turquoise);
            if (!alive)
                this.Enabled = false;
        }
        public void recieve_damage(int value, string type)
        {
            switch (type)
            {
                case "Life-Force":
                    health -= value;
                    if (health < 0)//death
                    {
                        health = 0;
                        this.Enabled = false;
                    }
                    HealthBar.buildBar(health, Color.Red);
                    break;
                case "Spirit":
                    spirit -= value;
                    if (spirit < 0)//manna death
                    {
                        spirit = 0;
                        manna = 0;
                        MannaBar.buildBar(manna, Color.Turquoise);
                        //add status or something
                    }
                    HealthBar.buildBar(spirit, Color.Blue);
                    break;
                case "Soul":
                    soul -= value;
                    if (soul < 0)//super death!
                    {
                        soul = 0;
                        manna = 0;
                        MannaBar.buildBar(manna, Color.Turquoise);
                        this.Enabled = false;
                        //add more status or something
                    }
                    HealthBar.buildBar(soul, Color.White);
                    break;
                case "Manna":
                    if (HalfPower.Checked == true)//half power checked
                        manna -= (int)(value * .5);
                    else if (FullPower.Checked == true)//full power checked
                        manna -= (int)(value * 1.5);
                    else
                        manna -= value;

                    if (manna < 0)
                        manna = 0;
                    MannaBar.buildBar(manna, Color.Turquoise);
                    break;
            }
        }
        public void END_TURN(int Saturation)
        {
            Residual = Convert.ToInt32(Residual_Cost.Text);
            if (Residual < 0)
                Residual = 0;
            if (spirit == 0 || soul == 0 || health == 0)// manna doesn't recover if spirit, health, or soul is dead
                return;
            if (Gathering == true)
            {
                if (Saturation > 50)
                {
                    manna += 30;
                    MannaBar.buildBar(manna, Color.Turquoise);
                }
                else if (Saturation > 25)
                {
                    manna += 15;
                    MannaBar.buildBar(manna, Color.Turquoise);
                }
                else
                    return;
            }
            else if (!currentEnergy_efficency)//only decrease manna if using manna based energy
                return;
            else
            {
                manna -= Residual;
                MannaBar.buildBar(manna, Color.Turquoise);
            }
        }
        public List<string> getTechniques()
        {
            List<string> S = new List<string>();
            for (int i = 0; i < TechniqueBox.Items.Count; i++)
            {
                S.Add(TechniqueBox.GetItemText(TechniqueBox.Items[i]));
            }
            return S;
        }
        public int[] get_energyStatus()
        {
            int[] status = new int[6];
            status[0] = health;
            status[1] = spirit;
            status[2] = soul;
            status[3] = manna;

            if (EnergyBox.SelectedItem == null)
                status[4] = 1;
            else
            switch (EnergyBox.SelectedItem.ToString())
            {
                case "Body":
                    status[4] = 1;

                    break;
                case "Mental":
                    status[4] = 2;

                    break;
                case "Spirit":
                    status[4] = 3;

                    break;
                case "Memory":
                    status[4] = 4;

                    break;
                case "Demon":
                    status[4] = 5;

                    break;
                case "Dark":
                    status[4] = 6;

                    break;
                case "Light":
                    status[4] = 7;

                    break;
                case "Evil":
                    status[4] = 8;

                    break;
                case "Soul":
                    status[4] = 9;

                    break;
            }//END SWITCH

            if (HalfPower.Checked)
                status[5] = -1;
            else if (Normalize.Checked)
                status[5] = 0;
            else
                status[5] = 1;

            return status;
        }
        public bool get_healthStatus()
        {
            if (health <= 0)
               return false;
            else
                return true;
        }

        private void bodyScaling(int level)
        {
            if (HalfPower.Checked)
                level -= host.Level / 4;
            if (FullPower.Checked)
                level += host.Level / 4;

            SpeedBurstBox.Enabled = false;
            if (host.Ether)
            {
                SpeedBurstBox.Text = "Ether Burst";
                switch (level / 15)
                {
                    case 6:
                        PowerBar.buildBar("Lv 7", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        TechniqueBox.Items.Add("Absorb");
                        break;
                    case 5:
                        PowerBar.buildBar("Lv 6", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 4:
                        PowerBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 3:
                        PowerBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        PowerBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        PowerBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 0:
                        PowerBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                }//calculate power bar for body energy

                switch (level / 20)
                {                    
                    case 5:
                        EndBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 4:
                        EndBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 3:
                        EndBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        EndBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        EndBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        EndBar.buildBar("Lv 0", host.bodyEnergy, Color.Gold);
                        break;
                }//calculate End bar for body energy

                switch (level / 15)
                {                    
                    case 6:
                        SpeedBar.buildBar("Lv 6", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Ether Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 5:
                        SpeedBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        break;
                    case 4:
                        SpeedBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        break;
                    case 3:
                        SpeedBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        break;
                    case 2:
                        SpeedBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        break;
                    case 1:
                        SpeedBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        break;
                    case 0:
                        SpeedBar.buildBar("Lv 0", host.bodyEnergy, Color.Gold);
                        break;
                }//calculate speed bar for body energy

                switch (level / 15)
                {
                    case 6:
                        FlightBar.buildBar("Lv 6", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Ether Jump");
                        break;
                    case 5:
                        FlightBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        break;
                    case 4:
                        if (level >= 70)
                            FlightBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        break;
                    case 3:
                        if (level >= 55)
                            FlightBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        break;
                    case 2:
                        if (level >= 40)
                            FlightBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        break;
                    case 1:
                        if (level >= 25)
                            FlightBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        break;
                    case 0:
                        if (level >= 10)
                            FlightBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 0", host.bodyEnergy, Color.Gold);
                        break;
                }//calculate flight bar for body energy
            }
            else
            {
                SpeedBurstBox.Text = "Speed Burst";
                if (level > 80)
                    level = 80;
                switch (level / 15)//calculate power bar for body energy
                {                   
                    case 5:
                        PowerBar.buildBar("Lv 6", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 4:
                        PowerBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 3:
                        PowerBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        PowerBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        PowerBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 0:
                        PowerBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                }

                switch (level / 20)//calculate End bar for body energy
                {
                    case 4:
                        EndBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 3:
                        EndBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        EndBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        EndBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        EndBar.buildBar("Lv 0", host.bodyEnergy, Color.Gold);
                        break;
                }

                switch (level / 15)//calculate speed bar for body energy
                {
                    case 5:
                        SpeedBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 4:
                        SpeedBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 3:
                        SpeedBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 2:
                        SpeedBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Step");
                        break;
                    case 1:
                        SpeedBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Step");
                        break;
                    case 0:
                        SpeedBar.buildBar("Lv 0", host.bodyEnergy, Color.Gold);
                        break;
                }

                switch (level / 15)//calculate flight bar for body energy
                {
                    case 5:
                        FlightBar.buildBar("Lv 5", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 4:
                        if (level >= 70)
                            FlightBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 3:
                        if (level >= 55)
                            FlightBar.buildBar("Lv 4", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 2:
                        if (level >= 40)
                            FlightBar.buildBar("Lv 3", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 1:
                        if (level >= 25)
                        {
                            FlightBar.buildBar("Lv 2", host.bodyEnergy, Color.Gold);
                            TechniqueBox.Items.Add("Phase Jump");
                        }
                        else
                            FlightBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        break;
                    case 0:
                        if (level >= 10)
                            FlightBar.buildBar("Lv 1", host.bodyEnergy, Color.Gold);
                        else
                            FlightBar.buildBar("Lv 0", host.bodyEnergy, Color.Gold);
                        break;
                }                
            }
        }
        private void mentalScaling( int level)
        {
            if (HalfPower.Checked)
                level -= host.Level / 4;
            if (FullPower.Checked)
                level += host.Level / 4;

            SpeedBurstBox.Enabled = false;
            if (host.Ether)
            {
                SpeedBurstBox.Text = "Ether Burst";
                switch (level / 25)
                {
                    case 4:
                        PowerBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Reflect");
                        TechniqueBox.Items.Add("Absorb");
                        break;
                    case 3:
                        PowerBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        PowerBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        PowerBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        break;
                    case 0:
                        PowerBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate Power bar for mental energy

                switch (level / 25)
                {
                    case 4:
                        EndBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 3:
                        EndBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        EndBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        EndBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        EndBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate End bar for mental energy

                switch (level / 25)
                {
                    case 4:
                        SpeedBar.buildBar("Lv 5", host.mentalEnergy, Color.HotPink);
                        SpeedBurstBox.Enabled = true;
                        TechniqueBox.Items.Add("Ether Step");
                        break;
                    case 3:
                        if (level >= 85)
                        {
                            SpeedBar.buildBar("Lv 5", host.mentalEnergy, Color.HotPink);
                            SpeedBurstBox.Enabled = true;
                            TechniqueBox.Items.Add("Ether Step");
                        }
                        else
                            SpeedBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        break;
                    case 2:
                        if (level >=  65)
                            SpeedBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        else
                            SpeedBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        break;
                    case 1:
                        if (level >= 45)
                        {
                            SpeedBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        }
                        else
                            SpeedBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        break;
                    case 0:
                        if (level >= 5)
                            SpeedBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        else
                            SpeedBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate Speed bar for mental energy

                switch (level / 25)
                {  
                    case 4:
                        FlightBar.buildBar("Lv 5", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Ether Jump");
                        break;
                    case 3:
                        if (level >= 95)
                        {
                            FlightBar.buildBar("Lv 5", host.mentalEnergy, Color.HotPink);
                            TechniqueBox.Items.Add("Ether Jump");
                        }
                        else
                            FlightBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        break;
                    case 2:
                        if (level >= 55)
                            FlightBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);                      
                        else
                            FlightBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        break;
                    case 1:
                        if (level >= 35)
                            FlightBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        else
                            FlightBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        break;
                    case 0:
                        if (level >= 15)
                            FlightBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        else
                            FlightBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate flight bar for mental energy
            }
            else
            {
                SpeedBurstBox.Text = "Speed Burst";
                if (level > 75)
                    level = 75;
                switch (level / 25)
                {
                    case 3:
                        PowerBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        PowerBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        PowerBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        break;
                    case 0:
                        PowerBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate Power bar for mental energy

                switch (level / 25)
                {
                    case 3:
                        EndBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        EndBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        EndBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        EndBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate End bar for mental energy

                switch (level / 25)
                {
                    case 3:
                            SpeedBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Phase Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 2:
                        if (level % 65 > 0)
                            SpeedBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        else
                            SpeedBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Phase Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 1:
                        if (level % 45 > 0)
                        {
                            SpeedBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                            SpeedBurstBox.Enabled = true;
                        }
                        else
                            SpeedBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Phase Step");
                        break;
                    case 0:
                        if (level % 5 > 0)
                            SpeedBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        else
                            SpeedBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate Speed bar for mental energy

                switch (level / 25)
                {
                    case 3:
                        FlightBar.buildBar("Lv 4", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 2:
                        if (level % 55 > 0)
                            FlightBar.buildBar("Lv 3", host.mentalEnergy, Color.HotPink);
                        else
                            FlightBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 1:
                        if (level % 35 > 0)
                            FlightBar.buildBar("Lv 2", host.mentalEnergy, Color.HotPink);
                        else
                            FlightBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 0:
                        if (level % 15 > 0)
                        { 
                            FlightBar.buildBar("Lv 1", host.mentalEnergy, Color.HotPink);
                            TechniqueBox.Items.Add("Phase Jump");
                        }
                        else
                            FlightBar.buildBar("Lv 0", host.mentalEnergy, Color.HotPink);
                        break;
                }//calculate flight bar for mental energy
            }
        }
        private void spiritualScaling (int level)
        {
            if (HalfPower.Checked)
                level -= host.Level / 4;
            if (FullPower.Checked)
                level += host.Level / 4;

            SpeedBurstBox.Enabled = false;
            if (host.Ether)
            {
                SpeedBurstBox.Text = "Ether Burst";
                switch (level / 20)//calculate power bar for spiritual energy
                {
                    case 5:
                        PowerBar.buildBar("Lv 7", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Reflect");
                        TechniqueBox.Items.Add("Absorb");
                        break;
                    case 4:
                        if (level >= 85)
                        {
                            PowerBar.buildBar("Lv 6", host.spiritualEnergy, Color.LightSkyBlue);
                            TechniqueBox.Items.Add("Absorb");
                        }
                        else
                            PowerBar.buildBar("Lv 5", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 3:
                        if (level >= 70)
                            PowerBar.buildBar("Lv 5", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            PowerBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        if (level >= 55)
                            PowerBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            PowerBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        if (level >= 25)
                        {
                            PowerBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                            TechniqueBox.Items.Add("Reflect");
                        }
                        else
                            PowerBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                    case 0:
                        if(level >= 10)
                            PowerBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            PowerBar.buildBar("Lv 0", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                }

                switch (level / 20)//calculate End bar for spiritual energy
                {
                    case 5:
                            EndBar.buildBar("Lv 7", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 4:
                        if (level >= 95)
                            EndBar.buildBar("Lv 7", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 6", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 3:
                        if (level >= 65)
                            EndBar.buildBar("Lv 6", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 5", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        if (level >= 50)
                            EndBar.buildBar("Lv 5", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        if (level >= 35)
                            EndBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        if (level >= 5)
                            EndBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 0", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                }

                switch (level / 15)//calculate speed and flight bar for spiritual energy
                {
                    case 6:
                        SpeedBar.buildBar("Lv 7", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 7", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Ether Step");
                        TechniqueBox.Items.Add("Ether Jump");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 5:
                        SpeedBar.buildBar("Lv 6", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 6", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Ether Step");
                        TechniqueBox.Items.Add("Ether Jump");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 4:
                        SpeedBar.buildBar("Lv 5", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 5", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Ether Step");
                        break;
                    case 3:
                        SpeedBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                    case 2:
                        SpeedBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                    case 1:
                        SpeedBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                    case 0:
                        SpeedBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                }                              
            }
            else
            {
                SpeedBurstBox.Text = "Speed Burst";
                if (level > 55)
                    level = 55;
                switch (level / 15)//calculate power bar for spirtual energy
                {
                    case 3:
                        if(level == 55)
                            PowerBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            PowerBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        if (level >= 40)
                            PowerBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            PowerBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        if (level >= 25)
                        {
                            PowerBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                            TechniqueBox.Items.Add("Reflect");
                        }
                        else
                            PowerBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                    case 0:
                        if (level >= 10)
                            PowerBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            PowerBar.buildBar("Lv 0", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                }

                switch (level / 15)//calculate End bar for spirtual energy
                {
                    case 3:
                        if (level == 50)
                            EndBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        if (level >= 35)
                            EndBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        if (level >= 20)
                        {
                            EndBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                            TechniqueBox.Items.Add("Guard");
                        }
                        else
                            EndBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                    case 0:
                        if (level >= 5)
                            EndBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        else
                            EndBar.buildBar("Lv 0", host.spiritualEnergy, Color.LightSkyBlue);
                        break;
                }

                switch (level / 15)//calculate speed and flight bar for spirtual energy
                {
                    case 3:
                        SpeedBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 4", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 2:
                        SpeedBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 3", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 1:
                        SpeedBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 2", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 0:
                        SpeedBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        FlightBar.buildBar("Lv 1", host.spiritualEnergy, Color.LightSkyBlue);
                        TechniqueBox.Items.Add("Phase Step");
                        break;
                }
            }
        }
        private void memoryScaling (int level)
        {
            if (HalfPower.Checked)
                level -= host.Level / 4;
            if (FullPower.Checked)
                level += host.Level / 4;

            SpeedBurstBox.Enabled = false;
            if (host.Ether)
            {
                SpeedBurstBox.Text = "Ether Burst";
                switch (level / 20)//calculate power bar for memory energy
                {
                    case 5:
                        PowerBar.buildBar("Lv 7", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        TechniqueBox.Items.Add("Absorb");
                        break;
                    case 4:
                        if (level >= 95)
                            PowerBar.buildBar("Lv 7", host.memoryEnergy, Color.Silver);
                        else
                            PowerBar.buildBar("Lv 6", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        TechniqueBox.Items.Add("Absorb");
                        break;
                    case 3:
                        if (level >= 65)
                        {
                            PowerBar.buildBar("Lv 5", host.memoryEnergy, Color.Silver);
                            TechniqueBox.Items.Add("Absorb");
                        }
                        else
                            PowerBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:
                        if (level >= 50)
                            PowerBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        else
                            PowerBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        if (level >= 35)
                            PowerBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        else
                            PowerBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 0:
                        if (level >= 5)
                        {
                            PowerBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                            TechniqueBox.Items.Add("Reflect");
                        }
                        else
                            PowerBar.buildBar("Lv 0", host.memoryEnergy, Color.Silver);
                        break;
                }
                switch (level / 15)//calculate End bar for memory energy
                {
                    case 6:
                        EndBar.buildBar("Lv 7", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 5:
                        EndBar.buildBar("Lv 6", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 4:
                        EndBar.buildBar("Lv 5", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        TechniqueBox.Items.Add("Barrier");
                        break;
                    case 3:
                        EndBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        EndBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        EndBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        EndBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                }
                switch (level / 25)//calculate speed bar for memory energy
                {
                    case 4:
                        SpeedBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Ether Step");
                        SpeedBurstBox.Enabled = true;
                        break;
                    case 3:
                        SpeedBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Ether Step");
                        break;
                    case 2:
                        SpeedBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        break;
                    case 1:
                        SpeedBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        break;
                    case 0:
                        SpeedBar.buildBar("Lv 0", host.memoryEnergy, Color.Silver);
                        break;
                }
                switch (level / 20)//calculate flight bar for memory energy
                {
                    case 5:
                        FlightBar.buildBar("Lv 5", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Ether Jump");
                        break;
                    case 4:
                        FlightBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Ether Jump");
                        break;
                    case 3:
                        FlightBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Ether Jump");
                        break;
                    case 2:
                        FlightBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        break;
                    case 1:
                        FlightBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        break;
                    case 0:
                        FlightBar.buildBar("Lv 0", host.memoryEnergy, Color.Silver);
                        break;
                }
            }
            else
            {
                SpeedBurstBox.Text = "Speed Burst";
                if (level > 50)
                    level = 50;
                switch (level / 10)//calculate power bar for memory energy
                {
                    case 5:
                        PowerBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 4:
                        PowerBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 3:
                        if (level >= 35)
                        PowerBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        else
                        PowerBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 2:                        
                        PowerBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 1:
                        PowerBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Reflect");
                        break;
                    case 0:
                        if (level >= 5)
                        {
                            PowerBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                            TechniqueBox.Items.Add("Reflect");
                        }
                        else
                            PowerBar.buildBar("Lv 0", host.memoryEnergy, Color.Silver);
                        break;
                }
                switch (level / 15)//calculate End bar for memory energy
                {
                    case 3:
                        EndBar.buildBar("Lv 4", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 2:
                        EndBar.buildBar("Lv 3", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 1:
                        EndBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                    case 0:
                        EndBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Guard");
                        break;
                }
                switch (level / 25)//calculate speed bar for memory energy
                {
                    case 2:
                        if (level == 50)
                        {
                            SpeedBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                            TechniqueBox.Items.Add("Phase Step");
                            SpeedBurstBox.Enabled = true;
                        }
                        break;
                    case 1:
                        SpeedBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        break;
                    case 0:
                        SpeedBar.buildBar("Lv 0", host.memoryEnergy, Color.Silver);
                        break;
                }
                switch (level / 20)//calculate flight bar for memory energy
                {                    
                    case 2:
                            FlightBar.buildBar("Lv 2", host.memoryEnergy, Color.Silver);
                        TechniqueBox.Items.Add("Phase Jump");
                        break;
                    case 1:
                            FlightBar.buildBar("Lv 1", host.memoryEnergy, Color.Silver);
                        break;
                    case 0:
                            FlightBar.buildBar("Lv 0", host.memoryEnergy, Color.Silver);
                        break;
                }
            }
        }
        private void DemonScaling(int level)
        {
            if (HalfPower.Checked)
                level -= host.Level / 4;
            if (FullPower.Checked)
                level += host.Level / 4;

            SpeedBurstBox.Text = "Speed Burst";
            SpeedBurstBox.Enabled = false;

                switch (level / 20)//calculate Power bar for Demonic energy
                {
                    case 5:
                        PowerBar.buildBar("Lv 7", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Reflect");
                    TechniqueBox.Items.Add("Absorb");
                    break;
                    case 4:
                    if (level >= 85)
                    {
                        PowerBar.buildBar("Lv 6", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Absorb");
                    }
                    else
                        PowerBar.buildBar("Lv 5", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Reflect");
                    break;
                case 3:
                    if (level >= 70)
                        PowerBar.buildBar("Lv 5", host.demonicEnergy, Color.DarkRed);
                    else
                        PowerBar.buildBar("Lv 4", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Reflect");
                    break;
                case 2:
                    if (level >= 55)
                        PowerBar.buildBar("Lv 4", host.demonicEnergy, Color.DarkRed);
                    else
                        PowerBar.buildBar("Lv 3", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Reflect");
                    break;
                case 1:
                    if (level >= 25)
                    {
                        PowerBar.buildBar("Lv 3", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Reflect");
                    }
                    else
                        PowerBar.buildBar("Lv 2", host.demonicEnergy, Color.DarkRed);
                    break;
                case 0:
                    if (level >= 10)
                        PowerBar.buildBar("Lv 1", host.demonicEnergy, Color.DarkRed);
                    else
                        PowerBar.buildBar("Lv 0", host.demonicEnergy, Color.DarkRed);
                    break;
            }

                switch (level / 20)//calculate End bar for spiritual energy
                {
                case 5:
                    EndBar.buildBar("Lv 7", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Guard");
                    TechniqueBox.Items.Add("Barrier");
                    break;
                case 4:
                    if (level >= 95)
                        EndBar.buildBar("Lv 7", host.demonicEnergy, Color.DarkRed);
                    else
                        EndBar.buildBar("Lv 6", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Guard");
                    TechniqueBox.Items.Add("Barrier");
                    break;
                case 3:
                    if (level >= 65)
                        EndBar.buildBar("Lv 6", host.demonicEnergy, Color.DarkRed);
                    else
                        EndBar.buildBar("Lv 5", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Guard");
                    break;
                case 2:
                    if (level >= 50)
                        EndBar.buildBar("Lv 5", host.demonicEnergy, Color.DarkRed);
                    else
                        EndBar.buildBar("Lv 4", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Guard");
                    break;
                case 1:
                    if (level >= 35)
                        EndBar.buildBar("Lv 3", host.demonicEnergy, Color.DarkRed);
                    else
                        EndBar.buildBar("Lv 2", host.demonicEnergy, Color.DarkRed);
                    TechniqueBox.Items.Add("Guard");
                    break;
                case 0:
                    if (level >= 5)
                        EndBar.buildBar("Lv 1", host.demonicEnergy, Color.DarkRed);
                    else
                        EndBar.buildBar("Lv 0", host.demonicEnergy, Color.DarkRed);
                    break;
            }

                switch (level / 15)//calculate speed and flight bar for demonic energy
                {
                    case 6:
                        SpeedBar.buildBar("Lv 7", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 7", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                    break;
                    case 5:
                        SpeedBar.buildBar("Lv 6", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 6", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                    break;
                    case 4:
                        SpeedBar.buildBar("Lv 5", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 5", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                    break;
                    case 3:
                        SpeedBar.buildBar("Lv 4", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 4", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                    break;
                    case 2:
                        SpeedBar.buildBar("Lv 3", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 3", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                        SpeedBurstBox.Enabled = true;
                    break;
                    case 1:
                        SpeedBar.buildBar("Lv 2", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 2", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                        TechniqueBox.Items.Add("Phase Jump");
                    break;
                    case 0:
                        SpeedBar.buildBar("Lv 1", host.demonicEnergy, Color.DarkRed);
                        FlightBar.buildBar("Lv 1", host.demonicEnergy, Color.DarkRed);
                        TechniqueBox.Items.Add("Phase Step");
                    break;                
            }
        }
        private void SoulScaling(int eff, Color att)
        {
            if (eff == 100)
            {
                PowerBar.buildBar("Lv 9", eff, att);
                EndBar.buildBar("Lv 9", eff, att);
                SpeedBar.buildBar("Lv 9", eff, att);
                FlightBar.buildBar("Lv 9", eff, att);
            }
            else if (eff >= 80)
            {
                PowerBar.buildBar("Lv 8", eff, att);
                EndBar.buildBar("Lv 8", eff, att);
                SpeedBar.buildBar("Lv 8", eff, att);
                FlightBar.buildBar("Lv 8", eff, att);
            }
            else if (eff >= 60)
            {
                PowerBar.buildBar("Lv 7", eff, att);
                EndBar.buildBar("Lv 7", eff, att);
                SpeedBar.buildBar("Lv 7", eff, att);
                FlightBar.buildBar("Lv 7", eff, att);
            }
            else if (eff >= 40)
            {
                PowerBar.buildBar("Lv 6", eff, att);
                EndBar.buildBar("Lv 6", eff, att);
                SpeedBar.buildBar("Lv 6", eff, att);
                FlightBar.buildBar("Lv 6", eff, att);
            }
            else if (eff >= 20)
            {
                PowerBar.buildBar("Lv 5", eff, att);
                EndBar.buildBar("Lv 5", eff, att);
                SpeedBar.buildBar("Lv 5", eff, att);
                FlightBar.buildBar("Lv 5", eff, att);
            }
            else
            {
                PowerBar.buildBar("Lv 4", eff, att);
                EndBar.buildBar("Lv 4", eff, att);
                SpeedBar.buildBar("Lv 4", eff, att);
                FlightBar.buildBar("Lv 4", eff, att);
            }

        }

        private void HealthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //use public value to change maximum health and manna bars because all other function calls 
            //default 100. only health, spirit, soul, and manna  

            switch(HealthBox.SelectedItem.ToString())
            {
                case "Life-Force":
                    HealthBar.MAXIMUM_VALUE = (int) ((host.Level + host.Constitution * 10 + 100) * (double)(1+ host.LifeBonus/100));
                    HealthBar.buildBar(health, Color.Red);
                    MannaBar.buildBar(manna, Color.Turquoise);
                    break;
                case "Spirit":
                    HealthBar.MAXIMUM_VALUE = 200;
                    HealthBar.buildBar(spirit, Color.Blue);
                    MannaBar.buildBar(manna, Color.Turquoise);
                    break;
                case "Soul":
                    HealthBar.MAXIMUM_VALUE = 300;
                    HealthBar.buildBar(soul, Color.White);
                    MannaBar.buildBar(manna, Color.Turquoise);
                    break;
            }
        }
        private void EnergyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpeedBurstBox.Checked = false;
            TechniqueBox.Enabled = true;
            TechniqueBox.Items.Clear();
                switch (EnergyBox.SelectedItem.ToString())
                {
                    case "Body":
                    TechniqueBox.Items.Clear();
                    bodyScaling(host.bodyEnergy);
                    currentEnergy_efficency = true;
                    break;
                    case "Mental":
                    TechniqueBox.Items.Clear();
                    mentalScaling(host.mentalEnergy);
                    currentEnergy_efficency = true;
                    break;
                    case "Spirit":
                    TechniqueBox.Items.Clear();
                    spiritualScaling(host.spiritualEnergy);
                    currentEnergy_efficency = true;
                    break;
                    case "Memory":
                    TechniqueBox.Items.Clear();
                    memoryScaling(host.memoryEnergy);
                    currentEnergy_efficency = true;
                    break;
                    case "Demon":
                    TechniqueBox.Items.Clear();
                    DemonScaling(host.demonicEnergy);
                    currentEnergy_efficency = false;
                    break;
                    case "Dark":
                    TechniqueBox.Items.Clear();
                    SoulScaling(host.Dark, Color.Gray);
                    currentEnergy_efficency = false;
                    break;
                    case "Light":
                    TechniqueBox.Items.Clear();
                    SoulScaling(host.Light, Color.FloralWhite);
                    currentEnergy_efficency = false;
                    break;
                    case "Evil":
                    TechniqueBox.Items.Clear();
                    SoulScaling(host.Evil, Color.Firebrick);
                    currentEnergy_efficency = false;
                    break;
                    case "Soul":
                    TechniqueBox.Items.Clear();
                    SoulScaling(host.soulEnergy, Color.Green);
                    currentEnergy_efficency = false;
                    break;
                }//END SWITCH
            for (int i = 0; i < TechniqueBox.Items.Count; i++)
            {
                TechniqueBox.GetItemChecked(i);
            }
            TechniqueBox.Enabled = false;
        }

        private void MemberBox_MouseHover(object sender, EventArgs e)
        {
            return;//Display_Text = health.ToString() + spirit.ToString() + manna.ToString();
        }

        private void EtherBurnBox_CheckedChanged(object sender, EventArgs e)
        {
            SpeedBurstBox.Checked = false;
            if (EtherBurnBox.Checked)
            {
                R_Modifiers += 3;
                if (HalfPower.Checked)
                    Residual_Cost.Text = ((int)(Residual + R_Modifiers) * .5).ToString();
                else if (FullPower.Checked)
                    Residual_Cost.Text = ((Residual + R_Modifiers) * 2).ToString();
                else
                    Residual_Cost.Text = (Residual + R_Modifiers).ToString();
                //EnergyBox.SelectedItem = EnergyBox.SelectedIndex;
            }
            else if (!EtherBurnBox.Checked)
            {
                R_Modifiers -= 3;
                if (HalfPower.Checked)
                    Residual_Cost.Text = ((int)(Residual + R_Modifiers) * .5).ToString();
                else if (FullPower.Checked)
                    Residual_Cost.Text = ((Residual + R_Modifiers) * 2).ToString();
                else
                    Residual_Cost.Text = (Residual + R_Modifiers).ToString();
                //EnergyBox.SelectedItem = EnergyBox.SelectedIndex;
            }
        }
        private void SpeedBurstBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SpeedBurstBox.Checked)
            {
                R_Modifiers += 3;
                if (HalfPower.Checked)
                    Residual_Cost.Text = ((int)(Residual + R_Modifiers) * .5).ToString();
                else if (FullPower.Checked)
                    Residual_Cost.Text = ((Residual + R_Modifiers) * 2).ToString();
                else
                    Residual_Cost.Text = (Residual+ R_Modifiers).ToString();
            }
            else if (!SpeedBurstBox.Checked)
            {
                R_Modifiers -= 3;
                if (HalfPower.Checked)
                    Residual_Cost.Text = ((int)(Residual + R_Modifiers) * .5).ToString();
                else if (FullPower.Checked)
                    Residual_Cost.Text = ((Residual + R_Modifiers) * 2).ToString();
                else
                    Residual_Cost.Text = (Residual + R_Modifiers).ToString();
            }
        }
        
        private void HalfPower_CheckedChanged(object sender, EventArgs e)
        {
            if (HalfPower.Checked)
                Residual_Cost.Text = ((int)((Residual + R_Modifiers) * .5)).ToString();
        }
        private void FullPower_CheckedChanged(object sender, EventArgs e)
        {
            if (FullPower.Checked)
                Residual_Cost.Text = ((Residual + R_Modifiers) * 2).ToString();

        }
        private void Normalize_CheckedChanged(object sender, EventArgs e)
        {
                Residual_Cost.Text = (Residual + R_Modifiers).ToString();
        }

        private void Residual_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Enter)        
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Residual = Convert.ToInt32(Residual_Cost.Text);
                }
                e.Handled = true;
            }            
        }

        private void Residual_Cost_MouseClick(object sender, MouseEventArgs e)
        {
            Normalize.Checked = true;
            EtherBurnBox.Checked = false;
            SpeedBurstBox.Checked = false;
        }
    }
}
