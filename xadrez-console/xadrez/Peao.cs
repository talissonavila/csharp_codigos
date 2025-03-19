using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao (Tabuleiro tabuleiro, Cor cor) : base (tabuleiro, cor) { }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao posicao)
        {
            Peca _peca = tabuleiro.peca(posicao);
            return _peca != null && _peca.cor != cor;
        }

        private bool livre(Posicao posicao)
        {
            return tabuleiro.peca(posicao) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao posicao_ = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                posicao_.definirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.isPosicaoValida(posicao_) && livre(posicao_))
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha - 2, posicao.coluna);
                if (tabuleiro.isPosicaoValida(posicao_) && livre(posicao_) && quantidadeDeMovimentos == 0)
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao.coluna] = true;
                }

                posicao_.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao.coluna] = true;
                }
            }
            else if (cor == Cor.Preta)
            {
                posicao_.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.isPosicaoValida(posicao_) && livre(posicao_))
                {
                    matriz[posicao_.linha, posicao.coluna] = true;
                }

                posicao_.definirValores(posicao.linha + 2, posicao.coluna);
                if (tabuleiro.isPosicaoValida(posicao_) && livre(posicao_) && quantidadeDeMovimentos == 0)
                {
                    matriz[posicao_.linha, posicao.coluna] = true;
                }

                posicao_.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao.coluna] = true;
                }

                posicao_.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao.coluna] = true;
                }
            }

            return matriz;
        }
    }
}
