using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldTimer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _timerImage;

    [Header("Properties")]
    [SerializeField] private float _holdDuration;

    private float _remainingDuration;
    private bool _depletedThisFrame;

    public void Initialize(GameObject holdable) {
        RefreshTimer();
        transform.position = holdable.transform.position;
    }

    public void RefreshTimer() {
        _remainingDuration = _holdDuration;
    }

    void FixedUpdate() {
        _depletedThisFrame = false;
    }

    public float Deplete() {
        if (!_depletedThisFrame) {
            _remainingDuration -= Time.deltaTime;
            _depletedThisFrame = true;
            _timerImage.fillAmount = _remainingDuration / _holdDuration;
        }
        return _remainingDuration;
    }
}
