using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor)
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
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //nordeste
            posicao_.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //direita
            posicao_.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //sudeste
            posicao_.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //abaixo
            posicao_.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //sudoeste 
            posicao_.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //esquerda 
            posicao_.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            //noroeste 
            posicao_.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            return matriz;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
