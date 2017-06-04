using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheHeiganDance
{

    class Program
    {
        private const int CloudDmg = 3500;
        private const int EruptionDmg = 6000;
        private static int playerRow = 7;
        private static int playerCol = 7;
        private static double heiganHp = 3000000;
        private static int playerHp = 18500;

        static void Main(string[] args)
        {
            double playerDmg = double.Parse(Console.ReadLine());
            bool isPoisoned = false;
            string lastSpellUsed = "";

            // Change to while
            for (int turn = 0; turn < 7; turn++)
            {
                var inputLine = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
                var spellType = inputLine[0];
                var spellRow = int.Parse(inputLine[1]);
                var spellCol = int.Parse(inputLine[2]);

                if (isPoisoned)
                {
                    lastSpellUsed = "Plague Cloud";
                    playerHp -= CloudDmg;
                    isPoisoned = false;
                }
                
                // Player Attacks
                heiganHp -= playerDmg;
                if (heiganHp <= 0)
                {
                    PrintResult(lastSpellUsed);
                    return;
                }

                // Heigan Attacks
                if (IsPlayerInRange(spellRow, spellCol))
                {
                    // Player moves UP
                    if (playerRow - 1 >= 0 && playerRow - 1 < spellRow -1)
                    {
                        playerRow--;
                    }
                    // Player moves Right
                    else if (playerCol + 1 < 15 && playerCol + 1 > spellCol + 1)
                    {
                        playerCol++;
                    }
                    // Player moves Down
                    else if (playerRow + 1 < 15 && playerRow + 1 > spellRow + 1)
                    {
                        playerRow++;
                    }
                    // Player moves Left
                    else if (playerCol - 1 >= 0 && playerCol - 1 < spellCol - 1)
                    {
                        playerCol--;
                    }
                    // Player stays in place and takes dmg
                    else
                    {
                        lastSpellUsed = spellType;
                        if (spellType == "Cloud")
                        {
                            lastSpellUsed = "Plague Cloud";
                            playerHp -= CloudDmg;
                            isPoisoned = true;
                        }
                        else
                        {
                            lastSpellUsed = "Eruption";
                            playerHp -= EruptionDmg;
                        }

                        // Player Dies
                        if (playerHp <= 0)
                        {
                            PrintResult(lastSpellUsed);
                            return;
                        }
                    }
                }
            }
        }

        private static bool IsPlayerInRange(int spellRow, int spellCol)
        {
            if ((playerRow >= spellRow - 1 || playerRow <= spellRow + 1) && 
                (playerCol >= spellCol - 1 || playerCol <= spellCol + 1))
            {
                return true;
            }
            return false;
        }

        private static void PrintResult(string lastSpellUsed)
        {
            if (heiganHp <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHp:f2}");
            }

            if (playerHp <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpellUsed}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHp}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }
    }
}
