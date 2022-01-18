using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;   //회전 속도 변수

    //회전 값 변수
    float mx = 0;
    float my = 0;


    void Start()
    {
        
    }

    void Update()
    { 
        /*사용자 마우스 입력받아 물체 회전시키고자 함*/
        //마우스 입력값 변수에 저장
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        //2. 마우스 입력값으로 회전 방향 결정
        transform.eulerAngles = new Vector3(-my, mx, 0);
        //3. 회전 방향으로 물체 회전시킴(r=r0+vt)
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        //4. x축 회전(상하회전)값 -90~90으로 제한
        Vector3 rot = transform.eulerAngles;
        rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        transform.eulerAngles = rot;
    }
}
