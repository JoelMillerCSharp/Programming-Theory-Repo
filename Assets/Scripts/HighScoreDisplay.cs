using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    private int playerScore;
    private string playerName;
    private bool gottenScore = false;

    private void Start()
    {
        LoadHighScoreData();
    }
    private void LoadHighScoreData()
    {
        if (GameManager.Instance.TryLoadScore())
        {
            playerScore = GameManager.Instance.highScore;
            playerName = GameManager.Instance.highScoreName;

            gottenScore = true;
        }
        else
        {
            playerScore = 0;
            playerName = null;

            gottenScore = false;
        }

        SetHighScoreText();
    }
    private void SetHighScoreText()
    {
        if (gottenScore)
            highScoreText.text = "High Score: " + playerName + " (" + playerScore + ")";
        else
            highScoreText.text = "No recorded high score yet. Be the first to set one!";
    }
}
