﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Sharp Mail Oder - Sales Bonus	
// Created by Mahesh mahesh
// Student # 200330980	
// Created on January 29th 2017	
//
// Simple windows form to calculate the total sales bonus per employee based on
// the total monlthy sales for the company and the percentage of which the employee
// in question worked.
//
namespace assignment1
{
    public partial class MailOrder : Form
    {
        //instance variables
        private double _percentageHours;
        private double _totalsalesamount;
        private string _EmployeeName;
        private string _employeeid;
        private string _hoursWorked;
        private string _totalSales;
        private double _salesBonus;

        //the mailOrder constructor
        public MailOrder()
        {
              InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// French, Spanish, English Radio Button Event Handler
        /// changes all label and button text to display in french,spanish,english 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Languagetranslate(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            //using if else statement to change the language of the labels and for the buttons
            if (radio.Tag.ToString() == "french")
            {
                Calculate.Text = "Calculer";
                print.Text = "Impression";
                clear.Text = "Clair";
                EmployeeName.Text = "Le nom de l'employé ";
                employeeId.Text = "   ID employé : ";
                hoursWorked.Text = "Heures travaillées : ";
                totalSales.Text = "Ventes totales : ";
                salesBonus.Text = "     Bonus de vente : ";
                languages.Text = "Langues";
            }
            else if (radio.Tag.ToString() == "spanish")
            {
                Calculate.Text = "Calcular";
                print.Text = "Impresión";
                clear.Text = "Claro";
                EmployeeName.Text = "Nombre del empleado ";
                employeeId.Text = "   ID de empleado : ";
                hoursWorked.Text = "Horas trabajadas : ";
                totalSales.Text = "Ventas totales : ";
                salesBonus.Text = "     Bonificación de ventas : ";
                languages.Text = "Idiomas";
            }
            else
            {
                Calculate.Text = "Calculate";
                print.Text = "Print";
                clear.Text = "Clear";
                EmployeeName.Text = "Employee\'s Name";
                employeeId.Text = "   Employee ID :";
                hoursWorked.Text = "Hours Worked ";
                totalSales.Text = "Total Sales ";
                salesBonus.Text = "     Sales bonus : ";
                languages.Text = "Languages";
            }

        }

        /// <summary>
        /// sales calculation event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salesCalculation(object sender, EventArgs e)
        {

            //instance variables
            this._EmployeeName = textBox1.Text;

            this._employeeid = textBox2.Text;

            this._hoursWorked = textBox3.Text;

            this._totalSales = textBox4.Text;



            Button button = sender as Button;
            //convert string values to the Doubles
            try
            {
                if (Isnegative(textBox3.Text) && (Convert.ToDouble(textBox3.Text)) <= 160)
                {

                    this._percentageHours = (Convert.ToDouble(textBox3.Text)) / 160;
                }
                else
                {
                    this.errorfunction("The Hours can only be between 1-160", "Error");
                }
                if (Isnegative(this._totalSales))

                {

                    this._totalsalesamount = (Convert.ToDouble(this._totalSales)) * (0.02);

                }
                this._salesBonus = (this._percentageHours) * (this._totalsalesamount);
                textBox4.Text = "$" + Convert.ToString(this._totalSales);
                textBox5.Text = Convert.ToString(this._salesBonus);
            }
            catch (Exception exception)
            {

                //Below is the message box place your error message inside string.
                MessageBox.Show("Invalid Data Entered", "InputError");
                Debug.WriteLine(exception.Message);
            }
            if (this._percentageHours != 0 && this._totalsalesamount != 0)
            {
                this._salesBonus = (this._percentageHours) * (this._totalsalesamount);
                textBox5.Text = Convert.ToString(this._salesBonus);
                this._percentageHours = 0;
                this._totalsalesamount = 0;
                this._salesBonus = 0;
            }
            else
            {
                this.textBox5.Text = string.Empty;
            }



        }
        /// <summary>
        /// this function will display the messages
        /// </summary>
        /// <param name="message"></param>
        /// <param name="val"></param>
        private void errorfunction(string message, string val)
        {
            MessageBox.Show(message, val);
        }

        /// <summary>
        /// use of the function statement to return the statements 
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        private
        bool
        Isnegative(string
        hours)

        {

            double _value;
            if (Double.TryParse(hours, out _value))

            {
            
                if (_value > 0)

                {
                    return true; 
                }

                else

                {
                    return false;
                }

            }
            else
            {
                return false;
            }

            

        }

        /// <summary>
        /// clear Button Event Handler
        /// clears all the employee information EXCEPT the total monthly sales
        /// and sets the sales bonus back to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox5.Text = "$0.00";

        }
    /// <summary>
    /// Print Button Event Handler
    /// creates a message box popup to indicate the form is printing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void print_Click(object sender, EventArgs e)
    {
        if (print.Text.Equals("Print"))
            {
                MessageBox.Show("The form has been sent to the default printer.", "Printing");
            }
            else
            {
                MessageBox.Show("Le formulaire a été envoyé à l'imprimante par défaut.", "Imprimer");
            }
        }
    }
}
