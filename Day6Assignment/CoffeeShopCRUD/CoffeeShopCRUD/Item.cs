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
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }


        private void InsertItem()
        {
            try
            {

                if (!(nameTextBox.Text == "" || priceTextBox.Text == "")) 
                {




                    //connection
                    string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                    SqlConnection connection = new SqlConnection(connectionString);


                    //command
                    string commandString = @"SELECT * FROM Item WHERE Name LIKE '" + nameTextBox.Text + "%'";
                    SqlCommand command = new SqlCommand(commandString, connection);

                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("This Item already exists...!!!");
                        return;
                    }
                    else
                    {
                        //command
                        string commandString2 = @"INSERT INTO Item(Name,Price) VALUES ('" + nameTextBox.Text + "'," + priceTextBox.Text + ")";
                        SqlCommand cmd = new SqlCommand(commandString, connection);


                        //connection open
                        connection.Open();

                        //command execute to insert data to database
                        int isRowAffected = cmd.ExecuteNonQuery();

                        if (isRowAffected > 0)
                        {
                            MessageBox.Show("Item Inserted Successfully...");
                        }
                        else
                        {
                            MessageBox.Show("Item Not Inserted...!!!");
                        }

                        //connection close
                        connection.Close();
                    }



                }
                else
                {
                    MessageBox.Show("Item name and price should not be empty");
                }



               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }








        private void ShowItem()
        {

            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"SELECT * FROM Item";
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



        private void UpdateItem()
        {
            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"UPDATE Item SET Name = '" + nameTextBox.Text + "', Price = '" + priceTextBox.Text + "'  WHERE Id = " + idTextBox.Text + "";
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

        private void DeleteItem()
        {

            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"DELETE FROM Item WHERE Id = " + idTextBox.Text + "";
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




        private void SearchItem()
        {

            try
            {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"SELECT * FROM Item WHERE Name LIKE '" + nameTextBox.Text + "%'";
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
            idTextBox.Text = nameTextBox.Text = priceTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            InsertItem();
            ResetAll();


        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowItem();
            ResetAll();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteItem();
            ResetAll();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

           
            
            UpdateItem();
            ResetAll();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchItem();
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
