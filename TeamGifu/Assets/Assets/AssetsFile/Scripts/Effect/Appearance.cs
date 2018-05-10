using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {
    Renderer matrial;
    public   bool StartF = false;
    float t;
    [SerializeField]
    private Material ChangeMaterial;

    private void OnEnable()
    {
    }
    private void Awake()
    {
        matrial = GetComponent<Renderer>();
        GetComponent<Collider>().enabled = false;

        t = 0;
    }
    // Use this for initialization
    void Start () {
        matrial.sharedMaterial.SetFloat("_Height", 0.0f);


    }

    // Update is called once per frame
    void Update () {

        if (StartF==true)
        {
            t += 0.01f;
            matrial.sharedMaterial.SetFloat("_Height", t);
                Debug.Log("OK");
            
        }
        
        if (matrial.sharedMaterial.GetFloat("_Height")>1.7f)
        {
            StartF = false;
            GetComponent<Collider>().enabled = true;
            t = 0;
         //   this.matrial.material = ChangeMaterial;
         //   Debug.Break();
        }

    }
}
