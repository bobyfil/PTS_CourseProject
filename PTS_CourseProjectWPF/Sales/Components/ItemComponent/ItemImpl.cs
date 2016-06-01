using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Model;

namespace Sales.ItemComponent
{
    public class ItemImpl : IItem
    {
        private SalesDBEntities dbContext;
        public ItemImpl() {
            dbContext = new SalesDBEntities();
    }
        public Items createItem(int itemGroupId, string name, string description, bool isService)
        {
            Items item = new Items();
            item.ItemGroupId = itemGroupId;
            item.Name = name;
            item.Description = description;
            item.IsService = isService;

            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            return item;
        }

        public void  deleteItem(int itemId)
        {
            Items itemForDelete = dbContext.Items.Where(item => item.ItemId.Equals(itemId)).SingleOrDefault();
            dbContext.Items.Remove(itemForDelete);
            dbContext.SaveChanges();
        }

        public List<Items> getAllItems()
        {
            List<Items> fetchedItems = dbContext.Items.ToList();
            return fetchedItems;
        }

       

        public Items getItem(int itemId)
        {
            Items fetchedItem = dbContext.Items.Where(item => item.ItemId.Equals(itemId)).SingleOrDefault();
            return fetchedItem;
        }

        public void updateItem(Items updatedItem)
        {
            Items itemToUpdate = dbContext.Items.Where(item => item.ItemId.Equals(updatedItem.ItemId)).SingleOrDefault();
            dbContext.Entry(itemToUpdate).CurrentValues.SetValues(updatedItem);
            dbContext.SaveChanges();

        }


       public ItemGroups createItemGroup(string name, string description)
        {
            ItemGroups itemGroup = new ItemGroups();
            itemGroup.Name = name;
            itemGroup.Description = description;
            
            dbContext.ItemGroups.Add(itemGroup);
            dbContext.SaveChanges();

            return itemGroup;
        }



        public void deleteItemGroup(int ItemGroupId)
        {
            ItemGroups itemGroupForDelete = dbContext.ItemGroups.Where(itemGroup => itemGroup.ItemGroupId.Equals(ItemGroupId)).SingleOrDefault();
            dbContext.ItemGroups.Remove(itemGroupForDelete);
            dbContext.SaveChanges();
        }
    }
}
