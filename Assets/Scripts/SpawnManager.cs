using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject turret;
    private float delay = 5f;

    private void Start()
    {
        GameManager.Instance.InitializeUI();

        InvokeRepeating("SpawnTurret", delay, delay);
    }
    //ABSTRACTION
    void SpawnTurret()
    {
        if(!GameManager.Instance.gameOver)
            Instantiate(turret, new Vector3(RandomCoordinate(), 1f, RandomCoordinate()), transform.rotation);
    }
    //ABSTRACTION
    public float RandomCoordinate()
    {
        return Random.Range(-49, 49);
    }
}
