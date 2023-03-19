using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Floor") {
            _rigidbody.AddForce(new Vector2(0, 30));
            _rigidbody.mass = 0.5f;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.name == "Floor") {
            _rigidbody.mass = 3;
        }
    }
}
