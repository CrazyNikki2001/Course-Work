using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Work
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            Hide();
        }
        private string Revers(string el)
        {
            char[] arr = el.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private void button1_Click(object sender, EventArgs e) // кнопка "сложение"
        {
            string A = Convert.ToString(textBox1.Text);
            string B = Convert.ToString(textBox2.Text);
            string result = "", reversA, reversB;
            int i, sum, p = 0;
            if (A.Length > B.Length)
            {
                reversA = Revers(A); 
                reversB = Revers(B);
            }
            else
            {
                reversA = Revers(B); 
                reversB = Revers(A);
            }
            for (i = 0; i < (A.Length); i++)
            {
                int Ai = reversA[i] - 48;
                if (i < B.Length)
                {
                    int Bi = reversB[i] - 48;
                    sum = Ai + Bi + p;

                }
                else
                {
                    sum = Ai + p;
                    p = sum / 10;
                    result += sum % 10;

                }
            }
            while (p > 0)
            {
                result += p % 10;
                p = p / 10;

            }
            textBox3.Text = Revers(result);
        }

        private void button2_Click(object sender, EventArgs e) // кнопка "вычитание"
        {
            string A = Convert.ToString(textBox1.Text);
            string B = Convert.ToString(textBox2.Text);
            string result = "", sign = "", reversA, reversB;
            int i, r, p = 0;
            if (A.Length < B.Length)
            {
                sign = "-";
            }
            if (A.Length == B.Length)
            {
                for (i = 0; i < (A.Length); i++)
                {
                    if (A[i] < B[i])
                    {
                        sign = "-";
                    }
                    if (A[i] > B[i])
                    {
                        break;
                    }
                }
            } 
            if (sign == "-")
            {
                reversB = Revers(A); 
                reversA = Revers(B);
            }
            else
            {
                reversA = Revers(A); 
                reversB = Revers(B);
            }
            for (i = 0; i < (reversA.Length); i++)
            {
                int Ai = reversA[i] - 48;
                if (i < reversB.Length)
                {
                    int Bi = reversB[i] - 48;
                    r = Ai - Bi - p;
                    if (r < 0)
                    {
                        r += 10;
                        p = 1;

                    }
                    else
                    {
                        p = 0;
                    }
                }
                else
                {
                    r = Ai - p;
                    if (r < 0)
                    {
                        r += 10;
                        p = 1;

                    }
                    else
                    {
                        p = 0;
                    }
                }
                result += System.Convert.ToString(r);
            }
            textBox3.Text += sign + Revers(result);
        }

        private void button3_Click(object sender, EventArgs e) // кнопка "умножение"
        {
            string A = Convert.ToString(textBox1.Text);
            string B = Convert.ToString(textBox2.Text);
            int[] result = new int[A.Length + B.Length]; ;
            int index_A = 0;
            int index_B = 0;
            int i;
            for (i = A.Length - 1; i >= 0; i--)
            {
                int p = 0;
                int Ai = A[i] - 48;
                index_B = 0;
                for (int j = B.Length - 1; j >= 0; j--)
                {
                    int Bj = B[j] - 48;
                    int sum = Ai * Bj + result[index_A + index_B] + p;
                    p = sum / 10;
                    result[index_A + index_B] = sum % 10;
                    index_B++;
                }
                if (p > 0)
                {
                    result[index_A + index_B] += p;
                }
                index_A++;
            }
            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
            {
                i--;
            }
            string itog = "";
            while (i >= 0)
            {
                itog += (result[i--]);
            }
            textBox3.Text += itog;
        }

        private void button4_Click(object sender, EventArgs e) // кнопка "деление"
        {
            string A = Convert.ToString(textBox1.Text);
            string B = Convert.ToString(textBox2.Text);
            string res = "";
            int i = 0;
            int temp = (int)(A[i] - '0');
            while (temp < Int32.Parse(B))
            {
                temp = temp * 10 + (int)(A[i + 1] - '0');
                i++;

            }
            ++i;
            while (A.Length > i)
            {
                res += (char)(temp / Convert.ToInt32(B) + '0');
                temp = (temp % Convert.ToInt32(B)) * 10 + (int)(A[i] - '0');
                i++;

            }
            res += (char)(temp / Convert.ToInt32(B) + '0');
            textBox3.Text += res;

        }

        private void Form2_Load(object sender, EventArgs e) 
        {

        }
    }
}
