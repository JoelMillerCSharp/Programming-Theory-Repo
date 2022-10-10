using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Player : Shooter
{
    [SerializeField]
    private float moveSpeed = 10f;
    private Rigidbody rBody;
    private bool isAlive = true;


    protected override void Awake()
    {
        base.Awake();
        rBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!isAlive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float yRot = Input.GetAxis("Mouse X");

        Move(horizontalMovement, verticalMovement, yRot);
    }

    //ABSTRACTION
    private void Jump()
    {
        rBody.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
    }
    //ABSTRACTION
    private void Move(float xMovement, float zMovement, float yMouseRotation)
    {
        transform.Translate(new Vector3(xMovement * moveSpeed * Time.deltaTime, 0, zMovement * moveSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(0, yMouseRotation, 0));
    }
    //POLYMORPHISM
    protected override void Shoot()
    {
        GameObject proj = Instantiate(projectile, shootingOffset.transform.position, transform.rotation);
        proj.GetComponent<ProjectileBase>().SetBaseSpeed(50f);
        proj.GetComponent<ProjectileBase>().fromPlayer = true;
    }
    //POLYMORPHISM
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        GameManager.Instance.SetHealthBar();
    }
}
