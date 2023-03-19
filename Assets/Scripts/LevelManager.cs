using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Vector3 SpawnPosition;
    public delegate void OnRestart();
    public static OnRestart e_OnRestart;

    public void Start() {
        SpawnPosition = new Vector3(0, 0, -1);
        e_OnRestart();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.R)) {
            if (e_OnRestart != null) {
                e_OnRestart();
            }
        }
    }
}
