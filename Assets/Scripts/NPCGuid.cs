using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCGuid : MonoBehaviour
{
    string[] guids =
    {
        "�������! ��� �ŷ��Ͻǰǰ���?",
        "������ ���� ���� ������ ���Դٱ���!",
        "��ҿɼ�"
    };

    public void guid()
    {
        // 0
        // 1
        // 2

        int rand = Random.Range(0,3);
        Debug.Log(guids[rand]);
        // guids[rand]

        //Debug.Log("�������! ��� �ŷ��Ͻǰǰ���?");
        //Debug.Log("������ ���� ���� ������ ���Դٱ���!");
        //Debug.Log("��ҿɼ�");
        //Debug.Log("�������! ��� �ŷ��Ͻǰǰ���?");
        //Debug.Log("�������! ��� �ŷ��Ͻǰǰ���?");
    }
}
