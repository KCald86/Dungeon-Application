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
        public Race MonsterRace { get; set; }
        public string Description { get; set; }
        //Constructor

        public Monster(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description) : base(name, maxLife, life, block, hitChance)
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
            MonsterRace = Race.Human;
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
            //    case Race.Goblin:
            //        description = " Weak on it's own, but never underestimate it.";
            //        break;
            //    case Race.Ogre:
            //        description = " Large and in charge. This monster is ready to beat you down!";
            //        break;
            //    case Race.BirthdayBoyOgre:
            //        description = " Just trying to make the most of his day.";
            //        break;
            //    case Race.Champion:
            //        description = " One hand closed and covered, you don't know what he's going to throw at you";
            //        break;
            //    case Race.Human:
            //        description = " Common, aggressive race that's good with tools.";
            //        break;
            //    case Race.UpSideDownMonster:
            //        description = " The more you look at it the more upside down things you notice about the monster";
            //        break;
            //    case Race.UncannyValleyMimic:
            //        description = " It shifts from one unsettling object to another";
            //        break;
            //    case Race.TempHotVampire:
            //        description = " A Vampire that's about to have a heat stroke";
            //        break;
            //    case Race.Skeleton:
            //        description = " A moving Skeleton.";
            //        break;
            //    case Race.Skelington:
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



            List<Monster> monsters = new List<Monster>()
            {
            dude,
            };
            return monsters[new Random().Next(monsters.Count)];
        }//end GetMosnter()
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
    //        MonsterRace = Race.Skeleton;
    //        IsFrail = true;
    //        NoGains = true;
    //    }
    //    public Skeleton(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool isFrail, bool noGains) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
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
    //        MonsterRace = Race.Skelington;
    //        SongOfItsPeople = false;
    //    }
    //    public Skelington(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool songOfItsPeople) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
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
    //        MonsterRace = Race.Goblin;
    //        GoblinHorde = false;
    //    }
    //    public Goblin(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool goblinHorde) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
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
    //        MonsterRace = Race.Ogre;
    //        BigSmash = false;
    //        IsClumsy = true;
    //    }
    //    public Ogre(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool bigSmash, bool isClumsy) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
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
    //        MonsterRace = Race.BirthdayBoyOgre;
    //        HavingAParty = true;
    //        CryIfIWantTo = true;
    //    }
    //    public BirthdayBoyOgre(string name, int maxLife, int life, int block, int hitChance, Race monsterRace, int maxDamage, int minDamage, string description, bool havingAParty, bool cryIfIWantTo) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
    //    {
    //        HavingAParty = havingAParty;
    //        CryIfIWantTo = cryIfIWantTo;
    //    }//end FQ CTOR
    //}//end BBoyOgre 
    #endregion
}//end namespace
