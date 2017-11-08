using UnityEngine;

namespace Zampediverse.UnityToolkit {

    /// <summary>
    /// Componente che permette di muovere la camera con i tasti W,A,S,D (riconfigurabili) e ruotare la camera con il mouse tenendo premuto tasto destro.
    /// </summary>
    public class FlyCamera : MonoBehaviour {

        [Header("Velocità di movimento con tasti")]
        /// <summary>
        /// Velocità di movimento camera con i tasti.
        /// </summary>
        public float mainSpeed = 2.0f;

        [Header("Sensibilità di rotazione con mouse")]
        /// <summary>
        /// Rotation sens.
        /// </summary>
        public float camSens = 0.25f;

        [Header("Tasti per movimento da tastiera")] 
        public KeyCode KeyForeward = KeyCode.W;
        public KeyCode KeyBackward = KeyCode.S;
        public KeyCode KeyRight = KeyCode.D;
        public KeyCode KeyLeft = KeyCode.A;

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
            }

            Vector3 p = GetBaseInput();
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            transform.Translate(p);

        }

        private Vector3 GetBaseInput() {
            Vector3 p_Velocity = new Vector3();
            if (Input.GetKey(KeyForeward)) {
                p_Velocity += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyBackward)) {
                p_Velocity += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyLeft)) {
                p_Velocity += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyRight)) {
                p_Velocity += new Vector3(1, 0, 0);
            }
            return p_Velocity;
        }
    }

}