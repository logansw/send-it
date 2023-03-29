using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Input component)
/// Parent class for components which move towards the mouse.
/// </summary>
public abstract class MouseMagnet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody2d;
    public bool magnetOn;

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (magnetOn && !GameManager.Ragdoll) {
            Magnetize();
        }
    }

    public abstract void Magnetize();
}
