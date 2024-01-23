using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AttackRange : MonoBehaviour
{
    //1. ����Ƽ �ν����Ϳ��� ���� �ش� ���� �������� �����Ͽ� �־��� ��!
    public Monster mon;
    protected bool isCool;
    public bool isHit = false;
    public Player player;
    protected Collider range;

    private void Start()
    {   
        player = FindObjectOfType<Player>();
        StartCoroutine(CoolTimeCo());
        range = GetComponent<Collider>();
    }
    public IEnumerator CoolTimeCo()
    {
        while (true)
        {
            if (isCool == true)
            {
                isCool = false;
            }
            yield return new WaitForSeconds(1.6f);
        }
    }

    protected IEnumerator DelayHit()
    {
        range.enabled = false;
        yield return new WaitForSeconds(3);
        range.enabled = true;
    }



    /*public virtual void OnTriggerEnter(Collider other)
    {
        isHit = true;
        if (isCool == false)
        {
            if (other.gameObject.tag == "Player" && isHit==true && mon.isDead == false)
            {
                mon.monsterCreature1.SetTrigger("Attack1");
                isCool = true;
                StartCoroutine(DelayHit());
            }

        }
    }*/

}
