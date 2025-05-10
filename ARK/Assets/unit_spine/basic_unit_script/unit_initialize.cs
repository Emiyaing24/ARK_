using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//���ű�ּ�ڵ��ؿ�����ʱ��ɽ�ɫ�����ݿ���ö�Ӧ�ز�
public class unit_initialize : MonoBehaviour
{
    public SkeletonMecanim skeletonMecanim;//spineģ��
    public Animator animation;//����������
    public unit_date_set unit_Date_Set;//���ݼ�
    public string name;//��ɫ����
    public unit_detailed_sc unit_Detailed_Sc;//״̬��
    public unit_date_leve unit_Date_Leve;//��������
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
                //����spineģ�ͺͶ���������
            }
        }
        
    }
    public void Status_bar()
    {
        //��ʼ��״̬��
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
