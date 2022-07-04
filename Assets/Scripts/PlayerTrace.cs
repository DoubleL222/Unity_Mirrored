using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrace : MonoBehaviour {

    public GameObject objectToFollow, playerObject;

	void Update () {
        if(playerObject && objectToFollow && gameObject)
            gameObject.transform.position = new Vector3(objectToFollow.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z);
	}
}
