using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollControl : MonoBehaviour
{
    public float runSpeed = 6.0f; //뛰는 속도
    public float rotationSpeed = 360.0f; //캐릭터 회전 속도

    bool Doll_Walk = false; //뛰기와 걷기 구별하기 위한 bool값

    CharacterController pcController; //캐릭터 컨트롤러 컴포넌트를 사용하기 위한 변수 선언

    Vector3 direction; //방향 값
    Animator animator; //애니메이터 컴포넌트를 사용하기 위한 변수 선언

    void Start()
    {
        pcController = GetComponent<CharacterController>(); //캐릭터 컨트롤러 컴포넌트 가져오기
        animator = GetComponentInChildren<Animator>(); //하위 에니메이터 사용
        animator = GetComponent<Animator>(); //애니메이터 컴포넌트 가져오기

    }


    void Update()
    {
        CharacterControl_Slerp(); //움직임을 정리한 함수
        animator.SetFloat("speed",pcController.velocity.magnitude); //컨트롤러의 속도 값을 애니메이터의 Speed와 연결
        animator.SetBool("Doll_Walk", Doll_Walk); //걷기, 뛰기 체크값을 애니메이터 IsRun과 연결

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetTrigger("Fly"); // Fly 애니메이션을 애니메이터 Trigger와 연결
        //}

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    animator.SetTrigger("Jump"); //애니메이터 Jump 애니메이션 연결
        //}

        //if (Input.GetKeyDown(KeyCode.))
        //{
        //    Doll_Walk = true;
        //    runSpeed = 6.0f;
        //}

        //else
        //{
        //    Doll_Walk = false;
        //    runSpeed = 3.0f;
        //}

        
    }

    private void CharacterControl_Slerp() //캐릭터 움직임 메소드 정의
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }

        animator.SetFloat("Move", direction.sqrMagnitude);

        pcController.Move(direction * runSpeed * Time.deltaTime);

    }
}
