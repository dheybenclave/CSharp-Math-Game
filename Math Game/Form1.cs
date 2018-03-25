using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Game
{
    public partial class Form1 : Form
    {
        int x = 0;
        int num1;
        int num2;
        int answerresult;
        string operators;
        int chosedigit;
        int correctpt;
        int wrongpt;
        int resultpt;
        int minute;
        int seconds;

        public Form1()
        {
           
            InitializeComponent();
           
        }

        public void timer()
        {
            minute = Convert.ToInt32(label8.Text);
            seconds = Convert.ToInt32(label10.Text);
            label10.Text = Convert.ToString(seconds - 1);
            if (seconds == 0)
            {
                label8.Text = Convert.ToString(minute - 1);
                label10.Text = "60";
                label16.Text = "";
            }
            if (seconds == 0 && minute == 0)
            {
                timer2.Stop();
                label10.Text = "0";
                label8.Text = "0";
                MessageBox.Show("Time is up!");


            }
            if (minute == 0 && seconds == 10)
            {
                label10.ForeColor = Color.Red;
                label8.ForeColor = Color.Red;
            }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void textdefault(ref object sender, ref KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            num1 = r.Next(1, chosedigit+1);
            num2 = r.Next(1, chosedigit + 1);
         
            Random asd = new Random();
            x++;
            if (x == 10)
            {
                label1.Text = Convert.ToString(num1);
                label2.Text = Convert.ToString(num2);
                timer1.Stop();
                x = 0;
            
            }

        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
          
           
            
        }
        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (operators == "*")answerresult = num1 * num2;
            else if(operators =="/")answerresult = num1 / num2;
            else if (operators == "+")answerresult = num1 + num2;
            else if (operators == "-")answerresult = num1 - num2;else {  }

            try
            {
                if (e.KeyValue == 13)
                {
                    if (answerresult == Convert.ToInt32(Convert.ToInt64(textBox1.Text)))
                    {
                       label16.Text = "Your answer is correct";                       
                        timer1.Start();
                        correctpt++;
                        
                        textBox2.Text = correctpt.ToString();
                        textBox1.Clear();
                       
                    }
                    else
                    {
                        label16.Text ="Your answer is wrong the correct answer is" + answerresult;
                        timer1.Start();
                        wrongpt++;
                        textBox3.Text = wrongpt.ToString();
                        textBox1.Clear();
                        textBox1.Clear();
                    }
                    resultpt++;
                    if (resultpt == 10)
                    {
                        correctpt = 0;
                        wrongpt = 0;
                        MessageBox.Show("your correct points is : " + textBox2.Text + " and your wrong points is : " + textBox3.Text);
                        resultpt = 0;
                        textBox2.Clear();
                        textBox3.Clear();
                        label8.Text = "02";
                        label10.Text = "00";
                        textBox2.Text = "0";
                        textBox3.Text = "0";

                    }
                }
            }
            catch {}
        
        }
       

        private void timer2_Tick(object sender, EventArgs e)
        {

            timer();
            

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = lblyourdigit.Text.Count();
            for (int i = 0; i < a; i++)
            {
                if (i == 11)
                    MessageBox.Show("Max digit is 10 ");
                else
                    chosedigit = Convert.ToInt32(i);
            }
            textBox2.Text = "0";
            textBox3.Text = "0";

            if (lblyouroperation.Text != "")
            {
                if (lblyourdigit.Text != "")
                {
                    groupBox2.Visible = false;
                    groupBox2.Enabled = false;
                    timer1.Enabled = true;
                    timer1.Start();
                    timer2.Enabled = true;
                    timer2.Start();               

                  //  chosedigit = Convert.ToInt32(lblyourdigit.Text);
                 


                }
                else
                { MessageBox.Show("Please complete the requirements!!"); }
            }
            else
            { MessageBox.Show("Please complete the requirements!!"); }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblyouroperation.Text = button1.Text;
            lblyourdigit.Text = txtdigit.Text;
            operators = "*";
            label3.Text = operators;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblyourdigit.Text = txtdigit.Text;
            lblyouroperation.Text = button2.Text;
            operators = "+";
            label3.Text = operators;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblyourdigit.Text = txtdigit.Text;
            lblyouroperation.Text = button3.Text;
            operators = "/";
            label3.Text = operators;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblyourdigit.Text = txtdigit.Text;
            lblyouroperation.Text = button4.Text;
            operators = "-";
            label3.Text = operators;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-') )
            {
                e.Handled = true;

            }
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
     
        private void button1_MouseHover(object sender, EventArgs e)
        {

           button1.BackColor = Color.White;
           button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DimGray;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DimGray;
            button2.ForeColor = Color.White;

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DimGray;
            button3.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DimGray;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {

            button5.BackColor = Color.PaleGreen;
            button5.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
        }

        private void txtdigit_TextChanged(object sender, EventArgs e)
        {
            lblyourdigit.Text = txtdigit.Text;
        }

        private void txtdigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox2.Visible = true;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
