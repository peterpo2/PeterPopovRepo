using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Models.Contracts
{
    public interface ICream:IProduct
    {
        ScentType ScentType { get; }
    }
}
