using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Room6_UpFloor : MonoBehaviour {
    [SerializeField, Header("目標の高さ")]
    private Vector3 PosY;

    private bool ride;


    private void Start()
    {
        ride = false;
    }
    private void Update()
    {
        if (ride)
        {
            transform.DOLocalMove(PosY, 5f);

        }
    }

    public void GetRideFlag(bool rideFlag)
    {
        ride = rideFlag;
    }
}
