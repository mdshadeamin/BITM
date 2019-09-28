using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CoffeeShopUI
{
    public partial class CoffeeShop : Form
    {
        public CoffeeShop()
        {
            InitializeComponent();
        }

        string message = "";
        List<string> customerName = new List<string>{ };
        List<string> contactNo = new List<string>{ };
        List<string> address = new List<string>{ };
        List<string> order = new List<string>{ };
        List<int> quantity = new List<int>{ };

        private void AddCustomer()
        {
            if (orderComboBox.Text == "")
            {
                MessageBox.Show("You must select an item");
                return;
            }
            else
            {
                customerName.Add(customerNameTextBox.Text);
                contactNo.Add(contactNoTextBox.Text);
                address.Add(addressTextBox.Text);
                order.Add(orderComboBox.Text);
                quantity.Add(Convert.ToInt32(quantityTextBox.Text));
            }
        }


        private void ShowCustomer()
        {

            for (int i = 0; i < customerName.Count(); i++)
            {

                message = "Customer Name: " + customerName[i] + "\n" + "Contact No: " + contactNo[i] + "\n" + "Address: " + address[i] + "\n" + "Order: " + order[i]+"\n" + "Quantity: " + quantity[i].ToString() + "\n\n\n";

            }

            customerDetailsRichTextBox.Text = message;
        }

        private void ShowAllCustomer()
        {

            for (int i = 0; i < customerName.Count(); i++)
            {

                message = "Customer Name: " + customerName[i] + "\n" + "Contact No: " + contactNo[i] + "\n" + "Address: " + address[i] + "\n" + "Order: " + order[i] + "\n" + "Quantity: " + quantity[i].ToString() + "\n\n\n";
                customerDetailsRichTextBox.Text += message;
            }

           
        }

        private void ClearAll()
        {

            customerNameTextBox.Text = "";
            contactNoTextBox.Text = "";
            addressTextBox.Text = "";
            orderComboBox.Text = "";
            quantityTextBox.Text = "";
            customerDetailsRichTextBox.Text = "";
          
          

        }


        private void addButton_Click(object sender, EventArgs e)
        {
            
           
            AddCustomer();
            ClearAll();
            ShowCustomer();
           
        }

        private void showButton_Click(object sender, EventArgs e)
        {


            ClearAll();
            ShowAllCustomer();
         



        }

      
      
      
    }
}
