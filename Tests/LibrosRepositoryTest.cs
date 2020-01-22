using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

namespace Tests
{
    [TestClass]
    public class LibrosRepositoryTest
    {
        [TestMethod]
        public void TestObtenerMenorNumeroCuyaSumaDeDigitosSeaIgualAlNumeroDado1Digito()
        {
            var number = 2;
            var result = ResultadoDelMetodo(number);

            Assert.AreEqual(number, result, "No está andando correctamente");
        }

        [TestMethod]
        public void TestObtenerMenorNumeroCuyaSumaDeDigitosSeaIgualAlNumeroDado2Digitos()
        {
            var number = 10;
            var result = ResultadoDelMetodo(number);

            Assert.AreEqual(19, result, "No está andando correctamente");
        }

        [TestMethod]
        public void TestObtenerMenorNumeroCuyaSumaDeDigitosSeaIgualAlNumeroDadoMax()
        {
            var number = 50;
            var result = ResultadoDelMetodo(number);

            Assert.AreEqual(599999, result, "No está andando correctamente");
        }


        public int ResultadoDelMetodo(int number)
        {
            var repo = new LibroRepository();
            var result = repo.ObtenerMenorNumeroCuyaSumaDeDigitosSeaIgualAlNumeroDado(number);

            return result;
        }
    }
}
