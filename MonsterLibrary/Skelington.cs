using DungeonLibrary;

namespace MonsterLibrary
{
    public sealed class Skelington : Skeleton
    {
        public bool SongOfItsPeople { get; set; }//+MinDmg to other monsters
        public Skelington()
        {
            //Name = "BagPipe of Bones";
            //MaxLife = 6;
            //Life = 6;
            //MaxDamage = 4;
            //MinDamage = 1;
            //HitChance = 38;
            //Block = 20;
            //MonsterRace = CreatureRace.Skelington;
            //SongOfItsPeople = false;
        }

        public Skelington(string name, int maxLife, int life, int block, int hitChance, CreatureRace monsterRace, int maxDamage, int minDamage, string description, bool isFrail, bool noGains, bool songOfItsPeople) : base(name, maxLife, life, block, hitChance, monsterRace, maxDamage, minDamage, description, isFrail, noGains)
        {
            SongOfItsPeople=songOfItsPeople;
        }

        public override int CalcHitChance()
        {
            int result = HitChance;
            if (SongOfItsPeople)
            {
                result += HitChance + 5;
            }
            return result;
        }//end CalcHitChance()

        public override string ToString()
        {
            return base.ToString() +(SongOfItsPeople?"Your thoughts are being drowned out by it's doots of doom!":"You can only hear a faint ringing in your ears.");
        }//end ToString
    }//end Skelington
}