using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Input Component)
/// Lets character jump from the floor
/// </summary>
public class Jump : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Bottom _bottom;

    [Header("Levers")]
    [SerializeField] private int _jumpForce;
    [SerializeField] private KeyCode _jumpButton;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_jumpButton) && _bottom.IsGrounded) {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
    }
}
