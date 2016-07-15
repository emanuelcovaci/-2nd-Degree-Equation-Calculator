using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void calcul()
        {

            long a = Convert.ToInt64(textBox1.Text);//citesc din casuta a un string si il transform in long
            long b = Convert.ToInt64(textBox2.Text);//citesc din casuta b un string si il transform in long
            long c = Convert.ToInt64(textBox3.Text);//citesc din casuta c un string si il transform in long

            textBox4.Text = "Ecuatia e : ";//aici e algoritmul de afisare a ecuatiei
            if (a > 0 || a < 0)
            { textBox4.Text = textBox4.Text + a + "x*x"; }
            if (b > 0)
            {
                if (a != 0)
                { textBox4.Text = textBox4.Text + "+" + b + "x"; }
                else { textBox4.Text = textBox4.Text + b + "x"; }
            }
            else
            {
                if (b < 0)
                { textBox4.Text = textBox4.Text + " " + b + "x"; }
            }
            if (c > 0)
            {
                textBox4.Text = textBox4.Text + "+" + c;
            }
            else
            {
                if (c < 0)
                { textBox4.Text = textBox4.Text + " " + c; }
            }
            textBox4.Text += " = 0 ";

            double delta;
            delta = (b * b) - (4 * a * c);//calculez delta
            textBox5.Text = "Delta=" + delta + Environment.NewLine;
            if (delta < 0)
            {
                textBox5.Text = textBox5.Text+"Ecuatia nu are solutii reale";
                calculComplex(a, b, c, delta);//apelez o alta metoda(functie) care sa-mi calculeze pentru solutiile ireale

            }
            else
            {
                if (delta == 0)
                {
                    // double x = -(b / (2 * a));
                   // Double  x = ((-b) / (2 * a));
                    Double x = (-b - Math.Sqrt(delta)) / (2 * a);
                    textBox5.Text =textBox5.Text+ "Solutia ecuatiei e =" + x;//afisez solutia ecuatiei
                }
                else
                {

                    Double x = (-b - Math.Sqrt(delta)) / (2 * a);//calculez radaciniile reale
                    Double y = (-b + Math.Sqrt(delta)) / (2 * a);
                    textBox5.Text = textBox5.Text + "Solutiile ecuatiei sunt:" + Environment.NewLine;//afisez radaciniile
                    textBox5.Text = textBox5.Text + "x1=" + x + Environment.NewLine;
                    textBox5.Text = textBox5.Text + "x2=" + y;

                }
            }
        }
        public void calculComplex(long a, long b, long c, double delta)//metoda care calculeaza radaciniile ireale
        {
            double rDelta = Math.Sqrt(-delta);
            textBox5.Text += Environment.NewLine;
            textBox5.Text += "Solutiile complexe:" + Environment.NewLine;
            if (b < 0)
            {
                textBox5.Text = textBox5.Text +"x1="+ -b + " + " + rDelta + " i " + "/" + 2 * a + Environment.NewLine;
                textBox5.Text = textBox5.Text + "x2="+ -b + " - " + rDelta + " i " + "/" + 2 * a + Environment.NewLine;
            }
            else
            {
                textBox5.Text = textBox5.Text +"x1="+ "-" + b + " + " + rDelta + " i " + "/" + 2 * a + Environment.NewLine;
                textBox5.Text = textBox5.Text +"x2="+ "-" + b + " - " + rDelta + " i " + "/" + 2 * a + Environment.NewLine;
            }


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try//cu ajutorul lui try-catch ,ofer programului dinamica,de fiecare daca cand schimb o valoare a,b,c se recalculeaza instant iar daca o casuta e goala
               //programul nu se blocheaza 
               //cand am scris primadata codul foloseam un buton ok si reset,introduceam valoriile pentru a.b.c ,dadeam ok se calcula ,iar daca doream sa schimb valoriile 
               //trebuia sa dau reset cu ajutorul try-catch problema sa rezolvat foarte usor si asa programul e si mai optim si mai dinamic 
            {
                calcul();
            }
            catch
            {
                textBox4.Text = "";//aici sterg informatiile din casutele de afisare
                textBox5.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
