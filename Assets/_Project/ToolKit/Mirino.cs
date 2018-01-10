using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zampediverse.UnityToolkit {

    public class Mirino : MonoBehaviour { 
        Camera cam;
        public Image TargetUI;
        public Image CounterUI;
        public float OverTimeLimit = 1;
        public float Distance = 3;
        float currentOverTime = 0;

        bool alreadyClicked = false;

        // Use this for initialization
        void Start() {
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update() {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Distance)) {
                InteractForAnimation interactor = hit.collider.GetComponent<InteractForAnimation>();
                if (interactor != null && interactor.CanInteract()) {
                    currentOverTime = currentOverTime + Time.deltaTime;
                    // Modifico visualizzazione Target
                    TargetUI.color = Color.red;
                    TargetUI.rectTransform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                    // Modifico visualizzazione Counter
                    CounterUI.fillAmount = currentOverTime / OverTimeLimit;
                    CounterUI.rectTransform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

                    if (currentOverTime >= OverTimeLimit && alreadyClicked == false) {
                        OnClick(hit);
                        //currentOverTime = 0;
                        alreadyClicked = true;
                    }
                } else {
                    ResetCounter();
                }

            } else {
                ResetCounter();
            }
        }

        /// <summary>
        /// Riporto il mirino in stato di non attivo azzerando anche tutti i contatori
        /// in modo che siano pronti in caso di un nuovo conteggio.
        /// </summary>
        void ResetCounter() {
            currentOverTime = 0;
            alreadyClicked = false;
            TargetUI.color = Color.white;
            TargetUI.rectTransform.localScale = Vector3.one;
            CounterUI.fillAmount = 0;
            CounterUI.rectTransform.localScale = Vector3.one;
        }

        void OnClick(RaycastHit _hit) {
            Debug.Log("OnClick " + _hit.transform.name);
            InteractForAnimation componentFinded = _hit.transform.GetComponent<InteractForAnimation>();
            if (componentFinded != null) {
                componentFinded.InteractionToggle();
            }
            
        }
    }
}