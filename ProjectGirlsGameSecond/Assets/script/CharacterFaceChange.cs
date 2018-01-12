using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

public class CharacterFaceChange : MonoBehaviour {

    private CubismModel _model;


    private float _t=-1;
    private bool sw;

	// Use this for initialization
	private void Start () {
        _model = this.FindCubismModel();
        sw = false;


	}
    private void LateUpdate()
    {
        //通常時の動作
        if (_t > -0.3f)
        {
            sw = true;
        }
        else if(_t< -0.8f)
        {
            sw = false; 
        }
        if (sw)
        {
            _t -= (Time.deltaTime * 0.5f);
        }
        else
        {
            _t += (Time.deltaTime * 0.5f);
        }
   
        var value = _t;

        var parameter = _model.Parameters[7];

        parameter.Value = value;
    }
    //表情のアップデート



}
