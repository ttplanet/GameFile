using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : Global{
    //メインシーンの処理
    [SerializeField]
    private GameObject mainobjects;
    //入力側テキスト関係
    private TextAsset storytext;
    private string[] storytext_str;
    //出力側テキスト関係
    [SerializeField]
    private Text OutText;
    //読み進め用のカウンター
    private int read_counter=zero_value;

    //選択肢出力関係
    [SerializeField]
    private GameObject[] selectbuttons_obj = new GameObject[selectbutton_total];
    private Button[] selectbuttons = new Button[selectbutton_total];

    //メニューボタンのアニメーション処理
    [SerializeField]
    private Button menubutton;
    [SerializeField]
    private Animator menubutton_animator;
    internal bool menuanim_sw;

    //ゲーム開始時メイン関係処理
    internal void MainFirstStart()
    {
        //選択ボタン最初の処理
        for(int selectbuttonnumber = zero_value; selectbuttonnumber < selectbutton_total; selectbuttonnumber++)
        {
            //選択ボタンゲームオブジェクトから選択ボタンゲット。
            selectbuttons[selectbuttonnumber] = selectbuttons_obj[selectbuttonnumber].GetComponent<Button>();
            //選択ボタンの非表示
            selectbuttons_obj[selectbuttonnumber].SetActive(false);
        }
        //メニューボタン処理登録作業
        menubutton.onClick.AddListener(MenuButton);
        menuanim_sw = false;
        //メインオブジェクト群非表示
        mainobjects.SetActive(false);
    }
    //メインシーン最初の処理
    internal void MainSecondStart()
    {
        //セーブなどに応じてストーリーテキストの読み込み
        storytext = Resources.Load<TextAsset>("story/story0");
        //@ごとに文章を区切る
        storytext_str = storytext.text.Split('@');
        OutText.text = storytext_str[read_counter];

        mainobjects.SetActive(true);
    }
    //メインシーン繰り返し処理
    internal void MainUpdate()
    {

        if (Input.GetMouseButtonDown(v_left))
        {
            //rayがテキストボックスだったら
            if (storytext_str.Length-1 > read_counter)
            {
                read_counter++;
            }
            
            //ストーリー読み進め

        }
        OutText.text = storytext_str[read_counter];
    }

    //メニューボタンのアニメーション処理
    void MenuButton()
    {
        //スイッチの切り替え
        if (menuanim_sw)
        {
            menuanim_sw = false;
        }
        else
        {
            menuanim_sw = true;
        }
        menubutton_animator.SetBool("menuanim_sw",menuanim_sw);
    }


}
