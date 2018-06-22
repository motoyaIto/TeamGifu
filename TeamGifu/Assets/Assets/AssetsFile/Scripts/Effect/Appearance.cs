using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {
    Renderer matrial;
    public  bool StartF = false;//エフェクト再生用のフラグ
    float t;//時間
    public Material Changematerial;

    public float maxHeight = 1;


    private void OnEnable()
    {
    }
    private void Awake()
    {
        matrial = GetComponent<Renderer>();
        StartF = true;
        t = 0;//
    }
    // Use this for initialization
    void Start () {
        //見えない状態に初期化
        matrial.sharedMaterial.SetFloat("_Height", 0.0f);
    }

    // Update is called once per frame
    void Update () {
        
        if (StartF==true)
        {
            t += 0.01f;
            matrial.sharedMaterial.SetFloat("_Height", t);
            
        }

        if (matrial.sharedMaterial.GetFloat("_Height") >= maxHeight)
        {
            StartF = false;
            this.matrial.material = Changematerial;
            Debug.Log("SetMaterial");


        }



    }
}
