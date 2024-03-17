using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMove : MonoBehaviour
{
    Transform playerPosition;
    public bool droneMove = false;
    private float droneSpeed = 15f;
    private float droneRotateSpeed = 70f;
    Vector3 droneVec;
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        transform.position = playerPosition.position;
    }

    void Update()
    {
        
        if (droneMove == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * droneSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * droneSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * droneSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.down * droneSpeed * Time.deltaTime);
            }
        }
    }

    public void SetPosition()
    {
        transform.position = playerPosition.position;
    }

    public void SetTrueMove()
    {
        droneMove = true;
    }
    public void setFalseMove()
    {
        droneMove = false;
    }
}
