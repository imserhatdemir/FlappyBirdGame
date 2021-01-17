using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamebird
{
    public partial class game : Form
    {

        int hız = 6;
        int zemin = 5;
        int skor = 0;
        public game()
        {
            InitializeComponent();
        }

       
        private void gamekeyidown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space )
            {
                zemin = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                 zemin = 10;
            }
        }
        private void endGame()
        {
            gametimer.Stop();
            button1.Visible = true;
            button2.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label3.Text += "SKOR:" + skor;
           
        }
        private void gametimerevent(object sender, EventArgs e)
        {
            flappyBird.Top += zemin;
            pipeBottom.Left -= hız; 
            pipeTop.Left -= hız; 
            label1.Text = "SKOR: " + skor;
            
            if (pipeBottom.Left < -150)
            {
              
                pipeBottom.Left = 400;
                skor++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 550;
                skor++;
            }

            
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
              
                endGame();
            }


          
            if (skor >= 5)
            {
                hız = 8;
            }
            if (skor >= 20)
            {
                hız = 10;
            }
            if (skor >= 50)
            {
                hız = 15  ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

      
    }
}
