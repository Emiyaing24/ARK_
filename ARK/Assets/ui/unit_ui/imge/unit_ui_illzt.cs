using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
//单个角色的ui 初始化

public class unit_ui_illzt : MonoBehaviour
{
    public Canvas canvas;
    public GameObject unit_detailed;
    public unit_initialize unit_Initialize;
    GameObject Unit_detailed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 loc = gameObject.transform.position;
        canvas.transform.position =new Vector3 (loc.x, loc.y + 2.5f, loc.z);
        RectTransform rectTransform = canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public bool select_bool = false;
   public void select()
    {
        print(select_bool);
        if(select_bool == false)
        {
            select_bool = true;

        }
        else
        {
            select_bool = false;
        }
    }
}
