using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float _bodyWeight;
    [SerializeField] float _bottomWeight;
    [SerializeField] float _shoulderStrength;
    [SerializeField] float _armStrength;

    [Header("References")]
    [SerializeField] Rigidbody2D _bodyRigidbody;
    [SerializeField] Rigidbody2D _bottomRigidbody;
    [SerializeField] MouseMagnet _leftShoulder;
    [SerializeField] MouseMagnet _rightShoulder;
    [SerializeField] MouseMagnet _leftArm;
    [SerializeField] MouseMagnet _rightArm;

    // Update is called once per frame
    void Update()
    {
        _bodyRigidbody.mass = _bodyWeight;
        _bottomRigidbody.mass = _bottomWeight;
        _leftShoulder.MagnetStrength = _shoulderStrength;
        _rightShoulder.MagnetStrength = _shoulderStrength;
        _leftArm.MagnetStrength = _armStrength;
        _rightArm.MagnetStrength = _armStrength;
    }
}
