using System;
using System.Collections.Generic;
using System.Text;

namespace Miojo
{
    public class Miojo
    {

        public int tempoCozimento { get; set; }

        public Miojo(int tempoCozimento)
        {
            if (IsTempoCozimentoCorreto(tempoCozimento))
            {
                this.tempoCozimento = tempoCozimento;
            }
            else
            {
                Console.WriteLine("Por favor, o tempo de cozimento não pode ser menor ou igual a zero.");
            }
        }

        private static bool IsTempoCozimentoCorreto(int tempoCozimento)
        {
            return tempoCozimento > 0;
        }
    }
}
