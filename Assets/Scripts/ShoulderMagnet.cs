using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Input component)
/// Moves character towards mouse.
/// </summary>
public class ShoulderMagnet : MouseMagnet
{
    [HideInInspector] public float MagnetStrength;
    public override void Magnetize()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = Vector3.Normalize(mousePosition - transform.position);
        _rigidbody2d.AddForce(direction * MagnetStrength);
    }
}
