using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDissolve : MonoBehaviour
{
    private GameObject[] myChildren = new GameObject[4];
    public float rand1, rand2, rand3, rand4;

    private void Start()
    {
        myChildren[0] = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        myChildren[1] = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
        myChildren[2] = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        myChildren[3] = this.gameObject.transform.GetChild(1).GetChild(1).gameObject;

        rand1 = Random.Range(0.0f, 0.4f);
        rand2 = Random.Range(0.0f, 0.2f);
        rand3 = Random.Range(0.0f, 0.4f);
        rand4 = Random.Range(0.0f, 0.2f);

        myChildren[0].GetComponent<InterpolateControl>().rand1 = rand1;
        myChildren[3].GetComponent<InterpolateControl>().rand1 = rand1;
        myChildren[0].GetComponent<InterpolateControl>().rand2 = rand3;
        myChildren[3].GetComponent<InterpolateControl>().rand2 = rand4;

        myChildren[1].GetComponent<InterpolateControl>().rand1 = rand3;
        myChildren[2].GetComponent<InterpolateControl>().rand1 = rand3;
        myChildren[1].GetComponent<InterpolateControl>().rand2 = rand4;
        myChildren[2].GetComponent<InterpolateControl>().rand2 = rand4;
    }

}
