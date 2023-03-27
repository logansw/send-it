using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    private float _originalWeight;
    public bool IsGrounded;

    void Start() {
        _originalWeight = _rigidbody.mass;
        IsGrounded = true;
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
