using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screencollider : Global {
    [SerializeField]
    private Main main;
    [SerializeField]
    private PolygonCollider2D before;
    [SerializeField]
    private PolygonCollider2D after;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (main.menuanim_sw)
        {
            before.enabled = false;
            after.enabled = true;
        }
        else
        {
            before.enabled = true;
            after.enabled = false;
        }
    }
}
