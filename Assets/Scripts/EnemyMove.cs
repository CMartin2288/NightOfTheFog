using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;

    Vector3 direction;
    Transform Player;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.direction = (this.Player.transform.position - this.transform.position).normalized;
        
        var velocity = this.direction*this.speed;
        this.rb.velocity = velocity;
        this.transform.LookAt(Player);
    }

    void FixedUpdate()
    {
        
    }

}
