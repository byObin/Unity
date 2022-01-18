using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.5f;    //���ŵ� �ð� ����
    float currentTime = 0;  //��� �ð� ������ ����
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > destroyTime)  //��� �ð��� ���ŵ� �ð� �ʰ� �� �ڱ� ����
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;  //��� �ð� ����
    }
}
