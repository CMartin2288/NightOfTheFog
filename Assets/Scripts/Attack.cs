using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{

    GameObject playerWeapon;
    public int shadehealth = 3;

    Animator animator;

    Animator enemyanimator;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = GameObject.FindWithTag("HoldWeap");
        //attaches sword animator
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
        GameObject enemy = other.gameObject;
        // Debug.Log("collision detected");

        //sword hits stalker or pumpkin
        if (enemy.CompareTag("Stalker")) {
            // do something??
            Destroy(enemy);
            Debug.Log("enemy destroyed");   
        }
        else 
        if (enemy.CompareTag("Pumpking")) {
            Debug.Log("hit Pumpking"); 
            enemyanimator = enemy.GetComponent<Animator>();
            bool test = (enemyanimator != null);
            // True = found enemy, false = null
            Debug.Log(test); 
            enemyanimator.ResetTrigger("Attack");
            enemyanimator.SetTrigger("Dead");
        }

        //sword hits shade enemy
        else if (enemy.CompareTag("Shade")) {
            Debug.Log("if shade enemy");
            //removes health
            shadehealth--;
            if (shadehealth==0) {
                Destroy(enemy);
                Debug.Log("destroyed");
                WinScreen();
            }
        }
    }

    private void WinScreen(){
        SceneManager.LoadSceneAsync("WinScreen");
    }
}
