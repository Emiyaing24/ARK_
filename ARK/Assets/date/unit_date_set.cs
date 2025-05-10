using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "nuitimgdate", menuName = "nuit/img_date_list")]
//角色总数据库
public class unit_date_set : ScriptableObject
{
    public List<unit_imf_date> unit_img_list = new List<unit_imf_date>();
}
