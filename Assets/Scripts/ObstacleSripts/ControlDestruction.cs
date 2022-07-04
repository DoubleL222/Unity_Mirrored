using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDestruction : MonoBehaviour
{
    public float pushbackForce = 0.01f;
    private GameObject[] myChildren = new GameObject[4];
    public GameObject destructionEffect;

    private void Start()
    {
        myChildren[0] = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        myChildren[1] = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
        myChildren[2] = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        myChildren[3] = this.gameObject.transform.GetChild(1).GetChild(1).gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //PlayerMovement.PushBack(other.GetComponent<Rigidbody>());
			PlayerController pc = other.gameObject.GetComponent<PlayerController>();
			if (pc != null) 
			{
				pc.PushBack ();
			}
            Debug.Log("Player Was Hit");
            for (int i = 0; i < myChildren.Length; i++)
            {
                if (myChildren[i].GetComponent<TriggerControl>().hasBeenTriggered == true)
                {
                    Debug.Log("Child that was Triggered was: " + myChildren[i].name);
                    if (myChildren[i].name.Contains("ObstacleMain (1)"))
                    {
                        CreateDesTop(myChildren[3], myChildren[i]);
                    }
                    else if (myChildren[i].name.Contains("ObstacleMain (2)"))
                    {
                        CreateDesTop(myChildren[2], myChildren[i]);
                    }
                    else if (myChildren[i].name.Contains("ObstacleMain (3)"))
                    {
                        CreateDesBot(myChildren[1], myChildren[i]);
                    }
                    else if (myChildren[i].name.Contains("ObstacleMain (4)"))
                    {
                        CreateDesBot(myChildren[0], myChildren[i]);
                    }
                }
            }
        }
    }

    void CreateDesBot(GameObject mirroredObj, GameObject actualObj)
    {
        Instantiate(destructionEffect, new Vector3(
        mirroredObj.transform.position.x,
        mirroredObj.transform.position.y,
        mirroredObj.transform.position.z - (mirroredObj.transform.localScale.y * 0.5f)),
        mirroredObj.transform.rotation);

        Instantiate(destructionEffect, new Vector3(
        actualObj.transform.position.x,
        actualObj.transform.position.y,
        actualObj.transform.position.z + (actualObj.transform.localScale.y * 0.5f)),
        actualObj.transform.rotation);

        mirroredObj.SetActive(false);
        actualObj.SetActive(false);
    }

    void CreateDesTop(GameObject mirroredObj, GameObject actualObj)
    {
        Instantiate(destructionEffect, new Vector3(
        mirroredObj.transform.position.x,
        mirroredObj.transform.position.y,
        mirroredObj.transform.position.z + (mirroredObj.transform.localScale.y * 0.5f)),
        mirroredObj.transform.rotation);

        Instantiate(destructionEffect, new Vector3(
        actualObj.transform.position.x,
        actualObj.transform.position.y,
        actualObj.transform.position.z - (actualObj.transform.localScale.y * 0.5f)),
        actualObj.transform.rotation);

        mirroredObj.SetActive(false);
        actualObj.SetActive(false);
    }
}
