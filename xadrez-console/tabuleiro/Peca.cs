namespace tabuleiro
{
    class Peca
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

        public void incrementarQuantidadeDeMovimentos()
        {
            quantidadeDeMovimentos++;
        }
    }
}
