using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca 
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "C";
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

            posicao_.definirValores(posicao.linha - 1, posicao.coluna - 2);
            if(tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            posicao_.definirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tabuleiro.isPosicaoValida(posicao_) && podeMover(posicao_))
            {
                matriz[posicao_.linha, posicao_.coluna] = true;
            }

            return matriz;
        }
    }
}
