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

    public partial class Form2 : Form
    {

        public string playername;
        public int gametime;
        public int Gametime
        {
            set
            {
                gametime = value;
            }
        }

        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            playername = name.Text;
            MessageBox.Show("玩家:  " + playername +"\n"+ "成績:  " + gametime +"秒");

            Form3 f3 = new Form3(playername,gametime);
            f3.Show();
            this.Close();
        }


    }
}
