using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirino : MonoBehaviour {
    Camera cam;
    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            print("Sto puntando a " + hit.transform.name);
        else
            print("Non sto puntando a niente!");
    }
}
