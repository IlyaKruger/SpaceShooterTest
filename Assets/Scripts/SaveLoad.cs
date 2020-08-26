using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public void SaveGame()
    {
        for (int i = 1; i < 4; i++)
        {
            PlayerPrefs.SetString(i.ToString(), LevelData.GetLevelState(i));
        }

    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("1"))
        {

            for (int i = 1; i < 4; i++)
            {
                LevelData.SetLevelState(i, PlayerPrefs.GetString(i.ToString()));
            }
        }
    }
}
