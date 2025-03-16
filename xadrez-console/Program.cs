using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.isPartidaTerminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();

                        Console.Write("Posição de Origem: ");
                        Posicao posicaoOrigem = Tela.lerPosicaoXadrez().toPosicao();

                        partida.validarPosicaoOrigem(posicaoOrigem);
                    
                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(posicaoOrigem).movimentosPossiveis();
                    
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);
                    
                        Console.WriteLine();
                        Console.Write("Posição de Destino: ");
                        Posicao posicaoDestino = Tela.lerPosicaoXadrez().toPosicao();

                        partida.validarPosicaoDestino(posicaoOrigem, posicaoDestino);
                        
                        partida.realizaJogada(posicaoOrigem, posicaoDestino);
                    }
                    catch (TabuleiroException exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            } 
            catch (TabuleiroException exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadLine();
        }
    }
}