using System;
using System.Threading;

namespace Miojo
{
    class Program
    {
        static void Main(string[] args)
        {

            Ampulheta ampulheta1;
            Ampulheta ampulheta2;
            Miojo miojo;

            int tempoAmpulheta1;
            int tempoAmpulheta2;
            int tempoCozimento;
            int tempoGasto = 0;
            int duracao;

            Console.WriteLine("Digite o tempo gasto para o cozimento do miojo");
            tempoCozimento = Int32.Parse(Console.ReadLine());
            miojo = new Miojo(tempoCozimento);

            Console.WriteLine("Digite a duração da primeira ampulheta");
            duracao = Int32.Parse(Console.ReadLine());
            ampulheta1 = new Ampulheta(duracao);

            Console.WriteLine("Digite a duração da segunda ampulheta");
            duracao = Int32.Parse(Console.ReadLine());
            ampulheta2 = new Ampulheta(duracao);

            
            if (isValorAmpulhetasCorreto(ampulheta1.duracao, ampulheta2.duracao, miojo.tempoCozimento) 
                &&
                isTempoCozimentoCorreto(miojo.tempoCozimento)
                && 
                isPossivelCozinharOMiojo(ampulheta1.duracao, ampulheta2.duracao, miojo.tempoCozimento))
            {
                tempoAmpulheta1 = ampulheta1.duracao;
                tempoAmpulheta2 = ampulheta2.duracao;

                while (true)
                {
                    if (tempoAmpulheta2 < tempoAmpulheta1)
                    {
                        tempoGasto += tempoAmpulheta2;

                        if (tempoAmpulheta2 == tempoCozimento)
                            break;

                        tempoAmpulheta1 = tempoAmpulheta1 - tempoAmpulheta2;
                        tempoAmpulheta2 = ampulheta2.duracao;
                    }
                    else
                    {
                        tempoGasto += tempoAmpulheta1;

                        if (tempoAmpulheta1 == tempoCozimento)
                            break;

                        tempoAmpulheta2 = tempoAmpulheta2 - tempoAmpulheta1;
                        tempoAmpulheta1 = ampulheta1.duracao;
                    }

                }

                Console.WriteLine("O tempo mínimo para o miojo ser cozido é de: {0} minuto(s)", tempoGasto);
                Thread.Sleep(2000);
            }
        }

        private static int Mdc(int a1Duracao, int a2Duracao)
        {
            int a1 = Math.Max(a1Duracao, a2Duracao);
            int a2 = Math.Min(a1Duracao, a2Duracao);

            if (a1 % a2 == 0)
                return a2;
            else
                return Mdc(a2, (a1 % a2));
        }

        private static bool isValorAmpulhetasCorreto(int a1, int a2, int tempoCozimento)
        {
            if (a1 < tempoCozimento || a2 < tempoCozimento)
            {
                Console.WriteLine("Por favor, os valores de ambas ampulhetas deve ser maior que o tempo de cozimento do miojo.");
                Thread.Sleep(2000);

                return false;
            }

            return true;
        }

        private static bool isTempoCozimentoCorreto(int tempoCozimento)
        {
            if (tempoCozimento <= 0)
            {
                Console.WriteLine("Por favor, o tempo de cozimento não pode ser menor ou igual a zero.");
                Thread.Sleep(2000);

                return false;
            }

            return true;
        }

        private static bool isPossivelCozinharOMiojo(int a1Duracao, int a2Duracao, int tempoCozimento)
        {
            int numero = Mdc(a1Duracao, a2Duracao);

            if ((tempoCozimento % numero) == 0)
                return true;

            Console.WriteLine("As ampulhetas disponíveis não permitem o cozimento do miojo");
            Thread.Sleep(2000);

            return false;
        }
    }

}
