using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Ogre : Monster
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
            BigSmash = false;
            IsClumsy = true;
        }
        public Ogre(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool bigSmash, bool isClumsy) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
        {
            BigSmash = bigSmash;
            IsClumsy = isClumsy;
        }//end FQ CTOR
        //TODO Methods

    }//end Ogre
}
