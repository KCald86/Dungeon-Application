using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class BirthdayBoyOgre : Monster
    {
        public bool HavingAParty { get; set; }//all stats up
        /*public bool CryIfIWantTo { get; set; }*///try to unlock an OTG at low hp
        public BirthdayBoyOgre()
        {
            //Name = "Birthday Boy";
            //MaxLife = 4;
            //Life = 4;
            //MaxDamage = 3;
            //MinDamage = 1;
            //HitChance = 33;
            //Block = 20;
            //MonsterRace = Race.BirthdayBoyOgre;
            //HavingAParty = true;
            //CryIfIWantTo = true;
        }
        public BirthdayBoyOgre(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool havingAParty) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
        {
            HavingAParty = havingAParty;
            //CryIfIWantTo = cryIfIWantTo;
        }//end FQ CTOR
        //TODO Methods
        //public override int 
    }//end BBoyOgre 
}
