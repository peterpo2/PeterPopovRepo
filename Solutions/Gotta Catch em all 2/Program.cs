using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;

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
            var output = new StringBuilder();

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
                    output.Append($"Added pokemon {name} to position {position}");
                }
                else if (tokens[0] == "find")
                {
                    string type = tokens[1];

                    var pokemons = system.FindByType(type);
                    
                    if (pokemons.Count > 0)
                    {
                        pokemons = pokemons.OrderByDescending(x => x.Power).ToList();
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
                        if (i!= 0)
                        {
                            Console.Write("; "); 
                        }
                        var pokemon = ranking[i];
                        Console.Write($"{i+1}. {pokemon.Name}({pokemon.Power})");
                    }
                    Console.WriteLine();
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
                    Console.WriteLine($"Added pokemon {name} to position {position}");
                }

                //if (pokemonDict.ContainsKey(name))
                //{
                //    // If a pokemon with the same name already exists, remove it from the dictionaries
                //    var existingPokemon = pokemonDict[name];
                //    rankList.Remove(existingPokemon.Position);
                //}

                //if (position >= 1 && position <= pokemons.Count + 1)
                //{
                //    // If the specified position is valid, insert the new pokemon at the specified position
                //    pokemons.Insert(position - 1, addedPokemon);
                //}
                //else
                //{
                //    // Otherwise, add the new pokemon to the end of the list
                //    pokemons.Add(addedPokemon);
                //    position = pokemons.Count;
                //}

                //// Update the position of the pokemon and add it to the dictionaries
                //addedPokemon.Position = position;
                //pokemonDict[name] = addedPokemon;
                //rankList[position] = addedPokemon;
                //pokemonsByType.TryGetValue(type, out List<Pokemon> typeList);


                //if (typeList == null)
                //{
                //    typeList = new List<Pokemon>();
                //    pokemonsByType.Add(type, typeList);
                //}

                //typeList.Add(addedPokemon);

                
                // If the new pokemon was not added to the end of the list, update the positions of the other pokemons
                //if (position != pokemons.Count)
                //{
                //    for (int i = position; i < pokemons.Count; i++)
                //    {
                //        var pokemon = pokemons[i];
                //        pokemon.Position = i + 1;
                //        rankList[pokemon.Position] = pokemon;
                //    }
                //}
            }

            public List<Pokemon> FindByType(string type)
            {
                pokemonDict = pokemonDict .OrderBy(x => x.Key);

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
                //pokemons = pokemonDict.Values.OrderByDescending(p => p.Power).ToList();
                List<Pokemon> pokemons = pokemonDict.Values.OrderByDescending(p => p.Power).ToList();
                foreach (Pokemon pokemon in pokemons)
                {
                    Console.Write($"Name: {pokemon.Name}, ");
                    Console.Write($"Type: {pokemon.Type}, ");
                    Console.Write($"Power: {pokemon.Power}");
                    Console.WriteLine(); // move to the next line after printing one Pokemon's information
                }

                for (int i = 0; i < pokemons.Count; i++)
                {
                    pokemons[i].Position = i + 1;
                    rankList[pokemons[i].Position] = pokemons[i];
                }
            }
        }
    }
}
