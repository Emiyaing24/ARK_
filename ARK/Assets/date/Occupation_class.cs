using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occupation_class : MonoBehaviour
{   //各类职业克制表和伤害结算规则
    public enum ProfessionType
    {
        Heavy,
        Mage,
        Pioneer,
        Sniper,
        Assist,
        Guard,
        special,
        Doctor
    }//职业枚举
    public static float Damage_settlement(ProfessionType attacker, ProfessionType defender,float acc,float CSR,float CSM)
    {
        float hit = 0;
        float beilv = GetDamageMultiplier(attacker, defender);
        float baoji = Random.Range(0f,1f);
        if(baoji < CSR)
        {
            hit = acc * beilv * CSM;
        }
        else
        {
            hit = acc * beilv;
        }
        return hit;//规则为攻击x倍率x是否暴击x暴击倍率
    }
    private static float GetDamageMultiplier(ProfessionType attacker, ProfessionType defender)
    {
        switch (attacker)
        {
            case ProfessionType.Heavy:
                return defender switch
                {
                    ProfessionType.Mage => 0.8f,
                    ProfessionType.Pioneer => 0.8f,
                    ProfessionType.Sniper => 0.8f,
                    ProfessionType.Assist => 0.8f,
                    ProfessionType.Guard => 0.8f,
                    ProfessionType.special => 0.8f,
                    ProfessionType.Doctor => 0.8f,
                    ProfessionType.Heavy => 1.0f
                };
            case ProfessionType.Mage:
                return defender switch
                {
                    ProfessionType.Heavy => 1.5f,
                    ProfessionType.Pioneer => 1.2f,
                    ProfessionType.Sniper => 1.2f,
                    ProfessionType.Assist => 1.2f,
                    ProfessionType.Guard => 0.8f,
                    ProfessionType.special => 0.8f,
                    ProfessionType.Doctor => 1f,
                    ProfessionType.Mage => 1f,
                };
            case ProfessionType.Pioneer:
                return defender switch
                {
                    ProfessionType.Heavy => 0.8f,
                    ProfessionType.Mage => 1.2f,
                    ProfessionType.Sniper => 1.2f,
                    ProfessionType.Assist => 1.2f,
                    ProfessionType.Guard => 1.2f,
                    ProfessionType.special => 1.2f,
                    ProfessionType.Doctor => 1.2f,
                    ProfessionType.Pioneer => 1f,
                };
            case ProfessionType.Sniper:
                return defender switch
                {
                    ProfessionType.Heavy => 0.8f,
                    ProfessionType.Pioneer => 1.2f,
                    ProfessionType.Mage => 1.2f,
                    ProfessionType.Assist => 1.2f,
                    ProfessionType.Guard => 1.2f,
                    ProfessionType.special => 1.2f,
                    ProfessionType.Doctor => 1.2f,
                    ProfessionType.Sniper => 1f,
                };
            case ProfessionType.Assist:
                return defender switch
                {
                    ProfessionType.Heavy => 0.8f,
                    ProfessionType.Pioneer => 0.8f,
                    ProfessionType.Sniper => 0.8f,
                    ProfessionType.Mage => 0.8f,
                    ProfessionType.Guard => 0.8f,
                    ProfessionType.special => 0.8f,
                    ProfessionType.Doctor => 0.8f,
                    ProfessionType.Assist => 1f
                };
            case ProfessionType.Guard:
                return defender switch
                {
                    ProfessionType.Heavy => 0.8f,
                    ProfessionType.Pioneer => 1.2f,
                    ProfessionType.Sniper => 1.5f,
                    ProfessionType.Assist => 1.5f,
                    ProfessionType.Mage => 1.5f,
                    ProfessionType.special => 1.5f,
                    ProfessionType.Doctor => 1.5f,
                    ProfessionType.Guard => 1f
                };
            case ProfessionType.special:
                return defender switch
                {
                    ProfessionType.Heavy =>0.8f,
                    ProfessionType.Pioneer => 1.5f,
                    ProfessionType.Sniper => 1.5f,
                    ProfessionType.Assist => 1.5f,
                    ProfessionType.Guard => 1.5f,
                    ProfessionType.Mage => 1.5f,
                    ProfessionType.Doctor => 1.5f,
                    ProfessionType.special =>1f
                };
            case ProfessionType.Doctor:
                return defender switch
                {
                    ProfessionType.Heavy => 1.5f,
                    ProfessionType.Pioneer => 1f,
                    ProfessionType.Sniper => 1f,
                    ProfessionType.Assist => 1f,
                    ProfessionType.Guard => 1f,
                    ProfessionType.special => 1f,
                    ProfessionType.Mage => 1f,
                    ProfessionType.Doctor => 1f
                };
            default:
                return 1f;
        }
    }
}
