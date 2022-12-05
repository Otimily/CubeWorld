using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        // ���� �ڵ� ����!!


        // ����� ���� ����� -> ������ -> ����
        // Resources ���� �ȿ� ����

        // 1. ���ҽ� �ε�
        // Resources ���� -> �޸𸮿� �÷��� �Ѵ�.
        Object enemy = Resources.Load("CubeEnemy");

        //// 2. �ҷ��� ���ҽ��� ������ ����
        //Instantiate(enemy);

        //// Instantiate(������Ʈ, ��ġ, ȸ��);
        //Instantiate(enemy, new Vector3(2, 0.5f, -2), Quaternion.identity);

        for (int i = 0; i < 10; i++)
        {
            float randomX = Random.Range(-10, 10.0f);
            float randomZ = Random.Range(0, 10.0f);

            Instantiate(enemy, new Vector3(randomX, 0.5f, randomZ), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
