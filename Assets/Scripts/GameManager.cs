using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static int s_HandsOnFinish = 0;
    private IEnumerator _countdownCoroutine;
    private bool _isCountingDown;
    [SerializeField] private Countdown _countdown;
    [SerializeField] private GameObject _chalkyPrefab;
    private GameObject _chalkyInstance;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    public static bool Ragdoll = false;
    public static Route s_CurrentRoute;

    void OnEnable() {
        LevelManager.e_OnRestart += Restart;
    }

    void OnDisable() {
        LevelManager.e_OnRestart -= Restart;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isCountingDown && s_HandsOnFinish == 2) {
            _countdownCoroutine = _countdown.StartCountdown();
            StartCoroutine(_countdownCoroutine);
            _isCountingDown = true;
            Ragdoll = true;
        } else if (_isCountingDown && s_HandsOnFinish != 2) {
            StopCoroutine(_countdownCoroutine);
            _isCountingDown = false;
            _countdown.EndCountdown();
            Ragdoll = false;
        }
    }

    void Restart() {
        Destroy(_chalkyInstance);
        _chalkyInstance = Instantiate(_chalkyPrefab, LevelManager.SpawnPosition, Quaternion.identity);
        s_HandsOnFinish = 0;
        _virtualCamera.Follow = _chalkyInstance.transform.Find("Body");
    }
}
