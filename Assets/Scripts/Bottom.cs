using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Blob component)
/// Bottom of character. Handles what happens when character is touching the floor
/// </summary>
public class Bottom : MonoBehaviour
{
    // Movement dead zone. If mouse is within [EPSILON] of character, no movement occurs
    private const float EPSILON = 1.0f;
    // Movement extremes. If mouse is [RANGE] units from character, max speed movement
    private const float RANGE = 10.0f;
    // Movement scale factor. Bigger number = faster :)
    private const float SPEED = 1.2f;

    [Header("References")]
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;

    [HideInInspector] public bool IsGrounded;
    private float _originalWeight;

    void Start() {
        _originalWeight = _rigidbody.mass;
        IsGrounded = false;
    }

    void FixedUpdate() {
        if (IsGrounded) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 bottomPosition = transform.position;
            Vector2 bottomToMouse = mousePosition - bottomPosition;
            float bottomToMouseHorizontal = Vector2.Dot(bottomToMouse, Vector2.right);

            if (Mathf.Abs(bottomToMouseHorizontal) < EPSILON) {
                // Do Nothing
            } else if (bottomToMouseHorizontal > 0) {
                _rigidbody.velocity = new Vector2(Mathf.Min(RANGE, bottomToMouseHorizontal) * SPEED, 0);
            } else {
                _rigidbody.velocity = new Vector2(Mathf.Max(-RANGE, bottomToMouseHorizontal) * SPEED, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Floor") {
            IsGrounded = true;
            _rigidbody.mass = _originalWeight / 4;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.name == "Floor") {
            IsGrounded = false;
            _rigidbody.mass = _originalWeight;
        }
    }
}