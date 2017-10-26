using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace ClassLibrary1
{
    public class Rateck : IRatFace
    {
        
        //me
    //duplicated?
        private int rightTurnCount = 0; //can be also without the 'private' - its automatic private
        private int leftTurnCount = 0;
        private int canMoveCount = 0;
         

        //besser/refactored Rat

        public class RatYoffe : IRatface
        {
            //me

            private int rightTurnCount = 0;
            private int leftTurnCount = 0;
            private int canMoveCount = 0;

            //true == kein Wand. false == Wand
            public int move(bool Wand)
            {
                //me

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
                    if (leftTurnCount == 2 && Wand)//added Wand - works better
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

        /*
        //true == kein Wand. false == Wand
        public int move(bool Wand)
        {

            //me
            
            if (
                (leftTurnCount == 3) && Wand || //maybe can remove '&& Wand'
                ((leftTurnCount == 1) && (canMoveCount == 1) && (rightTurnCount == 1)) && Wand ||
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
                else if (rightTurnCount == 1)
                {
                    if ((canMoveCount == 1) && Wand )//fixme facing wall
                    {
                        rightTurnCount = 0;
                        leftTurnCount = 0;
                        canMoveCount = 0;
                        return 0; // move forward
                    }
                    if (leftTurnCount == 2 && Wand)//added wand check it
                    {
                        rightTurnCount = 0;
                        leftTurnCount = 0;
                        canMoveCount = 0;
                        return 0; // move forward   
                    }
                    ++leftTurnCount;
                    return -1; // -1 == turn left
                }
                else  
	            {
                     ++canMoveCount;
                     ++rightTurnCount;
                     return 1; // 1 == turn right
	            }
            */

        /*
            ////not me
            
             //not finished
             //teachers/class solution TDD test driver development - writing the test first and changing the code accordingly:
            // before the move function:
            bool firstInput;
            //bool turnTwice = false;
            int stepCounter = 0;
            public int move(bool canGo) //canGo was Wall
            {
                //nuss sein
                if (stepCounter == 0)
	            {
                    firstInput = canGo;
                    stepCounter++;
                    return 1;
	            }
               
                if (stepCounter == 1)
	            { 
		            if (firstInput && !canGo)
	                {
                        stepCounter++;
		                return -1;
	                }
                    if (canGo)
                    {
                        stepCounter = 0;
                        return 0;
                    }
	               
                    firstInput = canGo;
		            return 1;
	                
                }
                stepCounter = 0;
                return 0;
        */

                //not me - teachers solution same speed as mine
                /*
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
                 */

            }
    }
}
