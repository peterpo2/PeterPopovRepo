﻿using System.Collections.Generic;

using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories.Contracts
{
    public interface IStylesRepository
    {
        List<Style> GetAll();
        Style GetById(int id);
    }
}
