using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    GameObject playerWeapon

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) { // right-click
            Debug.Log("Pressed right-click.");
            // ATTACK
            // sword collision with enemy??
            // DO DAMAGE
        }
    }
}
