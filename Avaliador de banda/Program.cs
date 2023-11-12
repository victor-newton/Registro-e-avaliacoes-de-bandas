//Screem Sound

using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

Console.Clear();

//using System.Runtime.CompilerServices;

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

void ExibirLogo()
{ 
    Console.WriteLine(@"
███████████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▀─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█─▄▄▄▄█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄█─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█▄▄▄▄─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀▄▄▄▄▄▀");
    Console.WriteLine("");
}

void ExibirOpcoesDoMenu()
{
    Console.Clear();

    ExibirLogo();
    Console.WriteLine("Digite 1 Para registrar uma banda");
    Console.WriteLine("Digite 2 Para mostrar todas as bandas");
    Console.WriteLine("Digite 3 Para Avaliar uma banda");
    Console.WriteLine("Digite 4 Para exibir a média de uma banda");
    Console.WriteLine("Digite 0 Para Sair");
     
    Console.Write("\nDigite a opção desejada: ");

    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

   switch (opcaoEscolhidaNumerica){
    case 1: RegistrarBanda();
    break;
    case 2: MostrarBandasRegistradas();
    break;
    case 3: AvaliarUmaBanda();
    break;
    case 4: MediaNotaBanda();
    break;
    case 0: FecharPrograma();
    break;
    default: ExibirOpcoesDoMenu();
    break;
       }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de banda");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    
    if (bandasRegistradas.ContainsKey(nomeDaBanda)){
        Console.WriteLine("\nEsta Banda Ja existe em nossa base de dados\n");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else{
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    //for(int i = 0; i < ListaDasBandas.Count; i++){
    //    Console.WriteLine($"Banda: {ListaDasBandas[i]}");
    //}

    ExibirTituloDaOpcao("Bandas registradas no sistema");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.Write("\nDigite qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(String titulo)
{

    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');

    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{

    Console.Clear();
    ExibirTituloDaOpcao("Avaliacao de banda");
    Console.Write("Digite a banda desejada: ");
    string nomeDaBanda = Console.ReadLine()!; 
    if (bandasRegistradas.ContainsKey(nomeDaBanda)){
        Console.WriteLine($"Qual a nota que a {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);

        bandasRegistradas[nomeDaBanda].Add(nota);

        Console.WriteLine($"\nA nota foi registrada com sucesso!");
        Thread.Sleep(3999);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else{
        Console.WriteLine($"\nA banda {nomeDaBanda} nao foi encontrada!");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }                                                                                                                                       

}

void MediaNotaBanda(){
    Console.Clear();
    ExibirTituloDaOpcao("Escolha uma das bandas abaixo para descobrir a media de notas");

    foreach (string bandas in bandasRegistradas.Keys){
        Console.WriteLine(bandas);
    }
    Console.WriteLine("");
    string bandaEscolhida = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(bandaEscolhida)){

        double mediaNota = bandasRegistradas[bandaEscolhida].Average();
        Console.WriteLine($"A media de notas da {bandaEscolhida} é de {mediaNota}");
        Console.Clear();
        Thread.Sleep(4000);
        ExibirOpcoesDoMenu();
    }
    else{
        Console.WriteLine($"\n A banda {bandaEscolhida} não faz parte de nossa base de dados");
        Console.Clear();
        Thread.Sleep(4000);
        ExibirOpcoesDoMenu();
    }

}

void FecharPrograma()
{
    Console.Clear();
    ExibirLogo();
    ExibirTituloDaOpcao("Obrigado por utilizar nosso programa volte sempre");
    Thread.Sleep(5000);
    Environment.Exit(0);
}

ExibirOpcoesDoMenu();