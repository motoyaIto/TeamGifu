using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpElevator : MonoBehaviour {
    [SerializeField, Header("目標の高さ")]
    private float Y;

    private bool ride;

    private Rigidbody rg;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        ride = false;
    }

    private void FixedUpdate()
    {
        if (ride)
        {
            if (rg.transform.position.y <= Y)
            {
                //Debug.Log("入ったよ");
                rg.MovePosition(transform.position + transform.up * Time.deltaTime);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ride = true;
        }
    }
}
