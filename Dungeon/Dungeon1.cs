﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    internal class Dungeon1
    {
        static void Main(string[] args)
        {
            Console.Title = "***Enter the Dungeon***";
            Console.WriteLine("Dungeon Mock Up");

            /*
            //TODO Create a Player
            Console.Write("What is your name adventurer? ");
            string playerName = Console.ReadLine();
            bool exitIntro=false;
            bool enterDungeon = false;
            do
            {


                Console.Write($"{playerName} are you prepared to enter the ancient caverns below? ");
                string playerStart = Console.ReadLine();
                switch (playerStart)
                {
                    case "y":
                    case "yes":
                        Console.Clear();
                        Console.WriteLine($"Be careful {playerName}. Everyone who has gone down there failed to return.");
                        exitIntro=true;
                        enterDungeon=true;
                        break;
                    case "n":
                    case "no":
                        Console.Clear();
                        Console.WriteLine("Then return when you are prepared!");
                        exitIntro=true;
                        enterDungeon=false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Are you listening? You need to be prepared!");
                        break;
                }//end switch
            } while (exitIntro==true);

            while (enterDungeon==true)
            {
                Console.WriteLine("you are in the dungeon");
            }//end while
            */
            //Oough wrote that up but was not working the way I wanted

            bool dungeon = true;

            do
            {


                //TODO make a Monster

                //private static string GetRoom()
                //{


                //string[] roomType =
                //{
                //    "A dark and brooding Red Room", "An Upside Down Room\nYour stomach sinks as you walk along the ceiling", "The room falls into an unsettling darkness\nAn overwhelming deep and loud pulse shakes your bones from the envolped void.", "The room looks like a normal room\nSomething really feels off about it.", "Some kind of Party Room\nA monster is blowing out a candle while surrounded by friends", "This is just a Room\nFour walls, a floor, and ceiling...what were you expecting?", "There is just a 'Room' ahead of you\nWhen you walked in you couldn't tell if you entered the room or the room entered you", "You thought this was an exit but it was just a room pretending to be an exit"
                //};
                //int room = randRoom.Next(8);
                //Console.WriteLine($"\n{roomType[room]}\n\n You find a monster!\tIt is charging at you!!!");
                //}//end GetRoom()
                Console.WriteLine(GetRoom());


                bool combat = true;
                do
                {
                    Random random = new Random();
                    Console.WriteLine("\n\nAn enemy approaches. What will you do?\n\n\nA. Attack:\nB. Run Away:\nC. Character Info:\nD. Monster Info:\nE. Exit:");
                    string combatCommand = Console.ReadLine().ToLower();
                    switch (combatCommand)
                    {
                        case "a":
                        case "attack":
                            Console.Clear();
                            int randAttack = random.Next(1, 4);
                            switch (randAttack)
                            {
                                case 1:
                                case 3:
                                    Console.WriteLine("\nPOW!\nEnemy defeated! Press any key to pick up loot and move on.");
                                    Console.ReadKey(true);
                                    combat = false;
                                    dungeon = true;
                                    break;
                                case 2:
                                    Console.WriteLine("\nYou were eaten in one gulp...");
                                    Console.ReadKey(true);
                                    combat = false;
                                    dungeon = false;
                                    break;
                                default:
                                    Console.WriteLine("How did you get here?");
                                    break;
                            }//end switch attack
                            break;

                        case "b":
                        case "run":
                        case "run away":
                            Console.Clear();
                            int randRunAway = random.Next(1, 3);
                            switch (randRunAway)
                            {
                                case 1:
                                    Console.WriteLine("\nYou pointed behind the enemy and took off when they looked the other way.\nPress any key to escape to another room.");
                                    Console.ReadKey(true);
                                    combat = false;
                                    dungeon = true;
                                    break;
                                case 2:
                                    Console.WriteLine("\nYou didn't fool it! It caught back up with you!");
                                    Console.ReadKey(true);
                                    combat = true;
                                    dungeon = true;
                                    break;
                                default:
                                    Console.WriteLine("How did you get here?");
                                    break;
                            }//end switch run
                            break;

                        case "c":
                        case "character":
                        case "character info":
                            Console.Clear();

                            Console.WriteLine("\nYep it's still you.");
                            combat = true;

                            break;
                        case "d":
                        case "monster":
                        case "monster info":
                            Console.Clear();

                            Console.WriteLine("\nA monster, but bigger than you thought it would be.");
                            combat = true;
                            break;

                        case "e":
                        case "exit":
                            Console.Clear();

                            Console.WriteLine("\nYou leave the dungeon.");
                            Console.ReadKey(true);
                            combat = false;
                            dungeon = false;
                            break;
                        default:
                            Console.Clear();

                            Console.WriteLine("\nThe enemy draws closer!");
                            Console.ReadKey(true);
                            combat = true;
                            dungeon = true;
                            break;
                    }//end switch combat

                } while (combat != false);
            } while (dungeon != false);


            #region Terminator
            Console.WriteLine("\n\n\nPress any key to exit the dungeon...");
            Console.ReadKey(true);
            #endregion
        }//end Main()

        private static string GetRoom()
        {
            Random randRoom = new Random();


            string[] roomType =
            {
                "A dark and brooding Red Room",
                "An Upside Down Room\nYour stomach sinks as you walk along the ceiling",
                "The room falls into an unsettling darkness\nAn overwhelming deep and loud pulse shakes your bones from the envolped void.",
                "The room looks like a normal room\nSomething really feels off about it.",
                "Some kind of Party Room\nA monster is blowing out a candle while surrounded by friends",
                "This is just a Room\nFour walls, a floor, and ceiling...what were you expecting?",
                "There is just a 'Room' ahead of you\nWhen you walked in you couldn't tell if you entered the room or the room entered you",
                "You thought this was an exit but it was just a room pretending to be an exit"
            };
            int room = randRoom.Next(roomType.Length);
            string roomDescription = roomType[room];
            return roomDescription;
        }//end GetRoom()

    }//end class
}//end namespace
