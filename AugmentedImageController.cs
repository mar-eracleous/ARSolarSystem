using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class AugmentedImageController : MonoBehaviour {

    //Set prefab to visualise an augmented image
    public AugmentedImageVisualiser augmentedImageVisualiser;

    //Gameobject to assign the fitToScanOverlay image
    public GameObject FitToScanOverlay;

    private readonly Dictionary<int, AugmentedImageVisualiser> _visualisers = new Dictionary<int, AugmentedImageVisualiser>();

    private readonly List<AugmentedImage> _images = new List<AugmentedImage>();    

    private void Update() {

        //Click back button to quit the app
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

        //Check motion tracking
        if (Session.Status != SessionStatus.Tracking) {
            //Adjust screen timeout to stay on while tracking
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //Get updated augmented image
        Session.GetTrackables<AugmentedImage>(_images, TrackableQueryFilter.Updated);

        foreach (var image in _images) {

            AugmentedImageVisualiser visualiser = null;
            _visualisers.TryGetValue(image.DatabaseIndex, out visualiser);
            if (image.TrackingState == TrackingState.Tracking && visualiser == null) {

                //Create anchor to ensure that the image is being tracked by ARCore
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                visualiser = (AugmentedImageVisualiser)Instantiate(augmentedImageVisualiser, anchor.transform);
                visualiser.Image = image;
                _visualisers.Add(image.DatabaseIndex, visualiser);

            } else if (image.TrackingState == TrackingState.Stopped && visualiser != null) {

                _visualisers.Remove(image.DatabaseIndex);
                GameObject.Destroy(visualiser.gameObject);

            }
        }

        //If no image is scanned, show the fit to scan overlay
        foreach (var visualiser in _visualisers.Values) {

            if (visualiser.Image.TrackingState == TrackingState.Tracking) {
                FitToScanOverlay.SetActive(false);
                return;
            }

        }

        FitToScanOverlay.SetActive(true);
    }
}
