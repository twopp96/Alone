using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


/*public struct PotionInfo
{
    public int hpBuff;
    public int atkBuff;
    public int buffTime;
}*/

public class Potion : Item
{
    //PotionInfo potion;
     protected int hpBuff; //ü��ȸ��
     protected int atkBuff;//���ݷ�����
     protected int buffTime;

  /*  void Start()
    {
        Init(inPutHpBuff, inPutAtkBuff);
    }*/

    void Update()
    {
        Rotate();
        
    }

/*    public void Use() //���� ����
    {       
        GameObject target;
        target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();
        player.Hp += hpBuff;
        player.Atk += atkBuff;

        this.useable = true; //�� �� ���Ǿ���
        Debug.Log(itemName + " �� ��� �Ͽ����ϴ�.");                    
        Debug.Log("����ü��" + player.Hp); //���ϴ��� Ȯ�ο�
        Debug.Log("������ݷ�" + player.Atk); //���ϴ��� Ȯ�ο�
        StartCoroutine(Reset());
    }
*/
/*    public void Init(int hp, int atk)
    {
       
        potion.hpBuff = hp;
        potion.atkBuff = atk;
       
    }*/

/*    IEnumerator Reset()
    {    

        yield return new WaitForSeconds(buffTime);
          GameObject target;
          target = GameObject.Find("Player");
          Player player = target.GetComponent<Player>();
          player.Atk -= atkBuff;
          Debug.Log("����ü��" + player.Hp); //���ϴ��� Ȯ�ο�
          Debug.Log("������ݷ�" + player.Atk); //���ϴ��� Ȯ�ο�
          Delete(this.useable);      

    }
*/

/*    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>()!=null)
        {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Use();          
        }
    }*/

}
