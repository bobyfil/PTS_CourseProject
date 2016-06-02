using Sales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Components.PriceComponent
{
    interface IPrice
    {
        IEnumerable<PriceTable> getAllPrices();
        IEnumerable<PriceTable> getCustomerPrices(int customerId);
        IEnumerable<PriceTable> getItemGroupPrices(int itemGroupId);
        IEnumerable<PriceTable> getItemPrices(int itemId);
        PriceTable getPrice(int customerId, int itemId);
        void addPriceItem(int customerId, int itemId, decimal price, DateTime fromDate, DateTime toDate = default(DateTime), int qty = 0);
        void addPriceItemGroup(int customerId, int itemGroupId, decimal price, DateTime fromDate, DateTime toDate = default(DateTime), int qty = 0);
        void addPriceCustomer(int customerId, decimal price, DateTime fromDate, DateTime toDate = default(DateTime), int qty = 0);
    }
}
