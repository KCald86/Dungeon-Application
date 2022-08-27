using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Goblin : Monster
    {
        public bool GoblinHorde { get; set; }//+goblin +MinDmg and +ToHit

        public Goblin()
        {
            //Name = "Goblin Scout";
            //MaxLife = 3;
            //Life = 3;
            //HitChance = 24;
            //Block = 15;
            //MonsterRace = CreatureRace.Goblin;
            //MaxDamage = 3;
            //MinDamage = 1;
            //GoblinHorde = false;
        }
        public Goblin(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool goblinHorde) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
        {
            GoblinHorde = goblinHorde;
        }//end FQ CTOR

        public override int CalcDamage()
        {
            if (GoblinHorde)
            {
                return new Random().Next(MinDamage+3, MaxDamage + 4);
            }
            return base.CalcDamage();
        }//end CalcDamage()
        public override int CalcHitChance()
        {
            int result = HitChance;
            if (GoblinHorde)
            {
                result += HitChance + 8;
            }
            return result;
        }//end CalcHitChance()
        //TODO ToString
    }//end goblin
}
