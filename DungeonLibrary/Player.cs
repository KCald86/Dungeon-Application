using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Unique Fields/Properties
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //ctor
        public Player(string name, int maxLife, int life, int block, int hitChance, Race characterRace, Weapon equippedWeapon) : base(name, maxLife, life, block, hitChance)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }//end FQ Ctor

        //Methods
        public Player() { }//end default CTOR
        public override string ToString()
        {
            //TODO organize and make some player and monster specific races.
            string description = "";
            switch (CharacterRace)
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
            return $"{base.ToString()}\n{CharacterRace}:\t{description}\n{EquippedWeapon}";
        }//end ToString()
        public override int CalcDamage()
        {
            //return base.CalcDamage(); //returns 0
            Random random = new Random();
            return new Random().Next(EquippedWeapon.MinDamage,EquippedWeapon.MaxDamage);
        }//end CalcDamage()
        public override int CalcHitChance()
        {
            return base.HitChance + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance()


    }//end class
}//end namespace
