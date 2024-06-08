using System;
using System.Runtime.InteropServices;

namespace Jogo_Pedra_Papel_Tesoura;

class Program
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        
        Console.Clear();

        Jogador jogadorNumero1 = CriarJogador(1);
        Jogador jogadorNumero2 = CriarJogador(2);

        var jogadaJogador1 = (EJogada)EscolherJogada(jogadorNumero1.Nome);
        var jogadaJogador2 = (EJogada)EscolherJogada(jogadorNumero2.Nome);

        if (jogadaJogador1.ToString() == "Pedra")
        {
            if (jogadaJogador2.ToString() == "Tesoura")
            {
                jogadorNumero1.SomarVitoria();
                jogadorNumero2.SomarDerrota();
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), $"O jogador {jogadorNumero1.Nome} ganhou.");
            }
            else if (jogadaJogador2.ToString() == "Papel") 
            {
                jogadorNumero1.SomarDerrota();
                jogadorNumero2.SomarVitoria();
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), $"O jogador {jogadorNumero2.Nome} ganhou.");
            }
            else 
            {
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), "Houve um empate.");
            }
        }
        else if (jogadaJogador1.ToString() == "Tesoura")
        {
            if (jogadaJogador2.ToString() == "Papel")
            {
                jogadorNumero1.SomarVitoria();
                jogadorNumero2.SomarDerrota();
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), $"O jogador {jogadorNumero1.Nome} ganhou.");
            }
            else if (jogadaJogador2.ToString() == "Pedra")
            {
                jogadorNumero1.SomarDerrota();
                jogadorNumero2.SomarVitoria();
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), $"O jogador {jogadorNumero2.Nome} ganhou.");
            }
            else 
            {
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), "Houve um empate.");
            }
        }
        else if (jogadaJogador1.ToString() == "Papel")
        {
            if (jogadaJogador2.ToString() == "Pedra")
            {
                jogadorNumero1.SomarVitoria();
                jogadorNumero2.SomarDerrota();
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), $"O jogador {jogadorNumero1.Nome} ganhou.");
            }
            else if (jogadaJogador2.ToString() == "Tesoura")
            {
                jogadorNumero1.SomarDerrota();
                jogadorNumero2.SomarVitoria();
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), $"O jogador {jogadorNumero2.Nome} ganhou.");
            }
            else 
            {
                MostrarResultado(jogadorNumero1.Nome, jogadorNumero2.Nome, jogadaJogador1.ToString(), jogadaJogador2.ToString(), "Houve um empate.");
            }
        }
    }

    public static void MostrarResultado(string nomeJogador1, string nomeJogador2, string jogadaJogador1, string jogadoJogador2, string resultador)
    {
        Console.Clear();
        Console.WriteLine($"O jogador {nomeJogador1} escolheu {jogadaJogador1}");
        Console.WriteLine($"O jogador {nomeJogador2} escolheu {jogadoJogador2}");
        Console.WriteLine(resultador);
    }

    public static int EscolherJogada(string jogadorNome)
    {
        bool concluido = false;

        while(!concluido)
        {
            Console.Clear();
            Console.WriteLine($"Por favor {jogadorNome}, escolha sua jogada:");
            Console.WriteLine($"Pedra: escolha 1");
            Console.WriteLine($"Papel: escolha 2");
            Console.WriteLine($"Tesoura: escolha 3");
            Console.Write($"Jogada {jogadorNome}: ");
            string escolha = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                escolha += key.KeyChar;
            }       

            if(int.TryParse(escolha, out int escolhaInt))
            {
                if (escolhaInt >= 1 && escolhaInt <= 3)
                {
                    concluido = true;
                    var jogadaJogador =  escolhaInt;
                    return jogadaJogador;
                }
            }
        }
        
        return 0;
    }

    public static Jogador CriarJogador(int numeroJogador){

        Console.WriteLine("Bem vindo! Esse é o jogo de pedra, papel e tesoura.");
        Console.WriteLine($"Entre com o nome do jogador número {numeroJogador}");
        Console.Write("Nome: ");
        string nomeJogador = Console.ReadLine();

        if (nomeJogador != null) {
            var jogador = new Jogador(nomeJogador, 0, 0);

            Console.WriteLine($"Olá {jogador.Nome}");
            Console.WriteLine("------------------------------------------------------------------");
            return jogador;
        }
        else {
            var jogador = new Jogador("Jogador 1", 0, 0);

            Console.WriteLine($"Olá {jogador.Nome}");
            Console.WriteLine("------------------------------------------------------------------");
            return jogador;
        }

    }

    enum EJogada {
        Pedra = 1,
        Papel = 2,
        Tesoura = 3,
    }
}