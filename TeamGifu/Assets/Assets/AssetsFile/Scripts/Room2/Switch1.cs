using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour {
    #region private
    private Rigidbody rigibody;
    [SerializeField]
    private Light light1;   // 消すライト
    [SerializeField]
    private Light light2;   // 点けるライト      
    [SerializeField]
    private GameObject light_obj;
    private GameObject empty;
    private Light_Controller controller_script;
    private int cnt;
    private bool active;
    #endregion

    #region public
    public GameObject obj1;  // スイッチ１
    public GameObject obj2;  // スイッチ２     
    public int order;
    #endregion

    RaycastHit hit;

    private void Start()
    {
        rigibody = gameObject.GetComponent<Rigidbody>();

        light1 = light1.GetComponent<Light>();
        light2 = light2.GetComponent<Light>();

        empty = GameObject.Find("Light_Switch");
        controller_script = empty.GetComponent<Light_Controller>();

        active = false;
        
        cnt = controller_script.GetCount();
        
    }
    GameObject g_obj;
    private void Update()
    {
        if(cnt==8)
        {
            Debug.Log("Clear");
        }
    }

    // スイッチに反応した時のアクション
    public void Action1()
    {
        cnt = controller_script.GetCount();
        if (cnt == order)
        {
            active = controller_script.NowActive(active);
            if (active)
            {
                light1.intensity = 0.0f;
                light2.intensity = 2.5f;
                light2.color = controller_script.GetColor();
                Debug.Log(light2.color);
                obj1.SetActive(false);
                obj2.SetActive(true);
                controller_script.CountUp();
                active = controller_script.NowActive(active);
            }
        }
    }
}
