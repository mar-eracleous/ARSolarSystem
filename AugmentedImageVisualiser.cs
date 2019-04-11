using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedImageVisualiser : MonoBehaviour {

    //Variable for the augmented image to visualise
    public AugmentedImage Image;
    //Variable to set the solar system
    public GameObject SolarSystem;

	public void Update () {

        //If no image is tracked, then the gameobject in inactive so, it doesn't show
        if (Image == null || Image.TrackingState != TrackingState.Tracking) {

            SolarSystem.SetActive(false);
            return;
        }
        
        //Set objects scale
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        //Set the object active
        SolarSystem.SetActive(true);

    }
}
