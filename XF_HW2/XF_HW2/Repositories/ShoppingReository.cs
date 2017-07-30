using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_HW2.Models;

namespace XF_HW2.Repositories
{
    public class ShoppingRepository
    {
        public List<ShoppingItem> GetShoppingItem()
        {
            List<ShoppingItem> oShoppingItems = new List<ShoppingItem>();
            oShoppingItems.Add(new ShoppingItem { Name = "Xamarin Form開發實務", Price = 650, Qty = 0 });
            oShoppingItems.Add(new ShoppingItem { Name = "ASP.net MVC5網站開發美學", Price = 580, Qty = 0 });
            oShoppingItems.Add(new ShoppingItem { Name = "Entity Framework實務精要", Price = 350, Qty = 0 });
            oShoppingItems.Add(new ShoppingItem { Name = "ASP.NET 2.0", Price = 500, Qty = 0 });
            oShoppingItems.Add(new ShoppingItem { Name = "SharePoint 2010", Price = 450, Qty = 0 });
            oShoppingItems.Add(new ShoppingItem { Name = "LG G4金裝版", Price = 3500, Qty = 0 });
            return oShoppingItems;
        }
    }
}
