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

            dbContext.Items.InsertOnSubmit(item);
            dbContext.Items.SubmitChanges();

            return item;
        }

        public void  deleteItem(int itemId)
        {
            Items itemForDelete = dbContext.Items.Where(item => item.ItemId.Equals(itemId));
            dbContext.Items.DeleteOnSubmit(itemForDelete);
            dbContext.Items.SubmitChanges();
        }

        public List<Items> getAllItems()
        {
            List<Items> fetchedItems = dbContext.Items.ToList();
            return fetchedItems;
        }

        public Items getItem(int itemId)
        {
            Items fetchedItem = dbContext.Items.Where(item => item.ItemId.Equals(itemId));
            return fetchedItem;
        }

        public void updateItem(Items updatedItem)
        {
            Items itemToUpdate = dbContext.Items.Where(item => item.ItemId.Equals(updatedItem.ItemId));
            itemToUpdate.ItemGroupId = updatedItem.ItemGroupId;
            itemToUpdate.Name = updatedItem.Name;
            itemToUpdate.Description = updatedItem.Description;
            itemToUpdate.IsService = updatedItem.IsService;

            dbContext.Items.UpdateOnSubmit(itemToUpdate);
            dbContext.Items.SubmitChanges();

        }

        ItemGroups IItem.createItemGroup(string name, string Description)
        {
            throw new NotImplementedException();
        }

        ItemGroups createItemGroup(string name, string description)
        {
            ItemGroups itemGroup = new ItemGroups();
            itemGroup.Name = name;
            itemGroup.Description = description;
            
            dbContext.ItemGroups.InsertOnSubmit(itemGroup);
            dbContext.ItemGroups.SubmitChanges();

            return itemGroup;
        }

        void IItem.deleteItemGroup(int ItemGroupId)
        {
            throw new NotImplementedException();
        }

        void deleteItemGroup(int ItemGroupId)
        {

            ItemGroups itemGroupForDelete = dbContext.ItemGroups.Where(itemGroup => itemGroup.ItemGroupId.Equals(ItemGroupId));
            dbContext.ItemGroups.DeleteOnSubmit(itemGroupForDelete);
            dbContext.ItemGroups.SubmitChanges();
        }
    }
}
