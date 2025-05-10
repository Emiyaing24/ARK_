using Spine.Unity.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//测试角色动画
public class operate_player : MonoBehaviour
{
    public Animator unit_animator;
    public bool is_select = false;
    public GameObject[] unit_list = new GameObject[2];
    public GameObject unit;
    public GameObject select_jt;
    public level_conller level_Conller;
    GameObject jt;
    level_conller.operate operate = new level_conller.operate();
    public void single_click_select()
    {   
        //基础选中----》弹出详情界面
        if(is_select is false)
        {
            unit_animator.SetBool("select", true);
            is_select = true;
            if (unit != unit_list[0])
            {
                if (unit_list[0] == null)
                {
                    unit_list[0] = unit;
                }
                else
                {
                    unit_list[1] = unit;
                    operate.transposition(unit_list[1], unit_list[0]);
                    unit_list[0].GetComponent<unit_ui_illzt>().select();
                    clean_selsct();
                }
            }
            else
            {
            }
        }
    }
    public void substitution()
    {
        //换人选中把要交换的unit提交到关卡运行脚本level——conller
        //鼠标移动时开启射线检测把碰到的unit加入list
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
            if (hit.collider.tag  == "unit")
                {
                unit = hit.collider.gameObject;
                if (unit != unit_list[0])//选中的第二个目标不为自己
                    {
                   
                        if(level_conller.Action_Resources >= 10)
                    {
                        unit_list[1] = hit.collider.gameObject;
                        operate.transposition(unit_list[1], unit_list[0]);
                        clean_selsct();
                        is_select = false;//触发换手动画清空数组
                    }
                    else
                    {
                        level_Conller.EndPlayerTurn();
                    }
                }
                else
                {
                    unit_list[0].GetComponent<unit_ui_illzt>().select_bool = true;
                    unit_list[0].GetComponent<unit_ui_illzt>().select();
                }
                }else if (hit.collider.tag == "unit_enemy" && level_conller.Action_Resources >= 10)
                {
                unit = hit.collider.gameObject;
                if (unit != unit_list[0])//选中的第二个目标不为自己
                {

                    unit_list[1] = hit.collider.gameObject;
                    operate.attack_one(unit_list[0], unit_list[1]);
                    clean_selsct();
                    is_select = false;//触发换手动画清空数组
                }
                else
                {
                    unit_list[0].GetComponent<unit_ui_illzt>().select_bool = true;
                    unit_list[0].GetComponent<unit_ui_illzt>().select();
                }
            }
            else
            {
                level_Conller.EndPlayerTurn();
            }
            }
        Destroy(jt,0f);
    }
    
    public void clean_selsct()
    {
        //在没有后续操作时清理选中目标，一般在换人换人结束后，技能释放后执行
        Array.Clear(unit_list,0, unit_list.Length);
    }
    public void Generate_arrows()
    {
        jt = Instantiate(select_jt);
        jt.GetComponentInParent<seleect_ui_script>().P1 = Camera.main.WorldToScreenPoint(unit.transform.position);
        jt.GetComponentInParent<seleect_ui_script>().unit = unit;
        //生成箭头

    }
}

