using Microsoft.VisualStudio.TestTools.UnitTesting;
using POO_YohCardisv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Eleve : Yohan Cardis
///École: ETML
///Date: 03.11/2023
namespace POO_YohCardisv2.Tests
{
    [TestClass()]
    public class MissileTests
    {
        [TestMethod()]
        public void InitializeTest() // Ce test verifie que une fois que le Missile soit passé dans la methode Initialize que sa position soit la bonne
        {
            Missile missile = new Missile();
            missile.Initialize(5, 7);
            Assert.AreEqual(5, missile.PosX);
            Assert.AreEqual(7, missile.PosY);
        }

        [TestMethod()]
        public void MoveTest() // Ce test verifie que une fois que le Missile soit passé dans la methode Move que sa position soit la bonne(y - 1)
        {
            Missile missile = new Missile();
            missile.Initialize(5, 7);
            missile.Move();
            Assert.AreEqual(5, missile.PosX);
            Assert.AreEqual(6, missile.PosY);
        }
    }
}