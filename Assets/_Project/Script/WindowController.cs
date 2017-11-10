using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class WindowController : MonoBehaviour {

    [Header("Titolo prodotto")]
    public string TextTitleBox;
    public TextMeshProUGUI TextTitleComponentTarget;

    [Header("Box descrizione del prodotto")]
    public string TextInfoBox;
    public TextMeshProUGUI TextComponentTarget;

    [Header("Didascalia")]
    [Multiline]
    public string TextDidaBox;
    public TextMeshProUGUI TextDidaComponentTarget;
    public bool RAlign;

    [Header("Box video")]
    public VideoPlayer VideoController;

	// Use this for initialization
	void Start () {
        TextComponentTarget.text = TextInfoBox;
        TextTitleComponentTarget.text = TextTitleBox;
        TextDidaComponentTarget.text = TextDidaBox;
        if (RAlign == true) {
            TextDidaComponentTarget.alignment = TextAlignmentOptions.TopRight;
        }
    }
	
	// Update is called once per frame
	void Update () {
        // TextDidaComponentTarget.text = VideoController.frame.ToString() + " / " + VideoController.frameCount.ToString();
    }

    private void OnMouseEnter() {
        VideoController.Play();
    }

    private void OnMouseExit() {
        VideoController.Stop();
    }
}
