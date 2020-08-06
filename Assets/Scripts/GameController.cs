using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public SaveLoad saveLoad;
    public Text scoreText;
    public Text winLoseText;
    public Text lifeText;
    public int lifes;
    private int score;
    public GameObject enemy;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    protected JoyButton joyButton;


    private void Update()
    {

        if (winLoseText.gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || joyButton.pressed == true)
            {
                Time.timeScale = 1;
                winLoseText.gameObject.SetActive(false);
                SceneManager.LoadScene(0);
            }
        }

    }

    private void Start()
    {
        saveLoad = FindObjectOfType<SaveLoad>();
        joyButton = FindObjectOfType<JoyButton>();
        UpdateScore();
        lifes = 3;
        LifeUpdate();
        StartCoroutine(SpwanEnemyWaves());
    }

    IEnumerator SpwanEnemyWaves()
    {
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemy, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
    public void ScorePlus()
    {
        score += 50;
        UpdateScore();
    }

    public void LifeMinus()
    {
        lifes -= 1;
        LifeUpdate();
        if (lifes <= 0)
        {
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "Поражение \n Нажмите кнопку стрельбы \n для вовзрата в меню";
            Time.timeScale = 0;
        }
    }
    private void LifeUpdate()
    {
        lifeText.text = "Жизни: " + lifes;
    }
    private void UpdateScore()
    {
        scoreText.text = "Счет: \n" + score + "/300";
        if (score == 300)
        {
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "Победа \n Нажмите кнопку стрельбы \n для вовзрата в меню";
            LevelData.SetLevelState(LevelData.targetLevel, "Пройден");
            if (LevelData.targetLevel != 3)
            {
                LevelData.SetLevelState(LevelData.targetLevel + 1, "Открыт");
            }
            saveLoad.SaveGame();
            Time.timeScale = 0;
        }
    }
}
