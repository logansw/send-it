using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    [SerializeField] private KeyCode _actionKey;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    public bool IsClamping { get; private set; }
    private bool _holdingTop;
    private Vector3[] _repeatRaycastOffsets;

    private void Start() {
        _repeatRaycastOffsets = new Vector3[5];
        _repeatRaycastOffsets[0] = new Vector3(-0.2f, 0, 0);
        _repeatRaycastOffsets[1] = new Vector3(0.2f, 0, 0);
        _repeatRaycastOffsets[2] = new Vector3(0, 0, 0);
        _repeatRaycastOffsets[3] = new Vector3(0, 0, -0.2f);
        _repeatRaycastOffsets[4] = new Vector3(0, 0, 0.2f);
    }

    void Update() {
        if (Input.GetKeyDown(_actionKey)) {
            Grab();
        }

        if (Input.GetKeyUp(_actionKey)) {
            Release();
        }
    }

    private void Grab() {
        // TODO: Sound effect here
        for (int i = 0; i < _repeatRaycastOffsets.Length; i++) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + _repeatRaycastOffsets[i], Vector3.forward);

            if (hit && hit.collider.gameObject.layer.Equals(6)) {
                _rigidbody2d.bodyType = RigidbodyType2D.Static;
                IsClamping = true;
                if (hit.collider.gameObject.name == "Start") {
                    RouteStart routeStart = hit.collider.gameObject.GetComponent<RouteStart>();
                    routeStart.Begin();
                } else if (hit.collider.gameObject.name == "Top") {
                    _holdingTop = true;
                    GameManager.s_HandsOnFinish++;
                }
                return;
            }
        }
    }

    private void Release() {
        _rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        IsClamping = false;
        if (_holdingTop) {
            _holdingTop = false;
            GameManager.s_HandsOnFinish--;
        }
    }
}
