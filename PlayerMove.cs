using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;    //�̵� �ӵ� ����

    CharacterController cc; //ĳ���� ��Ʈ�ѷ� ����

    float gravity = -20f;   //�߷� ����
    float yVelocity = 0;    //���� �ӷ� ����
    public float jumpPower = 10f;   //������ ����
    public bool isJumping = false;  //���� ���� ����

    public int hp = 20; //�÷��̾� ü�� ����

    int maxHp = 20;
    public Slider hpSlider;

    public void DamageAction(int damage)
    {
        hp -= damage;
    }


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        //2-2 ���� ���� ���̾��� �ٽ� �ٴڿ� �����ߴٸ�
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;  //���� �� ���·� �ʱ�ȭ
            yVelocity = 0;  //ĳ���� ���� �ӵ� 0���� ����
        }

        // 2-3 ���� ���� ���� ���� ���¿��� spacebar �Է� ��
        if (Input.GetButtonDown("Jump")&&!isJumping)
        {
            //ĳ���� ���� �ӵ��� ������ ����, �������·� ����
            yVelocity = jumpPower;
            isJumping = true;
        }

        //2-3 ĳ���� ���� �ӵ��� �߷°� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);  //3 �̵� �ӵ��� ���� �̵�


        hpSlider.value = (float)hp / (float)maxHp;

    }
}
