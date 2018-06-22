using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {
    Renderer matrial;
    public  bool StartF = false;
    float t;


    private void OnEnable()
    {
    }
    private void Awake()
    {
        matrial = GetComponent<Renderer>();
<<<<<<< HEAD
        StartF = true;
        //GetComponent<Collider>().enabled = false;

=======
        GetComponent<Collider>().enabled = false;
        StartF = true;
>>>>>>> master
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
        
        if (matrial.sharedMaterial.GetFloat("_Height")>=5.0f)
        {
            StartF = false;
          
            //t = 0;

         //   Debug.Break();
        }
        if(t>1.0f)
        {
            GetComponent<Collider>().enabled = true;
        }

    }
}
