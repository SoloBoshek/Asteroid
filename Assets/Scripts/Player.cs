using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    private bool _thrusting;
    private float _turnDirection;
    float thrustSpeed = 10;
    float turnSpeed = 1;

    private Rigidbody2D _rigidbody;


    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();    
    }

    private void Update() 
    {
        _thrusting = Input.GetKey(KeyCode.E);
        if (Input.GetKey(KeyCode.S)) { _turnDirection = 1.0f;}
        else if (Input.GetKey(KeyCode.F)) { _turnDirection = -1.0f;}
        else {_turnDirection = 0.0f;}

        if (Input.GetKeyDown(KeyCode.Space)) { Shoot();}
    }

    private void FixedUpdate() 
    {
        if (_thrusting) { _rigidbody.AddForce(this.transform.up *this.thrustSpeed);}

        if (_turnDirection != 0.0f) { _rigidbody.AddTorque(_turnDirection * this.turnSpeed);}
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
}
