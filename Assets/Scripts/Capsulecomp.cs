using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capsulecomp : MonoBehaviour
{
    public GameObject go;
    public Transform tr;
    public MeshFilter mf;
    public CapsuleCollider col;
    public MeshRenderer mr;

    void Start()
    {
        tr = go.transform;

        mf = go.GetComponent<MeshFilter>();
        col = go.GetComponent<CapsuleCollider>();
        mr = go.GetComponent<MeshRenderer>();
    }

    void Update()
    {

    }
}
