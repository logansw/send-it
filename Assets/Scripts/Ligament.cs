using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligament : MonoBehaviour
{
    [SerializeField] private Transform _connectionOne;
    [SerializeField] private Transform _connectionTwo;
    [SerializeField] private GameObject _hand;
    private Rigidbody2D _connectionTwoRb;

    private void Start() {
        _connectionTwoRb = _connectionTwo.gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        OrientLigament();
    }

    private void OrientLigament() {
        Vector3 positionOne = _connectionOne.gameObject.transform.position;
        Vector3 positionTwo = _connectionTwo.gameObject.transform.position + new Vector3(_connectionTwoRb.velocity.x * Time.fixedDeltaTime, _connectionTwoRb.velocity.y * Time.fixedDeltaTime, 0);
        float distance = Vector3.Distance(positionOne, positionTwo);

        Vector2 targ = new Vector2(positionTwo.x - positionOne.x, positionTwo.y - positionOne.y);
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        transform.localScale = new Vector3(distance, 1, 1);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.position = positionOne;

        _hand.transform.rotation = transform.rotation;
    }
}
