using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class OnMouseEnterPlayVideo : MonoBehaviour {

    public VideoPlayer VideoController;
    public Transform MonitorTransform;
    public float OffSizeRation = 0.000001f;

    Vector3 OnSize;
    Vector3 OffSize;

    public void Start() {
        if (!MonitorTransform)
            MonitorTransform = transform;
        VideoController.Play();
        VideoController.Stop();
        OnSize = MonitorTransform.localScale;
        OffSize = new Vector3(OffSizeRation * OnSize.x, OffSizeRation * OnSize.y, OnSize.z);
        MonitorTransform.localScale = OffSize;
    }

    private void OnMouseEnter() {
        if (VideoController.frame == 0) {
        }
        MonitorTransform.DOScale(OnSize, 0.5f).SetEase(Ease.OutExpo);
        VideoController.Play();
    }

    private void OnMouseExit() {
        VideoController.Pause();
        MonitorTransform.DOScale(OffSize, 0.3f).SetEase(Ease.OutExpo);
    }
}
