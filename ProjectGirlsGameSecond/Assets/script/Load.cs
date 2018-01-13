using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : Global {
    [SerializeField]
    private GameObject loadobjects;
    //ゲーム開始時ロード関係最初の処理
    internal void LoadFirstStart()
    {
        loadobjects.SetActive(false);
    }

    //ロードシーン開始処理
    internal void LoadSecondStart()
    {
        loadobjects.SetActive(true);
    }

    //ロードシーン繰り返し処理
    internal void LoadUpdate()
    {

    }
}
