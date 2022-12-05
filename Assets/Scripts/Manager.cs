using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Capsule;

    public Transform child1;
    public Transform child2;
    public Transform child3;
    
    void Start()
    {
        // ������Ʈ ã��

        // ���� �Ⱦ��δ�.
        Cube = GameObject.Find("Cube");
        child1 = transform.Find("Cylinder");

        // 2������ ���� ����
        Capsule = GameObject.FindGameObjectWithTag("MyCapsule"); // GameObject.FindGameObjectsWithTag - �迭�� ����
        child2 = transform.GetChild(1); // �ڽ��� �ε����� ã��
                
        // ���� ���� - õõ�� Ȱ�� / 1������ ���� ���δ�.
        child3 = transform.GetComponentInChildren<MeshCollider>().transform;

    }
}
