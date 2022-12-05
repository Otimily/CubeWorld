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
        // 오브젝트 찾기

        // 거의 안쓰인다.
        Cube = GameObject.Find("Cube");
        child1 = transform.Find("Cylinder");

        // 2순위로 많이 쓰임
        Capsule = GameObject.FindGameObjectWithTag("MyCapsule"); // GameObject.FindGameObjectsWithTag - 배열로 전달
        child2 = transform.GetChild(1); // 자식의 인덱스로 찾기
                
        // 가장 유용 - 천천히 활용 / 1순위로 많이 쓰인다.
        child3 = transform.GetComponentInChildren<MeshCollider>().transform;

    }
}
