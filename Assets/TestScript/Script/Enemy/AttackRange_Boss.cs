using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AttackRange_Boss : AttackRange
{
    private int random;


    private void Start()
    {   //���� ������ ��� �Ԥ̤Ѥ�
        //mon = FindObjectOfType<Monster>();
        player = FindObjectOfType<Player>();
        range=gameObject.GetComponent<BoxCollider>();
        StartCoroutine(CoolTimeCo());

    }

    /*public override void OnTriggerEnter(Collider other)
    {
        isHit = true;
        if (other.gameObject.tag == "Player" && isHit == true && mon.isDead == false)
        {
            random = Random.Range(0, 3);
            if (isCool == false)
            {
                switch (random)
                {
                    case 0:
                        mon.monsterCreature1.SetTrigger("Attack1");
                        Debug.Log("����1");
                        StartCoroutine(DelayHit());
                        break;
                    case 1:
                        mon.monsterCreature1.SetTrigger("Attack2");
                        Debug.Log("����2");
                        StartCoroutine(DelayHit());
                        break;
                    case 2:
                        mon.monsterCreature1.SetTrigger("Attack3");
                        Debug.Log("����3");
                        StartCoroutine(DelayHit());
                        break;
                }
                isCool = true;
            }
        }
    }*/

    private void Update()
    {
        
    }


}
