using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls on-screen countdowns
/// </summary>
public class Countdown : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _three;
    [SerializeField] private Sprite _two;
    [SerializeField] private Sprite _one;
    [SerializeField] private Sprite _top;
    [SerializeField] private AudioSource _countdownSound;
    [SerializeField] private Timer _timer;

    /// <summary>
    /// Starts 3-second countdown
    /// </summary>
    public IEnumerator StartCountdown() {
        _countdownSound.Play();
        StartCoroutine(AnimateSprite(_three));
        yield return new WaitForSeconds(1);
        StartCoroutine(AnimateSprite(_two));
        yield return new WaitForSeconds(1);
        StartCoroutine(AnimateSprite(_one));
        yield return new WaitForSeconds(1);
        _timer.EndTimer();
        StartCoroutine(AnimateSprite(_top));
        yield return new WaitForSeconds(1);
        EndCountdown();
    }

    /// <summary>
    /// Stops the countdown immediately
    /// </summary>
    public void EndCountdown() {
        _spriteRenderer.sprite = null;
        GameManager.Ragdoll = false;
        _countdownSound.Stop();
    }

    /// <summary>
    /// Displays and animates <paramref name="sprite"/> on screen
    /// </summary>
    /// <param name="sprite"></param>
    private IEnumerator AnimateSprite(Sprite sprite) {
        _spriteRenderer.sprite = sprite;
        float scale = 1.5f;
        while (scale > 1.0f) {
            _spriteRenderer.gameObject.transform.localScale = new Vector2(scale, scale);
            scale -= 0.01f;
            yield return null;
        }
    }
}
