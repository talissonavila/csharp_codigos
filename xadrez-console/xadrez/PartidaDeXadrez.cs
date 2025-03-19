using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool isPartidaTerminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> _pecasCapturadas;
        public bool xeque { get; private set; }


        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            xeque = false;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            _pecasCapturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca exececutaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            Peca peca = tabuleiro.retirarPeca(posicaoOrigem);
            peca.incrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(posicaoDestino);
            tabuleiro.colocarPeca(peca, posicaoDestino);
            if (pecaCapturada != null)
            {
                _pecasCapturadas.Add(pecaCapturada);
            }

            // #jogadaespecial roque pequeno
            if (peca is Rei && posicaoDestino.coluna == posicaoOrigem.coluna + 2)
            {
                Posicao posicaoOrigemDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna + 3);
                Posicao posicaoDestinoDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna + 1);
                Peca torre = tabuleiro.retirarPeca(posicaoOrigemDaTorre);
                torre.incrementarQuantidadeDeMovimentos();
                tabuleiro.colocarPeca(torre, posicaoDestinoDaTorre);
            }

            // #jogadaespecial roque grande
            if (peca is Rei && posicaoDestino.coluna == posicaoOrigem.coluna - 2)
            {
                Posicao posicaoOrigemDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna - 4);
                Posicao posicaoDestinoDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna - 1);
                Peca torre = tabuleiro.retirarPeca(posicaoOrigemDaTorre);
                torre.incrementarQuantidadeDeMovimentos();
                tabuleiro.colocarPeca(torre, posicaoDestinoDaTorre);
            }

            return pecaCapturada;
        }

        public void realizaJogada(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            Peca pecaCapturada = exececutaMovimento(posicaoOrigem, posicaoDestino);
            if (reiEstaEmXeque(jogadorAtual))
            {
                desfazMovimento(posicaoOrigem, posicaoDestino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }
            if (reiEstaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequeMate(adversaria(jogadorAtual)))
            {
                isPartidaTerminada = true;
            } else
            {
                turno++;
                mudaJogador();
            }
        }

        public void desfazMovimento(Posicao posicaoOrigem, Posicao posicaoDestino, Peca pecaCapturada)
        {
            Peca _peca = tabuleiro.retirarPeca(posicaoDestino);
            _peca.decrementarQuantidadeDeMovimentos();
            if (pecaCapturada != null)
            {
                tabuleiro.colocarPeca(pecaCapturada, posicaoDestino);
                _pecasCapturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocarPeca(_peca, posicaoOrigem);

            // #jogadaespecial roque pequeno
            if (_peca is Rei && posicaoDestino.coluna == posicaoOrigem.coluna + 2)
            {
                Posicao posicaoOrigemDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna + 3);
                Posicao posicaoDestinoDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna + 1);
                Peca torre = tabuleiro.retirarPeca(posicaoDestinoDaTorre);
                torre.decrementarQuantidadeDeMovimentos();
                tabuleiro.colocarPeca(torre, posicaoOrigemDaTorre);
            }

            // #jogadaespecial roque grande
            if (_peca is Rei && posicaoDestino.coluna == posicaoOrigem.coluna - 2)
            {
                Posicao posicaoOrigemDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna - 4);
                Posicao posicaoDestinoDaTorre = new Posicao(posicaoOrigem.linha, posicaoOrigem.coluna - 1);
                Peca torre = tabuleiro.retirarPeca(posicaoDestinoDaTorre);
                torre.decrementarQuantidadeDeMovimentos();
                tabuleiro.colocarPeca(torre, posicaoOrigemDaTorre);
            }
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
            if (!tabuleiro.peca(PosicaoOrigem).movimentoPossivel(PosicaoDestino))
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

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca> ();

            foreach(Peca peca in _pecasCapturadas) 
            { 
                if (peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca peca in pecas)
            {
                if (peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca) return Cor.Preta;
            return Cor.Branca;
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca _peca in pecasEmJogo(cor)) 
            {
                if (_peca is Rei) {
                    return _peca;
                }
            }
            return null;
        }

        public bool reiEstaEmXeque(Cor cor)
        {
            Peca _rei = rei(cor);
            if (_rei == null) throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");

            foreach( Peca _peca in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = _peca.movimentosPossiveis();
                if (matriz[_rei.posicao.linha, _rei.posicao.coluna]) return true;
                
            }
            return false;
        }

        public bool testeXequeMate(Cor cor)
        {
            if (!reiEstaEmXeque(cor)) return false;
            foreach (Peca _peca in pecasEmJogo(cor))
            {
                bool[,] matriz = _peca.movimentosPossiveis();
                for (int i = 0; i < tabuleiro.linhas; i++)
                {
                    for (int j = 0;  j < tabuleiro.colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao posicaoOrigem = _peca.posicao;
                            Posicao posicaoDestino = new Posicao(i, j);
                            Peca pecaCapturada = exececutaMovimento(posicaoOrigem, posicaoDestino);
                            bool testeXeque = reiEstaEmXeque(cor);
                            desfazMovimento(posicaoOrigem, posicaoDestino, pecaCapturada);
                            if (!testeXeque) return false;
                        }
                    }
                }
            }
            return true;
        }
        
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tabuleiro, Cor.Branca, this));
            colocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branca));


            colocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tabuleiro, Cor.Preta, this));
            colocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preta));
        }
    }
}
