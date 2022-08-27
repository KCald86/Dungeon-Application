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
        public PlayRace PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //ctor
        public Player(string name, int maxLife, int life, int block, int hitChance, PlayRace playerRace, Weapon equippedWeapon) : base(name, maxLife, life, block, hitChance)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
        }//end FQ Ctor

        //Methods
        public Player() { }//end default CTOR
        public override string ToString()
        {
            //TODO organize and make some player and monster specific races.
            string description = "";
            switch (PlayerRace)
            {
                case PlayRace.Human:
                    description = " Common, aggressive race that's good with tools.";
                    //PlayerRace = PlayRace.Human;
                    break;
                case PlayRace.Elf:
                    description = " Long-lived and even longer hair. Nimble and precice.";
                    //PlayerRace = PlayRace.Elf;

                    break;
                case PlayRace.Gnome:
                    description = " Would not approach with a non-gnome standard ten foot pole out of getting 'gnome'd'";
                    //PlayerRace = PlayRace.Gnome;

                    break;
                case PlayRace.Dwarf:
                    description = " Stout and sturdy. Great at making tools and digging";
                    //PlayerRace = PlayRace.Dwarf;

                    break;
                //case CreatureRace.BirthdayBoyOgre:
                //    description = " Just trying to make the most of his day.";
                //    break;
                //case CreatureRace.Champion:
                //    description = " One hand closed and covered, you don't know what he's going to throw at you";
                //    break;
                #region MonsterRaces I threw in here
                //case CreatureRace.Goblin:
                //    description = " Weak on it's own, but never underestimate it.";
                //    break;
                //case CreatureRace.Ogre:
                //    description = " Large and in charge. This monster is ready to beat you down!";
                //    break;
                //case CreatureRace.Skeleton:
                //    description = " A moving Skeleton.";
                //    break;
                //case CreatureRace.Skelington:
                //    description = " A Grooving Skeleton";
                //    break;
                //case CreatureRace.UpSideDownMonster:
                //    description = " The more you look at it the more upside down things you notice about the monster";
                //    break;
                //case CreatureRace.UncannyValleyMimic:
                //    description = " It shifts from one unsettling object to another";
                //    break;
                //case CreatureRace.TempHotVampire:
                //    description = " A Vampire that's about to have a heat stroke";
                //    break; 
                    #endregion
            }
            return $"{base.ToString()}\n{PlayerRace}\n{EquippedWeapon}";//zero exception
        }//end ToString()
        public override int CalcDamage()
        {
            //return base.CalcDamage(); //returns 0
            Random random = new Random();
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage);
        }//end CalcDamage()
        public override int CalcHitChance()
        {
            return base.HitChance + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance()


    }//end class
}//end namespace
