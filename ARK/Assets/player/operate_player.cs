using Spine.Unity.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���Խ�ɫ����
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
        //����ѡ��----�������������
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
        //����ѡ�а�Ҫ������unit�ύ���ؿ����нű�level����conller
        //����ƶ�ʱ�������߼���������unit����list
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
            if (hit.collider.tag  == "unit")
                {
                unit = hit.collider.gameObject;
                if (unit != unit_list[0])//ѡ�еĵڶ���Ŀ�겻Ϊ�Լ�
                    {
                   
                        if(level_conller.Action_Resources >= 10)
                    {
                        unit_list[1] = hit.collider.gameObject;
                        operate.transposition(unit_list[1], unit_list[0]);
                        clean_selsct();
                        is_select = false;//�������ֶ����������
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
                if (unit != unit_list[0])//ѡ�еĵڶ���Ŀ�겻Ϊ�Լ�
                {

                    unit_list[1] = hit.collider.gameObject;
                    operate.attack_one(unit_list[0], unit_list[1]);
                    clean_selsct();
                    is_select = false;//�������ֶ����������
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
        //��û�к�������ʱ����ѡ��Ŀ�꣬һ���ڻ��˻��˽����󣬼����ͷź�ִ��
        Array.Clear(unit_list,0, unit_list.Length);
    }
    public void Generate_arrows()
    {
        jt = Instantiate(select_jt);
        jt.GetComponentInParent<seleect_ui_script>().P1 = Camera.main.WorldToScreenPoint(unit.transform.position);
        jt.GetComponentInParent<seleect_ui_script>().unit = unit;
        //���ɼ�ͷ

    }
}

