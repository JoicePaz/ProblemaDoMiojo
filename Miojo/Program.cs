using System;
using System.Threading;

namespace Miojo
{
    class Program
    {
        static void Main(string[] args)
        {
            Miojo miojo;
            Ampulheta ampulheta1;
            Ampulheta ampulheta2;
            int tempoCozimento;
            int tempoAmpulheta1;
            int tempoAmpulheta2;
            int duracao;
            int tempoGasto = 0;
            int numero;

            bool flag = false;

            Console.WriteLine("Digite o tempo gasto para o cozimento do miojo");
            tempoCozimento = Int32.Parse(Console.ReadLine());
            miojo = new Miojo(tempoCozimento);

            Console.WriteLine("Digite a duração da primeira ampulheta");
            duracao = Int32.Parse(Console.ReadLine());
            ampulheta1 = new Ampulheta(duracao);

            Console.WriteLine("Digite a duração da segunda ampulheta");
            duracao = Int32.Parse(Console.ReadLine());
            ampulheta2 = new Ampulheta(duracao);


            if (ampulheta1.duracao < miojo.tempoCozimento || ampulheta2.duracao < miojo.tempoCozimento)
            {
                Console.Clear();
                Console.WriteLine("Por favor, os valores de ambas ampulhetas deve ser maior que o tempo de cozimento do miojo.");

                return;
            }

            numero = Mdc(ampulheta1.duracao, ampulheta2.duracao);

            if ((tempoCozimento % numero) == 0)
                flag = true;
            

            if (flag)
            {
                tempoAmpulheta1 = ampulheta1.duracao;
                tempoAmpulheta2 = ampulheta2.duracao;

                while (flag)
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
            else
            {
                Console.WriteLine("As ampulhetas disponíveis não permitem o cozimento do miojo");
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
    }

}
