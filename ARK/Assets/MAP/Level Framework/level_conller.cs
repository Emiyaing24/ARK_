using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System;
using UnityEngine.Experimental.GlobalIllumination;
using static Occupation_class;


//本脚本旨在完成一场战斗内的各项操作
public class level_conller : MonoBehaviour
{
    public GameObject[] unit_list = new GameObject[6];
    public GameObject[] play_unit_list = new GameObject[3];
    public GameObject player;
    operate_player operate_Player;
    public selectunit selectunit;
    public static float Action_Resources;
    public bool isPlayerTurn = true; // 新增：回合状态标志
    private bool isEnemyActing = false;

    // Start is called before the first frame update
    void Start()
    {
        operate_Player = player.GetComponentInParent<operate_player>();
        operate_Player.level_Conller = this;
        selectunit.is_play_round = true;
        Action_Resources = 30f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("unit_enemy");
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>().enemy_list = play_unit_list;
            enemy.GetComponent<EnemyAI>().cs();


        }

    }
    public class operate
    {
        public void attack_one(GameObject attack_Initiator, GameObject attack_suffer)
        {
            Vector3 A_zb = attack_Initiator.transform.position;
            Vector3 B_zb = attack_suffer.transform.position;
            attack_Initiator.transform.DOMoveX(B_zb.x + 2.5f, 2.0f).SetEase(Ease.OutQuad);
            attack_Initiator.GetComponent<unit_initialize>().enemy_unity = attack_suffer;
            attack_Initiator.GetComponent<unit_initialize>().attack();
            interface_script.Action_Resources_ch(Action_Resources -10f);
            Action_Resources = Action_Resources - 10;
        }
        public void transposition(GameObject A, GameObject B)
        {
            //任意两个单位交换位置
            Vector3 A_zb = A.transform.position;
            Vector3 B_zb = B.transform.position;
            A.transform.DOMoveX(B_zb.x, 2.0f).SetEase(Ease.OutQuad);
            B.transform.DOMoveX(A_zb.x, 2.0f).SetEase(Ease.OutQuad);
            interface_script.Action_Resources_ch(Action_Resources - 10f);
            Action_Resources = Action_Resources - 10;
        }
    }
    public void CheckEnemyTurn()
    {
        if (!isPlayerTurn && Action_Resources >= 10)
        {
            StartCoroutine(EnemyTurnRoutine());
        }
    }

    // 新增：敌方回合协程
    IEnumerator EnemyTurnRoutine()
    {
        isEnemyActing = true;
        Debug.Log("======== 敌方回合开始 ========");

        // 执行所有敌方行动（示例循环3次）
        yield return StartCoroutine(enemy_roResources());
        yield return new WaitForSeconds(0.5f); // 行动间隔
        EndEnemyTurn();
        isEnemyActing = false;
    }

    // 修改后的敌方行动方法
    public IEnumerator enemy_roResources()
    {
        Debug.Log("敌方执行行动，消耗10资源");
        // 示例：找到所有敌方单位执行动作
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("unit_enemy");
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>()?.PerformAction();
        }
        yield return 0;
    }

    // 新增：结束敌方回合
    void EndEnemyTurn()
    {
        // 重置资源并切换回合
        Action_Resources = 30f;
        interface_script.Action_Resources_ch(Action_Resources);
        isPlayerTurn = true;
        selectunit.is_play_round = true;
        Debug.Log("敌方回合结束，切换至玩家回合");
    }

    // 新增：结束玩家回合（需要在玩家操作结束时调用）
    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return;

        isPlayerTurn = false;
        selectunit.is_play_round = false;
        Debug.Log("======== 玩家回合结束 ========");

        // 自动开始敌方回合
        StartCoroutine(EnemyTurnRoutine());
    }

}
