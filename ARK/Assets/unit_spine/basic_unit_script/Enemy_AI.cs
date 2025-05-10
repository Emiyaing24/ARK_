using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Tuple<GameObject, float>[] enemy_hit = new Tuple<GameObject, float>[3];
    public unit_initialize unit_Initialize;
    public GameObject[] enemy_list = new GameObject[3];
    GameObject enemy_index;
    public void cs()
    {
        for (int i = 0; i < enemy_list.Length; i++)
        {
            enemy_hit[i] = Tuple.Create(enemy_list[i], 0f);
        }
    }
    public void PerformAction()
        {
        print(select_attack_unit());
        float hit = Occupation_class.Damage_settlement(unit_Initialize.unit_Date_Leve.professionType, enemy_index.GetComponent<unit_date_leve>().professionType, unit_Initialize.unit_Date_Leve.AP, unit_Initialize.unit_Date_Leve.CSR, unit_Initialize.unit_Date_Leve.CSM);
        enemy_index.GetComponent<unit_initialize>().be_hit(hit);
        }
    int select_attack_unit()
    {
        float[] hatred = new float[3];
        for (int i = 0; i < 3; i++) {
            int my_index = unit_Initialize.unit_Date_Leve.index;
            int enemy_index = enemy_hit[i].Item1.GetComponent<unit_date_leve>().index;
            float hit = (enemy_hit[i].Item2 + 10) / (enemy_index - my_index);
            hatred[i] = hit;
            print(unit_Initialize.unit_Date_Leve.index + "¶Ô" + enemy_hit[i].Item1.GetComponent<unit_date_leve>().index + "µÄ³ðºÞÊÇ" + hit);

        }
        float a = 0;
        int idex = 0;
        for (int i = 0; i < 3; i++)
        {
            if (hatred[i] > a)
            {
                enemy_index = enemy_hit[i].Item1;
                a = hatred[i];
                idex = enemy_hit[i].Item1.GetComponent<unit_date_leve>().index; ;
            }
        }
        return idex;
    }
    public void be_hit(GameObject enemy,float hit)
    {
        for (int i = 0; i < 3; i++) {

                if (enemy.name == enemy_hit[i].Item1.name)
                {
                    enemy_hit[i] = Tuple.Create(enemy_hit[i].Item1,hit);
                    break;
                }
            }
    }
    
}
