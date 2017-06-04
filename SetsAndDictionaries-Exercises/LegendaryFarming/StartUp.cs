using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> legendaryMats = new Dictionary<string, int>();
            legendaryMats["motes"] = 0;
            legendaryMats["fragments"] = 0;
            legendaryMats["shards"] = 0;
            SortedDictionary<string, int> junkMats = new SortedDictionary<string, int>();
            bool mustGoOn = true;

            char[] ignore = new char[] { ' ' };
            while (mustGoOn)
            {
                List<string> input = Console.ReadLine().ToLower().Split(ignore, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < input.Count; i += 2)
                {
                    string itemType = input[i + 1];
                    int itemQuantity = Convert.ToInt32(input[i]);

                    if (itemType == "motes" || itemType == "fragments" || itemType == "shards")
                    {
                        legendaryMats[itemType] += itemQuantity;

                        if (legendaryMats.Values.Max() >= 250)
                        {
                            if (legendaryMats["shards"] >= 250)
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                                legendaryMats["shards"] -= 250;
                            }

                            if (legendaryMats["fragments"] >= 250)
                            {
                                Console.WriteLine("Valanyr obtained!");
                                legendaryMats["fragments"] -= 250;
                            }

                            if (legendaryMats["motes"] >= 250)
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                                legendaryMats["motes"] -= 250;
                            }

                            PrintResult(legendaryMats, junkMats);
                            mustGoOn = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMats.ContainsKey(itemType))
                        {
                            junkMats[itemType] = itemQuantity;
                        }
                        else
                        {
                            junkMats[itemType] += itemQuantity;
                        }
                    }
                }
            }
        }

        private static void PrintResult(Dictionary<string, int> legendaryMats, SortedDictionary<string, int> junkMats)
        {
            foreach (var kvp in legendaryMats.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMats)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
