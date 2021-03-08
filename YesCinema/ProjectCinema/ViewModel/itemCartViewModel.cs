using ProjectCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCinema.ViewModel
{
    public class itemCartViewModel
    {
        public ItemCart ItemCart { get; set; }
        public List<ItemCart> ITEMS { get; set; }
    }
}