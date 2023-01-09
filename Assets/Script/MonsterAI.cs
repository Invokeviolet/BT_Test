using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonsterParentsAI
{
    // 체력
    [SerializeField] float hp = 100f;
    float speed = 2f;

    // 타겟
    GameObject target;
    // 적 받아올 배열
    GameObject[] enermies;

    // 공격 범위
    float attackRange = 1f;
    // 이동 범위
    float moveRange = 10f;

    // 몬스터가 가진 아이템
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
                Debug.Log("대기");
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
                Debug.Log("타겟 찾기");
                target = GameObject.FindGameObjectWithTag("Target");
                if (target == null)
                {
                    Debug.Log("못찾아");
                    return true;
                }
                else
                {
                    Debug.Log("찾아");
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
                Debug.Log("이동");
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
                Debug.Log("범위 내에 있음");
                float Distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (Distance <= attackRange)
                {
                    Debug.Log("공격범위 내에 있음");
                    myAni.SetBool("IsMove", false);
                    return true;
                }
                else
                {
                    Debug.Log("공격범위 내에 없음");
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
                Debug.Log("범위 내에 있음");
                float Distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (Distance <= attackRange)
                {
                    Debug.Log("공격범위 내에 있음");
                    myAni.SetBool("IsMove", false);
                    return true;
                }
                else
                {
                    Debug.Log("공격범위 내에 없음");
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
                Debug.Log("이동 범위 내에 있음");
                float Distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (Distance <= moveRange)
                {
                    Debug.Log("이동범위 내에 있음");                    
                    return false;
                }
                else
                {
                    Debug.Log("이동범위 내에 없음");
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
                Debug.Log("공격");
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
                Debug.Log("맞음");
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
                Debug.Log("죽었나?");
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
                Debug.Log("삭제");
                Destroy();
            };
        }
    }


}
