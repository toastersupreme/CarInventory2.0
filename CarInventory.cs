// Author: Willem Vidler
// Last Modified: Macrh 14th, 2021
// Description: A program for my NETD 2202 class where the user is able to insert information about cars into a form

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarInventory2._0
{
    public partial class formCarInventory : Form
    {
        //Declare a collection of all cars as a List.
        private List<Cars> carList = new List<Cars>();
        // An index representing the current selected car.
        private int selectedIndex = -1;

        public formCarInventory()
        {
            InitializeComponent();
        }

        #region "Event Handlers"

        private void ButtonEnterClick(object sender, EventArgs e)
        {
            // Empty the error label; it will fill with NEW errors if anything is wrong.
            textBoxValidation.Clear();

            // Check if the car is valid.
            if (IsCarValid(comboBoxMake.Text, textBoxModel.Text, comboBoxYear.Text, textBoxPrice.Text))
            {
                // Customer details are valid; create a car object.
                Cars newCarToAdd = new Cars(comboBoxMake.Text, textBoxModel.Text, comboBoxYear.Text, textBoxPrice.Text, checkBoxNew.Checked);

                // If a customer is currently selected...
                if (selectedIndex >= 0)
                {
                    // Replace the old version of that customer with the new one!
                    carList[selectedIndex] = newCarToAdd;
                }
                else
                {
                    // Otherwise, add a customer with the entered details to the end of the list.
                    carList.Add(newCarToAdd);
                }

                // Refresh the entire listView.
                PopulateListView(carList);

                // Reset the form to allow new entries.
                SetDefaults();
            }
        }

        /// <summary>
        /// Resets the data input fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonResetClick(object sender, EventArgs e)
        {
            SetDefaults();
        }

        /// <summary>
        /// Close the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExitClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// When a car is clicked on in the List View it brings the cars information back up into the data input fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarSelected(object sender, EventArgs e)
        {
            // If the list is populated and something is selected...
            if (listViewEntries.Items.Count > 0 && listViewEntries.FocusedItem != null)
            {
                // ...fill in the entry fields with values based on the selected customer.
                comboBoxMake.Text = listViewEntries.FocusedItem.SubItems[1].Text;
                textBoxModel.Text = listViewEntries.FocusedItem.SubItems[2].Text;
                comboBoxYear.Text = listViewEntries.FocusedItem.SubItems[3].Text;
                textBoxPrice.Text = listViewEntries.FocusedItem.SubItems[4].Text;
                checkBoxNew.Checked = listViewEntries.FocusedItem.Checked;

                // Set the selectedIndex to match the listView.
                selectedIndex = listViewEntries.FocusedItem.Index;
            }
            else
            {
                // If nothing is selected, set the selectedIndex to -1.
                selectedIndex = -1;
            }
        }

        #endregion

        #region "Functions"

        /// <summary>
        /// Converts the car passed in to a ListViewItem and adds it to listViewEntries
        /// </summary>
        /// <param name="newCar"></param>
        private void PopulateListView(List<Cars> carList)
        {
            // Clear the listView to start re-populating it.
            listViewEntries.Items.Clear();
            int count = 1;

            foreach (Cars newCar in carList)
            {
                // Declare and instantiate a new ListViewItem.
                ListViewItem carItem = new ListViewItem();

                // Allow the program to modify the ListView's checkboxes.
                carItem.Checked = newCar.NewStatus;
              
                carItem.SubItems.Add(newCar.Make);
                carItem.SubItems.Add(newCar.Model);
                carItem.SubItems.Add(newCar.Year);
                carItem.SubItems.Add(newCar.Price);

                // Add the customerItem to the ListView.
                listViewEntries.Items.Add(carItem);
             
            }
        }

        /// <summary>
        /// Reset the form's input fields to their default states.
        /// </summary>
        private void SetDefaults()
        {
            // Resets fields to default state.
            comboBoxMake.SelectedIndex = -1;
            textBoxModel.Clear();
            comboBoxYear.SelectedIndex = -1;
            textBoxPrice.Clear();
            checkBoxNew.Checked = false;
            listViewEntries.SelectedItems.Clear();
            textBoxValidation.Clear();
            selectedIndex = -1;

            // Set a default focus.
            comboBoxMake.Focus();
        }

        /// <summary>
        /// Checks wether input is valid or not
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        private bool IsCarValid(string make, string model, string year, string price)
        {
            // Assume the car is valid.
            bool isValid = true;

            // Check the first input.
            if (make == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textBoxValidation.Text += "You must select a make.\n";
            }
            // Check the second input.
            if (model == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textBoxValidation.Text += "You must enter a model.\n";
            }
            // Check the third input.
            if (year == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textBoxValidation.Text += "You must enter a year.";
            }
            // Check the fourth input.
            if (price == String.Empty)
            {
                // If it's not valid, set isValid = false and write an error message.
                isValid &= false;
                textBoxValidation.Text += "You must enter a price.";
            }

            return isValid;
        }

        #endregion

    }
}
