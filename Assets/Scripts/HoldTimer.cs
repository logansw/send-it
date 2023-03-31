using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldTimer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _timerImage;
    [SerializeField] private Image _timerBackgroundImage;

    private float _holdDuration;
    private float _remainingDuration;
    private bool _depletedThisFrame;

    public void Initialize(float duration, Color32 color) {
        _holdDuration = duration;
        _timerImage.color = color;
        Color32 transparentColor = color;
        transparentColor.a = 100;
        _timerBackgroundImage.color = transparentColor;
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
