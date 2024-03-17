using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMove : MonoBehaviour
{
    Transform move;
    // Start is called before the first frame update
    void Start()
    {
        move=gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.forward * -0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.up * -1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up * 1f);
        }

    }
}
