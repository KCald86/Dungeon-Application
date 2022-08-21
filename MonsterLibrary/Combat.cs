using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Combat
    {
        //This class will not have any fields, properties, or constructors, It is just
        //a method warehouse for combat functionality

        //Methods are static

        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll.
            Random random = new Random();
            int diceRoll = random.Next(1, 101);
            Thread.Sleep(300);//1000 is one second
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //we hit!
                //Calcuate the damage and save it to a variable!
                int damageDelt = attacker.CalcDamage();

                //assign value to defender's life
                defender.Life -= damageDelt;

                //write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDelt} damage!");
                Console.ResetColor();
            }//end if
            else
            {
                //attack missed!
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else

        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //player attacks first
            DoAttack(player, monster);
            //monster attacks second, if they're alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }//end if

        }//end DoBattle()

    }//end class
}//end namespace
