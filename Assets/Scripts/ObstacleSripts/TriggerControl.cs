using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{

    public bool hasBeenTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasBeenTriggered = true;
        }
    }
}
