using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentFormUI
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        List<string> ids = new List<string>();
        List<string> names = new List<string>();
        List<string> mobiles = new List<string>();
        List<int> ages = new List<int>();
        List<string> addresses = new List<string>();
        List<double> gpa = new List<double>();

        string singleStudent = "";
        string allStudent = "";

        private void AddStudent()
        {
            if (!String.IsNullOrEmpty(idTextBox.Text))
            {
                int length = idTextBox.Text.Length;
                if (length == 4)
                {

                    for (int i = 0; i < ids.Count(); i++)
                    {
                        if (idTextBox.Text == ids[i])
                        {
                            MessageBox.Show("id already exist.");
                            return;
                        }
                        else
                        {
                            ids.Add(idTextBox.Text);
                        }

                    }


                }
                else
                {
                    MessageBox.Show("ID must be 4 characters long");
                    return;
                }
               
            }
            else
            {
                MessageBox.Show("ID is required.");
                return;
            }
            
            names.Add(nameTextBox.Text);

            if (!String.IsNullOrEmpty(mobileTextBox.Text))
            {
                int length = mobileTextBox.Text.Length;
                if (length == 4)
                {

                    for (int i = 0; i < mobiles.Count(); i++)
                    {
                        if (mobileTextBox.Text == mobiles[i])
                        {
                            MessageBox.Show("this mobile no already exist.");
                            return;
                        }
                        else
                        {
                            mobiles.Add(mobileTextBox.Text);
                        }

                    }


                }
                else
                {
                    MessageBox.Show("Mobile must be 4 characters long");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Mobile no is required.");
                return;
            }
           
            if (!String.IsNullOrEmpty(ageTextBox.Text))
            {
                ages.Add(Convert.ToInt32(ageTextBox.Text));
            }
            else
            {
                MessageBox.Show("Please enter age.");
                return;
            }
        
            addresses.Add(addressTextBox.Text);
            gpa.Add(Convert.ToDouble(gpaTextBox.Text));

           
          
        }
    


        private void ShowStudent()
        {
            for (int i = 0; i < ids.Count(); i++)
            {
                singleStudent = "\nID: " + ids[i] +
                                "\nName: " + names[i] +  
                                "\nMobile: " + mobiles[i] + 
                                "\nAge: " + ages[i] + 
                                "\nAddress: " + addresses[i] + 
                                "\nGPA: " + gpa[i] + 
                                "\n.......................\n\n";

            }

            allStudent += singleStudent;
            showRichTextBox.Text = singleStudent.ToString();
        }


        private void ShowAllStudent()
        {
            showRichTextBox.Text = allStudent.ToString();
            ShowMaxMinTotalAvgGpa();
           
           
        }

        private void ShowMaxMinTotalAvgGpa()
        {
            maxTextBox.Text = gpa.Max().ToString();
            minTextBox.Text = gpa.Min().ToString();
            totalTextBox.Text = gpa.Sum().ToString();
            averageTextBox.Text = gpa.Average().ToString();

            for (int i = 0; i < gpa.Count(); i++)
            {
                if (gpa[i] == Convert.ToDouble(maxTextBox.Text))
                {
                    maxNameTextBox.Text += names[i] + ", ";
                }

                if (gpa[i] == Convert.ToDouble(minTextBox.Text))
                {
                    minNameTextBox.Text += names[i] + ", ";
                }
            }
        }


        private void ResetAll()
        {
            idTextBox.Text = nameTextBox.Text = mobileTextBox.Text = ageTextBox.Text = addressTextBox.Text = gpaTextBox.Text = showRichTextBox.Text = maxTextBox.Text = maxNameTextBox.Text = minTextBox.Text = minNameTextBox.Text = averageTextBox.Text = totalTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
           
            
                AddStudent();

                ResetAll();
                ShowStudent();
            
          
           
           
        }

        private void showAllButton_Click(object sender, EventArgs e)   
        {
            ResetAll();
            ShowAllStudent();
           
           
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (idRadioButton.Checked || nameRadioButton.Checked || mobileRadioButton.Checked)
            {
                if (idRadioButton.Checked)
                {
                    //idTextBox.Focus();
                    if (idTextBox.Text == "")
                    {
                        MessageBox.Show("You have not written any id...!!!");
                    }
                    else
                    {
                        string information = "";

                        for (int i = 0; i < ids.Count(); i++)
                        {
                            if (ids[i] == idTextBox.Text)
                            {
                                information = "\nID: " + ids[i] +
                                              "\nName: " + names[i] +
                                              "\nMobile: " + mobiles[i] +
                                              "\nAge: " + ages[i] +
                                              "\nAddress: " + addresses[i] +
                                              "\nGPA: " + gpa[i] +
                                              "\n.......................\n\n";
                            }

                        }
                        if (information == "")
                        {
                            MessageBox.Show("Invalid ID.This ID does not Exists");
                        }
                        else
                        {
                            showRichTextBox.Text = information;
                        }

                    }
                }

                if (nameRadioButton.Checked)
                {
                    if (nameTextBox.Text == "")
                    {
                        MessageBox.Show("You have not written any name...!!!");
                    }
                    else
                    {
                        string information = "";

                        for (int i = 0; i < ids.Count(); i++)
                        {
                            if (names[i] == nameTextBox.Text)
                            {
                                information = "\nID: " + ids[i] +
                                              "\nName: " + names[i] +
                                              "\nMobile: " + mobiles[i] +
                                              "\nAge: " + ages[i] +
                                              "\nAddress: " + addresses[i] +
                                              "\nGPA: " + gpa[i] +
                                              "\n.......................\n\n";
                            }

                        }
                        if (information == "")
                        {
                            MessageBox.Show("Invalid Name.This name does not Exists");
                        }
                        else
                        {
                            showRichTextBox.Text = information;
                        }

                    }
                }

                if (mobileRadioButton.Checked)
                {
                    if (mobileTextBox.Text == "")
                    {
                        MessageBox.Show("You have not written any mobile number...!!!");
                    }
                    else
                    {
                        string information = "";

                        for (int i = 0; i < ids.Count(); i++)
                        {
                            if (mobiles[i] == mobileTextBox.Text)
                            {
                                information = "\nID: " + ids[i] +
                                              "\nName: " + names[i] +
                                              "\nMobile: " + mobiles[i] +
                                              "\nAge: " + ages[i] +
                                              "\nAddress: " + addresses[i] +
                                              "\nGPA: " + gpa[i] +
                                              "\n.......................\n\n";
                            }

                        }
                        if (information == "")
                        {
                            MessageBox.Show("Invalid mobile number.This mobile number does not Exists");
                        }
                        else
                        {
                            showRichTextBox.Text = information;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a search item first.");
            }




           

        }
        
    }
}
