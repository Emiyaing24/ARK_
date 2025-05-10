using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class unit_detailed_sc : MonoBehaviour
{
    public string unit_name;
    public unit_date_set unit_Date_Set;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Image image_bc;
    public string startColorHex = "#FFFFFF";
    public string endColorHex = "#FAFF04";
    public float duration = 1f;
    public RawImage Image_Career;
    public UnityEngine.UI.Image HP_image;
    Vector2 HP_wh;
    private void Start()
    {
        Color startColor, endColor;
        ColorUtility.TryParseHtmlString(startColorHex, out startColor);
        ColorUtility.TryParseHtmlString(endColorHex, out endColor);
        image_bc.DOColor(endColor, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);

        HP_wh = HP_image.rectTransform.sizeDelta;
    }
    public void initialize()
    {
        print(name); 
        //以名字为索引从date获取各项数据
        for (int i = 0; i < unit_Date_Set.unit_img_list.Count; i++)
        {
            unit_imf_date unit_Imf_Date = unit_Date_Set.unit_img_list[i];
            if (unit_Imf_Date.name == unit_name)
            {
                image.sprite = unit_Imf_Date.tx;
                Image_Career.texture = unit_Imf_Date.image_career.texture;
            }
        }
    }
    public void HP_Change(float Max_HP,float Now_HP)
    {
        float width = Now_HP / Max_HP;
        HP_image.rectTransform.sizeDelta = new Vector2(HP_wh.x * width, HP_wh.y);
        //根据血条增加或减少改HP_image的宽度
    }
}
