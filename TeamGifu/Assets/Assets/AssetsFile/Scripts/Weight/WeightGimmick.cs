using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WeightGimmick : MonoBehaviour {
    private int Sum = 0;
    private int offset = 10;
    public GameObject[] obj = new GameObject[4];
    [SerializeField,Header("Weight1の重さ")]
    private int G_Obj1 = 5;
    [SerializeField, Header("Weight2の重さ")]
    private int G_Obj2 = 10;
    [SerializeField, Header("Weight3の重さ")]
    private int G_Obj3 = 15;
    [SerializeField, Header("Weight4の重さ")]
    private int G_Obj4 = 20;

    [SerializeField, Header("leftの重さ条件")]
    private int LeftWeight = 30;
    [SerializeField, Header("Rightの重さ条件")]
    private int RightWeight = 51;
    [SerializeField, Header("Frontの下限値")]
    private int lowerWeght = 31;
    [SerializeField, Header("Frontの上限値")]
    private int upperWeight = 50;
    public room3_front front;
    public room3_left left;
    public room3_right right;
    const string clone = "(Clone)";
    enum WEIGHT
    {
        FIVE,
        TEN,
        FIFTEEN,
        TWENTY
    }
    public int SumState
    {
        get
        {
            return Sum;
        }
    }

    // Use this for initialization
    void Start () {

        //int count = 0;
        //foreach (Transform child in transform)bj
        //{
        //    //child is your child transform

        //    Debug.Log("Child[" + count + "]:" + child.name);
        //    count++;

        //}
    }
	
	// Update is called once per frame
	void Update () {
        if(LeftWeight<=Sum)
        {
            left.LockFlagState = true;
            Debug.Log("left");
        }
        else if (lowerWeght <= Sum && Sum <= upperWeight)
        {
            front.LockFlagState = true ;
            Debug.Log("front");

        }
        else if (RightWeight <= Sum )
        {
            right.LockFlagState = true;
            Debug.Log("right");

        }
        else
        {
            left.LockFlagState = false;
            right.LockFlagState = false;
            front.LockFlagState = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
 
            if (collision.gameObject.name== obj[(int)WEIGHT.FIVE].name+clone)
            {
                Sum += G_Obj1;
                // Debug.Log("5");
            }
            if (collision.gameObject.name == obj[(int)WEIGHT.TEN].name + clone)
            {
                Sum += G_Obj2;
                // Debug.Log("10");
            }
            if (collision.gameObject.name == obj[(int)WEIGHT.FIFTEEN].name + clone)
            {
                Sum += G_Obj3;
                //Debug.Log("15");
            }
            if (collision.gameObject.name == obj[(int)WEIGHT.TWENTY].name + clone)
            {
                Sum += G_Obj3;
                //Debug.Log("20");
            }
    }
}
