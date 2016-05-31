using Sales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ItemComponent
{
    interface IItem
    {
        Items getItem(int itemId);
        List<Items> getAllItems();
        Items createItem(int itemGroupId, string name, string description, bool isService);
        void updateItem(Items updatedItem);
        void deleteItem(int itemId);
        ItemGroups createItemGroup(string name, string Description);
        void deleteItemGroup(int ItemGroupId);
    }
}


