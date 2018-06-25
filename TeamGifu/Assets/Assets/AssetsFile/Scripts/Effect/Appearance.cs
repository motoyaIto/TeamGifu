using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {
    Renderer matrial;
    public  bool StartF = false;//エフェクト再生用のフラグ
    float t;//時間
    public Material Changematerial;
    private Material oldMaterial;

    public  float StartHeight = 0;
    public float StartHeightState
    {
        set
        {
            StartHeight = value;
        }
    }
    public float MaxHeightState
    {
        set
        {
            maxHeight = value;
        }
    }

    public float maxHeight = 1;



    private void OnEnable()
    {
    }
    private void Awake()
    {
        matrial = GetComponent<Renderer>();
        StartF = true;
        matrial.sharedMaterial.SetFloat("_Height", StartHeight);
        t = StartHeight;//
        oldMaterial = gameObject.GetComponent<Renderer>().material;
        if(gameObject.name== "Sphere(Clone)")
        {
            GetComponent<Collider>().enabled = false;

        }

    }
    // Use this for initialization
    void Start () {
        //見えない状態に初期化

    }

    // Update is called once per frame
    void Update () {
        
        if (StartF==true)
        {
            t += 0.05f;
            matrial.sharedMaterial.SetFloat("_Height", t);
            
        }
        if(matrial.sharedMaterial.name==oldMaterial.name)
        {
            if (matrial.sharedMaterial.GetFloat("_Height") >= maxHeight)
            {

                GetComponent<Collider>().enabled = true;

                this.matrial.material = Changematerial;
                StartF = false;

            }
        }




    }
}
