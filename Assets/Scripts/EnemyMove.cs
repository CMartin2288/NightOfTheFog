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
        animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playMinusEnemy = this.Player.transform.position - this.transform.position;
        this.direction = (playMinusEnemy).normalized;
            
        var velocity = this.direction*this.speed;
        this.rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        this.transform.LookAt(Player);

        if (gameObject.tag != "Pumpking")
        {
            if(playMinusEnemy.magnitude < 20)
            {
                animator.SetTrigger("Chase");
                animator.ResetTrigger("Idle");
            }
            else
            {
                animator.SetTrigger("Idle");
                animator.ResetTrigger("Chase");
            }
        }

        if (playMinusEnemy.magnitude < 5) {
            // attack animations
            if (gameObject.tag == "Shade") {
                Debug.Log("Shade Attacked");
                animator.SetTrigger("Attack");
            }
            //stalker
            else if (gameObject.tag == "Stalker") {
                //do stuff based off animations
                Debug.Log("Stalker Attacked");
                animator.SetTrigger("Attack");
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
