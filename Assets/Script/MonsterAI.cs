using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonsterParentsAI
{
    // ü��
    float hp = 100;
    float speed = 2f;

    // Ÿ��
    GameObject target;
    // �� �޾ƿ� �迭
    GameObject[] enermies;

    int attackRange = 10;


    // �̵� �Լ� 
    protected override Action IsMove
    {
        get 
        {
            return () =>
            {
                Debug.Log("�̵�");
                gameObject.transform.LookAt(target.transform);
                gameObject.transform.Translate(Vector3.forward*speed*Time.deltaTime);
                
            };
        }
    }
    protected override Func<bool> IsFind
    {
        get 
        {
            return () =>
            {
                Debug.Log("Ÿ�� ã��");
                target = GameObject.FindGameObjectWithTag("Target");                
                return true;
                
            };
        }
    }
    protected override Func<bool> IsArrange
    {
        get 
        {
            return () => 
            {
                Debug.Log("���� ���� ����");
                float Distance = Vector3.Distance(gameObject.transform.position,target.transform.position);
                if (Distance<=attackRange)
                {
                    return true;
                }
                return false;
            };
        }
    }

}
