using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ray : MonoBehaviour {
    #region variable
    public static bool flag;
    [SerializeField]
    private Image CursorImage;
    private GameObject HitObj;//ヒットしたオブジェクト
    [SerializeField]
    private new Camera camera;
    Ray _ray;
    private bool rayFlag;

    [SerializeField]
   private string[] objName; 
    #endregion

    #region Event

    // Use this for initialization
    void Start()
    {
        CursorImage.enabled = false;
        rayFlag = false;
        objName = new string[5];
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        CursorImage.transform.position = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            CursorImage.enabled = true;
            rayFlag = true;

        }
        else
        {
            CursorImage.enabled = false;
            rayFlag = false;

        }
        if (rayFlag)
        {
            Debug.Log("生成");
            _ray = camera.ScreenPointToRay(Input.mousePosition);
        }
        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit))
        {
            if (hit.collider.tag == "cube")
            {
                for (int i = 0; i < 5; i ++)
                {
                    if (objName[i] == null)
                    {
                        if (objName[i]!=hit.collider.name)
                        {
                            objName[i] = hit.collider.gameObject.name;
                            break;
                        }

                      
                    }
                    else if(objName[i] == hit.collider.name) { break; }
                }
            }
   
        }
    }


    #endregion

}
