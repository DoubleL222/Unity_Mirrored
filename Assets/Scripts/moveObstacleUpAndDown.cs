using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacleUpAndDown : MonoBehaviour
{

    public float speed;
    private float time = 0.0f;
    private float change = 0.0f;
    private bool goUp = false;

    private GameObject[] myChildren = new GameObject[4];
    private Transform[] childTransform = new Transform[4];
    private Vector3[] childStartTransform = new Vector3[4];

    private GameObject gameController;
    private float maxAllowedSpacing;

    private void Start()
    {

        gameController = GameObject.Find("GameControl");
        maxAllowedSpacing = gameController.GetComponent<ObstacleCreate>().maxAllowedSpacing;
        Debug.Log("Max spacing allowed on MoveUpAndDOwn: " + maxAllowedSpacing);
        childTransform[0] = this.gameObject.transform.GetChild(0).GetChild(0); //Top-Top
        childTransform[1] = this.gameObject.transform.GetChild(0).GetChild(1); //Top-Buttom
        childTransform[2] = this.gameObject.transform.GetChild(1).GetChild(1); //Buttom-Top
        childTransform[3] = this.gameObject.transform.GetChild(1).GetChild(0); //Buttom-Buttom

        childStartTransform[0] = this.gameObject.transform.GetChild(0).GetChild(0).localScale; //Top-Top
        childStartTransform[1] = this.gameObject.transform.GetChild(0).GetChild(1).localScale; //Top-Buttom
        childStartTransform[2] = this.gameObject.transform.GetChild(1).GetChild(1).localScale; //Buttom-Top
        childStartTransform[3] = this.gameObject.transform.GetChild(1).GetChild(0).localScale; //Buttom-Buttom
    }

    private void Update()
    {

        if (time > 1.2) { goUp = true; }
        else if (time < 0) { goUp = false; }

        //Debug.Log("Time:" + time);
        //Debug.Log("goUp:" + goUp);

        if (!goUp)
        {
            time += Time.deltaTime;
            change += time / 35.0f * speed;
        }
        else if (goUp)
        {
            time -= Time.deltaTime;
            change -= time / 35.0f * speed;
        }

        if (((childTransform[0].localScale.y - change) < (childStartTransform[0].y * 3)) &&
            ((childTransform[0].localScale.y + change) > (0.3)) &&
            ((childTransform[1].localScale.y - change) < (childStartTransform[1].y * 3)) &&
            ((childTransform[1].localScale.y + change) > (0.3))
            )
        {

            childTransform[0].localScale = new Vector3(1, childStartTransform[0].y + change, 1);
            childTransform[1].localScale = new Vector3(1, childStartTransform[1].y - change, 1); //the is the "width" of the playingfield

            childTransform[2].localScale = new Vector3(1, childStartTransform[2].y + change, 1);
            childTransform[3].localScale = new Vector3(1, childStartTransform[3].y - change, 1); //the is the "width" of the playingfield
        }
        /*
        else {
            if (goUp) { time = 0; }
            else { time = 2; }
            goUp = !goUp; }
            */
    }
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacleUpAndDown : MonoBehaviour {

    public float speed;
    private float time = 0.0f;
    private float change = 0.0f;
    private bool goUp = false;
    private bool startGoUp = false;

    private GameObject[] myChildren = new GameObject[4];
    private Transform[] childTransform = new Transform[4];
    private Vector3[] childStartTransform = new Vector3[4];

    public float maxAllowedSpacing = 3.0f;

    private void Start(){

        float r = Random.RandomRange(0.0f, 1.0f);
        if(r <= 0.5f) { startGoUp = true; }
        else { startGoUp = false; }

        childTransform[0] = this.gameObject.transform.GetChild(0).GetChild(0); //Top-Top
        childTransform[1] = this.gameObject.transform.GetChild(0).GetChild(1); //Top-Buttom
        childTransform[2] = this.gameObject.transform.GetChild(1).GetChild(1); //Buttom-Top
        childTransform[3] = this.gameObject.transform.GetChild(1).GetChild(0); //Buttom-Buttom

        childStartTransform[0] = this.gameObject.transform.GetChild(0).GetChild(0).localScale; //Top-Top
        childStartTransform[1] = this.gameObject.transform.GetChild(0).GetChild(1).localScale; //Top-Buttom
        childStartTransform[2] = this.gameObject.transform.GetChild(1).GetChild(1).localScale; //Buttom-Top
        childStartTransform[3] = this.gameObject.transform.GetChild(1).GetChild(0).localScale; //Buttom-Buttom
    }

    private void Update(){

        if (!goUp){
            time += Time.deltaTime;
            change += time / 35.0f;
            change = change * speed;
        }
        else if(goUp){
            time -= Time.deltaTime;
            change -= time / 35.0f;
            change = change * speed;
        }

        if (startGoUp) {
            if (time > 2) { goUp = false; }
            else if (time < 0) { goUp = true; }
        }
        else {
            if (time > 2) { goUp = true; }
            else if (time < 0) { goUp = false; }
        }

        if (0 >= childTransform[0].localScale.y) { time = 2;  }
        else if (0 >= childTransform[1].localScale.y) { time = 2; }

        childTransform[0].localScale = new Vector3(1, childStartTransform[0].y-change, 1);
        childTransform[1].localScale = new Vector3(1, childStartTransform[1].y + change, 1); //the is the "width" of the playingfield

        childTransform[2].localScale = new Vector3(1, childStartTransform[2].y - change, 1);
        childTransform[3].localScale = new Vector3(1, childStartTransform[3].y + change, 1); //the is the "width" of the playingfield

    }

    private void changeScale(float change1,float change2){

    }
}
*/
