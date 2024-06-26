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
            for(int i = 0; i < linhas; i++) 
            {
                for(int j = 0; j < colunas; j++)
                {
                    tabuleiro[i, j] = 'A';
                }
            }

            pontuacao = 0;
            numTirosDados = 0;
            posTirosDados = new Posicao[numTirosDados];
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
    }
}
