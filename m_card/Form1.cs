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
    public partial class Form1 : Form
    {

        PictureBox[] pb = new PictureBox[16];
        Image image_back = Image.FromFile(Application.StartupPath + "\\back.jpg");
        Image[] image_list = new Image[8];
        Random rr = new Random(System.DateTime.Now.Millisecond);
        int[] pb_image = new int[16];
        bool[] solve = new bool[16];
        int pair = 0;
        int last_card = 0;
        int x;
        PictureBox b;
        int s_pairs = 8;
        int game_time = 0;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";

            for (int i = 0; i < 16; i++)
            {
                pb[i] = new PictureBox();
                pb[i].Width = 120;
                pb[i].Height =160;
                pb[i].BackColor = Color.Black;
                pb[i].Visible = true;
                pb[i].Enabled = false;
                pb[i].BorderStyle = BorderStyle.Fixed3D;
                pb[i].BackgroundImage = image_back;
                pb[i].BackgroundImageLayout = ImageLayout.Stretch;
                pb[i].Top =  30 + (i / 4) * 160;
                pb[i].Left = 30 + (i % 4) * 120;
                pb[i].Click += new EventHandler(pb_Click);
                pb[i].Name = i.ToString();
                this.Controls.Add(pb[i]);

                solve[i] = false;
            }
            for(int i = 0; i<8;i++)
            {
                image_list[i] = Image.FromFile(Application.StartupPath +"\\"+(i+1) +".jpg");
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Enabled = false;
            label1.Text = "";
            label2.Text = "";

            int[] imark = {2, 2, 2, 2, 2, 2, 2, 2};

            for(int i=0; i<16; i++)
            {
                int s;
                do { s = rr.Next(0, 8); } while (imark[s] == 0);              
                pb[i].BackgroundImage = image_list[s];
                pb_image[i] = s;
                imark[s]--;
                pb[i].Enabled = false;
            }
            timer2.Enabled = true;
            game_time = 0;
        }
 
        private void pb_Click(object sender, EventArgs e)
        {
            b = (PictureBox) sender;

            x = Convert.ToInt16(b.Name);
            
            if(!solve[x])
            {
                b.Enabled = false;
                b.BackgroundImage = image_list[pb_image[x]];
                pair++;

                if (pair == 2)
                {
                    for (int i = 0; i < 16; i++) pb[i].Enabled = false;
                   
                    timer1.Enabled = true;
                    pair = 0;
                }
                else
                    last_card = x;
            }
        }

        bool check_2_cards(int x, int y)
        {
            if (pb_image[x] == pb_image[y])
                return true;           
             else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check_2_cards(last_card, x)) //match
            {
                solve[x] = solve[last_card] = true;
                if(--s_pairs==0)
                {
                    for (int i=0; i < 16; i++) solve[i] = false;
                    s_pairs = 8;
                    label1.Text = "完成";
                    button1.Enabled = true;
                    timer3.Enabled = false;

                    Form2 form2 = new Form2();
                    form2.Gametime = game_time;
                    form2.Show();
                   
                }
            }
            else
            {
                b.BackgroundImage = image_back;
                pb[last_card].BackgroundImage = image_back;

            }
            for (int i = 0; i < 16; i++) pb[i].Enabled = true;
            timer1.Enabled = false;

        }

        int time_cnt = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            time_cnt++;
            if (time_cnt == 10)
            {
                timer2.Enabled = false;
                for (int i = 0; i < 16; i++)
                {
                    pb[i].BackgroundImage = image_back;
                    pb[i].Enabled = true;
                }
                time_cnt = 0;
                label1.Text = "";
                timer3.Enabled = true;
            }
            else
                label1.Text = "記憶時間: "+(10 - time_cnt).ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            game_time++;
            label2.Text = "遊戲時間: " + game_time + " 秒"; 
        }

        private void 歷史紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void 排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
