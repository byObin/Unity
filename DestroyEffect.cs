using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.5f;    //제거될 시간 변수
    float currentTime = 0;  //경과 시간 측정용 변수
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > destroyTime)  //경과 시간이 제거될 시간 초과 시 자기 제거
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;  //경과 시간 누적
    }
}
