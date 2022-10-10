using Caliber_Random_Party;
using System;
using System.Collections.Generic;
using System.Linq;


Console.WriteLine("Нажмите E для окончания ввода ников");
List<Person> players = SetPlayer();

SetCommandAndRole(ref players);
WritePlayer(players);

do
{
    Console.WriteLine("\nНажмите R для перетасовки");
    Console.WriteLine("Нажмите X для смены игроков");
    string inputText = Console.ReadLine();

    if (inputText == "R")
    {
        SetCommandAndRole(ref players);
    }
    if (inputText == "X")
    {
        players = SetPlayer();
    }
    WritePlayer(players);

} while (true);


static List<Person> SetPlayer()
{
    List<Person> players = new();
    int i = 0;
    while (true)
    {
        Console.WriteLine($"\nИгрок {i + 1}:");
        
        string PlayerName = Console.ReadLine();

        if (PlayerName == "E")
            break;
        
        players.Add(new Person() { Name = PlayerName });
        i++;
    }
    return players;
}

static void SetCommandAndRole(ref List<Person> Players)
{
    Tools.Shuffle(Players);
    int i = 1;
    int j = 1;
    int classId = 1;


    foreach (var Player in Players)
    {
        Player.Command = j;
        Player.ClassName = (PlayerClass)classId;

        if ((i % 4) == 0)
        {
            j++;
            classId = 0;
        }
        i++;
        classId++;
    }

}


static void WritePlayer(List<Person> players)
{
    //Tools.Shuffle(players);
    players.OrderBy(el => el.Command);
    foreach (var player in players)
    {
        Console.WriteLine(player.Command + " " + player.Name + ' ' + player.ClassName);
    }
}
