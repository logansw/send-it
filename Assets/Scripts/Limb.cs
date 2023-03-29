using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (Blob component)
/// Component for the entire arm, coordinating between the shoulder and hand.
/// </summary>
public class Limb : MonoBehaviour
{
    [SerializeField] private MouseMagnet _connectionOne;
    [SerializeField] private MouseMagnet _connectionTwo;
    [SerializeField] private Clamp _clampTwo;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_clampTwo.IsClamping) {
            _connectionOne.magnetOn = true;
            _connectionTwo.magnetOn = false;
        } else {
            _connectionOne.magnetOn = false;
            _connectionTwo.magnetOn = true;
        }
    }
}
