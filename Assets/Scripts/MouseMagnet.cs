using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMagnet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _magnetStrength;
    public bool magnetOn;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (magnetOn && !GameManager.Ragdoll) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = Vector3.Normalize(mousePosition - transform.position);
            _rigidbody2d.AddForce(direction * _magnetStrength);
        }
    }
}
