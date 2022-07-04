using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float time = 0;
    public float stunTime;
    private static bool stunned = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed, ForceMode.VelocityChange);

        if (stunned) { 
            time += Time.deltaTime;
            if (time >= stunTime)
                ClearStun();
        }

        if (!stunned) { 

        if (Input.GetKey("w") & Input.GetKey("d"))
            rb.velocity = new Vector3(2.0711f, 0, 7.0711f);
        else if (Input.GetKey("w") & Input.GetKey("a"))
            rb.velocity = new Vector3(-12.0711f, 0, 7.0711f);
        else if (Input.GetKey("s") & Input.GetKey("d"))
            rb.velocity = new Vector3(2.0711f, 0, -7.0711f);
        else if (Input.GetKey("s") & Input.GetKey("a"))
            rb.velocity = new Vector3(-12.0711f, 0, -7.0711f);

        else if (Input.GetKey("w"))
            rb.velocity = new Vector3(0, 0, 10);
        else if (Input.GetKey("s"))
            rb.velocity = new Vector3(0, 0, -10);
        else if (Input.GetKey("d"))
            rb.velocity = new Vector3(5, 0, 0);
        else if (Input.GetKey("a"))
            rb.velocity = new Vector3(-15, 0, 0);
        else 
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

     public static void PushBack(Rigidbody rb)
    {
        stunned = true;
        rb.velocity = new Vector3(-40, 0, 0);
    }
    private void ClearStun()
    {
        stunned = false;
        time = 0;
    }
}
