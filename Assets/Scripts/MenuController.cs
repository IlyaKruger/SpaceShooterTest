using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text level1Text;
    public Text level2Text;
    public Text level3Text;
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public SaveLoad saveLoad;

    private Button[] levelsButton;
    private Text[] levelsText;
    private void Awake()
    {
        levelsText = new Text[3] { level1Text, level2Text, level3Text };
        levelsButton = new Button[3] { level1Button, level2Button, level3Button };

        saveLoad = FindObjectOfType<SaveLoad>();
        saveLoad.LoadGame();
        for (int i = 1; i < 4; i++)
        {
            if (LevelData.GetLevelState(i) == "Открыт")
            {
                levelsText[i - 1].color = Color.white;

            }
            else if (LevelData.GetLevelState(i) == "Пройден")
            {
                levelsButton[i - 1].interactable = true;
                levelsText[i - 1].color = Color.green;
            }
            else
            {
                levelsButton[i - 1].interactable = false;
                levelsText[i - 1].color = Color.black;
            }
        }

    }

    private void Start()
    {

    }



    public void Quit()
    {
        Application.Quit();
    }
}
