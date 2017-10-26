using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatLab
{
  


    public class Rateck : IRatface
    {
        bool firstInput;
        bool turnTwice = false;
        int stepCounter = 0;


        public int move(bool canGo)
        {

            //muss sein
            // drehe nach rechts
            if (stepCounter == 0)
            {
                firstInput = canGo;
                stepCounter++;
                return 1;
            }
            //schaue was rechts ist
            if (stepCounter == 1)
            {
                if (turnTwice)
                {
                    turnTwice = false;
                    stepCounter++;
                    return 1;
                }
                //wenn rechts frei => gehe nach rechts
                if (canGo)
                {
                    stepCounter = 0;
                    return 0;
                }

                //wenn geradeaus frei und rechts blockiert => laeuft geradeaus weiter (stepCounter = 2)
                if (firstInput)// && !canGo)
                {
                    stepCounter++;
                    return -1;
                }

                //schau links, wenn frei gehe links
                turnTwice = true;
                return 1;

            }
            
            if (stepCounter == 2){
                if (canGo)
                {
                    stepCounter = 0;
                    return 0;
                }
                // Sackgasse
                stepCounter++;
                return -1;
            }
            if (stepCounter++ == 3)
                return 69;
            
            // stepCounter == 4 
            stepCounter = 0;
            return 0;
   
        }
    }

    public class Rattleck : IRatface
    {
        int stepCounter = 0;
        bool lastView;

        public int move(bool canGo)
        {
            if (stepCounter == 3)
            {
                stepCounter = 0;
                return -1;
            }

            if (stepCounter == 2)
            {
                stepCounter = 0;
                return 0;
            }
            if (stepCounter == 1)
            {
                //bin nach rechts gedreht
                //da ist frei ich gehe
                if (canGo)
                {
                    stepCounter = 0;
                    return 0;
                }
                //da ist nicht frei 
                //aber der vorherige war frei dann da lang
                if (lastView)
                {
                    //zurückdrehen und gehen (gehen über stepCounter)
                    stepCounter = 2;
                    return -1;
                }
                //der vorherige war nicht frei, vielleicht ja links von mir
                if (!lastView)
                {
                    //um 180 Grad drehen
                    stepCounter = 3;
                    return -1;
                }

            }
            //if (stepCounter == 0)
            {
                stepCounter = 1;
                lastView = canGo;
                return 1;
            }

        }
    }


    public class RatGampe : IRatface
    {
        int position = 0;

        public int move(bool canMove)
        {
            // if facing right and no wall: move 
            if (position == 1)
            {
                return 0;
            }
            // check if move 
            return 1;
        }
    }

    public class LSDRat : IRatface
    {
        int state = 0;
        bool hasMoved = false;
        Random r = new Random();
        public int move(bool Wand)
        {
            if (state == 5)
            {
                state = 0;
                return 0;
            }
            if (state == 4){
                state = 5;
                return 69;
            }
            if (state == 3 && !Wand)
            {
                state = 4;
                return -1;
            }
            if (state == 2)
            {
                state = 3;
                return 1;
            }
            if (state == 1 && !Wand)
            {
                state = 2;
                return 1;
            }
            // check if wall ahead and has moved
            if (hasMoved && !Wand)
            {
                state = 1; //look around
                return 1;
                // if dead end return 69 (have a sexyTime)
            }
            int myMove = r.Next(-1, 2);
            hasMoved = myMove == 0;
            state = 0;
            return myMove;
        }
    }

    public class RatYoffe : IRatface
    {
        private int rightTurnCount = 0;
        private int leftTurnCount = 0;
        private int canMoveCount = 0;

        //true == kein Wand. false == Wand
        public int move(bool Wand)
        {

            if (
                 (leftTurnCount == 3) ||
                 ((leftTurnCount == 1) && (canMoveCount == 1) && (rightTurnCount == 1)) ||
                 ((leftTurnCount == 0) && (canMoveCount == 0) && (rightTurnCount == 1)) && Wand ||
                 ((leftTurnCount == 0) && (canMoveCount == 1) && (rightTurnCount == 1) && Wand)
                )
            {
                rightTurnCount = 0;
                leftTurnCount = 0;
                canMoveCount = 0;
                return 0; // move forward
            }
            else if (!Wand && (rightTurnCount == 0))
            {
                ++rightTurnCount;
                return 1; // 1 == turn right
            }
            else if (rightTurnCount == 1) //TODO - can move to top brobably as (rightTurnCount == 1 && leftTC == 2 && Wand)  - but the else clause???
            {
                if (leftTurnCount == 2 && Wand)
                {
                    rightTurnCount = 0;
                    leftTurnCount = 0;
                    canMoveCount = 0;
                    return 0; // move forward   
                }
                ++leftTurnCount;                    //test todo facing no wall going right second position
                return -1; // -1 == turn left
            }

            ++canMoveCount;
            ++rightTurnCount;
            return 1; // 1 == turn right

        
        }
    }
}
