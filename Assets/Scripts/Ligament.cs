using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligament : MonoBehaviour
{
    [SerializeField] private GameObject _hand;
    private Rigidbody2D _connectionTwoRb;

    // Update is called once per frame
    void FixedUpdate()
    {
        OrientHand();
    }

    private void OrientHand() {
        _hand.transform.rotation = transform.rotation;
    }
}
