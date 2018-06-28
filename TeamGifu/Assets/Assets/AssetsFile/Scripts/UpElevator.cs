using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UpElevator : MonoBehaviour {
    [SerializeField, Header("目標の高さ")]
    private float PosY;
    private bool isStart;
    bool isSound;
    float count = 0.0f;
    private void Update()
    {
        if(isSound)
        {
            count += -0.1f;
            if(count<6.0f)
            {

            }

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            if (isStart!=false) return;
            SoundManager.PlaySe("ElevetorSe");
            transform.DOLocalMove(new Vector3(-119.33f, PosY, -3.1101f), 6f).SetEase(Ease.Linear).OnComplete(() =>
            {
            });

            isStart = true;
        }
    }
    void End()
    {

    }

}
