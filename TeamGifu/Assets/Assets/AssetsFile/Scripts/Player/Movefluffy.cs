using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movefluffy : MonoBehaviour {
    [SerializeField,Range(0,10)]
    private int frameCnt = 0; // フレームカウント
    [SerializeField, Range(0.0f, 5.0f)]
    private float amplitude = 0.02f; // 振幅
    [SerializeField]
    public float value = .2f;

    void Update()
    {
        frameCnt += 1;
        if (600 <= frameCnt)
        {
            frameCnt = 0;
        }
        if (0 == frameCnt % 2)
        {
            // 上下に振動させる（ふわふわを表現）
            float posYSin = Mathf.Sin(2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
            iTween.MoveAdd(gameObject, new Vector3(0, amplitude * posYSin, 0), 0.0f);
            transform.position = new Vector3(transform.position.x
             , +Mathf.Sin(Time.frameCount * value), transform.position.z);
        }
    }

    //private void FixedUpdate()
    //{
    //    frameCnt += 1;
    //    if (10000 <= frameCnt)
    //    {
    //        frameCnt = 0;
    //    }
    //    if (0 == frameCnt % 2)
    //    {
    //        // 上下に振動させる（ふわふわを表現）
    //        float posYSin = Mathf.Sin(2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
    //        iTween.MoveAdd(gameObject, new Vector3(0, amplitude * posYSin, 0), 0.0f);
    //    }
    //}
}
