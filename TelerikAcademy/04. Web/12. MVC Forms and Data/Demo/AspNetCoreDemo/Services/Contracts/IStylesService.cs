using System.Collections.Generic;

using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services.Contracts
{
    public interface IStylesService
    {
        List<Style> GetAll();
        Style GetById(int id);
    }
}
