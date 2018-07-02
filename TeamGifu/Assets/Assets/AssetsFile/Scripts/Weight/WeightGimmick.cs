using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WeightGimmick : MonoBehaviour {
    private int Sum = 0;//合計値
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
    //扉オブジェクト
    public room3_front front;
    const string clone = "(Clone)";
    [SerializeField]
    string[] objname;
    [SerializeField]
    List<GameObject> ListObj = new List<GameObject>();//重さオブジェクトを保存するリスト
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
 
        objname = new string[4];
        for (int i = 0; i < obj.Length; i++)
        {
            objname[i] = obj[i].name;
        }

    }

    // Update is called once per frame
    void Update ()
    {
        //重さの再計算
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

        //ListObj.Remove(obj);
        //ListObj.RemoveAll( c => c ==null ); // ラムダ式・デリゲート
        //ListObj = ListObj.Where(c => c == null).ToList(); // Where  - 指定された条件を満たすかどうか

        //真ん中の扉の条件
        if (lowerWeght <= Sum && Sum <= upperWeight)
        {
            front.LockFlagState = true ;

        }
        else
        {
            front.LockFlagState = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ListObj.Add(other.gameObject);
        Sum += ReturnSum(other.gameObject);


    }
 
    int ReturnSum(GameObject other)
    {
        int returnnum=0;
        
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
   
}
