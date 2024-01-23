using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBuff : Potion
{
    new int hpBuff= 30; //ü��ȸ��

    public void Use() //���� ����
    {
        GameObject target;
        target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();
        player.Hp += hpBuff;     

        this.useable = true; //�� �� ���Ǿ���
        Debug.Log(name + " �� ��� �Ͽ����ϴ�.");
        Debug.Log("����ü��" + player.Hp); //���ϴ��� Ȯ�ο�
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Use();
        }
    }
    void Start()
    {
        items[4] = gameObject;
    }
    void Update()
    {
        Rotate();
    }
}
