using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;   //���� ����Ʈ ������ ����

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect);   // ����Ʈ ������ ����

        eff.transform.position = transform.position; // ����Ʈ ������ ��ġ�� ����ź ��ġ�� ����

        Destroy(gameObject);    //�ڱ� �ڽ� ����
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
