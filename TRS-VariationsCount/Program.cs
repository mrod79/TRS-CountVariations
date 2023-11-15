using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        //flavors file in project folder root path
        //?? possible changes - use openfile dialog
        string jFile = "../../../flavors.json";

        if (File.Exists(jFile))
        {
            string json = File.ReadAllText(jFile);
            List<Dictionary<string, string>> data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            Dictionary<string, int> distinctCombo = DistinctComboCount(data);
            Console.WriteLine("{0,-40} {1}", "Combination", "Occurrences");
            Console.WriteLine(new string('-', 52));

            foreach (var combination in distinctCombo)
            {
                Console.WriteLine("{0,-40} {1}", combination.Key, combination.Value);
            }
        }
        else
        {
            Console.WriteLine("no file found");
        }

        Console.ReadLine();
    }

    static Dictionary<string, int> DistinctComboCount(List<Dictionary<string, string>> data)
    {
        Dictionary<string, int> Combinations = new Dictionary<string, int>();

        foreach (var set in data)
        {
            string combo = string.Join(", ", set.Values);
            if (Combinations.ContainsKey(combo))
            {
                Combinations[combo]++;
            }
            else
            {
                Combinations.Add(combo, 1);
            }
        }

        return Combinations;
    }
}