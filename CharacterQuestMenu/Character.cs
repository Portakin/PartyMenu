using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CharacterQuestMenu
{
    [Serializable]
    public class Character
    {                
        public int Level { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Race { get; set; }
        public int Age { get; set; } = 30;
        public int Difficulty { get; set; }
        public int Religion { get; set; } = 0;

        public int PartySlot { get; set; }
        //stats
        public int Constitution { get; set; }
        public int Resistence { get; set; }
        public int Skill { get; set; }
        public int intelligence { get; set; }
        //skills
        public int Tech { get; set; }
        public int MageTech { get; set; }
        public int combatArts { get; set; }
        public int weaponArts { get; set; }

        public bool Demon { get; set; }  = false;
        public bool Ether = false;
        public bool NPC = false;

        //private item[] Inventory;
        //private effects[] effects;
        //private techniques[] techniques;
        //private Covenant[] covenants;

        //Energy & Bonus
        public int mannaTraining { get; set; } = 0;
        public int mannaBonus { get; set; } = 0;
        public int LifeBonus { get; set; } = 0;
                
        public int bodyEnergy { get; set; }
        public int mentalEnergy { get; set; }
        public int memoryEnergy { get; set; }
        public int spiritualEnergy { get; set; }
        public int demonicEnergy { get; set; }
        public int soulEnergy { get; set; }

        //needs to be unlocked
        public bool dimensional_drifter { get; set; } = false;
        public bool attribute { get; set; } = false;
        public int Dark { get; set; } = 0;
        public int Light { get; set; } = 0;
        public int Evil { get; set; } = 0;
        public List<string> Training = new List<string>();
        public bool[] Forbidden_Magic { get; set; } = new bool[3];

        public string info { get; set; }

        //repetitive rolls don't accumilate
        public bool StatRoll = false;
        
        //makes bonuses for Character Creation
        public void CalculateStats()
        {                                        
            //base skills and stats
            switch( this.Race )
            {
                case 1:     //Ciaha

                    this.Constitution = 4;
                    this.Resistence = 1;
                    this.Skill = 3;
                    this.intelligence = 2;
                    this.Difficulty = 1;

                    this.weaponArts = 30;
                    this.combatArts = 25;
                    this.Tech = 10;
                    this.MageTech = 5;

                    this.bodyEnergy = 50 + this.Level / 2;
                    this.mentalEnergy = 20 + this.Level / 2;
                    this.spiritualEnergy = 20 + this.Level / 2;
                    this.memoryEnergy = 5 + this.Level / 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 10;
                   
                    break;
                case 2:     //Magian

                    this.Constitution = 1;
                    this.Resistence = 3;
                    this.Skill = 2;
                    this.intelligence = 4;
                    this.Difficulty = 1;

                    this.weaponArts = 5;
                    this.combatArts = 15;
                    this.Tech = 20;
                    this.MageTech = 30;

                    this.bodyEnergy = 5 + this.Level / 2;
                    this.mentalEnergy = 30 + this.Level / 2;
                    this.spiritualEnergy = 20 + this.Level / 2;
                    this.memoryEnergy = 15 + this.Level / 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 30;
                    
                    break;
                case 3:     //Necrain

                    this.Constitution = 2;
                    this.Resistence = 4;
                    this.Skill = 2;
                    this.intelligence = 3;
                    this.Difficulty = 1;

                    this.weaponArts = 15;
                    this.combatArts = 20;
                    this.Tech = 15;
                    this.MageTech = 20;

                    this.bodyEnergy = 25 + this.Level / 2;
                    this.mentalEnergy = 25 + this.Level / 2;
                    this.spiritualEnergy = 25 + this.Level / 2;
                    this.memoryEnergy = 20 + this.Level / 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 20;

                    this.Training.Add("Transcendence");
                    break;
                case 4:     //Arbiter
                    this.Constitution = 2;
                    this.Resistence = 2;
                    this.Skill = 2;
                    this.intelligence = 2;                    
                    this.Difficulty = 1;

                    this.weaponArts = 20;
                    this.combatArts = 10;
                    this.Tech = 30;
                    this.MageTech = 20;

                    this.bodyEnergy = 20 + this.Level / 2;
                    this.mentalEnergy = 40 + this.Level / 2;
                    this.spiritualEnergy = 20 + this.Level / 2;
                    this.memoryEnergy = 20 + this.Level / 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 10;

                    break;
                case 5:     //Adept
                    this.Constitution = 3;
                    this.Resistence = 2;
                    this.Skill = 4;
                    this.intelligence = 1;                    
                    this.Difficulty = 1;

                    this.weaponArts = 10;
                    this.combatArts = 30;
                    this.Tech = 5;
                    this.MageTech = 15;

                    this.bodyEnergy = 30 + this.Level / 2;
                    this.mentalEnergy = 10 + this.Level / 2;
                    this.spiritualEnergy = 50 + this.Level / 2;
                    this.memoryEnergy = 15 + this.Level / 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 10;

                    break;
                case 6:     //Riaha
                            //***************copy of adepts right now !!!************************

                    this.Constitution = 4;
                    this.Resistence = 1;
                    this.Skill = 3;
                    this.intelligence = 2;                    
                    this.Difficulty = 1;

                    this.weaponArts = 30;
                    this.combatArts = 25;
                    this.Tech = 10;
                    this.MageTech = 5;

                    this.bodyEnergy = this.Level / 2;
                    this.mentalEnergy = this.Level / 2;
                    this.spiritualEnergy = this.Level / 2;
                    this.memoryEnergy = this.Level / 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 0;

                    break;
                case 7:     //Celestials
                    this.Constitution = 7;
                    this.Resistence = 7;
                    this.Skill = 7;
                    this.intelligence = 7;
                    this.Difficulty = 5;

                    this.weaponArts = 30;
                    this.combatArts = 30;
                    this.Tech = 0;
                    this.MageTech = 50;

                    this.bodyEnergy = Level*2;
                    this.mentalEnergy = Level * 2;
                    this.spiritualEnergy = Level * 2;
                    this.memoryEnergy = Level * 2;
                    this.soulEnergy = 0;
                    this.mannaTraining = 100;

                    break;
            }//End Switch

            if (this.Demon == true)
            {
                this.demonicEnergy = this.Level / 2;
                { this.Constitution++; this.Skill++; this.Resistence++; this.intelligence++; this.Difficulty += 1; }
            }
            else
                this.demonicEnergy = 0;
           
            //skill bonuses from stats
            this.weaponArts += 5*this.Skill;
            this.combatArts += 5*this.Skill;
            this.Tech += 5*this.intelligence;
            this.MageTech += 5*this.intelligence;
            
            //*****prevents stat rolls from multipying********
            this.StatRoll = false;

        }
        public void CalculateEnergy_party_only()
        {
            switch (this.Race)
            {
                case 1:     //Ciaha
                    this.bodyEnergy = LimitToRange(50 + this.Level / 2, 0, 100);
                    this.mentalEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.spiritualEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.memoryEnergy = LimitToRange(5 + this.Level / 2, 0 ,100);
                    this.soulEnergy = 0;

                   // this.Manna = LimitToRange(this.Level + 20 + this.mannaBonus * 5, 0, 100);

                    if (this.Demon == true)
                        this.demonicEnergy = LimitToRange(this.Level, 0, 100);
                    else
                        this.demonicEnergy = 0;
                    break;
                case 2:     //Magian

                    this.bodyEnergy = LimitToRange(5 + this.Level / 2, 0, 100);
                    this.mentalEnergy = LimitToRange(30 + this.Level / 2, 0, 100);
                    this.spiritualEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.memoryEnergy = LimitToRange(15 + this.Level / 2, 0, 100);
                    this.soulEnergy = 0;

                  //  this.Manna = LimitToRange(this.Level + 20 + this.mannaBonus * 5, 0, 100);

                    if (this.Demon == true)
                        this.demonicEnergy = LimitToRange(this.Level, 0, 100);
                    else
                        this.demonicEnergy = 0;
                    break;
                case 3:     //Necrain
                    this.bodyEnergy = LimitToRange(25 + this.Level / 2, 0, 100);
                    this.mentalEnergy = LimitToRange(25 + this.Level / 2, 0, 100);
                    this.spiritualEnergy = LimitToRange(25 + this.Level / 2, 0, 100);
                    this.memoryEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.soulEnergy = 0;

                   // this.Manna = LimitToRange(this.Level + 20 + this.mannaBonus * 5, 0, 100);

                    if (this.Demon == true)
                        this.demonicEnergy = LimitToRange(this.Level, 0, 100);
                    else
                        this.demonicEnergy = 0;
                    break;
                case 4:     //Arbiter
                    this.bodyEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.mentalEnergy = LimitToRange(40 + this.Level / 2, 0, 100);
                    this.spiritualEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.memoryEnergy = LimitToRange(20 + this.Level / 2, 0, 100);
                    this.soulEnergy = 0;

                   // this.Manna = LimitToRange(this.Level + 20 + this.mannaBonus * 5, 0, 100);

                    if (this.Demon == true)
                        this.demonicEnergy = LimitToRange(this.Level, 0, 100);
                    else
                        this.demonicEnergy = 0;
                    break;
                case 5:     //Adept
                    this.bodyEnergy = LimitToRange(30 + this.Level / 2, 0, 100);
                    this.mentalEnergy = LimitToRange(10 + this.Level / 2, 0 ,100);
                    this.spiritualEnergy = LimitToRange(50 + this.Level / 2, 0, 100);
                    this.memoryEnergy = LimitToRange(15 + this.Level / 2, 0, 100);                   
                    this.soulEnergy = 0;

                   // this.Manna = LimitToRange(this.Level + 20 + this.mannaBonus * 5, 0, 100);

                    if (this.Demon == true)
                        this.demonicEnergy = LimitToRange(this.Level, 0, 100);
                    else
                        this.demonicEnergy = 0;
                    break;
                case 6:     //Riaha
                            //***************copy of adepts right now !!!************************

                    this.bodyEnergy = LimitToRange(this.Level, 0, 100);
                    this.mentalEnergy = LimitToRange(this.Level, 0, 100);
                    this.spiritualEnergy = LimitToRange(this.Level, 0, 100);
                    this.memoryEnergy = LimitToRange(this.Level, 0, 100);                    
                    this.soulEnergy = 0;

                    if (this.Demon == true)
                        this.demonicEnergy = LimitToRange(this.Level, 0, 100);
                    else
                        this.demonicEnergy = 0;
                    break;
                case 7:     //Celestials
                    this.bodyEnergy = 100;
                    this.mentalEnergy = 100;
                    this.spiritualEnergy = 100;
                    this.memoryEnergy = 100;
                    this.soulEnergy = 0;
                    break;
                }
            }
        private int LimitToRange(int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }
            
        public void AddStatRoll(int iRoll, int sRoll, int stRoll, int rRoll)
        {
            this.Constitution += stRoll;
            this.Skill += sRoll;
            this.Resistence += rRoll;
            this.intelligence += iRoll;

            this.weaponArts += sRoll * 5;
            this.combatArts += sRoll * 5;
            this.Tech += iRoll * 5;
            this.MageTech += iRoll * 5;
        }
        public void UnlockAttribute(string Attribute)
        {
            

        }

    }//END CLASS
}
