using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WindowController : MonoBehaviour {

    public 

    VideoPlayer VideoController;


	// Use this for initialization
	void Start () {
        VideoController = GetComponent<VideoPlayer>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter() {
        VideoController.Play();
    }

    private void OnMouseExit() {
        VideoController.Pause();
    }
}
