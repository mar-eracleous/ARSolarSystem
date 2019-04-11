using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisable : MonoBehaviour {

    //Countdown Script: https://www.youtube.com/watch?v=o0j7PdU88a4

    //Create a gameobject for instructions text
    GameObject Text;

    //Create variables to hold the starting and current times
    float currentTime = 0f;
    float startingTime = 20f;

    //Set public gameobject text
    [SerializeField] Text countdownText;

	void Start () {

        //Assign Text object to gameobject
        Text = GameObject.Find("Text");

        //Assign starting time as the current time
        currentTime = startingTime;

	}
	
	void Update () {

        //Current time decreases by 1 second
        currentTime -= 1 * Time.deltaTime;

        //Assign currentTime to countdownText and set the required digits
        countdownText.text = currentTime.ToString("0" + "s");

        //If the countdown reaches 0 then show current time as 0
        if (currentTime <= 0) {
            currentTime = 0;
        }

        //Destroy the object 'Text' after 20 seconds
        Destroy(GameObject.Find("Text"), 20);

	}
}
