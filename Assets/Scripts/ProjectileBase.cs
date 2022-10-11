using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float baseSpeed;
    private float bounds = 50;
    private bool speedHasBeenSet = false;
    public bool fromPlayer = false;

    private void Start()
    {
        if(!speedHasBeenSet)
        {
            Debug.LogWarning("Speed hasn't been set for this projectile! Setting to default speed...");
            SetBaseSpeed(25f);
        }
    }
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * baseSpeed;

        CheckBounds();
    }
    public void SetBaseSpeed(float speed)
    {
        baseSpeed = speed;
        speedHasBeenSet = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if(!fromPlayer)
            {
                other.gameObject.GetComponent<Player>().TakeDamage(1);
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            if(fromPlayer)
            {
                other.gameObject.GetComponent<Turret>().TakeDamage(5);
                Destroy(gameObject);
            }
        }
    }

    //ABSTRACTION
    void CheckBounds()
    {
        if (transform.position.x < -bounds)
            Destroy(gameObject);
        if (transform.position.x > bounds)
            Destroy(gameObject);
        if (transform.position.z < -bounds)
            Destroy(gameObject);
        if (transform.position.z > bounds)
            Destroy(gameObject);
    }
}
