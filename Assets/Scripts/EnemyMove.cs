using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;

    Vector3 direction;
    Transform Player;
    Rigidbody rb;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player").transform;

        // attaching animator
        if (gameObject.CompareTag("Shade") || gameObject.CompareTag("Pumpking") ) {
            animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        }
        else animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playMinusEnemy = this.Player.transform.position - this.transform.position;
        this.direction = (playMinusEnemy).normalized;
            
        var velocity = this.direction*this.speed;
        // this.rb.velocity = velocity;
        this.transform.LookAt(Player);

        if (playMinusEnemy.magnitude < 3) {
            // attack animations
            if (gameObject.tag == "Shade") {
                Debug.Log("Shade Attacked");
            }
            //stalker
            else if (gameObject.tag == "Stalker") {
                //do stuff based off animations
                Debug.Log("Stalker Attacked");
            }
            // pumpking
            else {
                animator.SetTrigger("Attack");
            }
        }
    }

    void FixedUpdate()
    {
        
    }

}
