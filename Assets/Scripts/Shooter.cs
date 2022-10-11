using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class to set for actors that can shoot (and be shot). Holds basic functionality for shooting objects and taking damage (and dying of course).
/// </summary>
public class Shooter : MonoBehaviour
{
    [SerializeField]
    protected GameObject projectile;
    [SerializeField]
    protected GameObject shootingOffset;
    public int maxHealth = 10;
    public int currentHealth = 10;

    protected virtual void Awake()
    {
        shootingOffset = gameObject.transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// Creates a projectile that travels in the direction the shooter is facing
    /// </summary>
    protected virtual void Shoot()
    {
        GameObject proj = Instantiate(projectile, shootingOffset.transform.position, transform.rotation);
        proj.GetComponent<ProjectileBase>().SetBaseSpeed(25f);
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    protected virtual void Die()
    {

    }
}
