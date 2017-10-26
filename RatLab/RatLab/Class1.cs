
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace RatLab
{
    public class RatManager
    {
        private IRatface brain;
        private int posX;
        private int posY;
        private Color color;
        private int direction;
        public int cntTurns;
        public int cntMoves;
        public String name;
        public long cpuTime;


        public RatManager(String name, int x, int y, int dir, Color color, IRatface brain){
            this.name = name;
            this.x = x;
            this.y = y;
            this.direction = dir;
            this.color = color;
            this.brain = brain;
        }

        public Color colors { get { return color; } set { this.color = value; } }

        public int x
        {
            get { return posX; }
            set { posX = value; }
        }

        public int y
        {
            get { return posY; }
            set { posY = value; }
        }

        public int dir
        {
            get { return direction; }
            set { direction = value; }
        }

        public int move(bool canMove)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int cmd = brain.move(canMove);
            if (cmd == 0)
                cntMoves++;
            cntTurns++;
            sw.Stop();
            cpuTime += sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
            return cmd;
        }

        public String ToString()
        {
            return this.name + " (" + this.brain.GetType() + ") " + this.cntTurns + ", " + this.cntMoves + ", "+ this.cpuTime + " us";
        }
    }
}