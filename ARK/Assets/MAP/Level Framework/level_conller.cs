using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System;
using UnityEngine.Experimental.GlobalIllumination;
using static Occupation_class;


//���ű�ּ�����һ��ս���ڵĸ������
public class level_conller : MonoBehaviour
{
    public GameObject[] unit_list = new GameObject[6];
    public GameObject[] play_unit_list = new GameObject[3];
    public GameObject player;
    operate_player operate_Player;
    public selectunit selectunit;
    public static float Action_Resources;
    public bool isPlayerTurn = true; // �������غ�״̬��־
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
            //����������λ����λ��
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

    // �������з��غ�Э��
    IEnumerator EnemyTurnRoutine()
    {
        isEnemyActing = true;
        Debug.Log("======== �з��غϿ�ʼ ========");

        // ִ�����ез��ж���ʾ��ѭ��3�Σ�
        yield return StartCoroutine(enemy_roResources());
        yield return new WaitForSeconds(0.5f); // �ж����
        EndEnemyTurn();
        isEnemyActing = false;
    }

    // �޸ĺ�ĵз��ж�����
    public IEnumerator enemy_roResources()
    {
        Debug.Log("�з�ִ���ж�������10��Դ");
        // ʾ�����ҵ����ез���λִ�ж���
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("unit_enemy");
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>()?.PerformAction();
        }
        yield return 0;
    }

    // �����������з��غ�
    void EndEnemyTurn()
    {
        // ������Դ���л��غ�
        Action_Resources = 30f;
        interface_script.Action_Resources_ch(Action_Resources);
        isPlayerTurn = true;
        selectunit.is_play_round = true;
        Debug.Log("�з��غϽ������л�����һغ�");
    }

    // ������������һغϣ���Ҫ����Ҳ�������ʱ���ã�
    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return;

        isPlayerTurn = false;
        selectunit.is_play_round = false;
        Debug.Log("======== ��һغϽ��� ========");

        // �Զ���ʼ�з��غ�
        StartCoroutine(EnemyTurnRoutine());
    }

}
