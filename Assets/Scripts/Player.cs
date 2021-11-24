using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Player
{
   public int id;
   public string name;
   public string email;
   public string username;
   public int points;
   public int platformIndex;
   public string platformName;
   public int countryIndex;
   public string countryName;
   public List<Hero> heroes = new List<Hero>();

   public int totalGold
   {
      get 
      { 
         return heroes.Sum(h => h.gold);
      }
   }
}
