using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {

        var inventory = new Dictionary<string, (double, string)>();

        var typeMap = new Dictionary<string, List<Tuple<string, double>>>();
        var sb = new StringBuilder();


        string exitCommand = "end";
        string command = string.Empty;

        while (command != exitCommand)
        {
            command = Console.ReadLine();
            string[] parts = command.Split();

            switch (parts[0])
            {
                case "add":
                    string itemName = parts[1];
                    double price = double.Parse(parts[2]);
                    string description = parts[3];

                    if (!inventory.ContainsKey(itemName))
                    {
                        inventory.Add(itemName, (price, description));
                        if (!typeMap.ContainsKey(description))
                        {
                            typeMap.Add(description, new List<Tuple<string, double>>());
                        }
                        typeMap[description].Add(Tuple.Create(itemName, price));
                        sb.AppendLine($"Ok: Item {itemName} added successfully");
                    }
                    else
                    {
                        sb.AppendLine($"Error: Item {itemName} already exists");
                    }
                    break;
                case "filter":
                    if (parts[2] == "type")
                    {
                        string type = parts[3];

                        if (!typeMap.ContainsKey(type))
                        {
                            sb.AppendLine($"Error: Type {type} does not exist");
                            continue;
                        }

                        var filtered = typeMap[type]
                            .OrderBy(item => item.Item2)
                            .ThenBy(item => item.Item1)
                            .Take(10)
                            .Select(x => $"{x.Item1}({x.Item2:F2})");

                        sb.AppendLine($"Ok: {string.Join(", ", filtered)}");
                    }
                    else if (parts[2] == "price")
                    {
                        if (parts[3] == "from" && parts.Length == 7)
                        {
                            double lowerBound = double.Parse(parts[4]);
                            double upperBound = double.Parse(parts[6]);

                            var filtered =
                                inventory
                                .Where(x => x.Value.Item1 >= lowerBound && x.Value.Item1 <= upperBound)
                                .OrderBy(x => x.Value.Item1)
                                .Take(10)
                                .OrderBy(x => x.Value.Item1)
                                .ThenBy(x => x.Key)
                                .Select(x => $"{x.Key}({x.Value.Item1:F2})")
                                .ToArray();

                            // Console.WriteLine();
                            sb.AppendLine($"Ok: {string.Join(", ", filtered)}");
                        }
                        else if (parts[3] == "from")
                        {
                            double lowerBound = double.Parse(parts[4]);

                            var filteredItems = inventory
                            .Where(item => item.Value.Item1 >= lowerBound)
                                .OrderBy(x => x.Value.Item1)
                                .Take(10)
                                .OrderBy(x => x.Value.Item1)
                                .ThenBy(x => x.Key)
                                .Select(x => $"{x.Key}({x.Value.Item1:F2})")
                                .ToArray();

                            sb.AppendLine($"Ok: {string.Join(", ", filteredItems)}");

                        }
                        else if (parts[3] == "to")
                        {
                            double upperBound = double.Parse(parts[4]);

                            var filteredItems = inventory
                            .Where(item => item.Value.Item1 <= upperBound)
                                .OrderBy(x => x.Value.Item1)
                                .Take(10)
                                .OrderBy(x => x.Value.Item1)
                                .ThenBy(x => x.Key)
                                .Select(x => $"{x.Key}({x.Value.Item1:F2})")
                                .ToArray();

                            sb.AppendLine($"Ok: {string.Join(", ", filteredItems)}");
                        }
                    }
                    break;
            }
        }
        Console.WriteLine(sb);
    }
}