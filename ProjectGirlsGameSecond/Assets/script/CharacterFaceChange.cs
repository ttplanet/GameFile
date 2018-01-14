using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class CharacterFaceChange : Global {

    private CubismModel _model;

    //番号によって表情変更
    public int face_number=default_face;

    #region 使うパラメーター
    //横揺れ
    private CubismParameter ParameterID_rolling;
    [SerializeField]
    private string parameter_str_rolling;
    //目の向き
    private CubismParameter ParameterID_orientation;
    [SerializeField]
    private string parameter_str_orientation;
    //左目
    private CubismParameter ParameterID_lefteye;
    [SerializeField]
    private string parameter_str_lefteye;
    //右目
    private CubismParameter ParameterID_righteye;
    [SerializeField]
    private string parameter_str_righteye;
    //左眉
    private CubismParameter ParameterID_lefteyebrow;
    [SerializeField]
    private string parameter_str_lefteyebrow;
    //右眉
    private CubismParameter ParameterID_righteyebrow;
    [SerializeField]
    private string parameter_str_righteyebrow;
    //口の空き具合１
    private CubismParameter ParameterID_mouse_x;
    [SerializeField]
    private string parameter_str_mouseX;
    //口の空き具合２
    private CubismParameter ParameterID_mouse_y;
    [SerializeField]
    private string parameter_str_mouseY;

    #endregion

    //タップされた時の判定スイッチ
    private bool tapmove_sw;
    private bool add_sw;
    private float tapmove_t = zero_value;
    //デフォルト時の動作関係
    private float default_t=-0.3f;
    private bool defaultmove_sw;
    private bool wait_sw;

	// Use this for initialization
	private void Start () {
        _model = this.FindCubismModel();

        #region パラメーター登録
        //横揺れ
        ParameterID_rolling     = _model.Parameters.FindById(parameter_str_rolling);
        //目の向き
        ParameterID_orientation = _model.Parameters.FindById(parameter_str_orientation);
        //左目
        ParameterID_lefteye     = _model.Parameters.FindById(parameter_str_lefteye);
        //右目
        ParameterID_righteye    = _model.Parameters.FindById(parameter_str_righteye);
        //左眉
        ParameterID_lefteyebrow = _model.Parameters.FindById(parameter_str_lefteyebrow);
        //右眉
        ParameterID_righteyebrow    = _model.Parameters.FindById(parameter_str_righteyebrow);
        //口の空き具合１
        ParameterID_mouse_x     = _model.Parameters.FindById(parameter_str_mouseX);
        //口の空き具合２
        ParameterID_mouse_y     = _model.Parameters.FindById(parameter_str_mouseY);
        #endregion

        tapmove_sw = false;
        add_sw = false;
        defaultmove_sw = false;
        wait_sw = false;
        
        DefaultFace();

	}
    //アップデート（繰り返し）処置
    private void LateUpdate()
    {
        //表情のアップデート
        switch (face_number)
        {
            case default_face:
                DefaultFace();
                break;
            case angry_face:
                AngryFace();
                break;
            case smile_face:
                SmileFace();
                break;
            case sick_face:
                SickFace();
                break;
            default:
                break;

        }

  
        //タップされた時の動作
        if (Input.GetMouseButtonDown(v_left))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                RaycastHit2D hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
                if (hitObject)
                {
                    //タップされた時の動作スイッチがオンになる
                    tapmove_t = default_t;
                    tapmove_sw = true;
                    Debug.Log("hit object is " + hitObject.collider.gameObject.name);
                    
                    
                }
            }
            

        }

        //タップ時の動作をするかどうか
        if (tapmove_sw)
        {
            #region タップされた時の動作
            if (tapmove_t <= -0.3f && !add_sw)
            {

                default_t = tapmove_t;
                tapmove_sw = false;
            }
            if (tapmove_t <= -0.3f)
            {
                add_sw = true;
                
            }
            else if (tapmove_t>1f)
            {
                add_sw = false;
            }

            if (add_sw)
            {
                tapmove_t += (Time.deltaTime * 3f);
            }
            else
            {
                tapmove_t -= (Time.deltaTime * 3f);
            }
            //横揺れ
            ParameterID_rolling.Value = tapmove_t;
            //目の向き
            ParameterID_orientation.Value = -tapmove_t;

            #endregion
        }
        else
        {
            #region 通常時の動作(タップされていないとき)
 

            if (!wait_sw)
            {
                if (defaultmove_sw)
                {
                    default_t -= (Time.deltaTime * 0.1f);
                }
                else
                {
                    default_t += (Time.deltaTime * 0.1f);
                }
            }
            if (default_t > -0.3f)
            {
                wait_sw = true;
                StartCoroutine("wait");
                defaultmove_sw = true;
            }
            else if (default_t < -0.8f)
            {
                wait_sw = true;
                StartCoroutine("wait");
                defaultmove_sw = false;
            }

            

            
            //横揺れ
            ParameterID_rolling.Value = default_t;
            //目の向き
            ParameterID_orientation.Value = -default_t;
            #endregion
        }
                        
    }
    
    //通常の表情
    void DefaultFace()
    {
        //目の開き具合
        ParameterID_lefteye.Value = 1;
        ParameterID_righteye.Value = 1;
        //眉毛の下がり具合       
        ParameterID_lefteyebrow.Value = 0;
        ParameterID_righteyebrow.Value = 0;
        //口の空き具合
        ParameterID_mouse_x.Value = 0;
        ParameterID_mouse_y.Value = 0.5f;



    }
    //怖い表情
    void AngryFace()
    {
        //目の開き具合
        ParameterID_lefteye.Value = 0.5f;
        ParameterID_righteye.Value = 0.5f;
        //眉毛の下がり具合
        ParameterID_lefteyebrow.Value = -1;
        ParameterID_righteyebrow.Value = -1;
        //口の空き具合
        ParameterID_mouse_x.Value = -1;
        ParameterID_mouse_y.Value = 1;

    }
    //笑顔
    void SmileFace()
    {
        //目の開き具合
        _model.Parameters[0].Value = 1;
        _model.Parameters[1].Value = 1;
        //眉毛の下がり具合
        _model.Parameters[3].Value = 1;
        _model.Parameters[4].Value = 1;
        //口の空き具合
        _model.Parameters[5].Value = 1;
        ParameterID_mouse_y.Value = 1;
    }
    //鬱顔
    void SickFace()
    {
        //目の開き具合
        _model.Parameters[0].Value = 0;
        _model.Parameters[1].Value = 0;
        //眉毛の下がり具合
        _model.Parameters[3].Value = 1;
        _model.Parameters[4].Value = 1;
        //口の空き具合
        _model.Parameters[5].Value = 1;
        ParameterID_mouse_y.Value = 1;
    }
    //一定間隔
    IEnumerator wait()
    {

        yield return new WaitForSeconds(0.2f);

        wait_sw = false;
    }

}
