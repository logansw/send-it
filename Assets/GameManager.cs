using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int s_HandsOnFinish = 0;
    private IEnumerator _countdownCoroutine;
    private bool _isCountingDown;
    [SerializeField] private Countdown _countdown;

    // Update is called once per frame
    void Update()
    {
        if (!_isCountingDown && s_HandsOnFinish == 2) {
            _countdownCoroutine = _countdown.StartCountdown();
            StartCoroutine(_countdownCoroutine);
            _isCountingDown = true;
        } else if (_isCountingDown && s_HandsOnFinish != 2) {
            StopCoroutine(_countdownCoroutine);
            _isCountingDown = false;
            _countdown.EndCountdown();
        }
    }
}
