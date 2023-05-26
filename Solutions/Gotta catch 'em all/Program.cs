using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Gotta_catch__em_all
{
    public class Program
    {
        static Dictionary<string, List<Pokemon>> pokemonsByType = new Dictionary<string, List<Pokemon>>();
        static Dictionary<int, Pokemon> rankList = new Dictionary<int, Pokemon>();
        static List<Pokemon> pokemons = new List<Pokemon>();
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            var system = new PokemonSystem();

            while (input[0] != "end")
            {
                string[] tokens = input;

                if (tokens[0] == "add")
                {
                    string name = tokens[1];
                    string type = tokens[2];
                    int power = int.Parse(tokens[3]);
                    int position = int.Parse(tokens[4]);

                    system.AddPokemon(name, type, power, position);
                }
                else if (tokens[0] == "find")
                {
                    string type = tokens[1];

                    var pokemons = system.FindByType(type);

                    if (pokemons.Count > 0)
                    {
                        Console.WriteLine("Type {0}: {1}", type, string.Join("; ", pokemons.Select(p => $"{p.Name}({p.Power})")));
                    }
                    else
                    {
                        Console.WriteLine("No pokemons found of type {0}", type);
                    }
                }
                if (tokens[0] == "ranklist")
                {
                    int start = int.Parse(tokens[1]);
                    int end = int.Parse(tokens[2]);

                    var ranking = system.GetRanking(start, end);

                    for (int i = 0; i < ranking.Count; i++)
                    {
                        var pokemon = ranking[i];
                        Console.WriteLine($"{start + i}. {pokemon.Name}({pokemon.Power})");
                    }
                }

                //Bug: The code should check if the tokens array has at least 3 elements before trying to parse the start and end values.

                input = Console.ReadLine().Split();
            }
        }
        public class Pokemon
        {
            public Pokemon(string name, string type, int power, int position)
            {
                Name = name;
                Type = type;
                Power = power;
                Position = position;
            }

            public string Name { get; set; }
            public string Type { get; set; }
            public int Power { get; set; }
            public int Position { get; set; }
        }

        public class PokemonSystem
        {
            private Dictionary<string, Pokemon> pokemonDict = new Dictionary<string, Pokemon>();

            public void AddPokemon(string name, string type, int power, int position)
            {
                var addedPokemon = new Pokemon(name, type, power, position);

                if (!pokemonDict.ContainsKey(name))
                {
                    pokemonDict.Add(name, addedPokemon);
                }
                else
                {
                    var existingPokemon = pokemonDict[name];
                    existingPokemon.Type = type;
                    existingPokemon.Power = power;
                    existingPokemon.Position = position;
                    addedPokemon = existingPokemon;
                }

                pokemonsByType.TryGetValue(type, out List<Pokemon> typeList);

                if (typeList == null)
                {
                    typeList = new List<Pokemon>();
                    pokemonsByType.Add(type, typeList);
                }

                typeList.Add(addedPokemon);

                rankList[position] = addedPokemon;

                Console.WriteLine($"Added pokemon {name} to position {position}");
            }

            public List<Pokemon> FindByType(string type)
            {
                if (pokemonsByType.ContainsKey(type))
                {
                    return pokemonsByType[type];
                }
                else
                {
                    return new List<Pokemon>();
                }
            }

            public List<Pokemon> GetRanking(int start, int end)
            {
                var ranking = new List<Pokemon>();

                for (int i = start; i <= end; i++)
                {
                    if (rankList.TryGetValue(i, out Pokemon pokemon))
                    {
                        ranking.Add(pokemon);
                    }
                }

                return ranking;
            }
            private void UpdatePositions()
            {
                //pokemons = pokemons.OrderByDescending(p => p.Power).ToList();
                pokemons = pokemonDict.Values.OrderByDescending(p => p.Power).ToList();

                for (int i = 0; i < pokemons.Count; i++)
                {
                    pokemons[i].Position = i + 1;
                    rankList[pokemons[i].Position] = pokemons[i];
                }
            }
        }
    }
}
