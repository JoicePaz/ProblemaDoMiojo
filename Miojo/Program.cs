using System;

namespace Miojo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valorAmpulhetasCorreto;
            bool tempoCozimentoCorreto;
            bool possivelCozinharOMiojo;

            int tempoAmpulheta1;
            int tempoAmpulheta2;
            int tempoCozimento;
            int tempoGasto = 0;
            int duracao;

            Ampulheta ampulheta1;
            Ampulheta ampulheta2;
            Miojo miojo;

            Console.WriteLine("Digite o tempo gasto para o cozimento do miojo");
            tempoCozimento = Int32.Parse(Console.ReadLine());
            miojo = new Miojo(tempoCozimento);

            Console.WriteLine("Digite a duração da primeira ampulheta");
            duracao = Int32.Parse(Console.ReadLine());
            ampulheta1 = new Ampulheta(duracao);

            Console.WriteLine("Digite a duração da segunda ampulheta");
            duracao = Int32.Parse(Console.ReadLine());
            ampulheta2 = new Ampulheta(duracao);

            valorAmpulhetasCorreto = IsValorAmpulhetasCorreto(ampulheta1.duracao, ampulheta2.duracao, miojo.tempoCozimento);
            possivelCozinharOMiojo = IsPossivelCozinharOMiojo(ampulheta1.duracao, ampulheta2.duracao, miojo.tempoCozimento);
            tempoCozimentoCorreto = IsTempoCozimentoCorreto(miojo.tempoCozimento);

            Console.Clear();

            if (valorAmpulhetasCorreto)
            {
                if (tempoCozimentoCorreto)
                {
                    if (possivelCozinharOMiojo)
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
                    }
                    else
                    {
                        Console.WriteLine("As ampulhetas disponíveis não permitem o cozimento do miojo");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, o tempo de cozimento não pode ser menor ou igual a zero.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, os valores de ambas ampulhetas deve ser maior que o tempo de cozimento do miojo.");
            }

            Console.Read(); //para manter o console aberto até que seja pressionado algo
        }

        private static bool IsPossivelCozinharOMiojo(int a1Duracao, int a2Duracao, int tempoCozimento)
        {
            int numero = Mdc(a1Duracao, a2Duracao);

            if ((tempoCozimento % numero) == 0)
                return true;
            return false;
        }

        private static bool IsValorAmpulhetasCorreto(int a1Duracao, int a2Duracao, int tempoCozimento)
        {
            if (a1Duracao < tempoCozimento || a2Duracao < tempoCozimento)
                return false;
            return true;
        }

        private static bool IsTempoCozimentoCorreto(int tempoCozimento)
        {
            if (tempoCozimento <= 0)
                return false;
            return true;
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
