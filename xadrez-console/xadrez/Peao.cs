using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao (Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base (tabuleiro, cor) 
        {
            this.partida = partida;
        }

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
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.isPosicaoValida(p2) && livre(p2) && tabuleiro.isPosicaoValida(posicao_) && livre(posicao_) && quantidadeDeMovimentos == 0)
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.isPosicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        matriz[esquerda.linha - 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.isPosicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant)
                    {
                        matriz[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                posicao_.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.isPosicaoValida(posicao_) && livre(posicao_))
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (
                    tabuleiro.isPosicaoValida(p2) 
                    && livre(p2) 
                    && tabuleiro.isPosicaoValida(posicao_)
                    && livre(posicao_) 
                    && quantidadeDeMovimentos == 0
                )
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                posicao_.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.isPosicaoValida(posicao_) && existeInimigo(posicao_))
                {
                    matriz[posicao_.linha, posicao_.coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.isPosicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        matriz[esquerda.linha + 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.isPosicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant)
                    {
                        matriz[direita.linha + 1, direita.coluna] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
