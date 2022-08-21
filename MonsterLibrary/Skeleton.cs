using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Skeleton : Monster
    {
        public bool IsFrail { get; set; }//-MaxLife or life=1
        public bool NoGains { get; set; }//-MaxDmg or set dmg=1

        public Skeleton()
        {
            //Name = "Bag of Bones";
            //MaxLife = 4;
            //Life = 4;
            //MaxDamage = 3;
            //MinDamage = 1;
            //HitChance = 33;
            //Block = 20;
            //MonsterRace = Race.Skeleton;
            //IsFrail = true;
            //NoGains = true;
        }

        public Skeleton(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool isFrail, bool noGains) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
        {
            IsFrail=isFrail;
            NoGains=noGains;
        }//end FQ CTOR
        public override int CalcDamage()
        {
            if (NoGains==true)
            {
                return 1;
            }
            return new Random().Next(MinDamage,MaxDamage+1);//will use isFrail for double dmg but to player unless I want something to cause the player to be frail
        }
    }//end skeleton
}
