using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida)
            : base(tabuleiro, cor) 
        { 
            this.partida = partida;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }

        private bool isRoquePossivel(Posicao posicao)
        {
            Peca _peca = tabuleiro.peca(posicao);
            return _peca != null && _peca is Torre && _peca.cor == cor && _peca.quantidadeDeMovimentos == 0;
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

            // #jogadaespecial roque
            if (quantidadeDeMovimentos == 0 && !partida.xeque)
            {
                // roque pequeno
                Posicao posicaoDaTorreRoquePequeno = new Posicao(posicao.linha, posicao.coluna + 3);
                if (isRoquePossivel(posicaoDaTorreRoquePequeno))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2 ] = true;
                    }

                }

                // roque grande
                Posicao posicaoDaTorreRoqueGrande = new Posicao(posicao.linha, posicao.coluna - 4);
                if (isRoquePossivel(posicaoDaTorreRoqueGrande))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        matriz[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
