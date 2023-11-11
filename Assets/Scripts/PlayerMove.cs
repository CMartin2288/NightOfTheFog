using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float sens = 1;

    float rotateX;
    float rotateY;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;

        rotateY += mouseX;
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 45f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
    }

    void FixedUpdate()
    {

    }
}
