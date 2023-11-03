using Microsoft.VisualStudio.TestTools.UnitTesting;
using POO_YohCardisv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_YohCardisv2.Tests
{
    [TestClass()]
    public class ShipTests
    {
        [TestMethod()]
        public void InitializeTest() // Ce test verifie que une fois que le ship soit passé dans la methode Initialize que sa position soit la bonne
        {
            Ship ship = new Ship();
            ship.Initialize(5, 7);
            Assert.AreEqual(5, ship.PosX);
            Assert.AreEqual(7, ship.PosY);
        }
    }
}