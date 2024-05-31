using NUnit.Framework;
using System;

namespace TestJaratKezeloProject
{
    [TestFixture]
    public class JaratKezeloTests
    {
        private JaratKezelo jaratKezelo;

        [SetUp]
        public void SetUp()
        {
            jaratKezelo = new JaratKezelo();
        }

        [Test]
        public void UjJarat_ShouldAddNewJarat()
        {
            jaratKezelo.UjJarat("A21", "ame", "fol", DateTime.Now);
            var indulasiIdo = jaratKezelo.MikorIndul("A21");

            Assert.AreEqual(indulasiIdo.Date, DateTime.Now.Date);
        }

        [Test]
        public void UjJarat_DuplicateJaratSzam_ShouldThrowException()
        {
            jaratKezelo.UjJarat("A21", "ame", "fol", DateTime.Now);

            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.UjJarat("A21", "ame", "fol", DateTime.Now);
            });
        }

        [Test]
        public void Keses_ShouldUpdateKeses()
        {
            jaratKezelo.UjJarat("A21", "ame", "fol", DateTime.Now);
            jaratKezelo.Keses("A21", 15);
            var indulasiIdo = jaratKezelo.MikorIndul("A21");

            Assert.AreEqual(indulasiIdo, DateTime.Now.AddMinutes(15));
        }

        [Test]
        public void Keses_NegativeResult_ShouldThrowException()
        {
            jaratKezelo.UjJarat("A21", "ame", "fol", DateTime.Now);

            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.Keses("A21", -10);
            });
        }

        [Test]
        public void MikorIndul_NonExistentJarat_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.MikorIndul("NonExistent");
            });
        }

        [Test]
        public void JaratokRepuloterrol_ShouldReturnCorrectJaratok()
        {
            jaratKezelo.UjJarat("A21", "ame", "fol", DateTime.Now);
            jaratKezelo.UjJarat("A24", "ame", "fil", DateTime.Now);

            var result = jaratKezelo.JaratokRepuloterrol("ame");

            Assert.AreEqual(2, result.Count);
            Assert.Contains("A21", result);
            Assert.Contains("22", result);
        }
    }
}