using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cubecomp : MonoBehaviour
{
    public GameObject go;
    public Transform tr;
    public MeshFilter mf;
    public BoxCollider col;
    public MeshRenderer mr;

    void Start()
    {
        // 2���� ������Ʈ�� �⺻������ �޷��ְ� �Ǿ �ڵ����� �����ȴ�.
        // GameObject
        // transform
        go = gameObject;
        tr = transform;

        mf = GetComponent<MeshFilter>();
        col = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }
}
