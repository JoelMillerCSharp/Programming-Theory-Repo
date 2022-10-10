using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Turret : Shooter
{
    private GameObject player;
    private float initDelay = 2f;
    private float fireRate = 2f;

    private void Start()
    {
        FindPlayer();
        InvokeRepeating("Shoot", initDelay, fireRate);
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }
    private void FindPlayer()
    {
        player = GameObject.Find("Player");
    }

    //POLYMORPHISM
    protected override void Shoot()
    {
        GameObject proj = Instantiate(projectile, shootingOffset.transform.position, transform.rotation);
        proj.GetComponent<ProjectileBase>().SetBaseSpeed(25f);
    }
    protected override void Die()
    {
        GameManager.Instance.AddScore(1);
    }
}
