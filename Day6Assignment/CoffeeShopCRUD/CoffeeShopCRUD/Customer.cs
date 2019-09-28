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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void InsertCustomer() {
            try {


                if (!(nameTextBox.Text == "" || contactTextBox.Text == "" || addressTextBox.Text == ""))
                {

                    //connection
                    string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                    SqlConnection connection = new SqlConnection(connectionString);


                    //command
                    string commandString = @"SELECT * FROM Customer WHERE Name LIKE '" + nameTextBox.Text + "%'";
                    SqlCommand command = new SqlCommand(commandString, connection);

                    connection.Open();
                    //show customer
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("This name already exists...!!!");
                        return;
                    }
                    else
                    {
                        //command
                        string commandString2 = @"INSERT INTO Customer(Name,Contact,Address) VALUES ('" + nameTextBox.Text + "'," + contactTextBox.Text + ",'" + addressTextBox.Text + "')";


                        SqlCommand cmd = new SqlCommand(commandString2, connection);



                        //command execute to insert data to database
                        int isRowAffected = cmd.ExecuteNonQuery();

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


                }
                else
                {
                    MessageBox.Show("No fields should be empty except ID");
                }


                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
           }
        }



        

                


        private void ShowCustomer()
        {
            
            try {

                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(commandString, connection);


                //connection open
                connection.Open();

                //show customer
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void UpdateCustomer()
        {
            try {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);


                if(!(nameTextBox.Text=="" || contactTextBox.Text == "" || addressTextBox.Text =="") )
                { 
                //command
                string commandString = @"UPDATE CUSTOMER SET Name = '" + nameTextBox.Text + "', Contact = '" + contactTextBox.Text + "', Address = '" + addressTextBox.Text + "' WHERE Id = " + idTextBox.Text + "";
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteCustomer()
        {

      try {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"DELETE FROM Customer WHERE Id = " + idTextBox.Text + "";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void SearchCustomer()
        {
    
            try {


                //connection
                string connectionString = @"server = EMON-PC\SQLEXPRESS; Database = CoffeeShop; integrated security = true";
                SqlConnection connection = new SqlConnection(connectionString);

                //command
                string commandString = @"SELECT * FROM Customer WHERE Name LIKE '"+nameTextBox.Text+"%'";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAll()
        {
            idTextBox.Text = nameTextBox.Text = contactTextBox.Text = addressTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            InsertCustomer();
            ResetAll();
           
            
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowCustomer();
            ResetAll();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
            ResetAll();
      
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            UpdateCustomer();
            ResetAll();
        
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchCustomer();
            ResetAll();
        }

        


        


        



    }
}
