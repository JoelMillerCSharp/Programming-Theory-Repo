using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private UIBarBase healthBar;
    private Player player;
    private bool gameOver = false;

    //ENCAPSULATION
    public int currentScore;
    public int currentScoreValue
    {
        get
        {
            return currentScore;
        }
        set
        {
            if(value < 0)
            {
                Debug.LogError("Can't set this to a negative value!");
            }
            else
            {
                currentScore = value;
            }
        }
    }
    //ENCAPSULATION
    public string currentName;
    public string currentNameValue
    {
        get
        {
            if (currentName != null)
                return currentName;
            else
                return "N/A";
        }
        set
        {
            if (value != null)
                currentName = value;
            else
                value = "N/A";
        }
    }

    public int highScore;
    public string highScoreName;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InitializeUI()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<UIBarBase>();
        healthBar.SetBarToMaxValue(10);
    }
    public void SetHealthBar()
    {
        healthBar.SetCurrentBarValue(player.currentHealth);
    }
    public void SetPlayerName(string name)
    {
        currentName = name;
    }
    public void ResetPlayerData()
    {
        currentName = null;
        ResetPlayerScore();
    }
    public void ResetPlayerScore()
    {
        currentScore = 0;
    }
    public void AddScore(int score)
    {
        currentScoreValue += score;
    }
    public void GameOver()
    {
        gameOver = true;
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
        ResetPlayerScore();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        ResetPlayerData();
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif 
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }
    public void SaveScore()
    {
        Debug.Log("New high score saved!");

        SaveData data = new SaveData();
        data.highScore = currentScore;
        data.highScoreName = currentName;

        string jsonText = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jsonText);
    }
    public bool TryLoadScore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;

            return true;
        }
        else
            return false;
    }
}
