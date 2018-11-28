using MiojoServico;
using NUnit.Framework;

namespace MiojoTeste
{
    [TestFixture]
    public class MiojoCozimentoTeste
    {
        [Test]
        public void Devo_Conseguir_Cozer_Um_Miojo()
        {
            MiojoCozimento miojoCozimento = new MiojoCozimento(5, 7, 3); //ampulheta 1, ampulheta 2, tempo de cozimento

            int tempoGasto = miojoCozimento.ObterTempoDeCozimento();

            Assert.AreEqual(tempoGasto, 10);
        }

        [Test]
        public void Deve_Retornar_Zero_Quando_Valor_Das_Ampulhetas_Nao_Estiver_Correto()
        {
            MiojoCozimento miojoCozimento = new MiojoCozimento(1, 1, 2);

            int tempoGasto = miojoCozimento.ObterTempoDeCozimento();

            Assert.AreEqual(tempoGasto, 0);
        }

        [Test]
        public void Deve_Retornar_Zero_Quando_Nao_For_Possivel_Cozinhar_O_Miojo()
        {
            MiojoCozimento miojoCozimento = new MiojoCozimento(7, 7, 2);

            int tempoGasto = miojoCozimento.ObterTempoDeCozimento();

            Assert.AreEqual(tempoGasto, 0);
        }
        
    }
}
