using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCreate : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3];
    public GameObject spawnObject;
    private Transform spawnLocation;
    public float maxTime = 3;
    public float minTime = 0.2f;
    private int randomIndexer;
    private bool locationCtrl = true;

    //Rate of spawn
    public float difficultyRate = 10.0f;
    private float timeControlSpawn;
    public int numberOfDiffIncremnts = 5;
    public float maxDiffDecrease = 0.2f;
    public float minDiffDecrease = 1.0f;
    private int difficultyIndex = 0;

    //Rate of shrink
    public float shrinkRate = 10.0f;
    private float timeControlShrink;
    public int noOfShrinkIncrements = 3;
    private int shrinkIndex = 0;
    public float maxAllowedSpacing = 5.0f;
    public float shrinkAmount = 0.5f;

    //Rate of Camera Control
    public float cameraChangeRate = 10.0f;
    private float timeControlCamera;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    //Start values
    private float startTime;

    private float _timer = 0f;

    void Start()
    {
        SetRandomness();
        spawnLocation = spawnObject.GetComponent<Transform>();
        time = minTime;
        startTime = time;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        ControlSpawnrate();
        ControlShrink();
        ControlCamera();

        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Main");
            _timer = 0f;
            SetRandomness();
        }
    }

    void ControlSpawnrate()
    {
        if (_timer > difficultyRate + timeControlSpawn && difficultyIndex < numberOfDiffIncremnts)
        {
            maxTime += -maxDiffDecrease;
            minTime += -minDiffDecrease;
            difficultyIndex++;

            Debug.Log("Difficult Lvl: " + difficultyIndex + " --- MaxTime/minTime: " + maxTime + "/" + minTime);
            timeControlSpawn = _timer;
        }
    }

    void ControlShrink()
    {
        if (_timer > shrinkRate + timeControlShrink && shrinkIndex < noOfShrinkIncrements)
        {
            maxAllowedSpacing += -shrinkAmount;
            Debug.Log("Shrink Objects!");
            shrinkIndex++;
            timeControlShrink = _timer;
        }
    }

    void ControlCamera()
    {
        if (_timer > cameraChangeRate + timeControlCamera)
        {
            CameraAnimator.instance.TriggerTransition();
            timeControlCamera = _timer;
            Debug.Log("CAMERA CHANGE!!!!");
        }
    }

    void FixedUpdate()
    {
        //Counts up to use for respawing
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SetRandomness();
            SpawnObject();
        }
    }



    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0;
        Instantiate(obstacles[randomIndexer], new Vector3(spawnLocation.position.x, spawnLocation.position.y, spawnLocation.position.z), Quaternion.identity);
    }

    //Sets the random time between minTime and maxTime, selects the index to control which object to spawn and alternate between spawn position
    void SetRandomness()
    {
        spawnTime = Random.Range(minTime, maxTime);
        randomIndexer = Random.Range(0, 3);
    }
}