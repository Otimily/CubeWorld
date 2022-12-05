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
        // 2가지 컴포넌트는 기본적으로 달려있게 되어서 자동으로 생성된다.
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
