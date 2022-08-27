using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public sealed class Mustache : Monster
    {
        public bool IsCombed { get; set; }
        public bool IsMagnificent { get; set; }

        public Mustache() { }//end defult CTOR

        public Mustache(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool isCombed, bool isMagnificent) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description)
        {
            IsCombed = isCombed;
            IsMagnificent = isMagnificent;
        }//end FQ CTOR

    public override int CalcBlock()
        {
            int result = Block;
            if (IsMagnificent)
            {
                result += Block / 2;
            }//end if
            return result;
        }//end override CalcBlock()
        //TODO ToString

    }//end child class
}//end namespace
