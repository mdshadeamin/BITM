using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day2Assignments
{
    public partial class CoffeeShop : Form
    {
        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void CoffeeShop_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            int price=0;
            if(orderComboBox.Text == "Black-120"){
                 price = Convert.ToInt32(quantityTextBox.Text)*120;
            }
            else if (orderComboBox.Text == "Cold-100")
            {
                 price = Convert.ToInt32(quantityTextBox.Text) * 100;
            }
            else if (orderComboBox.Text == "Hot-90")
            {
                 price = Convert.ToInt32(quantityTextBox.Text) * 90;
            }
            else if (orderComboBox.Text == "Regular-80")
            {
                 price = Convert.ToInt32(quantityTextBox.Text) * 80;
            }
            
            richTextBox.Text ="\n Customer Name: "+ nameTextBox.Text +"\n\n Contact No: "+ contactNoTextBox.Text+ "\n\n Address: "+addressTextBox.Text +"\n\n Order: " +orderComboBox.Text+"\n\n Quantity: "+quantityTextBox.Text+"\n\n Total Price: "+ price.ToString();

        }

       
    }
}
