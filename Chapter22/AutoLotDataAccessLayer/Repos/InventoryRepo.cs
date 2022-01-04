using AutoLotDataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotDataAccessLayer.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll()
            => Context.Inventory.OrderBy(i => i.Name).ToList();
    }
}
