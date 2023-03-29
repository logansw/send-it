using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Crosshair so people don't lose track of the mouse
/// </summary>
public class Crosshair : MonoBehaviour
{
    void Start() {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
}
