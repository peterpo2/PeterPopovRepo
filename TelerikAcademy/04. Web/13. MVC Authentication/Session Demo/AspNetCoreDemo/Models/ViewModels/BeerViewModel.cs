using AspNetCoreDemo.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreDemo.Models.ViewModels
{
    public class BeerViewModel : BeerDto
    {
        public SelectList Styles { get; set; }
    }
}
