using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Sorting : MonoBehaviour
{
    public Load load;
    public Text text;
    
    List<Player> players;

    void Start()
    {
        players = load.players;
        // Listar em ordem descendente, os 3 jogadores com maior número de pontos.
        // Ordenar por país os jogadores que ainda não criaram heróis.
        // Qual é a classe de herói mais criada e a menos criada.
        // Qual é o país que possue mais jogadores.
        // Qual plataforma possue os jogadores com melhores pontos.
        // Listar os 10 jogadores com maior total de "gold".
               
        // ThreeMostPoints();
        // CountryNoHeroes();
        // ClassesMostFewest();
        // CountryMostPlayers();
        // PlatformBestPoints();
        // TenTopGold();
    }

    // Listar em ordem descendente, os 3 jogadores com maior número de pontos.
    public void ThreeMostPoints()
    {
        string str = "3 jogadores com maior número de pontos:\n\n";

        var points =
        from player in players
        orderby player.points descending
        select player;

        int index = 1;
        foreach(var point in points)
        {
            str += index + ". " +  point.name + " - Points: " + point.points + '\n';

            index++;

            if(index > 3)
                break;
        }

        //print(str);
        text.text = str;
    }

    // Ordenar por país os jogadores que ainda não criaram heróis.
    public void CountryNoHeroes()
    {
        string str = "Jogadores que ainda não criaram heróis por país:\n\n";

        var countries = 
        from player in players
        where player.heroes.Count == 0
        orderby player.countryName ascending
        select player;

        foreach(var country in countries)
            str += country.countryName + " - Player: " + country.name + '\n';

        //print(str);
        text.text = str;
    }

    // Qual é a classe de herói mais criada e a menos criada.
    public void ClassesMostFewest()
    { 
        string str = "Classe de herói mais criada e a menos criada:\n\n";

        var classes =
        from player in players
        from hero in player.heroes
        group hero by hero.heroClassName into heroes
        orderby heroes.Count() descending
        select heroes;

        str += "Mais Criada: " + classes.First().Key + " - Total: " + classes.First().Count() + '\n';
        str += "Menos Criada: " + classes.Last().Key + " - Total: " + classes.Last().Count() + '\n';

        //print(str);
        text.text = str;
    }

    // Qual é o país que possue mais jogadores.
    public void CountryMostPlayers()
    {
        string str = "País que possue mais jogadores:\n\n";

        var countryPlayers =
        from player in players
        group player by player.countryName into country
        orderby country.Count() descending
        select country;

        str += countryPlayers.First().Key + " - Players: " + countryPlayers.First().Count() + '\n';
        //print(str);
        text.text = str;
    }

    // Qual plataforma possue os jogadores com melhores pontos.
    public void PlatformBestPoints()
    {
        string str = "Plataforma com jogadores com melhores pontos:\n\n";

        var platforms =
        from player in players
        group player by player.platformName into platform
        orderby platform.Average(p => p.points) descending
        select platform;

        str += platforms.First().Key + " - Average Points: " + (int)platforms.First().Average(p => p.points) + '\n';
        //print(str);
        text.text = str;
    }

    // Listar os 10 jogadores com maior total de "gold".
    public void TenTopGold()
    {
        string str = "Os 10 jogadores com maior total de \"gold\":\n\n";

        var golds = 
        from player in players
        orderby player.totalGold descending
        select player;

        int index = 1;
        foreach(var gold in golds)
        {
            str += index + ". " + gold.name + " - Total Gold: " + gold.totalGold + '\n';

            index++;

            if(index > 10)
                break;
        }

        //print(str);
        text.text = str;
    }
}
