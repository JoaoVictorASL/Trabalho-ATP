using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batalha_Naval
{
    internal class Posicao
    {
        private int linha;
        private int coluna;

        public int Linha
        {
            get { return linha; }
            set { linha = value; }
        }

        public int Coluna
        {
            get { return coluna; }
            set { coluna = value; }
        }
    }
}
