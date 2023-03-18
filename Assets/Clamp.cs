using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    [SerializeField] private KeyCode _actionKey;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private LayerMask _ignoreRaycast;
    [SerializeField] private Transform _limb;
    public bool IsClamping { get; private set; }
    private bool _holdingTop;

    void Update() {
        if (Input.GetKeyDown(_actionKey)) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back, ~_ignoreRaycast);

            if (hit.collider.gameObject.layer.Equals(6)) {
                _rigidbody2d.bodyType = RigidbodyType2D.Static;
                IsClamping = true;
                if (hit.collider.gameObject.name == "Top") {
                    _holdingTop = true;
                    GameManager.s_HandsOnFinish++;
                }
            }
        }

        if (Input.GetKeyUp(_actionKey)) {
            _rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            IsClamping = false;
            if (_holdingTop) {
                _holdingTop = false;
                GameManager.s_HandsOnFinish--;
            }
        }
    }
}
