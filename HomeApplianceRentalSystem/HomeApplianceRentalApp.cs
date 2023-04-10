using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeApplianceRentalSystem
{
    public partial class HomeApplianceRentalApp : Form
    {
        public HomeApplianceRentalApp()
        {
            InitializeComponent();
        }

        private void HomeApplianceRentalApp_Load(object sender, EventArgs e)
        {
            //Add column headers
            listItems.Columns.Add("ID", 50);
            listItems.Columns.Add("Type", 180);
            listItems.Columns.Add("Brand", 120);
            listItems.Columns.Add("Model", 200);
            listItems.Columns.Add("Dimensions", 250);
            listItems.Columns.Add("Colour", 120);
            listItems.Columns.Add("Energy Consumption", 220);
            listItems.Columns.Add("Monthly Fee (£)", 180);

            // Error handling for missing file path
            try
            { 
            //Read the file
                string path = @"D:\HomeApplianceRentalSystem\items.txt";    //Change file path if necessary
                using (StreamReader reader = new StreamReader(path))
                {
                    string content;
                    //Add values from items file in which each string is separated by ','
                    while ((content = reader.ReadLine()) != null)
                    {
                        string[] columns = content.Split(',');  //Separate each word by using build-in split method
                        ListViewItem items = new ListViewItem(columns[0]);
                        items.SubItems.Add(columns[1]);
                        items.SubItems.Add(columns[2]);
                        items.SubItems.Add(columns[3]);
                        items.SubItems.Add(columns[4]);
                        items.SubItems.Add(columns[5]);
                        items.SubItems.Add(columns[6]);
                        items.SubItems.Add(columns[7]);
                        listItems.Items.Add(items); // Adding item from file to listView control
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Path for File IO must be correct.", ex.Message);
            }
        }
        //Create an inheritance class of build-in IComparer class for searching items in listView control
        class ListViewItemComparer : IComparer
        {
            private int column;
            //Create constructor method
            public ListViewItemComparer(int column)
            {
                this.column = column;   //in which column we want to search items
            }
            //function to compare object for searched items, return integer 
            public int Compare(object x, object y)
            {
                ListViewItem itemX = (ListViewItem)x;
                ListViewItem itemY = (ListViewItem)y;

                string strX = itemX.SubItems[column].Text;
                string strY = itemY.SubItems[column].Text;

                return strX.CompareTo(strY);
            }
        }



        //Search textBox
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();  //Remove any white space

            if (searchText != "")
            {
                int searchColumn = 1; // Assuming the search column is the second column (index 1)
                ListViewItemComparer comparer = new ListViewItemComparer(searchColumn); //Initialize comparer object
                listItems.ListViewItemSorter = comparer;    

                foreach (ListViewItem item in listItems.Items)  //Searching the desired items in listView control by using foreach loop
                {
                    if (item.SubItems[searchColumn].Text.ToLower().Contains(searchText.ToLower()))
                    {
                        item.BackColor = Color.Yellow;  //Yellow backcolor for searching items
                    }
                    else
                    {
                        item.BackColor = Color.White;
                    }
                }
            }
            //Null condition
            else
            {
                listItems.ListViewItemSorter = null;

                foreach (ListViewItem item in listItems.Items)
                {
                    item.BackColor = Color.White;
                }
            }
        }
        //Create an inheritance class of build-in IComparer class for sorting items
        class ListViewItemComparer1 : IComparer
        {
            private int col;
            public ListViewItemComparer1(int column)
            {
                col = column;   //in which column we want to make sorting items
            }
            //Ascending order by comparing objects
            public int Compare(object x, object y)
            {
                //Formula for Ascending order which will return integer
                int returnVal = -1; 
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                return returnVal;
            }
        }

        //Sorting comboBox
        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSort.Text == "Energy Consumption") //Ascending order by energy consumption
            {
                listItems.ListViewItemSorter = new ListViewItemComparer1(6);    //Initialize object for sorting by energy consumption
                listItems.Sort();
            }
            else if(comboBoxSort.Text == "Monthly Cost") // Ascending order by monthly fee
            {
                listItems.ListViewItemSorter = new ListViewItemComparer1(7);    //Initialize object for sorting by monthly fee
                listItems.Sort();
            }
            else if (comboBoxSort.Text == "None")
            {
                listItems.ListViewItemSorter = null;    //Get back to normal form
                listItems.Refresh();
            }
        }
        // price calculation for selected item
        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listItems.SelectedItems.Count > 0)
            {
                //To avoid NullReferenceException
                try
                {
                    int totalMonths = int.Parse(txtTotalMonths.Text);   //get value from text box

                    ListViewItem selectedItem = listItems.SelectedItems[0]; //selectedItem object
                    txtPrice.Text = selectedItem.SubItems[7].Text;  //show details about selected item in textboxes
                    txtBrand.Text = selectedItem.SubItems[2].Text;
                    txtType.Text = selectedItem.SubItems[1].Text;
                    //if the user's input is negative integer, turn it into positive one
                    if(totalMonths < 0)
                    {
                        totalMonths = - totalMonths;
                    }
                    //Validation of minimum rental period for first (5) items
                    if (selectedItem.SubItems[0].Text == "1" && txtTotalMonths.Text == "1")
                    {
                        MessageBox.Show("This item must be rented for at least 2 months.  Please select item and total month again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrice.Text = ""; //clear textFields
                        txtBrand.Text = "";
                        txtType.Text = "";
                        txtTotalMonths.Text = "";
                        txtTotalPrice.Text = "";
                    }
                    else if (selectedItem.SubItems[0].Text == "2" && (txtTotalMonths.Text == "1" || txtTotalMonths.Text == "2"))
                    {
                        MessageBox.Show("This item must be rented for at least 3 months.  Please select item and total month again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrice.Text = "";
                        txtBrand.Text = "";
                        txtType.Text = "";
                        txtTotalMonths.Text = "";
                        txtTotalPrice.Text = "";
                    }
                    else if (selectedItem.SubItems[0].Text == "3" && (txtTotalMonths.Text == "1" || txtTotalMonths.Text == "2" || txtTotalMonths.Text == "3"))
                    {
                        MessageBox.Show("This item must be rented for at least 4 months.  Please select item and total month again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrice.Text = "";
                        txtBrand.Text = "";
                        txtType.Text = "";
                        txtTotalMonths.Text = "";
                        txtTotalPrice.Text = "";
                    }
                    else if (selectedItem.SubItems[0].Text == "4" && txtTotalMonths.Text == "1")
                    {
                        MessageBox.Show("This item must be rented for at least 2 months.  Please select item and total month again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrice.Text = "";
                        txtBrand.Text = "";
                        txtType.Text = "";
                        txtTotalMonths.Text = "";
                        txtTotalPrice.Text = "";
                    }
                    else if (selectedItem.SubItems[0].Text == "5" && (txtTotalMonths.Text == "1" || txtTotalMonths.Text == "2"))
                    {
                        MessageBox.Show("This item must be rented for at least 3 months.  Please select item and total month again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrice.Text = "";
                        txtBrand.Text = "";
                        txtType.Text = "";
                        txtTotalMonths.Text = "";
                        txtTotalPrice.Text = "";
                    }
                    else
                    {
                        // Parse the value of the price per month from the selected item's subitem[7]
                        int pricePerMonth = int.Parse(selectedItem.SubItems[7].Text);

                        totalPriceCalculate(totalMonths, pricePerMonth);        //Call the totalPriceCalcalate function
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please type valid data (int) in the textbox of total months.", ex.Message);
                }
                
            }
        }
        //function for the calculation of the total price
        private void totalPriceCalculate(int tm, int pm)
        {
            int itemTotalPrice;
            // Multiply the number of months with the price per month to get the total price for the selected item
            itemTotalPrice = tm* pm;
            // Set the value of txtTotalPrice to the total price
            txtTotalPrice.Text = itemTotalPrice.ToString();
        }

        //AddtoCart button
        private void cmdAddtoCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You added" + txtBrand.Text + "" + txtType.Text + " to your shopping cart. Your total price is £" + txtTotalPrice.Text , "Successfully Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
