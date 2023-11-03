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
    public class EnemyTests
    {
        [TestMethod()]
        public void InitializeTest()// Ce test verifie que une fois que l'enemy soit passé dans la methode Initialize que sa position soit la bonne
        {
            Enemy enemy = new Enemy();
            enemy.Initialize(5, 7);
            Assert.AreEqual(5, enemy.PosX);
            Assert.AreEqual(7, enemy.PosY);
        }
    }
}