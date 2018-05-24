using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Open_to_the_left : MonoBehaviour {

    private bool doorSwitch = false;
    [SerializeField,Header("扉の初期座標")]
    private Vector3 Movepos;
    [SerializeField,Header("扉移動後の座標")]
    private Vector3 Returnpos;
    [SerializeField,Header("移動させる時間"),Range(0,2.0f)]
    private  float TitmeNum=0.0f;
    [SerializeField, Header("扉の移動量")]
    private Vector3 Distance;

    private AudioSource As;
    [HideInInspector]
    public AudioClip Ac;

    private bool CloseFlag = false;


    // Use this for initialization
    void Start () {
        As = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (doorSwitch == true)
        {
            transform.DOLocalMove(new Vector3(Movepos.x , Movepos.y, Movepos.z)+Distance, TitmeNum);
            As.PlayOneShot(Ac);
            CloseFlag = true;
        }
        else if (!doorSwitch && CloseFlag == true)
        {
            transform.DOLocalMove(new Vector3(Returnpos.x , Movepos.y, Movepos.z)-Distance, 1.5f);
            As.PlayOneShot(Ac);
        }
    }

    public void SetDoorSwitch(bool state)
    {
        doorSwitch = state;
    }
}
