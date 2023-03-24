using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MouseMagnet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody2d;
    [HideInInspector] public float MagnetStrength;
    public bool magnetOn;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (magnetOn && !GameManager.Ragdoll) {
            Magnetize();
        }
    }

    public abstract void Magnetize();
}
