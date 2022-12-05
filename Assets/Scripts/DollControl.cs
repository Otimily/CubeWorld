using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollControl : MonoBehaviour
{
    public float runSpeed = 6.0f; //�ٴ� �ӵ�
    public float rotationSpeed = 360.0f; //ĳ���� ȸ�� �ӵ�

    bool Doll_Walk = false; //�ٱ�� �ȱ� �����ϱ� ���� bool��

    CharacterController pcController; //ĳ���� ��Ʈ�ѷ� ������Ʈ�� ����ϱ� ���� ���� ����

    Vector3 direction; //���� ��
    Animator animator; //�ִϸ����� ������Ʈ�� ����ϱ� ���� ���� ����

    void Start()
    {
        pcController = GetComponent<CharacterController>(); //ĳ���� ��Ʈ�ѷ� ������Ʈ ��������
        animator = GetComponentInChildren<Animator>(); //���� ���ϸ����� ���
        animator = GetComponent<Animator>(); //�ִϸ����� ������Ʈ ��������

    }


    void Update()
    {
        CharacterControl_Slerp(); //�������� ������ �Լ�
        animator.SetFloat("speed",pcController.velocity.magnitude); //��Ʈ�ѷ��� �ӵ� ���� �ִϸ������� Speed�� ����
        animator.SetBool("Doll_Walk", Doll_Walk); //�ȱ�, �ٱ� üũ���� �ִϸ����� IsRun�� ����

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetTrigger("Fly"); // Fly �ִϸ��̼��� �ִϸ����� Trigger�� ����
        //}

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    animator.SetTrigger("Jump"); //�ִϸ����� Jump �ִϸ��̼� ����
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

    private void CharacterControl_Slerp() //ĳ���� ������ �޼ҵ� ����
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
