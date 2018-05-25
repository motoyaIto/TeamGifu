using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Vector3 ResetPos = new Vector3(-8.5f, 35f, 0);
        other.transform.position = ResetPos;
    }
}
