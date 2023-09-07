using System.Text;

namespace InventoryManager
{
    public class Program
    {
        static HashSet<string> itemNames = new HashSet<string>();
        static Dictionary<string,List<Item>> itemsByType = new Dictionary<string,List<Item>>();
        static List<Item> itemsByPrice = new List<Item>();
        static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            string terminaryCommand = "end";
            string input = Console.ReadLine();

            while (input != terminaryCommand) 
            {
                string[] commandParams = input.Split(' ');
                string command = commandParams[0];

                switch (command)
                {
                    case"add":
                        AddCommand(commandParams);
                            break;
                    case"filter":
                        FilterCommand(commandParams);
                            break;
                }
                sb.AppendLine();
                input = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString());
        }
        static void AddCommand(string[] commandParams)
        {
            string itemName = commandParams[1];
            decimal itemPrice = decimal.Parse(commandParams[2]);
            string itemType = commandParams[3];

            Item item = new Item(itemName, itemPrice,itemType);

            if (TryAdd(item))
            {
                sb.Append($"Ok: Item {item.Name} added successfully");
            }
            else 
            {
                sb.Append($"Error: Item {item.Name} already exists");
            }


        }

        static bool TryAdd(Item item) 
        {
            bool itemAdded = false;

            if(itemNames.Add(item.Name)) 
            {
                itemsByPrice.Add(item);
                if(!itemsByType.ContainsKey(item.Type)) 
                {
                    itemsByType[item.Type]= new List<Item>();
                }
                itemsByType[item.Type].Add(item);
                itemAdded = true;
            }

            return itemAdded;
        }

        static void FilterCommand(string[] commandParams)
        {
            List<Item> items = new List<Item>();

            if (commandParams[2] == "type")
            {
                string type = commandParams[3];
                if (!itemsByType.ContainsKey(type))
                {
                    sb.Append($"Error: Type {type} does not exist");
                    return;
                }
                else 
                {
                    items = FilterByType(type);
                }
                
            }

            else if (commandParams.Length == 7)
            {
                //filterFromTo
                decimal from = decimal.Parse(commandParams[4]);
                decimal to = decimal.Parse(commandParams[6]);
                items = FilterFromTo(from, to);

            }

            else 
            {
                if (commandParams[3] == "from")
                {
                    decimal from = decimal.Parse(commandParams[4]);
                    decimal to = Decimal.MaxValue;
                    items = FilterFromTo(from, to);
                }

                else 
                {
                    decimal from = 0;
                    decimal to = decimal.Parse(commandParams[4]);
                    items = FilterFromTo(from, to);

                }
            }

            sb.Append("Ok: ");

            if(items.Count > 0) 
            {
                sb.Append(String.Join(", ", items));
            }

        }

        static List<Item> FilterByType(string type) 
        {
            List<Item> list = itemsByType[type]
                .OrderBy(item=>item.Price)
                .ThenBy(item=>item.Name)
                .Take(10)
                .ToList();
            return list;
        }

        static List<Item> FilterFromTo(decimal priceFrom, decimal priceTo) 
        {
            List<Item> list = itemsByPrice
                .Where(item=>item.Price>=priceFrom && item.Price<=priceTo)
                .OrderBy(item => item.Price)
                .ThenBy(item => item.Name)
                .Take(10)
                .ToList();
            return list;
        }
    }

    

    public class Item 
    {
        public Item(string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
        public string Name { get; }
        public decimal Price { get; }
        public string Type { get; }

        public override string ToString()
        {
            return $"{this.Name}({this.Price:F2})";
        }
    }
}