using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //Field
        private string _name;
        private WeaponType _type;
        private bool _isTwoHanded;
        private int _bonusHitChance;
        private int _maxDamage;
        private int _minDamage;

        //Props
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name

        public  WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }//end WeaponType

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value<=MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else if (value>MaxDamage)
                {
                    _minDamage = _maxDamage;
                }//end else if
                else
                {
                    _minDamage = value;
                }
            }//end set

        }//end MinDamage

        //CTOR
        public Weapon(string name, WeaponType type, bool isTwoHanded, int bonusHitChance, int maxDamage, int minDamage)
        {
            Name = name;
            Type = type;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }//end FQ CTOR

        //default ctor
        public Weapon() { }

        //Methods
        //-> Namespace.ClassName
        public override string ToString()
        {
            return $"{Name}\t\t{Type}\n" +
                $"{(IsTwoHanded ? "Two Handed" : "One Handed")}\n" +
                $"Bonus Hit Chance: {BonusHitChance}\n" +
                $"Minimum Damage: {MaxDamage}\n" +
                $"Maximum Damage: {MinDamage}\n";
        }


    }//end class Weapon
}//end namespace DungeonLibrary
