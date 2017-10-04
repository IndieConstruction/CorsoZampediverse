using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour {

    /// <summary>
    /// Speed movement.
    /// </summary>
    public float mainSpeed = 10.0f;
    /// <summary>
    /// Rotation sens.
    /// </summary>
    public float camSens = 0.25f;

    private Vector3 lastMouse;
    private float totalRun = 1.0f;

    void Awake() {
        transform.rotation = Quaternion.Euler(25, 0, 0);
    }

    void Update() {

        if (Input.GetMouseButtonDown(1)) {
            lastMouse = Input.mousePosition;
        }

        if (Input.GetMouseButton(1)) {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
            //Mouse  camera angle done.  
        }

        Vector3 p = GetBaseInput();
        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        p = p * mainSpeed;

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        transform.Translate(p);

    }

    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W)) {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S)) {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A)) {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}

