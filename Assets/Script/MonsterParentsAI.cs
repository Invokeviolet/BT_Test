
using UnityEngine;
using System;
using BehaviorTree;
using static BehaviorTree.BehaviorTreeMan;

public abstract class MonsterParentsAI : MonoBehaviour
{
    private INode root = null;

    // ���� �ִϸ��̼� ��������
    protected Animator myAni;

    private void Awake()
    {
        root = GetComponent<INode>();
        InitRootNode();
        myAni = GetComponent<Animator>();

    }
    private void Start()
    {

    }

    private void Update()
    {
        root.Run();

    }

    private void InitRootNode()  // ���� AI �⺻ �ൿ ����
    {
        Debug.Log("�̴�");
        root = Selector
            (
                 // �����Ÿ� ���� �ȿ� ���� ���� �°�, ���� -> ������ ���� �ڿ� �����
                 IF(IsFind),
                    IfElseAction(IsArange, IsMove, IsAttack)               

                /*Sequence
                (
                    IfElseAction(IsAttackArrange, IsHit, IsDead)
                )*/
            );
    }

    // � ��쿡 ����Ұ��� ���� ��
    protected virtual Action IsIdle
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

    protected virtual Func<bool> IsFind
    {
        get
        {
            return () =>
            {
                Debug.Log("Ÿ�� ã��");

                return true;
            };
        }
    }


    protected virtual Action IsMove
    {
        get
        {
            return () =>
            {
                Debug.Log("�̵�");
                myAni.SetBool("IsMove", true);
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
                return true;
            };
        }
    }
    /*protected virtual Func<bool> IsAttackArrange
    {
        get
        {
            return () =>
            {
                Debug.Log("���� ���� ���� ����");
                return false;
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
                return true;
            };
        }
    }*/

    protected virtual Action IsAttack
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

    protected virtual Action IsHit
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

    protected virtual Action IsDead
    {
        get
        {
            return () =>
            {
                Debug.Log("�׾���?");
                myAni.SetBool("IsDead", true);
            };
        }
    }
    protected virtual Action Destroy
    {
        get
        {
            return () =>
            {
                Debug.Log("����");
            };
        }
    }
}
