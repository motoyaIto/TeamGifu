using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UpElevator : MonoBehaviour {
    [SerializeField, Header("目標の高さ")]
    private float PosY;

    private bool ride;


    private void Start()
    {
        ride = false;
    }
    private void Update()
    {
        if (ride)
        {
            transform.DOLocalMove(new Vector3(-119.33f, PosY, -3.1101f), 5f).SetEase(Ease.Linear);

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
