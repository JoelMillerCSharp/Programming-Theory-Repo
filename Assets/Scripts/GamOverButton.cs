using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamOverButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
