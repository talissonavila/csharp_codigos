namespace tabuleiro
{
    internal class Peca
    {
        public Posicao posicao {  get; set; }
        public Cor cor { get; protected set; }
        public int quantidadeDeMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca (Posicao posicao, Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = posicao;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            quantidadeDeMovimentos = 0;
        }
    }
}
