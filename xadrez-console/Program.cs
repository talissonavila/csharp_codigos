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
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro);

                    Console.WriteLine();

                    Console.Write("Posição de Origem: ");
                    Posicao posicaoOrigem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Posição de Destino: ");
                    Posicao posicaoDestino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.exececutaMovimento(posicaoOrigem, posicaoDestino);

                }
                Console.ReadLine();
            } catch (TabuleiroException exc)
            {
                Console.WriteLine(exc.Message);
            }

        }
    }
}