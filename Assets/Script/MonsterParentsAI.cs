
using UnityEngine;
using System;
using BehaviorTree;
using static BehaviorTree.BehaviorTreeMan;

public abstract class MonsterParentsAI : MonoBehaviour
{
    private INode root = null;

    // 나의 애니메이션 가져오기
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

    private void InitRootNode()  // 몬스터 AI 기본 행동 로직
    {
        Debug.Log("이닛");
        root = Selector
            (
                 // 사정거리 범위 안에 있을 때만 맞고, 죽음 -> 죽으면 몇초 뒤에 사라짐
                 IF(IsFind),
                    IfElseAction(IsArange, IsMove, IsAttack)               

                /*Sequence
                (
                    IfElseAction(IsAttackArrange, IsHit, IsDead)
                )*/
            );
    }

    // 어떤 경우에 대기할건지 정할 것
    protected virtual Action IsIdle
    {
        get
        {
            return () =>
            {
                Debug.Log("대기");
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
                Debug.Log("타겟 찾기");

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
                Debug.Log("이동");
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
                Debug.Log("범위 내에 있음");
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
                Debug.Log("공격 범위 내에 있음");
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
                Debug.Log("이동 범위 내에 있음");
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
                Debug.Log("공격");
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
                Debug.Log("맞음");
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
                Debug.Log("죽었나?");
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
                Debug.Log("삭제");
            };
        }
    }
}
