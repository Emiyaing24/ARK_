using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
//单个角色的数据类型
[CreateAssetMenu(fileName = "nuitimgdate",menuName ="nuit/img_date")]
public class unit_imf_date : ScriptableObject
{
    public string name;
    public int start;
    public Sprite tx;
    public SkeletonDataAsset SkeletonDataAsset;
    public AnimatorController animatorController;
    public Sprite image_career;
    public Occupation_class.ProfessionType professionType;
    public float HP;
    public float SP;
    public float AP;
    public float PR;
    public float CSR;
    public float CSM;

}
