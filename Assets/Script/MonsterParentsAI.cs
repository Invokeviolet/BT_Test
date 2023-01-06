
using UnityEngine;
using System;
using BehaviorTree;
using static BehaviorTree.BehaviorTreeMan;

public abstract class MonsterParentsAI : MonoBehaviour
{
    private INode root = null;


    private void Awake()
    {
        root = GetComponent<INode>();
        InitRootNode();

    }
    private void Start()
    {

    }

    private void Update()
    {

        root.Run();
        Debug.Log(root);
    }

    private void InitRootNode()  // 몬스터 AI 기본 행동 로직
    {
        Debug.Log("이닛");
        root = Selector
            (
            IF(IsFind),
            IF(IsArrange),
            ActionN(IsMove)

            );

    }

    protected virtual Action IsMove
    {
        get
        {
            return () =>
            {
                Debug.Log("이동");

            };
        }
    }
    protected virtual Func<bool> IsFind
    {
        get
        {
            return () =>
            {
                Debug.Log("찾는중");
                return true;
            };
        }
    }
    protected virtual Func<bool> IsArrange
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


   // 공격
   // 죽음
  
}
