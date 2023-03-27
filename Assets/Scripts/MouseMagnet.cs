using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
