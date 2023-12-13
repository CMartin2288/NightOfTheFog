using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    GameObject playerWeapon;
    public int shadehealth = 3;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = GameObject.FindWithTag("HoldWeap");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) { // right-click
            // Debug.Log("Pressed right-click.");
            animator.SetTrigger("Attack");
        }

    }

    // Detects sword collision and does damage
    private void OnTriggerEnter(Collider other){
        Debug.Log("Attack collision detected");
        //sword hits stalker or pumpkin
        if (other.gameObject.CompareTag("Stalker") || other.gameObject.CompareTag("Pumpking")) {
            Debug.Log("if enemy");

            // run death animations when applicable
            
            Destroy(other.gameObject);
            Debug.Log("enemy destroyed");
            
        }
        //sword hits shade enemy
        else if (other.gameObject.CompareTag("Shade")) {
            Debug.Log("if shade enemy");
            //removes health
            shadehealth--;
            if (shadehealth==0) {
                Destroy(other.gameObject);
                Debug.Log("destroyed");
            }
        }
    }
}
