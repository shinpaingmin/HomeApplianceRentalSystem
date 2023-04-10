using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeApplianceRentalSystem
{
    public partial class frmAdminDashboard : Form
    {
        //Creating a list to store itemList object in which all items from listView control will be stored.
        List<itemList> allItems = new List<itemList>(); 
        public frmAdminDashboard()
        {
            InitializeComponent();
        }
        //Inserting headers when the program is loaded
        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
  
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
                        string[] columns = content.Split(',');
                        ListViewItem items = new ListViewItem(columns[0]);
                        items.SubItems.Add(columns[1]);
                        items.SubItems.Add(columns[2]);
                        items.SubItems.Add(columns[3]);
                        items.SubItems.Add(columns[4]);
                        items.SubItems.Add(columns[5]);
                        items.SubItems.Add(columns[6]);
                        items.SubItems.Add(columns[7]);
                        listItems.Items.Add(items); // Adding item from file to listView control
                        //Adding item from file to object
                        itemList addObjects = new itemList(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7]);
                        //Adding object to list
                        allItems.Add(addObjects);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("File Path for File IO must be correct.", ex.Message);
            }
        }


        //Showing selected items from listView to txtFields
        private void listItems_Click(object sender, EventArgs e)
        {
            if (listItems.SelectedItems.Count > 0)
            {
                txtID.Text = listItems.SelectedItems[0].SubItems[0].Text;
                txtType.Text = listItems.SelectedItems[0].SubItems[1].Text;
                txtBrand.Text = listItems.SelectedItems[0].SubItems[2].Text;
                txtModel.Text = listItems.SelectedItems[0].SubItems[3].Text;
                txtDimensions.Text = listItems.SelectedItems[0].SubItems[4].Text;
                txtColour.Text = listItems.SelectedItems[0].SubItems[5].Text;
                txtEConsump.Text = listItems.SelectedItems[0].SubItems[6].Text;
                txtFee.Text = listItems.SelectedItems[0].SubItems[7].Text;
                
            }
        }
        //Edit or Update button
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            string path = @"D:\UpdateHomeApplianceRentalSystem\items.txt";    //Change file path if necessary
            // Find the data for the selected item in the list of custom objects
            itemList selectedItemData = allItems.FirstOrDefault(item => 
            item.ID == listItems.SelectedItems[0].SubItems[0].Text &&
            item.Type == listItems.SelectedItems[0].SubItems[1].Text &&
            item.Brand == listItems.SelectedItems[0].SubItems[2].Text &&
            item.Model == listItems.SelectedItems[0].SubItems[3].Text &&
            item.Dimensions == listItems.SelectedItems[0].SubItems[4].Text &&
            item.Colour == listItems.SelectedItems[0].SubItems[5].Text &&
            item.EnergyConsumption == listItems.SelectedItems[0].SubItems[6].Text &&
            item.MonthlyFee == listItems.SelectedItems[0].SubItems[7].Text
            );

            if (selectedItemData != null)
            {
                // Modify the data for the selected item in the list of custom objects
                selectedItemData.ID = txtID.Text;
                selectedItemData.Type = txtType.Text;
                selectedItemData.Brand = txtBrand.Text;
                selectedItemData.Model = txtModel.Text;
                selectedItemData.Dimensions = txtDimensions.Text;
                selectedItemData.Colour = txtColour.Text;
                selectedItemData.EnergyConsumption = txtEConsump.Text;
                selectedItemData.MonthlyFee = txtFee.Text;

                // Write the updated list of custom objects data to the file
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (itemList item in allItems)
                    {
                        writer.WriteLine($"{item.ID},{item.Type},{item.Brand},{item.Model},{item.Dimensions},{item.Colour},{item.EnergyConsumption},{item.MonthlyFee}");
                  
                    }
                }
            }
            //Update data in listView control
            if (listItems.SelectedItems.Count > 0)
            {
                listItems.SelectedItems[0].SubItems[0].Text = txtID.Text;
                listItems.SelectedItems[0].SubItems[1].Text = txtType.Text;
                listItems.SelectedItems[0].SubItems[2].Text = txtBrand.Text;
                listItems.SelectedItems[0].SubItems[3].Text = txtModel.Text;
                listItems.SelectedItems[0].SubItems[4].Text = txtDimensions.Text;
                listItems.SelectedItems[0].SubItems[5].Text = txtColour.Text;
                listItems.SelectedItems[0].SubItems[6].Text = txtEConsump.Text;
                listItems.SelectedItems[0].SubItems[7].Text = txtFee.Text;
            }

            

            //Clear text fields
            txtID.Text = "";
            txtType.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtDimensions.Text = "";
            txtColour.Text = "";
            txtEConsump.Text = "";
            txtFee.Text = "";
        }
        //Delete button
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //use error handling for the situation of no selected item
            try { 

                //Get the index of the selected item of the listView for deleting item in list
                int index = listItems.SelectedIndices[0];

                //Remove the item from the list
                allItems.RemoveAt(index);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Please select an item from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Deleting item in listView control
            if (listItems.SelectedItems.Count > 0)
            {
                listItems.Items.Remove(listItems.SelectedItems[0]);
            }

            //Delete and rewrite items in the file
            string path = @"D:\HomeApplianceRentalSystem\items.txt";    //Change file path if necessary 
            using (StreamWriter writer = new StreamWriter(path))
            {
                //Updating all items from list to file using foreach loop
                foreach (itemList i in allItems)
                {
                    //Looping all objects with the format to write in the file
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", i.ID, i.Type, i.Brand, i.Model, i.Dimensions, i.Colour, i.EnergyConsumption, i.MonthlyFee);
                }
            }
            //Clear text fields
            txtID.Text = "";
            txtType.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtDimensions.Text = "";
            txtColour.Text = "";
            txtEConsump.Text = "";
            txtFee.Text = "";
        }
        //Add Button
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem(txtID.Text);    //Initialize object to store data from textFields
            newItem.SubItems.Add(txtType.Text);
            newItem.SubItems.Add(txtBrand.Text);
            newItem.SubItems.Add(txtModel.Text);
            newItem.SubItems.Add(txtDimensions.Text);
            newItem.SubItems.Add(txtColour.Text);
            newItem.SubItems.Add(txtEConsump.Text);
            newItem.SubItems.Add(txtFee.Text);
            listItems.Items.Add(newItem);   //Adding a new row in listView control

            //Adding item from text box to object
            itemList addObject = new itemList(txtID.Text, txtType.Text, txtBrand.Text, txtModel.Text, txtDimensions.Text, txtColour.Text, txtEConsump.Text, txtFee.Text);
            //Add object to list
            allItems.Add(addObject);
            //Store in items file
            string path = @"D:\HomeApplianceRentalSystem\items.txt";    //Change file path if necessary
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(txtID.Text + ", " + txtType.Text + ", " + txtBrand.Text + ", " + txtModel.Text + ", " + txtDimensions.Text +
                    ", " + txtColour.Text + ", " + txtEConsump.Text + ", " + txtFee.Text);
            }
            //Clear text fields
            txtID.Text = "";
            txtType.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtDimensions.Text = "";
            txtColour.Text = "";
            txtEConsump.Text = "";
            txtFee.Text = "";
        }
    }
}
