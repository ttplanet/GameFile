using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : Global{
    //メインシーンの処理
    [SerializeField]
    private GameObject mainobjects;

    private TextAsset storytext;
    //ゲーム開始時メイン関係処理
    internal void MainFirstStart()
    {
        mainobjects.SetActive(false);
    }
    //メインシーン最初の処理
    internal void MainSecondStart()
    {
        //セーブなどに応じてストーリーテキストの読み込み
        storytext = Resources.Load<TextAsset>("");

        mainobjects.SetActive(true);
    }
    //メインシーン繰り返し処理
    internal void MainUpdate()
    {

        if (Input.GetMouseButtonDown(v_left))
        {
            Debug.Log("メインシーン");
        }
    }


}
