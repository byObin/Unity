using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;   //폭발 이펙트 프리팹 변수

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect);   // 이펙트 프리팹 생성

        eff.transform.position = transform.position; // 이펙트 프리팹 위치는 수류탄 위치와 동일

        Destroy(gameObject);    //자기 자신 제거
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
