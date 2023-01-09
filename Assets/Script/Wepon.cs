using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public MonsterAI monsterAI;
    public float WeponDamage = 30f;
    private void Start()
    {
        monsterAI = FindObjectOfType<MonsterAI>();
    }
  
}
