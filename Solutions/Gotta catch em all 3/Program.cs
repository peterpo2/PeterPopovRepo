using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Gotta_catch__em_all
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var allPokemons = new List<Pokemon>();
            var pokemonsByType = new Dictionary<string, SortedSet<Pokemon>>();
            var input = "";
            var Sorted = new List<int>();
            var pokemonCount = 0;
            while (input != "end")
            {
                input = Console.ReadLine();
                var com = input.Split();
                var comp = new PokemonComparer();
                if (com[0] == "add")
                {
                    var pokemon = new Pokemon(com[1], com[2], int.Parse(com[3]));
                    sb.AppendLine($"Added pokemon {pokemon.Name} to position {com[4]}");
                    Sorted.Insert(int.Parse(com[4]) - 1, pokemonCount);
                    allPokemons.Add(pokemon);
                    pokemonCount++;
                    if (pokemonsByType.ContainsKey(pokemon.Type))
                    {
                        if (pokemonsByType[pokemon.Type].Count > 4)
                        {
                            if (comp.Compare(pokemon, pokemonsByType[pokemon.Type].Max) < 0)
                            {
                                pokemonsByType[pokemon.Type].Remove(pokemonsByType[pokemon.Type].Max);
                                pokemonsByType[pokemon.Type].Add(pokemon);
                            }
                        }
                        else pokemonsByType[pokemon.Type].Add(pokemon);
                    }
                    else pokemonsByType.Add(pokemon.Type, new SortedSet<Pokemon>(comp) { pokemon });
                }
                else if (com[0] == "find")
                {
                    var type = com[1];
                    sb.Append($"Type {type}: ");
                    if (pokemonsByType.ContainsKey(type))
                    {
                        foreach (var item in pokemonsByType[type])
                            sb.Append(item.ToString() + "; ");
                        sb.Remove(sb.Length - 2, 2);
                    }
                    sb.AppendLine();
                }
                else if (com[0] == "ranklist")
                {
                    var start = int.Parse(com[1]);
                    var end = int.Parse(com[2]);
                    for (int i = start - 1; i < end; i++)
                    {
                        sb.Append($"{i + 1}. {allPokemons[Sorted[i]].ToString()}; ");
                    }
                    sb.Remove(sb.Length - 2, 2);
                    sb.AppendLine();
                }
            }
            Console.Write(sb.ToString());
        }
    }
    public class Pokemon
    {
        public Pokemon(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }
        public override string ToString()
        {
            return this.Name + "(" + this.Power + ")";
        }
    }
    public class PokemonComparer : IComparer<Pokemon>
    {
        public int Compare(Pokemon x, Pokemon y)
        {
            int result = x.Name.CompareTo(y.Name);
            if (result == 0) result = -1 * (x.Power.CompareTo(y.Power));
            return result;
        }
    }
}
