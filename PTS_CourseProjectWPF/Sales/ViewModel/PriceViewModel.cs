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
        public DataTable dataTable
        {
            set
            {
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
            header = "Prices";
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
            
            PropertyInfo[] props = typeof(PriceTable).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            tb.Columns.Add("Item", typeof(int));
            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in priceManager.getAllPrices())
            {
                var values = new object[props.Length + 1];
                values[0] = item.Items.ItemId;
                for (var i = 1; i < props.Length + 1; i++)
                {
                    values[i] = props[i - 1].GetValue(item, null);
                }

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
