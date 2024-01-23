using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    public bool isEquip;
    public bool isBox;
    public GameObject gunParent;
    public GameObject gun;
    public GameObject tempGun;
    public Player player;
    public TreasureBox box;
    public TextMeshProUGUI currentBulletText;
    int temp = 0;
/*
    [SerializeField]
    private string dropGun;

    [SerializeField]
    private string pickUpGun;*/

    private void Start()
    {
        isBox = false;
    }
    void Update()
    {

        if (gun != null)
        {
            currentBulletText.text = gun.GetComponent<Gun>().curBullet+"";
            player.weaponImage.sprite = gun.GetComponent<Gun>().image;
        }

        if (Input.GetMouseButton(0))
        {
            if (gun == null)
                return;

            else if (gun != null)
                gun.GetComponent<Gun>().Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (gun == null)
                return;

            gun.GetComponent<Gun>().ZoomCamera();
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (gun == null)
                return;

            gun.GetComponent<Gun>().ZoomReturn();
        }

        if (Input.GetKeyDown(KeyCode.G) && isEquip)
        {
            if (gun == null)
                return;

            player.itemSlot[temp] = null;

            //SoundManager.instance.PlaySE(dropGun);
            isEquip = false;
            gun.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gun.gameObject.GetComponent<Collider>().isTrigger = false;
            gun.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 4f, ForceMode.Impulse);
            gun.transform.SetParent(null);
            gun = null;
        }

        if (Input.GetKeyDown(KeyCode.Q))
            {
            if (isBox)
                box.OpenBox();
            else
                return;
            }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gun == tempGun)
                return;

            if (isEquip == false)
            {
                if (tempGun == null)
                    return;

               // SoundManager.instance.PlaySE(pickUpGun);
                int index = 0;
                GameObject current = player.itemSlot[index];
                while (current != null && index < 5)
                {
                    index++;
                    current = player.itemSlot[index];
                }
                player.itemSlot[index] = tempGun;

                isEquip = true;
                gun = tempGun;
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (isEquip == true)
            {
                if (tempGun == null)
                    return;

                int index = 0;
                GameObject current = player.itemSlot[index];
                while (current != null && index < 5)
                {
                    index++;
                    current = player.itemSlot[index];
                }
                player.itemSlot[index] = tempGun;
                tempGun.SetActive(false);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (player.itemSlot[0] == null)
                return;

            else
            {
                temp = 0;
                isEquip = true;
            }

            if (gun == null)
            {
                gun = player.itemSlot[0];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (gun != null)
            {
                gun.gameObject.SetActive(false);
                gun = null;
                gun = player.itemSlot[0];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (player.itemSlot[1] == null)
                return;

            else
            {
                temp = 1;
                isEquip = true;
            }

            if (gun == null)
            {
                gun = player.itemSlot[1];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (gun != null)
            {
                gun.gameObject.SetActive(false);
                gun = null;
                gun = player.itemSlot[1];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (player.itemSlot[2] == null)
                return;

            else
            {
                temp = 2;
                isEquip = true;
            }
            if (gun == null)
            {
                gun = player.itemSlot[2];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (gun != null)
            {
                gun.gameObject.SetActive(false);
                gun = null;
                gun = player.itemSlot[2];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (player.itemSlot[3] == null)
                return;

            else
            {
                temp = 3;
                isEquip = true;
            }
            if (gun == null)
            {
                gun = player.itemSlot[3];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (gun != null)
            {
                gun.gameObject.SetActive(false);
                gun = null;
                gun = player.itemSlot[3];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            if (player.itemSlot[4] == null)
                return;

            else
            {
                temp = 4;
                isEquip = true;
            }
            if (gun == null)
            {
                gun = player.itemSlot[4];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (gun != null)
            {
                gun.gameObject.SetActive(false);
                gun = null;
                gun = player.itemSlot[4];
                gun.SetActive(true);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gun")
        {
            tempGun = other.gameObject;
        }
        else if (other.tag == "Box")
        {
            box = other.gameObject.GetComponent<TreasureBox>();
            isBox = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gun")
        {
            tempGun = null;
        }
        else if (other.tag == "Box")
        {
            box = null;
            isBox = false;
        }
    }
}
