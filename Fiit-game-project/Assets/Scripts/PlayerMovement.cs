using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40;

    private float horizontalMove;
    private bool jump;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
            jump = true;
    }

    private bool isGrounded = false; // ��� ��� ������ ���� ������� ����, ��� � �����

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;

    } //���������� ����� ���� �������������  ���������� ������� � ������� ������������



    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }  //���������� �����, ���������� "����� �� �������� ����� ���������" (���� ��������������� OnCollisionEnter2D)

    //������� ���������� - ������ � ��� ����� ������� physics
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
