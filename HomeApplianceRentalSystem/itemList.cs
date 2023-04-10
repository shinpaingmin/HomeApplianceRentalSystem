using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRentalSystem
{
    internal class itemList
    {
        private string id, type, brand, model, dimensions, colour, energyConsumption, monthlyFee;
        public itemList(string i, string t, string b, string m, string d, string c, string e, string f)
        {
            id = i;
            type = t;
            brand = b;
            model = m;
            dimensions = d;
            colour = c;
            energyConsumption = e;
            monthlyFee = f;

        }
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public string Dimensions
        {
            get
            {
                return dimensions;
            }
            set
            {
                dimensions = value;
            }
        }
        public string Colour
        {
            get
            {
                return colour;
            }
            set
            {
                colour = value;
            }
        }
        public string EnergyConsumption
        {
            get
            {
                return energyConsumption;
            }
            set
            {
                energyConsumption = value;
            }
        }
        public string MonthlyFee
        {
            get
            {
                return monthlyFee;
            }
            set
            {
                monthlyFee = value;
            }
        }
       
    }
}
