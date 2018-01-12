using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Menu : Global {
    //メニューシーン処理

    //gamestate変数
    [SerializeField]
    private GameState gamestate;

    //ボタンの登録
    [SerializeField]
    private Button[] menubutton = new Button[menubutton_total];

    //メニューオブジェクト
    [SerializeField]
    private GameObject menuobjects;

    //ゲームの初めのメニュー関係の処理
    internal void MenuFirstStart()
    {
        //ボタンの登録
        for (int buttonnumber = zero_value ; buttonnumber < menubutton.Length; buttonnumber++)
        {
            int i = buttonnumber+1;
            UnityAction onClickAction = () => MenuButtonPush(i);
            menubutton[buttonnumber].onClick.AddListener(onClickAction);
        }
    }
    //シーン初めのメニュー関係の処理
    internal void MenuSecondStart()
    {
        //メニューオブジェクトの表示
        menuobjects.SetActive(true);
    }

    //メニュー繰り返し処理
    internal void MenuUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("メニューシーン");
        }
        
    }

    //ボタンの処理
    void MenuButtonPush(int buttonnum)
    {

        //その他は準備中なので処理しない
        if (buttonnum != state_other)
        {
            //メニューオブジェクトを非表示
            menuobjects.SetActive(false);
            //番号によってシーン遷移
            gamestate.GameStateNumber = buttonnum;
        }
        


    }
}
