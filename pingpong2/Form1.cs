using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingpong2
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int points = 0;
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();                                       // hide the cursor
            this.FormBorderStyle = FormBorderStyle.None;         //removr any border
            this.TopMost = true;                                 // bring the form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;          //make it full screen
            racket.Top = playground.Bottom - (playground.Bottom / 10); //set the position of the racket

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2);
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2); // set the cursor to the position
            ball.Left += speed_left; //move the ball
            ball.Top += speed_top;
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                points += 1;
                points_lbl.Text = points_lbl.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 250), r.Next(155, 255), r.Next(150, 255));
            }
            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                gameover_lbl.Visible = true;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }  //press escape to quit
            if (e.KeyCode == Keys.S)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
                playground.BackColor = Color.Chocolate;

            }
        }

        private void points_lbl_Click(object sender, EventArgs e)
        {

        }


      
    }
}
