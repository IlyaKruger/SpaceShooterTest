using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelData
{
    public static int targetLevel = 1;
    static Dictionary<int, string> levelState = new Dictionary<int, string>()
    {
        {1, "Открыт"},
        {2, "Закрыт"},
        {3, "Закрыт"}
    };
    /*
     Белый - открыт
     Зеленый - пройден
     Черный - закрыт
         */
    public static string GetLevelState(int level)
    {
        return levelState[level];
    }
    public static void SetLevelState(int level, string state)
    {
        levelState[level] = state;
    }

}
