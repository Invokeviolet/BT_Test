
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

    private void InitRootNode()  // ���� AI �⺻ �ൿ ����
    {
        Debug.Log("�̴�");
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
                Debug.Log("�̵�");

            };
        }
    }
    protected virtual Func<bool> IsFind
    {
        get
        {
            return () =>
            {
                Debug.Log("ã����");
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
                Debug.Log("���� ���� ����");
                return true;
            };
        }
    }


   // ����
   // ����
  
}
