using DungeonLibrary;
using MonsterLibrary;
using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Dungeon
{
    internal class Dungeon1
    {
        static void Main(string[] args)
        {
            Console.Title = "***Enter the Dungeon***";
            Console.WriteLine("Dungeon Mock Up");

            int score = 0;
            string userContinue;
            bool endlessMode = false;
            bool combat = true;
            Monster monster = Monster.GetMonster();
            #region First thoughts
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
            #endregion

            Weapon sword = new Weapon("Test Sword", WeaponType.Sword, false, 60, 20, 12);
            Console.Write("Hello Adventurer! What is your Name? ");
            string userName = Console.ReadLine();

            #region PlayRace Selection
            var races = Enum.GetValues(typeof(PlayRace));
            int index = 1;
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine($"{index}) ");
            //    index++;
            //}
            foreach (var race in races)
            {
                Console.WriteLine($"{index}) {race}");
                index++;

            }
            Console.WriteLine("Please select a race from the list above...");
            //9 items or less, you can use a Console.Readcey(). anymore and you'll need a readline.
            int userInput = int.Parse(Console.ReadLine()) - 1;//subtracting 1 to make it zero-based
            //CAST INT TO A RACE
            PlayRace userRace = (PlayRace)userInput;
            Console.WriteLine(userRace);
            Console.Clear();
            #endregion

            Player player = new Player(userName, 50, 50, 25, 40, userRace, sword);

            bool dungeon = true;
            bool boss = false;
            bool exit = false;
            while (exit == false)
            {

                do
                {


                    if (score == 4 && endlessMode == false)//you win...for now
                    {
                        Console.WriteLine($"You brutally slain the ogre who was trying to throw a party his friends would never forget, but it's quieter in the nearby town that hired you...\n\nYour job is done here, but you sense there could be other challenges that await you deeper inside.\n\nWould you like to go deeper? (y/n)");
                        userContinue = Console.ReadLine().ToLower();
                        switch (userContinue)
                        {
                            case "y":
                                Console.WriteLine("Your life in the dungeon awaits...");
                                endlessMode = true;
                                boss = false;
                                combat = true;
                                break;
                            case "n":
                                Console.WriteLine($"You decide to return to town a hero\n******************=-{score}-=******************");
                                exit = true;
                                combat = false;
                                dungeon = false;
                                break;
                            default:
                                break;
                        }
                    }


                    else if (score == 3)//boss
                    {
                        Console.WriteLine($"A giant club hits you from behind knocking you through a wall and into a party room. The ogre who wanted his birthday party inside this dungeon has had his party ruined!");
                        monster = Monster.GetBoss();
                        combat = true;

                        do
                        {
                            // Random random = new Random(); for old combat
                            Console.WriteLine("\n\n" + monster.Name + " approaches. What will you do?\n\n\nA. Attack:\nB. Run Away:\nC. Character Info:\nD. Monster Info:\nE. Exit:");
                            string combatCommand = Console.ReadLine().ToLower();
                            switch (combatCommand)
                            {
                                case "a":
                                case "attack":
                                    Console.Clear();
                                    #region Old Combat
                                    //int randAttack = random.Next(1, 4);
                                    //switch (randAttack)
                                    //{
                                    //    case 1:
                                    //    case 3:
                                    //        Console.WriteLine("\nPOW!\nEnemy defeated! Press any key to pick up loot and move on.");
                                    //        Console.ReadKey(true);
                                    //        combat = false;
                                    //        dungeon = true;
                                    //        break;
                                    //    case 2:
                                    //        Console.WriteLine("\nYou were eaten in one gulp...");
                                    //        Console.ReadKey(true);
                                    //        combat = false;
                                    //        dungeon = false;
                                    //        break;
                                    //    default:
                                    //        Console.WriteLine("How did you get here?");
                                    //        break;
                                    //}//end switch attack 
                                    #endregion
                                    Combat.DoBattle(player, monster);
                                    if (monster.Life <= 0)
                                    {
                                        //IT'S DEAD!
                                        //Could put logic hee to have the player get items, life, or something similiar due to beating the monster.
                                        score++;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nYou killed {monster.Name}");
                                        Console.Beep(700, 500);
                                        Console.ResetColor();
                                        combat = false;//break out of the while and check for conditions, if not met then get new room and a new monster

                                    }//end if monster dies
                                    if (player.Life <= 0)//put after switch if you have items or non combat situations where you could reduce health and die
                                    {
                                        Console.WriteLine("Dude.... You died!\a");
                                        dungeon = true;//leave the entire game
                                    }//end if player dies
                                    break;


                                case "b":
                                case "run":
                                case "run away":
                                    Console.Clear();
                                    Random random = new Random();
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
                                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                                            Combat.DoAttack(monster, player);
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

                                    Console.WriteLine($"\nYou give yourself a pat-down and know...\n {player}\nMonsters Defeated: {score}");//zero exception
                                    combat = true;

                                    break;
                                case "d":
                                case "monster":
                                case "monster info":
                                    Console.Clear();

                                    Console.WriteLine($"You strain your eyes to look at the {monster.MonsterRace} and see\n{monster}");
                                    combat = true;
                                    break;

                                case "e":
                                case "exit":
                                    Console.Clear();

                                    Console.WriteLine("\nYou leave the dungeon.");
                                    Console.ReadKey(true);
                                    exit = true;
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

                        } while (combat != false); //end while boss combat
                    }


                    #region GetRoom 1.0
                    //private static string GetRoom()
                    //{


                    //string[] roomType =
                    //{
                    //    "A dark and brooding Red Room", "An Upside Down Room\nYour stomach sinks as you walk along the ceiling", "The room falls into an unsettling darkness\nAn overwhelming deep and loud pulse shakes your bones from the envolped void.", "The room looks like a normal room\nSomething really feels off about it.", "Some kind of Party Room\nA monster is blowing out a candle while surrounded by friends", "This is just a Room\nFour walls, a floor, and ceiling...what were you expecting?", "There is just a 'Room' ahead of you\nWhen you walked in you couldn't tell if you entered the room or the room entered you", "You thought this was an exit but it was just a room pretending to be an exit"
                    //};
                    //int room = randRoom.Next(8);
                    //Console.WriteLine($"\n{roomType[room]}\n\n You find a monster!\tIt is charging at you!!!");
                    //}//end GetRoom() 
                    #endregion

                    else
                    {

                        Console.WriteLine(GetRoom());
                        monster = Monster.GetMonster();
                        combat = true;
                        do
                        {
                            // Random random = new Random(); for old combat
                            Console.WriteLine("\n\n" + monster.Name + " approaches. What will you do?\n\n\nA. Attack:\nB. Run Away:\nC. Character Info:\nD. Monster Info:\nE. Exit:");
                            string combatCommand = Console.ReadLine().ToLower();
                            switch (combatCommand)
                            {
                                case "a":
                                case "attack":
                                    Console.Clear();
                                    #region Old Combat
                                    //int randAttack = random.Next(1, 4);
                                    //switch (randAttack)
                                    //{
                                    //    case 1:
                                    //    case 3:
                                    //        Console.WriteLine("\nPOW!\nEnemy defeated! Press any key to pick up loot and move on.");
                                    //        Console.ReadKey(true);
                                    //        combat = false;
                                    //        dungeon = true;
                                    //        break;
                                    //    case 2:
                                    //        Console.WriteLine("\nYou were eaten in one gulp...");
                                    //        Console.ReadKey(true);
                                    //        combat = false;
                                    //        dungeon = false;
                                    //        break;
                                    //    default:
                                    //        Console.WriteLine("How did you get here?");
                                    //        break;
                                    //}//end switch attack 
                                    #endregion
                                    Combat.DoBattle(player, monster);
                                    if (monster.Life <= 0)
                                    {
                                        //IT'S DEAD!
                                        //Could put logic hee to have the player get items, life, or something similiar due to beating the monster.
                                        score++;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nYou killed {monster.Name}");
                                        Console.Beep(700, 500);
                                        Console.ResetColor();
                                        combat = false;//break out of the while and check for conditions, if not met then get new room and a new monster

                                    }//end if monster dies
                                    if (player.Life <= 0)//put after switch if you have items or non combat situations where you could reduce health and die
                                    {
                                        Console.WriteLine("Dude.... You died!\a");
                                        dungeon = true;//leave the entire game
                                    }//end if player dies
                                    break;


                                case "b":
                                case "run":
                                case "run away":
                                    Console.Clear();
                                    Random random = new Random();
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
                                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                                            Combat.DoAttack(monster, player);
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

                                    Console.WriteLine($"\nYou give yourself a pat-down and know...\n {player}\nMonsters Defeated: {score}");//zero exception
                                    combat = true;

                                    break;
                                case "d":
                                case "monster":
                                case "monster info":
                                    Console.Clear();

                                    Console.WriteLine($"You strain your eyes to look at the {monster.MonsterRace} and see\n{monster}");
                                    combat = true;
                                    break;

                                case "e":
                                case "exit":
                                    Console.Clear();

                                    Console.WriteLine("\nYou leave the dungeon.");
                                    Console.ReadKey(true);
                                    exit = true;
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

                        } while (combat != false); //end while normal combat
                    }

                    //do
                    //{
                    //    // Random random = new Random(); for old combat
                    //    Console.WriteLine("\n\n" + monster.Name + " approaches. What will you do?\n\n\nA. Attack:\nB. Run Away:\nC. Character Info:\nD. Monster Info:\nE. Exit:");
                    //    string combatCommand = Console.ReadLine().ToLower();
                    //    switch (combatCommand)
                    //    {
                    //        case "a":
                    //        case "attack":
                    //            Console.Clear();
                    //            #region Old Combat
                    //            //int randAttack = random.Next(1, 4);
                    //            //switch (randAttack)
                    //            //{
                    //            //    case 1:
                    //            //    case 3:
                    //            //        Console.WriteLine("\nPOW!\nEnemy defeated! Press any key to pick up loot and move on.");
                    //            //        Console.ReadKey(true);
                    //            //        combat = false;
                    //            //        dungeon = true;
                    //            //        break;
                    //            //    case 2:
                    //            //        Console.WriteLine("\nYou were eaten in one gulp...");
                    //            //        Console.ReadKey(true);
                    //            //        combat = false;
                    //            //        dungeon = false;
                    //            //        break;
                    //            //    default:
                    //            //        Console.WriteLine("How did you get here?");
                    //            //        break;
                    //            //}//end switch attack 
                    //            #endregion
                    //            Combat.DoBattle(player, monster);
                    //            if (monster.Life <= 0)
                    //            {
                    //                //IT'S DEAD!
                    //                //Could put logic hee to have the player get items, life, or something similiar due to beating the monster.
                    //                score++;
                    //                Console.ForegroundColor = ConsoleColor.Green;
                    //                Console.WriteLine($"\nYou killed {monster.Name}");
                    //                Console.Beep(700, 500);
                    //                Console.ResetColor();
                    //                combat = false;//break out of the while and check for conditions, if not met then get new room and a new monster

                    //            }//end if monster dies
                    //            if (player.Life <= 0)//put after switch if you have items or non combat situations where you could reduce health and die
                    //            {
                    //                Console.WriteLine("Dude.... You died!\a");
                    //                dungeon = true;//leave the entire game
                    //            }//end if player dies
                    //            break;


                    //        case "b":
                    //        case "run":
                    //        case "run away":
                    //            Console.Clear();
                    //            Random random = new Random();
                    //            int randRunAway = random.Next(1, 3);
                    //            switch (randRunAway)
                    //            {
                    //                case 1:
                    //                    Console.WriteLine("\nYou pointed behind the enemy and took off when they looked the other way.\nPress any key to escape to another room.");
                    //                    Console.ReadKey(true);
                    //                    combat = false;
                    //                    dungeon = true;
                    //                    break;
                    //                case 2:
                    //                    Console.WriteLine("\nYou didn't fool it! It caught back up with you!");
                    //                    Console.ReadKey(true);
                    //                    Console.WriteLine($"{monster.Name} attacks you as you flee!");
                    //                    Combat.DoAttack(monster, player);
                    //                    combat = true;
                    //                    dungeon = true;
                    //                    break;
                    //                default:
                    //                    Console.WriteLine("How did you get here?");
                    //                    break;
                    //            }//end switch run
                    //            break;

                    //        case "c":
                    //        case "character":
                    //        case "character info":
                    //            Console.Clear();

                    //            Console.WriteLine($"\nYou give yourself a pat-down and know...\n {player}\nMonsters Defeated: {score}");//zero exception
                    //            combat = true;

                    //            break;
                    //        case "d":
                    //        case "monster":
                    //        case "monster info":
                    //            Console.Clear();

                    //            Console.WriteLine($"You strain your eyes to look at the {monster.MonsterRace} and see\n{monster}");
                    //            combat = true;
                    //            break;

                    //        case "e":
                    //        case "exit":
                    //            Console.Clear();

                    //            Console.WriteLine("\nYou leave the dungeon.");
                    //            Console.ReadKey(true);
                    //            exit = true;
                    //            combat = false;
                    //            dungeon = false;
                    //            break;
                    //        default:
                    //            Console.Clear();

                    //            Console.WriteLine("\nThe enemy draws closer!");
                    //            Console.ReadKey(true);
                    //            combat = true;
                    //            dungeon = true;
                    //            break;
                    //    }//end switch combat

                    //} while (combat != false); //end while combat
                } while (dungeon != false);
            }//end while exit is false
            Console.WriteLine("You defeated " + score + " Monster" + (score == 1 ? "." : "s."));

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
                "Some kind of Party Room\nA monster is blowing out a candle while surrounded by friends",
                "A dark and brooding Red Room",
                "An Upside Down Room\nYour stomach sinks as you walk along the ceiling",
                "The room falls into an unsettling darkness\nAn overwhelming deep and loud pulse shakes your bones from the envolped void.",
                "The room looks like a normal room\nSomething really feels off about it.",
                "This is just a Room\nFour walls, a floor, and ceiling...what were you expecting?",
                "There is just a 'Room' ahead of you\nWhen you walked in you couldn't tell if you entered the room or the room entered you",
                "You thought this was an exit but it was just a room pretending to be an exit"
            };
            int room = randRoom.Next(roomType.Length);
            string roomDescription = roomType[room];
            return roomDescription;
        }//end GetRoom()
        #region GetMonster attempt 1 outline moved
        //private static string GetMonster()
        //{
        //    Random randomMonster = new Random();

        //    string[] monsterPool =
        //    {

        //    };
        //    int monsterV =randomMonster.Next(monsterPool.Length);
        //    var spawnMonster=monsterPool[monsterV];
        //    return spawnMonster;
        //}//end GetMonster() 
        #endregion
    }//end class
}//end namespace
