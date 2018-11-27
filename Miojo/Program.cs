using System;

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

            if (ampulheta1.duracao < miojo.tempoCozimento || ampulheta2.duracao < miojo.tempoCozimento)
            {
                Console.Clear();
                Console.WriteLine("Por favor, os valores de ambas ampulhetas deve ser maior que o tempo de cozimento do miojo.");

                return;
            }
        }
    }
}
