using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Unique Fields/Properties
        private int _minDamage;
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage
       public Race MonsterRace { get; set; }
        //Constructor
       
        public Monster(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage) : base(name, maxLife, life, block, hitChance)
        {
            MonsterRace = monsterRace;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }//end FQ CTOR
        public Monster() { }//end default CTOR

        //Method
        public override string ToString()
        {
            string description = "";
            switch (MonsterRace)
            {
                case Race.Goblin:
                    description = " Weak on it's own, but never underestimate it.";
                    break;
                case Race.Ogre:
                    description = " Large and in charge. This monster is ready to beat you down!";
                    break;
                case Race.BirthdayBoyOgre:
                    description = " Just trying to make the most of his day.";
                    break;
                case Race.Champion:
                    description = " One hand closed and covered, you don't know what he's going to throw at you";
                    break;
                case Race.Human:
                    description = " Common, aggressive race that's good with tools.";
                    break;
                case Race.UpSideDownMonster:
                    description = " The more you look at it the more upside down things you notice about the monster";
                    break;
                case Race.UncannyValleyMimic:
                    description = " It shifts from one unsettling object to another";
                    break;
                case Race.TempHotVampire:
                    description = " A Vampire that's about to have a heat stroke";
                    break;
                case Race.Skeleton:
                    description = " A moving Skeleton.";
                    break;
                case Race.Skelington:
                    description = " A Grooving Skeleton";
                    break;
            }
            return $"{base.ToString()}\n{MonsterRace}:\t{description}\n{MaxDamage} - {MinDamage}";
        }//end ToString()

        public override int CalcDamage()
        {
            //return base.CalcDamage();
            Random random = new Random();
            return random.Next(MinDamage, MaxDamage);
        }//end CalcDamage()

    }//end class
}//end namespace
