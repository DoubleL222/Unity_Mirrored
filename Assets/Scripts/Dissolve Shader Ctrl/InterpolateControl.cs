using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateControl : MonoBehaviour
{
    Material dissolveM;
    public Material dissolveM_Fire;
    Renderer rend;
    public float dissolveControlSpeeed = 1.0f;
    public float timeToDissolve = 2.0f;
    private float iniTime;
    private bool beginInterpolation = false;
    private bool beginInterpolation_start = false;
    float result, oscilationRange, oscilationOffset;

    float startRange = 0.6f;
    float endRange = 0.1f;
    public float rand1, rand2;

    // Use this for initialization
    void Start()
    {
        //dissolveM = GetComponent<Renderer>().material;

        // var materials = GetComponent<Renderer>().materials;

        dissolveM = GetComponent<Renderer>().material;

        rend = GetComponent<MeshRenderer>();

        rend.material = dissolveM;
        //dissolveM = Resources.Load("Materials/Dissolve_M") as Material;
        //dissolveM_Fire = Resources.Load("Dissolve_M1") as Material;
        //dissolveM_Fire = Resources.Load("Materials/Dissolve_M 1.mat", typeof(Material)) as Material;
        //DissolveExample
        //rand1 = Random.Range(0.5f, 0.8f);
        //rand2 = Random.Range(0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        oscilationRange = (endRange - (startRange+ rand2)) / 2;
        oscilationOffset = oscilationRange + startRange;
        result = oscilationOffset + Mathf.Sin(Time.time * rand1) * oscilationRange;
        dissolveM.SetFloat("_InterpolateControl", result);

        /*
        if (beginInterpolation) //Is runned when object is ending 
        {
            rend.material = dissolveM_Fire;
            iniTime += Time.deltaTime / timeToDissolve;
            dissolveM_Fire.SetFloat("_InterpolateControl", Mathf.Lerp(0.0f, 1.0f, iniTime));
        }
        
        if (beginInterpolation_start && !beginInterpolation) //Is runned when object is instantiated 
        {
            dissolveM.SetFloat("_InterpolateControl", Mathf.Lerp(0.0f, 1.0f, iniTime));
            iniTime -= Time.deltaTime;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Backline"))
        {
            iniTime = 0; //reset iniTime
            //rend.material = dissolveM_Fire; //Set material to fire-material
            beginInterpolation = true;
        }
        if (other.CompareTag("FrontLine"))
        {
            beginInterpolation_start = true;
            iniTime = 1;
        }
    }
}
