using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//本脚本旨在当关卡加载时完成角色在数据库调用对应素材
public class unit_initialize : MonoBehaviour
{
    public SkeletonMecanim skeletonMecanim;//spine模型
    public Animator animation;//动画控制器
    public unit_date_set unit_Date_Set;//数据集
    public string name;//角色名字
    public unit_detailed_sc unit_Detailed_Sc;//状态栏
    public unit_date_leve unit_Date_Leve;//各项数据
    public GameObject enemy_unity;
    public GameObject my;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < unit_Date_Set.unit_img_list.Count;i++)
        {
            unit_imf_date unit_Imf_Date = unit_Date_Set.unit_img_list[i];

            if (unit_Imf_Date.name == name)
            {
                skeletonMecanim.skeletonDataAsset = unit_Date_Set.unit_img_list[i].SkeletonDataAsset;
                animation.runtimeAnimatorController = unit_Date_Set.unit_img_list[i].animatorController;
                unit_Date_Leve.HP = unit_Date_Set.unit_img_list[i].HP;
                unit_Date_Leve.AP = unit_Date_Set.unit_img_list[i].AP;
                unit_Date_Leve.SP = unit_Date_Set.unit_img_list[i].SP;
                unit_Date_Leve.PR = unit_Date_Set.unit_img_list[i].PR;
                unit_Date_Leve.CSR = unit_Date_Set.unit_img_list[i].CSR;
                unit_Date_Leve.CSM = unit_Date_Set.unit_img_list[i].CSM;
                unit_Date_Leve.professionType = unit_Date_Set.unit_img_list[i].professionType;
                //设置spine模型和动画控制器
            }
        }
        
    }
    public void Status_bar()
    {
        //初始化状态栏
        unit_Detailed_Sc.unit_name = name;
        unit_Detailed_Sc.initialize();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void attack()
    {
       float hit = Occupation_class.Damage_settlement(unit_Date_Leve.professionType, enemy_unity.GetComponent<unit_date_leve>().professionType,unit_Date_Leve.AP, unit_Date_Leve.CSR, unit_Date_Leve.CSM);
       enemy_unity.GetComponent<EnemyAI>().be_hit(my, hit);
    }
    public void be_hit(float hit)
    {
        float now_hp = unit_Date_Leve.HP - hit;
        unit_Detailed_Sc.HP_Change(unit_Date_Leve.HP, now_hp);
    }

}
