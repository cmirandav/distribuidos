using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCrearPaisOK()
        {
            PaisesWS.PaisesClient proxy = new PaisesWS.PaisesClient();
            PaisesWS.Pais paisCreado = proxy.CrearPais(new PaisesWS.Pais()
            {
                cod_pais="ARG",
                nom_pais="ARGENTINA"
            }
            );

            Assert.AreEqual("ARG", paisCreado.cod_pais);
            Assert.AreEqual("ARGENTINA", paisCreado.nom_pais);
        }

        [TestMethod]
        public void TestCrearPaisRepetido()
        {
            PaisesWS.PaisesClient proxy = new PaisesWS.PaisesClient();
            try
            {
                PaisesWS.Pais paisCreado = proxy.CrearPais(new PaisesWS.Pais()
                {
                    cod_pais = "ARG",
                    nom_pais = "ARGENTINA"
                }
                );
            }
            catch (FaultException<PaisesWS.PaisRepetido> error)
            {
                Assert.AreEqual("Error al intentar crear Pais", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo , "101");
                Assert.AreEqual(error.Detail.Descripcion , "El codigo de Pais ya existe");
            }
        }
    }
}
