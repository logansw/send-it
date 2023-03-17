using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    [SerializeField] private KeyCode _actionKey;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private LayerMask _ignoreRaycast;
    public bool IsClamping { get; private set; }

    void Update() {
        if (Input.GetKeyDown(_actionKey)) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back, ~_ignoreRaycast);
            Debug.Log(hit.collider.gameObject.layer);

            if (hit.collider.gameObject.layer.Equals(6)) {
                _rigidbody2d.bodyType = RigidbodyType2D.Static;
                IsClamping = true;
            }
        }

        if (Input.GetKeyUp(_actionKey)) {
            _rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            IsClamping = false;
        }
    }
}
