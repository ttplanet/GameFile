using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : Global {
    [SerializeField]
    private Main main;
    [SerializeField]
    private Menu menu;
    [SerializeField]
    private Load load;



    private int nowgamestatenumber = zero_value;
    internal int GameStateNumber
    {
        get { return nowgamestatenumber; }
        set { nowgamestatenumber = value; }
    }

    private int beforegamestatenumber;

    // Use this for initialization
    void Start ()
    {
        beforegamestatenumber = GameStateNumber;
        menu.MenuFirstStart();
        main.MainFirstStart();
        load.LoadFirstStart();

	}
	
	// Update is called once per frame
	void Update () {
        //シーン遷移時の処理
        if (GameStateNumber != beforegamestatenumber)
        {
            //それぞれシーンの開始処理を行う
            switch (GameStateNumber)
            {
                case state_menu:
                    menu.MenuSecondStart();
                    break;
                case state_main:
                    main.MainSecondStart();
                    break;
                case state_load:
                    load.LoadSecondStart();
                    break;
                case state_other:
                    break;

            }
            beforegamestatenumber = GameStateNumber;
        }

        //ゲームの一連のループ
        switch (GameStateNumber)
        {
            case state_menu:
                menu.MenuUpdate();
                break;
            case state_main:
                main.MainUpdate();
                break;
            case state_load:
                load.LoadUpdate();
                break;
            case state_other:
                break;

        }
	}
}
