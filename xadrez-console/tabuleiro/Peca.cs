namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao? posicao {  get; set; }
        public Cor cor { get; protected set; }
        public int quantidadeDeMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca (Tabuleiro tabuleiro, Cor cor)
        {
            posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            quantidadeDeMovimentos = 0;
        }

        public abstract bool[,] movimentosPossiveis();

        public bool existeMovimentosPossiveis()
        {
            bool[,] matriz = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (matriz[i, j]) return true;
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao posicao)
        {
            return movimentosPossiveis()[posicao.linha, posicao.coluna];
        }

        public void incrementarQuantidadeDeMovimentos()
        {
            quantidadeDeMovimentos++;
        }

        public void decrementarQuantidadeDeMovimentos()
        {
            quantidadeDeMovimentos--;
        }
    }
}
