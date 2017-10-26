using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RatLab
{
    public partial class Maze : Form
    {
        private int cntTurns = 0;
        private bool sexyTime = false;
        private int[] sexyPlace = new int[2];
        Timer timer = new Timer();
        private int[] exit = { 31, 16 };//{ 15, 9 };
        private List<RatManager> rats = new List<RatManager>();
        public Maze()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initRats();
            drawRat(rats[0]);
        }

        public void initRats()
        {
         //   rats.Add(new RatManager("Herr Hoffmann", 1, 3, 0, Color.FromArgb(128, 160, 80, 80), new LSDRat()));
            rats.Add(new RatManager("GY", 1, 3, 0, Color.FromArgb(128, 0, 160 , 0), new RatYoffe()));
           // rats.Add(new RatManager("Kollektiv", 1, 3, 0, Color.FromArgb(90,  10,50,0), new Rateck()));
         //   rats.Add(new RatManager("Herr Eckart", 1, 3, 0, Color.FromArgb(128, 0,0, 160), new Rattleck()));
        }


        public bool playGame()
        {
            PictureBox pic;
            int xOff = 0;
            int yOff = 0;
            int turn;
            bool canMove;

            cntTurns++;
            label1.Text = cntTurns.ToString();
            listBox1.Items.Clear();

            foreach (RatManager rat in rats)
            {
                if (rat.x == exit[0] && rat.y == exit[1])
                {
                    Console.WriteLine("exit found");
                    listBox1.Items.Add(rat.ToString());
                    continue;
                }

                //translate direction into Offset for x or y
                switch (rat.dir)
                {
                    case 0:
                        xOff = 0;
                        yOff = -1;
                        break;
                    case 1:
                        xOff = 1;
                        yOff = 0;
                        break;
                    case 2:
                        xOff = 0;
                        yOff = 1;
                        break;
                    case 3:
                        xOff = -1;
                        yOff = 0;
                        break;
                }
                // check if rat faces Wall, and call .move with the resuting bool
                pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(rat.x + xOff, rat.y + yOff);
                if (pic.BackColor.Equals(pBCliche.BackColor))
                {
                    Console.WriteLine("Wall");
                    canMove = false;
                    turn = rat.move(canMove);
                }
                else
                {
                    Console.WriteLine("Hallway");
                    canMove = true;
                    turn = rat.move(canMove);
                }
                // handle return value of .move
                Console.WriteLine("++++ Command: " + turn);
                if (!canMove && turn == 0)
                    Console.WriteLine("Error, rat cant go there!");
                else
                    undrawRat(rat);
                if (canMove && turn == 0)
                {
                    rat.x += xOff;
                    rat.y += yOff;
                    Console.WriteLine("New Position: " + rat.x + "  " + rat.y);
                }
                else if (turn == 1)
                {
                    Console.WriteLine("Rat turns clockwise");
                    rat.dir = (rat.dir + turn) % 4;
                    Console.WriteLine("New Rat direction: " + rat.dir);
                }
                else if (turn == -1)
                {
                    Console.WriteLine("Rat turns anti-clockwise");
                    rat.dir = (rat.dir + 4 + turn) % 4;                 // +4 to avoid negative numbers
                    Console.WriteLine("New Rat direction: " + rat.dir);
                }
                drawRat(rat);
                if (sexyTime && turn == 0)
                {
                    sexyTime = false;
                    handleDeadEnd(sexyPlace[0], sexyPlace[1]);
                }
                if (turn == 69)
                {
                    Console.WriteLine("Rat is in a deadend");
                    sexyPlace[0] = rat.x;
                    sexyPlace[1] = rat.y;
                    sexyTime = true;
                }
                int index = listBox1.Items.Add(rat.ToString());
            }
            return false;
        }

        public void undrawRat(RatManager rat)
        {
            PictureBox pic;
            pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(rat.x, rat.y);
            pic.Image = null;
            pic.BackColor = rat.colors;//Color.FromName("White");
        }

        public void drawRat(RatManager rat)
        {
            PictureBox pic;
            pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(rat.x, rat.y);
            switch(rat.dir){
                case 0: 
                    pic.Image = ratpics.rat_alpha0;
                    break;
                case 1:
                    pic.Image = ratpics.rat_alpha1;
                    break;
                case 2:
                    pic.Image = ratpics.rat_alpha2;
                    break;
                case 3:
                    pic.Image = ratpics.rat_alpha3;
                    break;
                    
            }
            pic.BackColor = rat.colors;
        }
        private void handleDeadEnd(int x, int y)
        {
            PictureBox pic;
            pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(x, y);
            pic.BackColor = pBCliche.BackColor;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            playGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Text = "Start";
            timer1.Stop();
            playGame();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text == "Stop")
            {
                button2.Text = "Start";
                timer1.Stop();
            }
            else
            {
                button2.Text = "Stop";
                timer1.Start();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int val;
            if (textBox1.Text != "")
            {
                try
                {
                    val = Int32.Parse(textBox1.Text);
                    if (val > 0)
                    {
                        timer1.Interval = val;
                    }
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
