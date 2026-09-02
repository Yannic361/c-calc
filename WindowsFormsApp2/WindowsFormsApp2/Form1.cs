using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        private double firstvalue = 0;
        private double secondvalue = 0;
        private string currentOperator = "";
        private bool operatorPressed = false;

        public Form1()
        {
            InitializeComponent();
            btn_0.Click += NumberButton_Click;
            btn_1.Click += NumberButton_Click;
            btn_2.Click += NumberButton_Click;
            btn_3.Click += NumberButton_Click;
            btn_4.Click += NumberButton_Click;
            btn_5.Click += NumberButton_Click;
            btn_6.Click += NumberButton_Click;
            btn_7.Click += NumberButton_Click;
            btn_8.Click += NumberButton_Click;
            btn_9.Click += NumberButton_Click;

            btn_plus.Click += OperatorButton_Click;
            btn_minus.Click += OperatorButton_Click;
            btn_multiply.Click += OperatorButton_Click;
            btn_divide.Click += OperatorButton_Click;

            btn_comma.Click += CommaButton_CLick;
            btn_del.Click += DeleteButton_Click;
            btn_calc.Click += CalculateButton_Click;


        }

        
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string value = btn.Text;

            if (operatorPressed)
            {
                textbox_result.Text = "0";
                operatorPressed = false;
            }
            if (textbox_result.Text == "0")
            {
                textbox_result.Text = value;
            } else
            {
                textbox_result.Text += value;
            }

        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (string.IsNullOrEmpty(textbox_result.Text))
            {
                return;
            }
            firstvalue = Convert.ToDouble(textbox_result.Text.Replace(',', '.'));
            currentOperator = btn.Text;
            operatorPressed = true;
        }

        private void CommaButton_CLick(object sender, EventArgs e)
        {
            if (textbox_result.Text.Contains(","))
            {
                return;
            }
            if (operatorPressed)
            {
                textbox_result.Text = "0";
                operatorPressed = false;
            }
            textbox_result.Text += ",";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
            firstvalue = 0;
            secondvalue = 0;
            currentOperator = "";
            operatorPressed = false;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperator))
            {
                return;
            }
            secondvalue = Convert.ToDouble(textbox_result.Text.Replace(',', '.'));
            double result = 0;
            
            switch (currentOperator)
            {
                case "+":
                    result = firstvalue + secondvalue;
                    break;
                case "−":
                    result = firstvalue - secondvalue;
                    break;
                case "×":
                    result = firstvalue * secondvalue;
                    break;
                case "÷":
                    result = firstvalue / secondvalue;
                    break;
            }
            textbox_result.Text = result.ToString(CultureInfo.InvariantCulture);
            currentOperator = "";
            operatorPressed = true;
        }
    }   
}
