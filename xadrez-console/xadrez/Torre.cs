using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor) { }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao posicao_ = new Posicao(0, 0);

            //acima
            posicao_.definirValores(posicao.linha - 1, posicao.coluna);
            while(tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.linha = posicao_.linha - 1;
            }

            //abaixo
            posicao_.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.linha = posicao_.linha + 1;
            }

            //direita
            posicao_.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.coluna = posicao_.coluna - 1;
            }

            //esquerda
            posicao_.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
                if (tabuleiro.peca(posicao_) != null && tabuleiro.peca(posicao_).cor != cor)
                {
                    break;
                }
                posicao_.coluna = posicao_.coluna + 1;
            }
            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
