using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Switch : MonoBehaviour {
    #region private
    private Rigidbody rigibody;
    private GameObject obj;
    private Light_Controller controller;
    #endregion

    public void Awake()
    {
        rigibody = gameObject.GetComponent<Rigidbody>();
        obj = GameObject.Find("Light_Switch");
        controller = obj.GetComponent<Light_Controller>();
    }

    public void OnUserAction()
    {
        // リセット
        controller.State_Reset();
    }

}
