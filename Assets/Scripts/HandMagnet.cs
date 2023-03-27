using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMagnet : MouseMagnet
{
    [Header("References")]
    [SerializeField] private GameObject _ligament;
    [SerializeField] private Transform _shoulderTransform;

    [Header("Properties")]
    [HideInInspector] private float _maxDistance;
    private float _maxDelta;

    public void Initialize(float maxDistance) {
        _maxDistance = maxDistance;
        _maxDelta = _maxDistance / 4.0f;
    }

    protected override void FixedUpdate() {
        if (magnetOn && !GameManager.Ragdoll) {
            Magnetize();
        } else {
            OrientLigament(_shoulderTransform.position, transform.position);
        }
    }

    public override void Magnetize()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shoulderPos = new Vector2(_shoulderTransform.position.x, _shoulderTransform.position.y);
        Vector2 handPos = new Vector2(transform.position.x, transform.position.y);

        Vector2 shoulderToMouse = mousePos - shoulderPos;

        Vector2 targetPos;
        if (shoulderToMouse.magnitude > _maxDistance) {
            targetPos = shoulderPos + (shoulderToMouse / shoulderToMouse.magnitude * _maxDistance);
        } else {
            targetPos = mousePos;
        }

        Vector2 handToTarget = targetPos - handPos;

        if (handToTarget.magnitude < _maxDelta) {
            transform.position = targetPos;
        } else {
            transform.position = (Vector2)transform.position + (handToTarget / handToTarget.magnitude * _maxDelta);
        }

        OrientLigament(shoulderPos, transform.position);
    }

    private void OrientLigament(Vector2 shoulderPos, Vector2 targetPos) {
        Vector2 shoulderToTarget = targetPos - shoulderPos;
        float distance = Mathf.Min(Vector2.Distance(targetPos, shoulderPos), _maxDistance);
        _ligament.transform.position = shoulderPos;
        _ligament.transform.right = targetPos - shoulderPos;
        _ligament.transform.localScale = new Vector3(distance, 1, 1);
    }
}