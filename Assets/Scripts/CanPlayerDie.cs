using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanPlayerDie : MonoBehaviour
{

    public bool playerCanDie = false;
    public bool quitApplication = false;
    public Text endText;

    void Awake()
    {
        if (!playerCanDie)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            var name = other.name;

            if(name == "Player1" && endText.text ==""){
                endText.color = Color.green;
                endText.text = "Green wins!" + "\n" + "Press R to restart";
            }
            else if (name == "Player2" && endText.text == ""){
                endText.color = Color.red;
                endText.text = "Red wins!" + "\n" + "Press R to restart";
            }

            Destroy(other.gameObject);
            if (quitApplication)
            {
                //UnityEditor.EditorApplication.isPlaying = false;
                //Application.Quit();
            }
        }
    }

}
