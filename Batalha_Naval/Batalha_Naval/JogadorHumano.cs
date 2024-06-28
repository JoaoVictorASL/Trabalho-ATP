using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batalha_Naval
{
    internal class JogadorHumano
    {
        private char[,] tabuleiro;
        private int pontuacao;
        private int numTirosDados;
        private Posicao[] posTirosDados;
        private string nickname;

        public JogadorHumano(int linhas, int colunas, string nomeCompleto)
        {
            tabuleiro = new char[linhas, colunas];
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    tabuleiro[i, j] = 'A';
                }
            }

            pontuacao = 0;
            numTirosDados = 0;
            posTirosDados = new Posicao[linhas * colunas];
            for (int i = 0; i < posTirosDados.Length; i++)
            {
                posTirosDados[i] = new Posicao(-1, -1);
            }

            nickname = GerarNickname(nomeCompleto);
        }

        public char[,] Tabuleiro
        {
            get { return tabuleiro; }
            set { tabuleiro = value; }
        }

        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }

        public int NumTirosDados
        {
            get { return numTirosDados; }
            set { numTirosDados = value; }
        }

        public Posicao[] PosTirosDados
        {
            get { return posTirosDados; }
            set { posTirosDados = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string GerarNickname(string nomeCompleto)
        {
            string[] vetorNome = nomeCompleto.Split(' ');
            string apelido = vetorNome[0];

            for (int i = 1; i < vetorNome.Length; i++)
            {
                apelido += vetorNome[i].Substring(0, 1).ToUpper();
            }
            return apelido;
        }

        public Posicao EscolherAtaque()
        {
            bool teste = true;
            Posicao tiro = null;

            do
            {
                Console.Write("Informe a linha do Ataque: ");
                int lin = int.Parse(Console.ReadLine());
                Console.Write("Informe a coluna do Ataque: ");
                int col = int.Parse(Console.ReadLine());
                tiro = new Posicao(lin, col);

                if (lin < 0 || lin >= tabuleiro.GetLength(0) || col < 0 || col >= tabuleiro.GetLength(1))
                {
                    Console.WriteLine("Posição fora dos limites do tabuleiro. Tente novamente.");
                    teste = false;
                }
                else
                {
                    teste = true;
                    for (int i = 0; i < posTirosDados.Length && teste; i++)
                    {
                        if (tiro.Linha == posTirosDados[i].Linha && tiro.Coluna == posTirosDados[i].Coluna)
                        {
                            Console.WriteLine("Posição já utilizada. Tente novamente.");
                            teste = false;
                        }
                    }
                }

            } while (!teste);

            posTirosDados[numTirosDados] = tiro;
            numTirosDados++;

            return tiro;
        }

        public bool ReceberAtaque(Posicao tiroRecebido)
        {
            bool acertou = false;

            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (i == tiroRecebido.Linha && j == tiroRecebido.Coluna)
                    {
                        if (tabuleiro[i, j] != 'A')
                        {
                            acertou = true;
                            tabuleiro[i, j] = 'T';
                        }
                        else if (tabuleiro[i, j] == 'A')
                        {
                            tabuleiro[i, j] = 'X';
                        }
                    }
                }
            }

            return acertou;
        }

        public void ImprimirTabuleiroJogador()
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    Console.Write($"  " + tabuleiro[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void ImprimirTabuleiroAdversario()
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (tabuleiro[i, j] == 'A' || tabuleiro[i, j] == 'T' || tabuleiro[i, j] == 'X')
                    {
                        Console.Write($"  " + tabuleiro[i, j]);
                    }
                    else
                    {
                        Console.Write("A");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool AdicionarEmbarcacao(Embarcacao embarcacao, Posicao posEmbarcacao)
        {
            bool ehPossivel = false;

            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (i == posEmbarcacao.Linha && j == posEmbarcacao.Coluna)
                    {
                        if (i + embarcacao.Tamanho <= 9)
                        {
                            ehPossivel = true;
                        }
                    }
                }
                Console.WriteLine();
            }

            return ehPossivel;
        }
    }
}
