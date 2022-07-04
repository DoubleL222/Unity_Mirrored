using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObstacles : MonoBehaviour
{

    private Transform[] childTransform = new Transform[4];
    private float maxAllowedSpacing;
    public float fieldSize = 15.0f;
    private GameObject gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameControl");
        maxAllowedSpacing = gameController.GetComponent<ObstacleCreate>().maxAllowedSpacing; 
        //Debug.Log("Shrink Amount of Spawned Prefab: " + maxAllowedSpacing);
        ScaleChildren();
    }

    private void ScaleChildren()
    {
        //Originally did it with a nested loop but kept getting errors -- later found that I accidently applied to script to another object
        //Could not be bothered to do the loops again; sorry for the monkey coding but fuck it; it works.
        childTransform[0] = this.gameObject.transform.GetChild(0).GetChild(0);
        childTransform[1] = this.gameObject.transform.GetChild(0).GetChild(1);
        childTransform[2] = this.gameObject.transform.GetChild(1).GetChild(1);
        childTransform[3] = this.gameObject.transform.GetChild(1).GetChild(0);

        float rangeIndex = Random.Range(1.0f, (fieldSize - 1) - maxAllowedSpacing);
        childTransform[0].localScale = new Vector3(1, rangeIndex, 1);
        childTransform[1].localScale = new Vector3(1, fieldSize - rangeIndex - maxAllowedSpacing, 1); //the is the "width" of the playingfield

        childTransform[2].localScale = new Vector3(1, rangeIndex, 1);
        childTransform[3].localScale = new Vector3(1, fieldSize - rangeIndex - maxAllowedSpacing, 1); //the is the "width" of the playingfield

    }
}
