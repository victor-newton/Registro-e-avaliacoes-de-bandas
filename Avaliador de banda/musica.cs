//nome
//artista
//duracao
//disponivel
class Musica{
    public string nome;
    public string artista;
    public int duracao;
    public bool disponivel;


    public void ExibirFichaTecnica(){

        System.Console.WriteLine($"Nome: {nome}");
        System.Console.WriteLine($"Artista: {artista}");
        System.Console.WriteLine($"Duração: {duracao}");
        if (disponivel){
            System.Console.WriteLine("Disponivel no plano");
        }
        else{
            System.Console.WriteLine("Indisponivel no plano atual");
        }
    }
    public void ExibirNomeEArtista()
    {
        Console.WriteLine($"Nome/Artista: {nome} - {artista}");
    }

}
