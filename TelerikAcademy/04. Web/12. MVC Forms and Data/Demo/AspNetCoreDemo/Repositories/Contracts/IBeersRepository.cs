using AspNetCoreDemo.Models;

using System.Collections.Generic;

namespace AspNetCoreDemo.Repositories.Contracts
{
    public interface IBeersRepository
    {
        List<Beer> GetAll();
        List<Beer> FilterBy(BeerQueryParameters filterParameters);
        Beer GetById(int id);
        Beer GetByName(string name);
        bool BeerExists(string name);
        Beer Create(Beer beer);
        Beer Update(int id, Beer beer);
        Beer Delete(int id);
    }
}
