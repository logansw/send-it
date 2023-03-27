using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pamphlet : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;
    public Sprite[] _pages;
    private int _currentPage;

    // Start is called before the first frame update
    void Start()
    {
        _currentPage = 0;
        _spriteRenderer.sprite = _pages[_currentPage];
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            AdvancePage();
        }
    }

    private void AdvancePage() {
        _currentPage++;
        if (_currentPage == _pages.Length) {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        } else {
            _spriteRenderer.sprite = _pages[_currentPage];
        }
    }
}
