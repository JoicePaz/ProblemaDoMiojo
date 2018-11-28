using System;
using System.Collections.Generic;
using System.Text;

namespace Miojo
{
    public class MiojoCozimento
    {
        private readonly int _ampulheta1Duracao;
        private readonly int _ampulheta2Duracao;
        private readonly int _tempoCozimento;



        public MiojoCozimento(int ampulheta1Duracao, int ampulheta2Duracao, int tempoCozimento)
        {
            _ampulheta1Duracao = ampulheta1Duracao;
            _ampulheta2Duracao = ampulheta2Duracao;
            _tempoCozimento = tempoCozimento;
        }

        public int ObterTempoDeCozimento()
        {
            int tempoAmpulheta1;
            int tempoAmpulheta2;
            int tempoGasto = 0;

            bool valorAmpulhetasCorreto = IsValorAmpulhetasCorreto(_ampulheta1Duracao, _ampulheta2Duracao, _tempoCozimento);
            bool possivelCozinharOMiojo = IsPossivelCozinharOMiojo(_ampulheta1Duracao, _ampulheta2Duracao, _tempoCozimento);

            if (valorAmpulhetasCorreto || possivelCozinharOMiojo)
            {
                tempoAmpulheta1 = _ampulheta1Duracao;
                tempoAmpulheta2 = _ampulheta2Duracao;

                while (true)
                {
                    if (tempoAmpulheta2 < tempoAmpulheta1)
                    {
                        tempoGasto += tempoAmpulheta2;
                        if (tempoAmpulheta2 == _tempoCozimento)
                            break;

                        tempoAmpulheta1 = tempoAmpulheta1 - tempoAmpulheta2;
                        tempoAmpulheta2 = _ampulheta2Duracao;
                    }
                    else
                    {
                        tempoGasto += tempoAmpulheta1;
                        if (tempoAmpulheta1 == _tempoCozimento)
                            break;

                        tempoAmpulheta2 = tempoAmpulheta2 - tempoAmpulheta1;
                        tempoAmpulheta1 = _ampulheta1Duracao;
                    }
                }
                return tempoGasto;
            }
            return 0;
        }

        private bool IsPossivelCozinharOMiojo(int a1Duracao, int a2Duracao, int tempoCozimento)
        {
            int numero = Mdc(a1Duracao, a2Duracao);
            return ((tempoCozimento % numero) == 0);
        }

        private bool IsValorAmpulhetasCorreto(int a1Duracao, int a2Duracao, int tempoCozimento)
        {
            return (a1Duracao > tempoCozimento || a2Duracao > tempoCozimento);
        }

        private int Mdc(int a1Duracao, int a2Duracao)
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
