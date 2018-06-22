using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UpElevator : MonoBehaviour {
    [SerializeField, Header("目標の高さ")]
    private float PosY;
    private bool isStart;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isStart!=false) return;
            transform.DOLocalMove(new Vector3(-119.33f, PosY, -3.1101f), 6f).SetEase(Ease.Linear);
            isStart = true;
        }
    }

}
