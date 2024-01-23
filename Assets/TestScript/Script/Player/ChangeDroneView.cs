using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDroneView : MonoBehaviour
{
    // �÷��̾� ����
    public GameObject playerCamera;
    // ��� ����
    public GameObject droneCamera;
    // ��� �̵� ��ũ��Ʈ
    public DroneMove droneControll;
    // �÷��̾� �̵� ��ũ��Ʈ
    public PlayerMove playerControll;
    
    public int batteryCnt;
    public Image crossHair;
    private bool droneCool;
    public TextMeshProUGUI batteryCntTxt;

    private void Awake()
    {
        playerCamera.SetActive(true);
        droneCamera.SetActive(false);
        batteryCnt = 5;
    }

    void Update()
    {

        batteryCntTxt.text = batteryCnt.ToString();
        if (Input.GetKeyDown(KeyCode.V) && batteryCnt > 0 && droneCool == false)
        {
            StartCoroutine(CameraSwitch());
            batteryCnt--;
        }
    }

    IEnumerator CameraSwitch()
    {
        droneCool = true;
        droneControll.SetPosition();
        droneControll.gameObject.SetActive(true);
        playerCamera.SetActive(false);
        droneCamera.SetActive(true);
        droneControll.droneMove = true;
        playerControll.playerMove = false;
        crossHair.enabled = false;
        yield return new WaitForSeconds(7f);
        droneCamera.SetActive(false);
        playerCamera.SetActive(true);
        playerControll.playerMove = true;
        crossHair.enabled = true;
        droneControll.GetComponent<BoxCollider>().enabled = false;
        droneCool = false;
    }

}