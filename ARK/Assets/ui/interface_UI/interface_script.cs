using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//旨在对回合界面作出响应

public class interface_script : MonoBehaviour
{
    public static TextMeshProUGUI Action_Text;
    // Start is called before the first frame update
    public TextMeshProUGUI Action_Text_yy;
    public unit_detailed_sc[] unit_Detailed_Scs = new unit_detailed_sc[3];
    public GameObject[] unit_list;
    public level_conller level_Conller;
   
    private void Start()
    {
        float x = Screen.width / 2 - 1000;
        float y = Screen.height / 2 *-1;
        print(x);
        unit_list = level_Conller.play_unit_list;
        Action_Text = Action_Text_yy;
        for (int i = 0; i < unit_Detailed_Scs.Length; i++) {
            unit_list[i].GetComponent<unit_initialize>().unit_Detailed_Sc = unit_Detailed_Scs[i];
            unit_list[i].GetComponent<unit_initialize>().Status_bar();
            unit_Detailed_Scs[i].image_bc.rectTransform.localPosition = new UnityEngine.Vector3(x + 450*i ,y + 100,0);
        }
    }
    public static void Action_Resources_ch(float Action_Resources)
    {
        string arc = Action_Resources.ToString();
        Action_Text.text = arc;
        //回合资源显示
    }
    public void unit_detailed_select()
    {

    }
}
