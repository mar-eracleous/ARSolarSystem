using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour {

    //Create ray and raycasthit variables
    Ray ray;
    RaycastHit hit;

    //Create public gameobjects for each tooltip
    public GameObject TooltipSun;
    public GameObject TooltipMercury;
    public GameObject TooltipVenus;
    public GameObject TooltipEarth;
    public GameObject TooltipMoon;
    public GameObject TooltipMars;
    public GameObject TooltipJupiter;
    public GameObject TooltipSaturn;
    public GameObject TooltipUranus;
    public GameObject TooltipNeptune;

    void Start() {

    }

    void Update() {

        //If there is touch,
        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began) {

            //get touch position using raycast from camera
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            //If the ray hits an object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                
                //use the if, else if statement to check which object is touched and instantiate the corresponding tooltip
                if (hit.transform.gameObject.tag == "Sun") {

                    Instantiate(TooltipSun);

                } else if (hit.transform.gameObject.tag == "Mercury") {

                    Instantiate(TooltipMercury);

                } else if (hit.transform.gameObject.tag == "Venus") {

                    Instantiate(TooltipVenus);

                } else if (hit.transform.gameObject.tag == "Earth") {

                    Instantiate(TooltipEarth);

                } else if (hit.transform.gameObject.tag == "Moon") {

                    Instantiate(TooltipMoon);

                } else if (hit.transform.gameObject.tag == "Mars") {

                    Instantiate(TooltipMars);

                } else if (hit.transform.gameObject.tag == "Jupiter") {

                    Instantiate(TooltipJupiter);

                } else if (hit.transform.gameObject.tag == "Saturn") {

                    Instantiate(TooltipSaturn);

                } else if (hit.transform.gameObject.tag == "Uranus") {

                    Instantiate(TooltipUranus);

                } else if (hit.transform.gameObject.tag == "Neptune") {

                    Instantiate(TooltipNeptune);
                }
            }
        }

    }
}
