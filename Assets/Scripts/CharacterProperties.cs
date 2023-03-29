using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inspector-exposed class for controlling properties about attached character
/// (e.g. mass, shoulder strength, arm length).
/// </summary>
public class CharacterProperties : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float _bodyWeight;
    [SerializeField] float _bottomWeight;
    [SerializeField] float _shoulderStrength;
    [SerializeField] float _armLength;

    [Header("References")]
    [SerializeField] Rigidbody2D _bodyRigidbody;
    [SerializeField] Rigidbody2D _bottomRigidbody;
    [SerializeField] ShoulderMagnet _leftShoulder;
    [SerializeField] ShoulderMagnet _rightShoulder;
    [SerializeField] HandMagnet _leftHand;
    [SerializeField] HandMagnet _rightHand;

    void Start() {
        _bodyRigidbody.mass = _bodyWeight;
        _bottomRigidbody.mass = _bottomWeight;
        _leftShoulder.MagnetStrength = _shoulderStrength;
        _rightShoulder.MagnetStrength = _shoulderStrength;
        _leftHand.Initialize(_armLength);
        _rightHand.Initialize(_armLength);

    }
}
