using Sales.Components.PriceComponent;
using Sales.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ViewModel 
{
    class PriceViewModel : INotifyPropertyChanged
    {
        private string header;
        private int customerId;
        private DataTable dataTable;
        public DataTable DataTable
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
                PropChanged();
            }
        }
        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
                header = String.Format("Prices for Customer: {0}", customerId);
                dataTable = getPrices(customerId);
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                this.header = value;
                PropChanged();
            }

        }
        private IPrice priceManager;

        public PriceViewModel()
        {
            priceManager = new PriceImpl();
            header = "Prices for Customer: Petrov";
            dataTable = getPrices();
        }

        private DataTable getPrices(int customerId)
        {
            var tb = new DataTable(typeof(PriceTable).Name);

            PropertyInfo[] props = typeof(PriceTable).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            tb.Columns.Add("Item", typeof(int));
            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }
            
            foreach (PriceTable item in priceManager.getCustomerPrices(customerId))
            {
                var values = new object[props.Length + 1];
                values[0] = item.Items.ItemId;
                for (var i = 1; i < props.Length+1; i++)
                {
                    values[i] = props[i-1].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        private DataTable getPrices()
        {
            var tb = new DataTable(typeof(PriceTable).Name);
            
            
            tb.Columns.Add("Item", typeof(int));
            tb.Columns.Add("Price", typeof(decimal));
            tb.Columns.Add("From date", typeof(DateTime));
            tb.Columns.Add("To date", typeof(DateTime));
            tb.Columns.Add("Min qty", typeof(int));

            foreach (var item in priceManager.getAllPrices())
            {
                var values = new object[5];
                values[0] = item.Items.ItemId;
                values[1] = item.Price;
                values[2] = item.FromDate;
                values[3] = item.ToDate;
                values[4] = item.MinQty;

                tb.Rows.Add(values);
            }

            return tb;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void PropChanged([CallerMemberName]String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
