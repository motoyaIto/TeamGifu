using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6_WeightGimic : MonoBehaviour {

    private int Sum = 0;
    private int offset = 10;
    public GameObject[] obj = new GameObject[4];
    [SerializeField, Header("Weight1の重さ")]
    private int G_Obj1 = 5;
    [SerializeField, Header("Weight2の重さ")]
    private int G_Obj2 = 10;
    [SerializeField, Header("Weight3の重さ")]
    private int G_Obj3 = 15;
    [SerializeField, Header("Weight4の重さ")]
    private int G_Obj4 = 20;

    private int LeftWeight = 60;//レフトのクリア条件
    private int RightWeight = 70;//ライトのクリア条件
    [SerializeField]
    private Light[] lightobj;

    const string clone = "(Clone)";
    [SerializeField]
    private string[] objname;
    [SerializeField]
    List<GameObject> ListObj = new List<GameObject>();
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
    void Start()
    {

        objname = new string[4];
        for (int i = 0; i < obj.Length; i++)
        {
            objname[i] = obj[i].name;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //レフトの重さが完全一致なら
        if (LeftWeight == Sum)
        {
            lightobj[0].color = Color.green;
            lightobj[1].color = Color.green;
            lightobj[2].color = Color.green;
        }
        //ライトの重さが完全一致なら
       else  if (RightWeight == Sum)
        {
            lightobj[3].color = Color.blue;
            lightobj[4].color = Color.green;
            lightobj[5].color = Color.red;

        }
        else
        {
            for(int i=0;i<5;i++)
            {
                lightobj[i].color = Color.white;
            }

        }


        Sum = 0;
        for (int i = 0; i < ListObj.Count; i++)
        {
            GameObject obj = ListObj[i];

            if (obj != null)
            {
                Sum += ReturnSum(obj);
            }
            else
            {
                ListObj.RemoveAt(i);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ListObj.Add(other.gameObject);
        Sum += ReturnSum(other.gameObject);
    }
    int ReturnSum(GameObject other)
    {
        int returnnum = 0;

        if (other.name == obj[(int)WEIGHT.FIVE].name)
        {
            returnnum += G_Obj1;
        }
        if (other.name == obj[(int)WEIGHT.TEN].name)
        {
            returnnum += G_Obj2;
        }
        if (other.name == obj[(int)WEIGHT.FIFTEEN].name)
        {
            returnnum += G_Obj3;
        }
        if (other.name == obj[(int)WEIGHT.TWENTY].name)
        {
            returnnum += G_Obj4;
        }
        return returnnum;
    }


    bool desFalg = false;
    public void Destroy()
    {
        desFalg = true;

    }
}
