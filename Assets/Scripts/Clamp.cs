using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Input component)
/// Component for grabbing/releasing hands to holds.
/// </summary>
public class Clamp : MonoBehaviour
{
    // When player grabs, upward force is applied to make vertical progress easier.
    private const int UPWARD_ASSIST_FORCE = 6;
    [SerializeField] private KeyCode _actionKey;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private Rigidbody2D _coreBody;
    [SerializeField] private AudioSource _grabSound;
    public bool IsClamping { get; private set; }
    private bool _holdingTop;
    private Vector3[] _repeatRaycastOffsets;
    private Holdable _currentHold;

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

    void FixedUpdate() {
        if (IsClamping) {
            _coreBody.AddForce(new Vector2(0, UPWARD_ASSIST_FORCE));
            if (_currentHold == null) { return; }
            float remaining = _currentHold.HoldTimer.Deplete();
            if (remaining <= 0) {
                Release();
            }
        }
    }

    private void Grab() {
        for (int i = 0; i < _repeatRaycastOffsets.Length; i++) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + _repeatRaycastOffsets[i], Vector3.forward);

            if (hit && hit.collider.gameObject.layer.Equals(6)) {
                _grabSound.Play();
                _rigidbody2d.bodyType = RigidbodyType2D.Static;
                IsClamping = true;
                if (hit.collider.gameObject.name == "Start") {
                    RouteStart routeStart = hit.collider.gameObject.GetComponent<RouteStart>();
                    routeStart.Begin();
                } else if (hit.collider.gameObject.name == "Top") {
                    _holdingTop = true;
                    GameManager.s_HandsOnFinish++;
                } else {
                    _currentHold = hit.collider.gameObject.GetComponent<Holdable>();
                    _currentHold.DisplayTimer(true);
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
        if (_currentHold != null) {
            _currentHold.DisplayTimer(false);
        }
        _currentHold = null;
    }
}
