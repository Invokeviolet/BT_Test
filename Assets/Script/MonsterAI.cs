using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonsterParentsAI
{
    // ü��
    [SerializeField] float hp = 100f;
    float speed = 2f;

    // Ÿ��
    GameObject target;
    // �� �޾ƿ� �迭
    GameObject[] enermies;

    // ���� ����
    float attackRange = 1f;
    // �̵� ����
    float moveRange = 10f;

    // ���Ͱ� ���� ������
    [SerializeField] GameObject Item;

    private void Start()
    {

    }

    protected override Action IsIdle
    {
        get
        {
            return () =>
            {
                Debug.Log("���");
                myAni.SetBool("IsMove", false);
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
                if (target == null)
                {
                    Debug.Log("��ã��");
                    return true;
                }
                else
                {
                    Debug.Log("ã��");
                    return false;
                }
            };
        }
    }


    protected override Action IsMove
    {
        get
        {
            return () =>
            {
                Debug.Log("�̵�");
                myAni.SetBool("IsMove", true);
                myAni.SetBool("IsAttack", false);
                gameObject.transform.LookAt(target.transform);
                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            };
        }
    }
    protected virtual Func<bool> IsArange
    {
        get
        {
            return () =>
            {
                Debug.Log("���� ���� ����");
                float Distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (Distance <= attackRange)
                {
                    Debug.Log("���ݹ��� ���� ����");
                    myAni.SetBool("IsMove", false);
                    return true;
                }
                else
                {
                    Debug.Log("���ݹ��� ���� ����");
                    return false;
                }
            };
        }
    }
   /* protected override Func<bool> IsAttackArrange
    {
        get
        {
            return () =>
            {
                Debug.Log("���� ���� ����");
                float Distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (Distance <= attackRange)
                {
                    Debug.Log("���ݹ��� ���� ����");
                    myAni.SetBool("IsMove", false);
                    return true;
                }
                else
                {
                    Debug.Log("���ݹ��� ���� ����");
                    return false;
                }
            };
        }
    }
    protected virtual Func<bool> IsMoveArrange
    {
        get
        {
            return () =>
            {
                Debug.Log("�̵� ���� ���� ����");
                float Distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (Distance <= moveRange)
                {
                    Debug.Log("�̵����� ���� ����");                    
                    return false;
                }
                else
                {
                    Debug.Log("�̵����� ���� ����");
                    return true;
                }
            };
        }
    }*/

    protected override Action IsAttack
    {
        get
        {
            return () =>
            {
                Debug.Log("����");
                myAni.SetBool("IsAttack", true);
            };
        }
    }
    protected override Action IsHit
    {
        get
        {
            return () =>
            {
                Debug.Log("����");
                myAni.SetTrigger("IsHit");
            };
        }
    }

    protected override Action IsDead
    {
        get
        {
            return () =>
            {
                Debug.Log("�׾���?");
                myAni.SetBool("IsDead", true);
                Instantiate(Item, this.transform.position, Quaternion.identity);
            };
        }
    }
    protected override Action Destroy
    {
        get
        {
            return () =>
            {
                Debug.Log("����");
                Destroy();
            };
        }
    }


}
