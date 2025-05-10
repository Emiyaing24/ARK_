using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.CanvasScaler;
//配合select预制体实现选取箭头
public class seleect_ui_script : MonoBehaviour
{
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;
    public float t = 0f;
    public UnityEngine.UI.Image[] image = new UnityEngine.UI.Image[7];
    Vector3[] zb_list = new Vector3[8];
    public GameObject unit;
    public GameObject[] unit_list = new GameObject[2];
    void Start()
    {
        for (int i = 0; i < image.Length; i++)
        {
            qiudian();
            

        }
        unit_list[0] = unit;
    }
    void Update()
    {
        P3 = Input.mousePosition;
        qiudian();
        for (int i = 0; i < image.Length; i++)
        {
            image[i].transform.position = zb_list[i + 1];
            float ange = Vector3.Angle(zb_list[i], zb_list[i + 1]);
            //image[i].transform.rotation = Quaternion.Euler(0, 0, ange*-100);
            var euler = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, zb_list[i] - zb_list[i + 1]));
            image[i].transform.rotation = Quaternion.Euler(euler * -1);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "unit" || hit.collider.tag == "unit_enemy")
            {
                unit = hit.collider.gameObject;
                if (unit != unit_list[0])//选中的第二个目标不为自己
                {
                   if (hit.collider.tag == "unit")
                    {
                        huanse_g();
                    }
                    else
                    {
                        huanse_r();
                    }

                }
            }
        }
    }
        void qiudian()
        {
            int i = 0;
            while (t < 1)
            {
                P2 = (P1 + P3) / 2;
                P2 = new Vector3(P2.x, P2.y + 50, P2.z);
                Vector3 aa = P1 + (P2 - P1) * t;
                Vector3 bb = P2 + (P3 - P2) * t;
                Vector3 zb = aa + (bb - aa) * t;
                zb_list[i] = zb;
                t += 0.125f;
                i += 1;
            }
            t = 0;

        }
        void huanse_r()
    {
        for (int i = 0; i < image.Length; i++)
        {

            image[i].color = Color.red;
                }
    }
    void huanse_g()
    {
        for (int i = 0; i < image.Length; i++)
        {

            image[i].color = Color.gray;
        }
    }
}


