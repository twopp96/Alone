using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBuff : Potion
{
    new int atkBuff =50;//���ݷ�����
    new int buffTime = 60;
   


    public void Use() //���� ����
    {
        GameObject target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();
        player.Hp += hpBuff;

        
       // player.gun.Damage += atkBuff;

        this.useable = true; //�� �� ���Ǿ���
        Debug.Log(name + " �� ��� �Ͽ����ϴ�.");
        Debug.Log("����ü��" + player.Hp); //���ϴ��� Ȯ�ο�
        //Debug.Log("������ݷ�" + player.gun.Damage); //���ϴ��� Ȯ�ο�
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {

        yield return new WaitForSeconds(buffTime);
        GameObject target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();

        //player.gun.Damage -= atkBuff;
       
        //Debug.Log("������ݷ�" + player.gun.Damage); //���ϴ��� Ȯ�ο�
        Delete(this.useable);

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
        items[5] = gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
}
