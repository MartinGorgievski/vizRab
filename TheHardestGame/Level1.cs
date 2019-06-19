using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheHardestGame
{
    public partial class Level1 : Form
    {
        //public Square square;
        public GameDoc gameDoc;
        private Timer timer;
        private int TimerCount;
        //private bool timerActive;
        public Level1()
        {   
            InitializeComponent();
            panel1.Hide();
            DoubleBuffered = true;
            gameDoc = new GameDoc();
            timer = new Timer();
            timer.Interval = 10;
            TimerCount = 0;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            //timerActive = true;
            this.BackColor = Color.White;
            btnMenu.Hide();
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            TimerCount += timer.Interval;
            foreach(var item in gameDoc.balls)
            {
                item.MoveBall();
                Invalidate(true);
            }
        }
        private void Level1_Paint(object sender, PaintEventArgs e)
        {
            Brush b = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pen.Width = 5;
            toolStripLabel1.Text = "X: " + gameDoc.square.X + ", Y: " + gameDoc.square.Y;
            e.Graphics.DrawLines(pen, gameDoc.points);
            gameDoc.DrawBalls(e.Graphics);
            Time.Text = (TimerCount / 1000).ToString() + ":"+ (TimerCount % 1000).ToString() + "s";
            gameDoc.DrawSquare(e.Graphics);
        }

        private void Level1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
               gameDoc.square.Move(Direction.UP);
               Invalidate(true);
            }
            if(e.KeyCode == Keys.Down)
            {
               gameDoc.square.Move(Direction.DOWN);
               Invalidate(true);
            }
            if(e.KeyCode == Keys.Left)
            {
              gameDoc.square.Move(Direction.LEFT);
              Invalidate(true);
            }

            if(e.KeyCode == Keys.Right)
            {
              gameDoc.square.Move(Direction.RIGHT);
              Invalidate(true); 
            }
           
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel1.Show();
            timer.Stop();
        }

        private void btnRezume_Click(object sender, EventArgs e)
        {
            
            panel1.Enabled = false;
            panel1.Hide();
            timer.Start();
        }
    }
}
