namespace Jogo_Pedra_Papel_Tesoura;

public class Jogador 
{

    public string Nome;
    private int Vitorias;
    private int Derrotas;

    public Jogador(string nome, int vitorias, int derrotas)
    {
        Nome = nome;
        Vitorias = vitorias;
        Derrotas = derrotas;
    }

    public string ResumoJogado()
    {
        return $"O jogador {Nome} possuí {Vitorias} vitórias e {Derrotas} derrotas";
    }

    public void SomarVitoria()
    {
        Vitorias += 1;
    }

    public void SomarDerrota()
    {
        Vitorias += 1;
    }
}