using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject playerWeapon;
    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = GameObject.FindWithTag("HoldWeap");
        playerWeapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("collision detected");
        if (other.gameObject.CompareTag("FieldWeap")) {
            Debug.Log("if field weap");
            Destroy(other.gameObject);
            Debug.Log("destroyed");
            playerWeapon.SetActive(true);
        }
    }
}
