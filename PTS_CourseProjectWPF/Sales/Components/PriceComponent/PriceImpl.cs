using Sales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Components.PriceComponent
{
    class PriceImpl : IPrice
    {
        private SalesDBEntities context;

        public void addPriceCustomer(int customerId, decimal price, DateTime fromDate, DateTime toDate = default(DateTime), int qty = 0)
        {
            PriceTable pt = new PriceTable
            {
                CustomerId = customerId,
                Price = price,
                FromDate = fromDate,
                ToDate = toDate,
                MinQty = qty
            };
            using (context = new SalesDBEntities())
            {
                context.PriceTable.Add(pt);
                context.SaveChanges();
            }
        }

        public void addPriceItem(int customerId, int itemId, decimal price, DateTime fromDate, DateTime toDate = default(DateTime), int qty = 0)
        {
            PriceTable pt = new PriceTable
            {
                CustomerId = customerId,
                Price = price,
                FromDate = fromDate,
                ToDate = toDate,
                MinQty = qty
            };
            
            using (context = new SalesDBEntities())
            {
                context.PriceTable.Add(pt);
                context.SaveChanges();
            }
        }

        public void addPriceItemGroup(int customerId, int itemGroupId, decimal price, DateTime fromDate, DateTime toDate = default(DateTime), int qty = 0)
        {
            PriceTable pt = new PriceTable
            {
                CustomerId = customerId,
                Price = price,
                FromDate = fromDate,
                ToDate = toDate,
                MinQty = qty
            };

            using (context = new SalesDBEntities())
            {
                context.PriceTable.Add(pt);
                context.SaveChanges();
            }
        }

        public IEnumerable<PriceTable> getAllPrices()
        {
            IEnumerable<PriceTable> records;
            using (context = new SalesDBEntities())
            {
                records = from pt in context.PriceTable
                          select pt;
            }
            return records;

        }

        public IEnumerable<PriceTable> getCustomerPrices(int customerId)
        {
            IEnumerable<PriceTable> records;
            using (context = new SalesDBEntities())
            {
                records = from pt in context.PriceTable
                          where pt.CustomerId == customerId
                          select pt;
            }
            return records;
        }


        public IEnumerable<PriceTable> getItemGroupPrices(int itemGroupId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<PriceTable> getItemPrices(int itemId)
        {
            throw new NotImplementedException();
        }

        public PriceTable getPrice(int customerId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
