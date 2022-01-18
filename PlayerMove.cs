using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;    //이동 속도 변수

    CharacterController cc; //캐릭터 컨트롤러 변수

    float gravity = -20f;   //중력 변수
    float yVelocity = 0;    //수직 속력 변수
    public float jumpPower = 10f;   //점프력 변수
    public bool isJumping = false;  //점프 상태 변수

    public int hp = 20; //플레이어 체력 변수

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

        //2-2 만약 점프 중이었고 다시 바닥에 착지했다면
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;  //점프 전 상태로 초기화
            yVelocity = 0;  //캐릭터 수직 속도 0으로 만듦
        }

        // 2-3 만약 점프 하지 않은 상태였고 spacebar 입력 시
        if (Input.GetButtonDown("Jump")&&!isJumping)
        {
            //캐릭터 수직 속도에 점프력 적용, 점프상태로 변경
            yVelocity = jumpPower;
            isJumping = true;
        }

        //2-3 캐릭터 수직 속도에 중력값 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);  //3 이동 속도에 맞춰 이동


        hpSlider.value = (float)hp / (float)maxHp;

    }
}
