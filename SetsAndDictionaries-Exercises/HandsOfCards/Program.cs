using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> peopleWithCards = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine()
                .Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "JOKER")
            {
                var name = input[0];
                var setOfCards = input[1].Split(new string[] {", ", " ", ","}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (peopleWithCards.ContainsKey(name))
                {
                    foreach (var card in setOfCards)
                    {
                        peopleWithCards[name].Add(card);
                    }
                }
                else
                {
                    peopleWithCards.Add(name, new HashSet<string>(setOfCards));
                }

                //Console.WriteLine($"Name:{name}=>cards:{string.Join(",", setOfCards)}");

                input = Console.ReadLine()
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            foreach (var person in peopleWithCards)
            {
                Console.WriteLine($"{person.Key}: {CalculateValue(person.Value)}");
            }
        }

        private static int CalculateValue(HashSet<string> cards)
        {
            var result = 0;

            foreach (var card in cards)
            {
                var type = card.Substring(card.Length - 1, 1);
                var power = card.Substring(0, card.Length - 1);
                var resultType = 0;
                var resultPower = 0;

                switch (type)
                {
                    case "C":
                        resultType = 1;
                        break;
                    case "D":
                        resultType = 2;
                        break;
                    case "H":
                        resultType = 3;
                        break;
                    case "S":
                        resultType = 4;
                        break;
                }

                switch (power)
                {
                    case "J":
                        resultPower = 11;
                        break;
                    case "Q":
                        resultPower = 12;
                        break;
                    case "K":
                        resultPower = 13;
                        break;
                    case "A":
                        resultPower = 14;
                        break;
                    default:
                        resultPower = int.Parse(power);
                        break;
                }

                result += resultPower * resultType;
            }

            return result;
        }
    }
}
