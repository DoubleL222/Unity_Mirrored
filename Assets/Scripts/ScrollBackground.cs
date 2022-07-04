using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    void FixedUpdate()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

}