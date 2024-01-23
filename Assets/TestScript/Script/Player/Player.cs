using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject[] itemSlot = new GameObject[5];
    private float hp;
    private const int maxHp = 1000;

    public TextMeshProUGUI curHpTxt;
    public Image weaponImage;

    public GameObject hitEffect;
  

    public float Hp
    {
        get { return hp; }
        set { 
            if(hp >= maxHp) hp = maxHp;
            hp = value; }
    }


    private void Start()
    {
        hp = maxHp;

        
    }

    private void Update()
    {
        curHpTxt.text = hp.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
           /* hp -= collision.gameObject.GetComponent<Monster>().atk;*/
        }
        if (hp > 0 && collision.gameObject.tag == "Monster")
        {
            StartCoroutine(PlayerHitEffect());
        }
    }

    IEnumerator PlayerHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        hitEffect.SetActive(false);
    }

}
