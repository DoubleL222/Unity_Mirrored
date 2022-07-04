using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour {

    public float Delay;

	void Start () {
        Destroy(this.gameObject, Delay);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Backline"))
        {
            Destroy(this.gameObject, 2.0f);
        }
    }
}
