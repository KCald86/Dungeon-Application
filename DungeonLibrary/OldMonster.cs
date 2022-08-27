using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class OldMonster : Character
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
       public CreatureRace MonsterRace { get; set; }
        //Constructor
       
        public OldMonster(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage) : base(name, maxLife, life, block, hitChance)
        {
            MonsterRace = monsterRace;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }//end FQ CTOR
        public OldMonster() { }//end default CTOR

        //Method
        public override string ToString()
        {
            string description = "";
            switch (MonsterRace)
            {
                case CreatureRace.Goblin:
                    description = " Weak on it's own, but never underestimate it.";
                    break;
                case CreatureRace.Ogre:
                    description = " Large and in charge. This monster is ready to beat you down!";
                    break;
                case CreatureRace.BirthdayBoyOgre:
                    description = " Just trying to make the most of his day.";
                    break;
                case CreatureRace.Champion:
                    description = " One hand closed and covered, you don't know what he's going to throw at you";
                    break;
                case CreatureRace.Human:
                    description = " Common, aggressive CreatureRace that's good with tools.";
                    break;
                case CreatureRace.UpSideDownMonster:
                    description = " The more you look at it the more upside down things you notice about the monster";
                    break;
                case CreatureRace.UncannyValleyMimic:
                    description = " It shifts from one unsettling object to another";
                    break;
                case CreatureRace.TempHotVampire:
                    description = " A Vampire that's about to have a heat stroke";
                    break;
                case CreatureRace.Skeleton:
                    description = " A moving Skeleton.";
                    break;
                case CreatureRace.Skelington:
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

    public class Skeleton : OldMonster
    {
        public bool IsFrail { get; set; }//-MaxLife or life=1
        public bool NoGains { get; set; }//-MaxDmg or set dmg=1

        public Skeleton()
        {
            Name = "Bag of Bones";
            MaxLife =4;
            Life =4;
            MaxDamage =3;
            MinDamage =1;
            HitChance =33;
            Block =20;
            MonsterRace = CreatureRace.Skeleton;
            IsFrail = true;
            NoGains = true;
        }
        public Skeleton(string name, int maxLife, int life, int maxDamage, int minDamage, int hitChance, int block, CreatureRace monsterRace, bool isFrail, bool noGains) : base(name, maxLife, life, maxDamage, minDamage, monsterRace, hitChance, block)
        {
            IsFrail=isFrail;
            NoGains=noGains;
        }//end FQ CTOR
    }//end skeleton
    public class Skelington : OldMonster
    {
        public bool SongOfItsPeople { get; set; }//+MinDmg to other monsters
        public Skelington()
        {
            Name = "BagPipe of Bones";
            MaxLife = 6;
            Life = 6;
            MaxDamage = 4;
            MinDamage = 1;
            HitChance = 38;
            Block = 20;
            MonsterRace = CreatureRace.Skelington;
            SongOfItsPeople = false;
        }
        public Skelington(string name, int maxLife, int life, int maxDamage, int minDamage, int hitChance, int block, CreatureRace monsterRace, bool songOfItsPeople) : base (name, maxLife, life, maxDamage, minDamage, monsterRace, hitChance, block)
        {
            SongOfItsPeople=songOfItsPeople;
        }//end FQ CTOR

    }//end Skelington
    public class Goblin : OldMonster
    {
        public bool GoblinHorde { get; set; }//+goblin +MinDmg and +ToHit

        public Goblin()
        {
            Name = "Goblin Scout";
            MaxLife = 3;
            Life = 3;
            MaxDamage = 3;
            MinDamage = 1;
            HitChance = 24;
            Block = 15;
            MonsterRace = CreatureRace.Goblin;
            GoblinHorde = false;
        }
        public Goblin(string name, int maxLife, int life, int maxDamage, int minDamage, int hitChance, int block, CreatureRace monsterRace, bool goblinHorde) : base(name, maxLife, life, maxDamage, minDamage, monsterRace, hitChance, block)
        {
            GoblinHorde = goblinHorde;
        }//end FQ CTOR

    }//end goblin
    public class Ogre : OldMonster
    {
        public bool BigSmash { get; set; }//more MaxDmg
        public bool IsClumsy { get; set; }//Lower ToHit

        public Ogre()
        {
            Name = "Stumbling Ogre";
            MaxLife = 4;
            Life = 4;
            MaxDamage = 3;
            MinDamage = 1;
            HitChance = 33;
            Block = 20;
            MonsterRace = CreatureRace.Ogre;
            BigSmash=false;
            IsClumsy=true;
        }
        public Ogre(string name, int maxLife, int life, int maxDamage, int minDamage, int hitChance, int block, CreatureRace monsterRace, bool bigSmash, bool isClumsy) : base(name, maxLife, life, maxDamage, minDamage, monsterRace, hitChance, block)
        {
            BigSmash = bigSmash;
            IsClumsy = isClumsy;
        }//end FQ CTOR
    }//end Ogre
    public class BirthdayBoyOgre: OldMonster
    {
        public bool HavingAParty { get; set; }//all stats up
        public bool CryIfIWantTo { get; set; }//try to unlock an OTG at low hp
        public BirthdayBoyOgre()
        {
            Name = "Birthday Boy";
            MaxLife = 4;
            Life = 4;
            MaxDamage = 3;
            MinDamage = 1;
            HitChance = 33;
            Block = 20;
            MonsterRace = CreatureRace.BirthdayBoyOgre;
            HavingAParty = true;
            CryIfIWantTo = true;
        }
        public BirthdayBoyOgre(string name, int maxLife, int life, int maxDamage, int minDamage, int hitChance, int block, CreatureRace monsterRace, bool havingAParty, bool cryIfIWantTo) : base(name, maxLife, life, maxDamage, minDamage, monsterRace, hitChance, block)
        {
            HavingAParty= havingAParty;
            CryIfIWantTo = cryIfIWantTo;
        }//end FQ CTOR
    }//end BBoyOgre
}//end namespace
