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
            MiojoCozimento miojoCozimento = new MiojoCozimento(11, 6, 5);

            int tempoGasto = miojoCozimento.ObterTempoDeCozimento();

            Assert.AreEqual(tempoGasto, 11);
        }

        [Test]
        public void Deve_Retornar_Zero_Quando_Valor_Das_Ampulhetas_Nao_Estiver_Correto()
        {
            MiojoCozimento miojoCozimento = new MiojoCozimento(1, 1, 2);

            int tempoGasto = miojoCozimento.ObterTempoDeCozimento();

            Assert.AreEqual(tempoGasto, 0);
        }
    }
}
