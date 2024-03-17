using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isRun;

    private float moveSpeed;
    public bool isPlayerMove = true;
    CharacterController controller;
    // 중력값 변수
    public float gravity = -9.8f;
    // 수직 속력 변수
    public float yVelocity = 0;
    // 점프력 변수
    public float jumpPower = 5f;
    // 점프상태 변수
    public bool isJumping = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 이동속도 초기화
        moveSpeed = IsRun();

        // 사용자에게 입력 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동방향 정하기
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        if (isPlayerMove == true)
        {
            // 카메라 기준으로 방향 전환
            dir = Camera.main.transform.TransformDirection(dir);
           
            // 만약 바닥에 착지된 상태였다면
            if (controller.collisionFlags == CollisionFlags.Below)
            {
                // 점프롤 한 뒤였다면
                if (isJumping)
                {
                    isJumping = false;
                    yVelocity = 0;
                }
            }

            // spacebar 누를 시, 바닥에 착지된 상태라면
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                yVelocity = jumpPower;
                isJumping = true;
            }

            // 캐릭터의 수직 속도에 중력값 적용
            yVelocity += gravity * Time.deltaTime;
            dir.y = yVelocity;

            // 이동속도에 맞춰 이동시키기
            controller.Move(dir * moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator RunSound()
    {
        yield return new WaitForSeconds(1.2f);
        isRun = false;
    }
    float IsRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isRun)
            {
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    //마지막
                    //SoundManager.instance.StopSE(playerRunning);
                    //Destroy(SoundManager.instance);
                }
                else
                {
                    //SoundManager.instance.PlaySE(playerRunning);
                    isRun = true;
                    StartCoroutine(RunSound());
                }
            }
            return 10f;
        }
        else
        {
            return 4f;
        }
    }
}