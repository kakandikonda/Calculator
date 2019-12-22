using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string prevEquation = "", prevOperation = "", operation = "";
        private static double answer = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void display_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void All_btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn_delete": // delete button
                    if (display.Text.Length > 0)
                    {
                        display.Text = display.Text.Substring(0, display.Text.Length - 1);
                        
                    }
                    break;
                case "btn_clear": // clear button
                    operation = "";
                    display.ResetText();
                    break;
                case "btn_clearE":
                    display.ResetText();
                    display2.ResetText();
                    prevEquation = "";
                    prevOperation = "";
                    operation = "";
                    break;
                case "btn_point":
                    if (display.Text.Contains("."))
                    {
                        //this should do nothing
                    }
                    else
                    {
                        display.Text += ".";
                    }
                    break;
                case "btn_PL": // the plus or minus symbol
                    if (display.Text.Contains("-"))
                    {
                        display.Text = display.Text.Substring(1, display.Text.Length - 1);
                    }
                    else
                    {
                        display.Text = "-" + display.Text; 
                    }
                    break;
                default: // this is just for all the buttons
                    if(operation == "=")
                    {
                        operation = "";
                        display.ResetText();
                    }
                    if(display.Text == "0")
                    {
                        display.Text = btn.Text;
                    }
                    else
                    {
                        display.Text += btn.Text;
                    }
                    break;
               
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void multi_equations()
            {
                if (prevOperation == "+")
                {
                    prevOperation = operation;
                    answer = (Convert.ToDouble(prevEquation)) + (Convert.ToDouble(display.Text));
                    prevEquation = answer.ToString();
                    display2.Text = prevEquation + " " + operation + " ";
                    display.ResetText();
                }
                else if (prevOperation == "-")
                {
                    prevOperation = operation;
                    answer = (Convert.ToDouble(prevEquation)) - (Convert.ToDouble(display.Text));
                    prevEquation = answer.ToString();
                    display2.Text = prevEquation + " " + operation + " ";
                    display.ResetText();
                }
                else if (prevOperation == "X")
                {
                    prevOperation = operation;
                    answer = (Convert.ToDouble(prevEquation)) * (Convert.ToDouble(display.Text));
                    prevEquation = answer.ToString();
                    display2.Text = prevEquation + " " + operation + " ";
                    display.ResetText();
                }
                else if (prevOperation == "÷")
                {
                    prevOperation = operation;
                    answer = (Convert.ToDouble(prevEquation)) / (Convert.ToDouble(display.Text));
                    prevEquation = answer.ToString();
                    display2.Text = prevEquation + " " + operation + " ";
                    display.ResetText();
                }
            }

        private void Operation_Click(object sender, EventArgs e)
        {
            

            Button opr = sender as Button;

            switch (opr.Text)
            {
                case "+":
                    if(display.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "+";
                            prevOperation = operation;
                            prevEquation = display.Text;
                            display2.Text = prevEquation + operation;
                            display.ResetText();
                        }
                        else
                        {
                            operation = "+";
                            multi_equations();
                        }
                    }
                    break;
                case "-":
                    if (display.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "-";
                            prevOperation = operation;
                            prevEquation = display.Text;
                            display2.Text = prevEquation + operation;
                            display.ResetText();
                        }
                        else
                        {
                            operation = "-";
                            multi_equations();
                        }
                    }
                    break;
                case "X":
                    if (display.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "X";
                            prevOperation = operation;
                            prevEquation = display.Text;
                            display2.Text = prevEquation + operation;
                            display.ResetText();
                        }
                        else
                        {
                            operation = "X";
                            multi_equations();
                        }
                    }
                    break;
                case "÷":
                    if (display.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "÷";
                            prevOperation = operation;
                            prevEquation = display.Text;
                            display2.Text = prevEquation + operation;
                            display.ResetText();
                        }
                        else
                        {
                            operation = "÷";
                            multi_equations();
                        }
                    }
                    break;
                case "=":
                    operation = "=";
                    multi_equations();
                    display2.ResetText();
                    display.Text = answer.ToString();
                    break;
            }
            
        }
    }
}
