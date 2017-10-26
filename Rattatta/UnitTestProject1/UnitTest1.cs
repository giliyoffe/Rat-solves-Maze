using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIfWall()
        {
            IRatFace rat = new Rateck();
            Assert.AreEqual(1, rat.move(false),"Wenn es gibt ein Wand dann dreh recht -> 1");
        }
        /*
        [TestMethod]
        public void TestIfNoWall()
        {
            IRatFace rat = new Rateck();
            Assert.AreEqual(0, rat.move(true), "Wenn kein Wand dann lauf/move -> 0");
        }
        */

        //not me
        [TestMethod]
        public void TestFirstStepIfWall()
        {
            IRatFace rat = new Rateck();
            Assert.AreEqual(1, rat.move(false));
        }
        [TestMethod]
        public void TestFirstStepIfNoWall()
        {
            IRatFace rat = new Rateck();
            Assert.AreEqual(1, rat.move(true));
        }
        [TestMethod]
        public void Test2StepIfRightWallInFrontNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(true);
            Assert.AreEqual(-1, rat.move(false));
        }
        [TestMethod]
        public void Test2StepIfRightNoWallInFrontWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false);
            Assert.AreEqual(1, rat.move(true));
        }
        [TestMethod]
        //zweiter Schritt mit Mauer vorn und rechts
        public void Test2StepIfRightWallInFrontWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false);
            Assert.AreEqual(1, rat.move(false));
        }
        [TestMethod]
        //zweiter Schritt keine Mauer vorn keine Mauer rechts
        public void Test2StepIfRightNoWallInFrontNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(true);
            Assert.AreEqual(1, rat.move(true));
        }
        [TestMethod]
        //dritter Schritt wenn vorher vorn keine Mauer und rechts ne Mauer war
        public void Test3StepFirstWasNoWallSecondWasAWall()
        {
            IRatFace rat = new Rateck();
            rat.move(true);
            rat.move(false);
            Assert.AreEqual(0, rat.move(true));
        }
        [TestMethod]
        //dritter Schritt wenn vorher vorn  Mauer und rechts keine Mauer war
        public void Test3StepFirstWasWallSecondWasNoWallThirdNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false);
            rat.move(true);
            Assert.AreEqual(1, rat.move(true));
        }
        [TestMethod]
        //dritter Schritt wenn vorher vorn  Mauer und rechts keine Mauer war
        public void Test3StepFirstWasWallSecondWasNoWallThirdWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false);
            rat.move(true);
            Assert.AreEqual(-1, rat.move(false));
        }
        /*
        [TestMethod]
        public void TestStepIfRightNoWallInFrontNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false); 
            Assert.AreEqual(1, rat.move(true));
        }
        [TestMethod]
        public void Test2StepIfRightWallInFrontNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false); 
            Assert.AreEqual(1, rat.move(false));
        }
        [TestMethod]
        public void Test2StepIfRightNoWallInFrontNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(true); 
            Assert.AreEqual(-1, rat.move(true));
        }
        [TestMethod]
        public void Test3StepFirstWallThenNoWallThirdNoWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false);
            rat.move(true);
            Assert.AreEqual(1, rat.move(true));
        }
        [TestMethod]
        public void Test3StepFirstWallThenNoWallThirdWall()
        {
            IRatFace rat = new Rateck();
            rat.move(false);
            rat.move(true);
            Assert.AreEqual(-1, rat.move(false));
        }
        */
        //me new tests

        //[TestMethod]
        //public void TestIfNoWall()
        //{
        //    IRatFace rat = new Rateck();
        //    Assert.AreEqual(1, rat.move(true), "Wenn kein Wand dann dreh recht -> 1");
        //}

        //[TestMethod] 
        //public void TestIfNoWallStraightButWallOnRight()
        //{
        //    IRatFace rat = new Rateck();
        //    rat.move(true); //no wall gerade
        //    rat.move(false); // wall right
        //    Assert.AreEqual(0, rat.move(true), "Wenn kein Wand gerade und Wand auf rechtezeite dann lauf/move gerade -> 0");
        //}
    }
}
