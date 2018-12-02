using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;

namespace CharacterQuestMenu
{
    [Serializable]
        public class Party
    {
        public string Partyname;

        public List<Character> Members { get; set; } 
        private List<int> healthStatus = new List<int>(); 
        private List<int> spiritStatus = new List<int>();
        private List<int> soulStatus = new List<int>();
        private List<int> energyStatus = new List<int>(); //which type of energy currently being channeled
        private List<int> mannaReserves = new List<int>();
        private List<int> powerstate = new List<int>(); 
        private List<bool> alive = new List<bool>();

        public bool inBattle = false; //unused so far
        public int turnCount = 0;
        public int dayCount = 0;
        public int Environment = 100;
        
        public void constructParty(List<Character> R, string name)
        {
            Partyname = name;
            Members = R;
            foreach(Character c in Members)
            {
                healthStatus.Add((int)((c.Level + c.Constitution * 10 + 100) * (double)(1 + c.LifeBonus / 100)));
                spiritStatus.Add(200);
                soulStatus.Add(300);                
                mannaReserves.Add((int)((c.Level + c.Constitution * 10 + 100) * (double)(1 + c.LifeBonus / 100)));
                energyStatus.Add(1);
                powerstate.Add(0);
                alive.Add(true);
            }
        }//party creation only

        public void clearMembers()
        {
            healthStatus.Clear();
            spiritStatus.Clear();
            soulStatus.Clear();
            mannaReserves.Clear();
            energyStatus.Clear();
            powerstate.Clear();
            alive.Clear();
        }

        public List<Character> getMembers()
        {
            return Members;
        }
        
        public int[] get_MemberStats(int placement)
        {
            int[] stats = new int[6];
           
                    stats[0] = healthStatus[placement];
                    stats[1] = spiritStatus[placement];
                    stats[2] = soulStatus[placement];
                    stats[3] = mannaReserves[placement];
                    stats[4] = energyStatus[placement];
                    stats[5] = powerstate[placement];
            
            return stats;
        }

        public bool get_MemberLife(int placement)
        {
            return alive[placement];
        }

        public List<TabPage> makeCurrent_NPCs()
        {
            int x = 0;
            int[] stats = new int[5];
            List<TabPage> NPCS = new List<TabPage>();

            foreach (Character c in Members)
            {
                if (c.NPC)
                {
                    stats[0] = healthStatus[x];
                    stats[1] = spiritStatus[x];
                    stats[2] = soulStatus[x];
                    stats[3] = mannaReserves[x];
                    stats[4] = energyStatus[x];

                    TabPage New_T = new TabPage();
                    MemberBox M = new MemberBox();
                    M.buildCurrentMember(c, stats, alive[x]);

                    New_T.Name = c.Name;
                    New_T.Text = c.Name;
                    New_T.Controls.Add(M);
                    NPCS.Add(New_T);
                }
                x++;
            }
            return NPCS;
        }

        public void Save_Party(int[] status, bool a)
        {
            foreach (int i in status)
            {
                healthStatus.Add(status[0]);
                spiritStatus.Add(status[1]);
                soulStatus.Add(status[2]);
                mannaReserves.Add(status[3]);
                energyStatus.Add(status[4]);
                powerstate.Add(status[5]);
                alive.Add(a);
            }

        }

    }
}
