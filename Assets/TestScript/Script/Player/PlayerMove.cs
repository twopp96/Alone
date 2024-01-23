using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isRun;

    private float moveSpeed;
    public bool playerMove = true;
    CharacterController controller;
    // �߷°� ����
    public float gravity = -9.8f;
    // ���� �ӷ� ����
    public float yVelocity = 0;
    // ������ ����
    public float jumpPower = 5f;
    // �������� ����
    public bool isJumping = false;

/*    [SerializeField]
    public string playerWalking;
    [SerializeField]
    private string playerRunning;
    [SerializeField]
    public string playerJumping;*/

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // �̵��ӵ� �ʱ�ȭ
        moveSpeed = IsRun();

        // ����ڿ��� �Է� �ޱ�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵����� ���ϱ�
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        if (playerMove == true)
        {
            // ī�޶� �������� ���� ��ȯ
            dir = Camera.main.transform.TransformDirection(dir);
           
            // ���� �ٴڿ� ������ ���¿��ٸ�
            if (controller.collisionFlags == CollisionFlags.Below)
            {
                // ������ �� �ڿ��ٸ�
                if (isJumping)
                {
                    isJumping = false;
                    yVelocity = 0;
                }
            }

            // spacebar ���� ��, �ٴڿ� ������ ���¶��
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                yVelocity = jumpPower;
                isJumping = true;
            }

            // ĳ������ ���� �ӵ��� �߷°� ����
            yVelocity += gravity * Time.deltaTime;
            dir.y = yVelocity;

            // �̵��ӵ��� ���� �̵���Ű��
            controller.Move(dir * moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator RunSound()
    {

        yield return new WaitForSeconds(1.2f);
        isRun = false;

    }
    float IsRun()
    { 
    if (Input.GetKey(KeyCode.LeftShift))
        {
            if(!isRun)
            {
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    //������
                    //SoundManager.instance.StopSE(playerRunning);
                    //Destroy(SoundManager.instance);
                }
                else
{
    //SoundManager.instance.PlaySE(playerRunning);
    isRun = true;
    StartCoroutine(RunSound());
}
            }
            return 10f;
        }
        else
{
    return 4f;
}
    }
}
