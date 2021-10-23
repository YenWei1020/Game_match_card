using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace m_card
{
   
    public partial class Form3 : Form
    {
       
        string ToWritePlayer;
        int TowriteTime;
        public Form3()
        {
            InitializeComponent();
            readdata();

        }
        public Form3(string player,int game_time)
        {
            InitializeComponent();
            ToWritePlayer = player;
            TowriteTime = game_time;
            
            readdata();

            textBox1.Text += (player + ":  " + game_time + "秒");

            savedata();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void readdata()
        {
            // 讀取game data
            
            StreamReader gamefileRead = new StreamReader(Application.StartupPath+ "\\gamedata.txt");
             string  ReadAll;
        
            ReadAll = gamefileRead.ReadToEnd();
          
            textBox1.Text += ReadAll;
            
            gamefileRead.Close();



            //讀player data

            string[] p_lines = System.IO.File.ReadAllLines(Application.StartupPath + "\\playerdata.txt");
            List<string>playerlist = new List<string>();

            foreach (string line in p_lines)
            {

                playerlist.Add(line);
            }

            //讀score data

            string[] s_lines = System.IO.File.ReadAllLines(Application.StartupPath + "\\scoredata.txt");
            List<int> scorelist = new List<int>();

            foreach (string line in s_lines)
            {
                int score = int.Parse(line);
                scorelist.Add(score);
            }

        }
        private void savedata()
        {
            StreamWriter gamefileWrite = new StreamWriter(Application.StartupPath + "\\gamedata.txt");

            gamefileWrite.WriteLine(textBox1.Text);   
            gamefileWrite.Close();



            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\playerdata.txt", true))
            {
                file.WriteLine(ToWritePlayer);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\scoredata.txt", true))
            {
                file.WriteLine(TowriteTime);
            }
        }

  

    }


   


}
