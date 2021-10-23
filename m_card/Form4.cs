using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m_card
{
    public partial class Form4 : Form
    {
        List<string> playerlist = new List<string>();
        List<int> scorelist = new List<int>();
        int[] scorearray;
        string[] playerarray;

        public Form4()
        {
            InitializeComponent();
            readdata();
            scorearray = scorelist.ToArray();
            playerarray = playerlist.ToArray();
            BubbleSort(scorearray, playerarray);
           
            for(int i = 0;i< scorearray.Length;i++)
            {
                textBox1.Text += ( (i+1) +".  "+ playerarray[i] + ":  " + scorearray[i] + "秒\r\n"); 
            }
            
        }


        private void readdata()
        {

            //讀player data

            string[] p_lines = System.IO.File.ReadAllLines(Application.StartupPath + "\\playerdata.txt");
            

            foreach (string line in p_lines)
            {

                playerlist.Add(line);
            }

            //讀score data

            string[] s_lines = System.IO.File.ReadAllLines(Application.StartupPath + "\\scoredata.txt");
           

            foreach (string line in s_lines)
            {
                int score = int.Parse(line);
                scorelist.Add(score);
            }

        }


        public void BubbleSort(int[] list, string[] slist)
        {
            int len = list.Length;
            for (int i = 1; i <= len - 1; i++)//執行的回數
                for (int j = 1; j <= len - i; j++)//執行的次數
                {
                    if (list[j] < list[j - 1])
                    {
                        //二數交換
                        int temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;

                        string stemp = slist[j];
                        slist[j] = slist[j - 1];
                        slist[j - 1] = stemp;
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
