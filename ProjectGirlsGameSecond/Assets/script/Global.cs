using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
    //配列の一番最初,初期値
    protected const int zero_value = 0;
    //マウスクリックの左側、タップ
    protected const int v_left = 0;

    //ゲームのシーンを通して使われる定数や変数を定義する場所

    protected const int state_menu = 0;
    protected const int state_main = 1;
    protected const int state_load = 2;
    protected const int state_other = 3;

    #region メニュー関係
    //メニューボタンの数
    protected const int menubutton_total = 3;
    #endregion

    #region メイン関係
    //選択肢ボタンの数
    protected const int selectbutton_total = 3;
    #endregion

    #region ストーリー関係
    //ストーリーテキストの文字列

    #endregion


    #region キャラクター表情関係
    //デフォルト
    protected const int default_face = 0;
    protected const int angry_face = 1;
    protected const int smile_face = 2;
    protected const int sick_face = 3;
    #endregion

}
