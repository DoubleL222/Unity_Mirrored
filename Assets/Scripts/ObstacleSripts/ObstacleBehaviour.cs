using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    public float pushbackForce = 1.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.left * pushbackForce, ForceMode.Force);
            Debug.Log("Player hit");
            Destroy(this.gameObject);
        }
            
    }
}
