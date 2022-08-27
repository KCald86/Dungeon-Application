using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Monster : Character
    {
        //Unique Fields/Properties
        public int MaxDamage { get; set; }
        private int _minDamage;
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //if (value > 0 && value <= MaxDamage)
                //{
                //    _minDamage = value;
                //}//end if
                //else
                //{
                //    _minDamage = 1;
                //}//end else
                _minDamage = value > MaxDamage || value < 1 ? 1 : value;
            }//end set
        }//end MinDamage
        public CreatureRace MonsterRace { get; set; }
        public string Description { get; set; }
        //Constructor

        public Monster(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description) : base(name, maxLife, life, block, hitChance)
        {
            MonsterRace = monsterRace;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }//end FQ CTOR
        public Monster()
        {
            //Character Fields
            Name = "Dude";
            MaxLife = 15;
            Life = 15;
            HitChance = 30;
            Block = 8;
            //Monster Fields
            MonsterRace = CreatureRace.Human;
            MaxDamage = 4;//goes first
            MinDamage = 1;
            Description = "Just a normal guy";
        }//end default CTOR

        //Method
        public override string ToString()
        {
            #region old switch for monsterRace and description
            //string description = "";
            //switch (MonsterRace)
            //{
            //    case CreatureRace.Goblin:
            //        description = " Weak on it's own, but never underestimate it.";
            //        break;
            //    case CreatureRace.Ogre:
            //        description = " Large and in charge. This monster is ready to beat you down!";
            //        break;
            //    case CreatureRace.BirthdayBoyOgre:
            //        description = " Just trying to make the most of his day.";
            //        break;
            //    case CreatureRace.Champion:
            //        description = " One hand closed and covered, you don't know what he's going to throw at you";
            //        break;
            //    case CreatureRace.Human:
            //        description = " Common, aggressive CreatureRace that's good with tools.";
            //        break;
            //    case CreatureRace.UpSideDownMonster:
            //        description = " The more you look at it the more upside down things you notice about the monster";
            //        break;
            //    case CreatureRace.UncannyValleyMimic:
            //        description = " It shifts from one unsettling object to another";
            //        break;
            //    case CreatureRace.TempHotVampire:
            //        description = " A Vampire that's about to have a heat stroke";
            //        break;
            //    case CreatureRace.Skeleton:
            //        description = " A moving Skeleton.";
            //        break;
            //    case CreatureRace.Skelington:
            //        description = " A Grooving Skeleton";
            //        break;
            //}//end switch 
            #endregion
            return $@"
==========* {Name} *==========
~~~~~~~ {MonsterRace} ~~~~~~~
Health: {Life}/{MaxLife}
Damage: {MinDamage} - {MaxDamage}
Avoidance: {Block}
Description:
{Description}";
        }//end ToString()

        public override int CalcDamage()
        {
            //return base.CalcDamage();
            //Random random = new Random();
            return new Random().Next(MinDamage, MaxDamage + 1);//+1 because it's exclusive
        }//end CalcDamage()

        public static Monster GetMonster()
        {
            Monster dude = new Monster();
            Monster g1 = new Goblin("Goblin Scout", 20, 20, 24, 15, CreatureRace.Goblin, 4, 1, "A scout from an aproaching goblin army", true);
            Monster sk1 = new Skeleton("Bag of Bones", 5, 5, 20, 33, CreatureRace.Skeleton, 6, 2, "Nothing but bones!", true, true);
            Monster skl1 = new Skelington("BagPipe of Bones", 9, 9, 23, 38, CreatureRace.Skelington, 7, 3, "A shambling Bag of Bones that can groan in harmony", true, false, true);
            Monster og1 = new Ogre("Stumbling Ogre", 16, 16, 28, 20, CreatureRace.Ogre, 15, 9, "Has awful depth perception", true, true);
            

            List<Monster> monsters = new List<Monster>()
            {
            g1,g1,g1,sk1,sk1,g1,g1,skl1,skl1,og1,og1,sk1,og1
            };
            return monsters[new Random().Next(monsters.Count)];
        }//end GetMosnter()
        public static Monster GetBoss()
        {
            Monster bBoy = new BirthdayBoyOgre("Birthday Boy", 50, 50, 25, 20, CreatureRace.BirthdayBoyOgre, 13, 7, "Just wants to have a good time", true);

            List<Monster> boss = new List<Monster>()
            {
            bBoy
            };
            return boss[new Random().Next(boss.Count)];
        }
        
}//end class
    //Put all these guys in the MonsterLibrary
    #region Monsters move to own class
    //public class Skeleton : Monster
    //{
    //    public bool IsFrail { get; set; }//-MaxLife or life=1 or player double dmg?
    //    public bool NoGains { get; set; }//-MaxDmg or set dmg=1

    //    public Skeleton()
    //    {
    //        Name = "Bag of Bones";
    //        MaxLife = 4;
    //        Life = 4;
    //        MaxDamage = 3;
    //        MinDamage = 1;
    //        HitChance = 33;
    //        Block = 20;
    //        MonsterRace = CreatureRace.Skeleton;
    //        IsFrail = true;
    //        NoGains = true;
    //    }
    //    public Skeleton(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool isFrail, bool noGains) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
    //    {
    //        IsFrail = isFrail;
    //        NoGains = noGains;
    //    }//end FQ CTOR
    //}//end skeleton
    //public class Skelington : Monster
    //{
    //    public bool SongOfItsPeople { get; set; }//+MinDmg to other monsters
    //    public Skelington()
    //    {
    //        Name = "BagPipe of Bones";
    //        MaxLife = 6;
    //        Life = 6;
    //        MaxDamage = 4;
    //        MinDamage = 1;
    //        HitChance = 38;
    //        Block = 20;
    //        MonsterRace = CreatureRace.Skelington;
    //        SongOfItsPeople = false;
    //    }
    //    public Skelington(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool songOfItsPeople) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
    //    {
    //        SongOfItsPeople = songOfItsPeople;
    //    }//end FQ CTOR

    //}//end Skelington
    //public class Goblin : Monster
    //{
    //    public bool GoblinHorde { get; set; }//+goblin +MinDmg and +ToHit

    //    public Goblin()
    //    {
    //        Name = "Goblin Scout";
    //        MaxLife = 3;
    //        Life = 3;
    //        MaxDamage = 3;
    //        MinDamage = 1;
    //        HitChance = 24;
    //        Block = 15;
    //        MonsterRace = CreatureRace.Goblin;
    //        GoblinHorde = false;
    //    }
    //    public Goblin(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool goblinHorde) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
    //    {
    //        GoblinHorde = goblinHorde;
    //    }//end FQ CTOR

    //}//end goblin
    //public class Ogre : Monster
    //{
    //    public bool BigSmash { get; set; }//more MaxDmg
    //    public bool IsClumsy { get; set; }//Lower ToHit

    //    public Ogre()
    //    {
    //        Name = "Stumbling Ogre";
    //        MaxLife = 4;
    //        Life = 4;
    //        MaxDamage = 3;
    //        MinDamage = 1;
    //        HitChance = 33;
    //        Block = 20;
    //        MonsterRace = CreatureRace.Ogre;
    //        BigSmash = false;
    //        IsClumsy = true;
    //    }
    //    public Ogre(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool bigSmash, bool isClumsy) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
    //    {
    //        BigSmash = bigSmash;
    //        IsClumsy = isClumsy;
    //    }//end FQ CTOR
    //}//end Ogre
    //public class BirthdayBoyOgre : Monster
    //{
    //    public bool HavingAParty { get; set; }//all stats up
    //    public bool CryIfIWantTo { get; set; }//try to unlock an OTG at low hp
    //    public BirthdayBoyOgre()
    //    {
    //        Name = "Birthday Boy";
    //        MaxLife = 4;
    //        Life = 4;
    //        MaxDamage = 3;
    //        MinDamage = 1;
    //        HitChance = 33;
    //        Block = 20;
    //        MonsterRace = CreatureRace.BirthdayBoyOgre;
    //        HavingAParty = true;
    //        CryIfIWantTo = true;
    //    }
    //    public BirthdayBoyOgre(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool havingAParty, bool cryIfIWantTo) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
    //    {
    //        HavingAParty = havingAParty;
    //        CryIfIWantTo = cryIfIWantTo;
    //    }//end FQ CTOR
    //}//end BBoyOgre 
    #endregion
}//end namespace
