using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float sens = 500;
    public float speed = 10;

    float mouseY;
    float rotateX;
    float mouseX;
    float rotateY;

    public Transform orientation;

    float hori;
    float vert;

    Vector3 move;

    Rigidbody rb;

    public AudioSource walk;

    void Start()
    {
        rotateY = transform.rotation.eulerAngles.y;
        //rotateX = transform.rotation.eulerAngles.x;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        walk.Play();
        walk.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;

        rotateY += mouseX;
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 45f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        orientation.rotation = Quaternion.Euler(0, rotateY, 0);

        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        move = orientation.forward*vert + orientation.right*hori;
        if(move.magnitude > 1) move = move.normalized;
        move = move * speed;
        move.y = rb.linearVelocity.y;

        if(move.magnitude > 0.2) walk.UnPause();
        else walk.Pause();

        rb.linearVelocity = move;
    }

    void FixedUpdate()
    {
        
    }

}
