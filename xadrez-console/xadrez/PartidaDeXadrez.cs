using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool isPartidaTerminada { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        public void exececutaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            Peca peca = tabuleiro.retirarPeca(posicaoOrigem);
            peca.incrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(posicaoDestino);
            tabuleiro.colocarPeca(peca, posicaoDestino);
        }

        public void realizaJogada(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            exececutaMovimento(posicaoOrigem, posicaoDestino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao posicao)
        {
            if (tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");
            }
            if (jogadorAtual != tabuleiro.peca(posicao).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!tabuleiro.peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para esta peça");
            }
        }

        public void validarPosicaoDestino(Posicao PosicaoOrigem, Posicao PosicaoDestino)
        {
            if (!tabuleiro.peca(PosicaoOrigem).podeMoverPara(PosicaoDestino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else if (jogadorAtual == Cor.Preta)
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
        }
    }
}
