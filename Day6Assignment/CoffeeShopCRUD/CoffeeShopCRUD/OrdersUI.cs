using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopCRUD
{
    public partial class OrdersUI : Form
    {
        public OrdersUI()
        {
            InitializeComponent();
        }



        double totalPrice = 0;

        private Double GetTotalPrice()
        {
            if(nameTextBox.Text =="Black"){

                totalPrice = Convert.ToDouble(quantityTextBox.Text) * 90;
            } 
            else if (nameTextBox.Text == "Hot")
            {

                totalPrice = Convert.ToDouble(quantityTextBox.Text) * 100;
            }
            else if (nameTextBox.Text == "Cold")
            {

                totalPrice = Convert.ToDouble(quantityTextBox.Text) * 110;
            }
            else if (nameTextBox.Text == "Regular")
            {

                totalPrice = Convert.ToDouble(quantityTextBox.Text) * 80;
            }
            else if (nameTextBox.Text == "Special")
            {

                totalPrice = Convert.ToDouble(quantityTextBox.Text) * 120;
            }

            return totalPrice;
        }

        private void InsertOrder()
        {
            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"INSERT INTO ItemOrder(Name,Quantity,TotalPrice) VALUES ('"+nameTextBox.Text+"',"+quantityTextBox.Text+","+GetTotalPrice().ToString()+")";
                SqlCommand command = new SqlCommand(commandString, connection);


                //connection open
                connection.Open();

                //command execute to insert data to database
                int isRowAffected = command.ExecuteNonQuery();

                if (isRowAffected > 0)
                {
                    MessageBox.Show("Data Inserted Successfully...");
                }
                else
                {
                    MessageBox.Show("Data Not Inserted...!!!");
                }

                //connection close
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }








        private void ShowOrders()
        {

            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"SELECT * FROM ItemOrder";
                SqlCommand command = new SqlCommand(commandString, connection);


                //connection open
                connection.Open();

                //show customer
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable != null)
                {
                    outputDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No Data Found...!!!");
                }

                //connection close
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void UpdateOrder()
        {
            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"UPDATE ItemOrder SET Name = '" + nameTextBox.Text + "',Quantity = " + quantityTextBox.Text + ", TotalPrice = '" + GetTotalPrice().ToString() + "'  WHERE Id = " + idTextBox.Text + "";
                SqlCommand command = new SqlCommand(commandString, connection);


                //connection open
                connection.Open();
  
                

                //command execute to UPDATE data 
                int isRowAffected = command.ExecuteNonQuery();
                if (isRowAffected > 0)
                {
                    MessageBox.Show("Data Updated Successfully...");
                }
                else
                {
                    MessageBox.Show("Data Not Updated...!!!");
                }

                //connection close
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteOrder()
        {

            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"DELETE FROM ItemOrder WHERE Id = " + idTextBox.Text + "";
                SqlCommand command = new SqlCommand(commandString, connection);


                //connection open
                connection.Open();

                //command execute to DELETE data 
                int isRowAffected = command.ExecuteNonQuery();
                if (isRowAffected > 0)
                {
                    MessageBox.Show("Data Deleted Successfully...");
                }
                else
                {
                    MessageBox.Show("Data Not Deleted...!!!");
                }

                //connection close
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void SearchOrder()
        {

            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"SELECT * FROM ItemOrder WHERE Name LIKE '" + nameTextBox.Text + "%'";
                SqlCommand command = new SqlCommand(commandString, connection);


                //connection open
                connection.Open();

                //show customer
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable != null)
                {
                    outputDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No Data Found...!!!");
                }

                //connection close
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAll()
        {
            idTextBox.Text = nameTextBox.Text = quantityTextBox.Text = totalPriceTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            InsertOrder();
            ResetAll();


        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowOrders();
            ResetAll();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteOrder();
            ResetAll();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

           
            
            UpdateOrder();
            ResetAll();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchOrder();
            ResetAll();
        }

        //private void getSingleData() {


        //    //connection
        //    string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
        //    SqlConnection connection = new SqlConnection(connectionString);


        //    //connection open
        //    connection.Open();

        //    //show customer
        //    string commandString = @"SELECT * FROM Item Where Id = " + idTextBox.Text + "";
        //    SqlCommand command = new SqlCommand(commandString, connection);
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //    DataTable dataTable = new DataTable();
        //    dataAdapter.Fill(dataTable);
        //    if (dataTable != null)
        //    {
        //        idTextBox.Text = dataTable.Rows[0][0].ToString();
        //        nameTextBox.Text = dataTable.Rows[0][1].ToString();
        //        priceTextBox.Text = dataTable.Rows[0][2].ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Data Found...!!!");
        //    }


        //    //connection close
        //    connection.Close();
        //}

       

    }
}

    

