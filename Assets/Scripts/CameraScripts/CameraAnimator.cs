using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimator : MonoBehaviour {

    #region Variables
    //Reference to cameras animator
    private Animator myAnimator;

    //Singleton pattern. This enables any script in the scene to reference this script very easily.
    //This is done so: CameraAnimator.instance.[any public function]
    private static CameraAnimator _instance;
    public static CameraAnimator instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CameraAnimator>();
            }
            return _instance;
        }
    }
    #endregion

    #region Private Functions
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    #endregion

    #region Public Functions

    //TODO write all the animation triggering code
    public void TriggerTransition()
    {
        myAnimator.SetTrigger("NextState");
    }
    #endregion
}
