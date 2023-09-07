using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AspNetCoreDemo.Models
{
	public class Style
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//[JsonIgnore]
		public List<Beer> Beers { get; set;}
	}
}
