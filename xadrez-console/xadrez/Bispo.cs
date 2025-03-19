using tabuleiro;

namespace xadrez
{
    class Bispo : Peca 
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base (tabuleiro, cor) { }

        public override string ToString()
        {
            return "B";
        }

        private bool podeMover(Posicao posicao)
        {
            Peca _peca = tabuleiro.peca(posicao);
            return _peca == null || _peca.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao posicao_ = new Posicao(0, 0);

            // noroeste
            posicao_.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.definirValores(posicao_.linha - 1, posicao_.coluna - 1);
            }

            // nordeste
            posicao_.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.definirValores(posicao_.linha - 1, posicao_.coluna + 1);
            }

            // sudeste
            posicao_.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.definirValores(posicao_.linha + 1, posicao_.coluna + 1);
            }

            // sudoeste
            posicao_.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao.definirValores(posicao_.linha + 1, posicao_.coluna - 1);
            }

            return matriz;
        }
    }
}
