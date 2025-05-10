using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//选中角色并将相关数据传递给测试脚本
public class selectunit : MonoBehaviour
{
    private LayerMask mask;
    public GameObject role;
    public Animator unit_animator;
    public operate_player operate_Player;
    public bool mous_dowm = false;
    public Vector3 mous_ps;
    bool is_select;
    bool mous_move = false;
    public bool is_play_round;

    void Start()
    {
        is_select = false;
    }
    void Update()
    {
        if (is_play_round = true)
        {
            Vector3 check_now = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                mous_ps = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
                RaycastHit hit;
                mous_dowm = true;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "unit")
                    {
                        operate_Player.unit_animator = hit.collider.GetComponentInParent<Animator>();
                        operate_Player.unit = hit.collider.gameObject;
                        operate_Player.single_click_select();
                        is_select = true;
                        Debug.Log("ndw");
                    }
                }
            }
            if (is_select == true && mous_dowm == true)
            {
                Vector3 cha = mous_ps - check_now;
                float a = (Math.Abs(cha.x) + (Math.Abs(cha.y)) + (Math.Abs(cha.z)));
                if (a > 20)
                {
                    operate_Player.Generate_arrows();
                    is_select = false;
                    mous_move = true;
                    //当鼠标点击时如果和点击时的位置差超过20判定为拖动，创建箭头
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (mous_move == true)
                {
                    mous_dowm = false;
                    operate_Player.substitution();
                }
                mous_dowm = false;

                operate_Player.is_select = false;
                //鼠标松下时检测是否处于换位拖动转态，如果是则移除箭头并触发换位
            }
        }

    }

}

