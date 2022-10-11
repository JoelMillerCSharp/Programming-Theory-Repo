using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LoadGameplayScene();
    }
    public void Quit()
    {
        GameManager.Instance.QuitGame();
    }
}
