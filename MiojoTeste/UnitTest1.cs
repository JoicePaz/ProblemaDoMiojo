using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiojoProblema;

namespace MiojoTeste
{
    [TestClass]
    public class MiojoTeste
    {
        [TestMethod]
        public void Não_Devo_Instanciar_Um_Miojo_Sem_Tempo_De_Cozimento()
        {

            var tempoCozimento = 2;

            Miojo miojo = new Miojo(tempoCozimento);

            Assert.IsNotNull(miojo);
            Assert.IsTrue(tempoCozimento > 0);

        }


        [TestMethod]
        public void O_Tempo_Das_Ampulhetas_Nao_Devem_Ser_Menores_Que_O_Tempo_De_Preparo()
        {

            Ampulheta ampulheta1 = new Ampulheta(3);
            Ampulheta ampulheta2 = new Ampulheta(1);
            Miojo miojo = new Miojo(1);

            Assert.IsNotNull(ampulheta1);
            Assert.IsNotNull(ampulheta2);
            Assert.IsTrue(ampulheta1.duracao > miojo.tempoCozimento && ampulheta2.duracao > miojo.tempoCozimento);

        }
    }
}
