using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonsterParentsAI
{
    // 체력
    float hp = 100;
    float speed = 2f;

    // 타겟
    GameObject target;
    // 적 받아올 배열
    GameObject[] enermies;

    int attackRange = 10;


    // 이동 함수 
    protected override Action IsMove
    {
        get 
        {
            return () =>
            {
                Debug.Log("이동");
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
                Debug.Log("타겟 찾기");
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
                Debug.Log("범위 내에 있음");
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
