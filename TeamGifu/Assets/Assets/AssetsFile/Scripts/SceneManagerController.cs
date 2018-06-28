using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerController : MonoBehaviour
{
    private AsyncOperation ope = null;//シーンを格納

    //各シーン名
    public enum SceneName
    {
        TITLE,
        PLAY,
        GOAL,
    };

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Confined;
       
        //次のシーンを読み込む
        if (SceneManager.GetActiveScene().buildIndex < (int)SceneName.GOAL)
        {
            ope = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            ope = SceneManager.LoadSceneAsync(0);
        }

        //自動再生を無効にする
        ope.allowSceneActivation = false;
    }

    /// <summary>
    /// シーン切替
    /// </summary>
    public void ChangeCene()
    {
        //再生する
        ope.allowSceneActivation = true;
        
    }


}
