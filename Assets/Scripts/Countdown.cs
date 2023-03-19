using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _three;
    [SerializeField] private Sprite _two;
    [SerializeField] private Sprite _one;
    [SerializeField] private Sprite _top;

    public IEnumerator StartCountdown() {
        StartCoroutine(AnimateSprite(_three));
        yield return new WaitForSeconds(1);
        StartCoroutine(AnimateSprite(_two));
        yield return new WaitForSeconds(1);
        StartCoroutine(AnimateSprite(_one));
        yield return new WaitForSeconds(1);
        StartCoroutine(AnimateSprite(_top));
        yield return new WaitForSeconds(1);
        EndCountdown();
    }

    public void EndCountdown() {
        _spriteRenderer.sprite = null;
    }

    public IEnumerator AnimateSprite(Sprite sprite) {
        _spriteRenderer.sprite = sprite;
        float scale = 1.5f;
        while (scale > 1.0f) {
            _spriteRenderer.gameObject.transform.localScale = new Vector2(scale, scale);
            scale -= 0.01f;
            yield return null;
        }
    }
}
