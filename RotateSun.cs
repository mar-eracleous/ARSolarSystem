using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour {

    //Public variable to assign the object/pivot the planets are orbiting
    public Transform orbitPivot;

    //Public variable to hold the planets' orbit speed
    public float orbitSpeed;

    //Public variable to hold planets' rotation speed
    public float rotationSpeed;

    void Start () {

    }
	
	void Update () {
        //Get the pivot's position and the planet's orbitspeed to orbit the planet
        this.transform.RotateAround(orbitPivot.position, Vector3.up, orbitSpeed * Time.deltaTime);
        //Rotate planet around itself
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
