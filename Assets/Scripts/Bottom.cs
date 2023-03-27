using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    private const float EPSILON = 1.0f;
    private const float RANGE = 10.0f;
    private const float SPEED = 1.2f;

    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    private float _originalWeight;
    public bool IsGrounded;

    void Start() {
        _originalWeight = _rigidbody.mass;
        IsGrounded = false;
    }

    void FixedUpdate() {
        if (IsGrounded) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 bottomPos = transform.position;
            Vector2 bottomToMouse = mousePos - bottomPos;
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
