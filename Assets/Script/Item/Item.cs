using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using System;

public  class Item : MonoBehaviour
{
    public GameObject [] items = new GameObject[7];

    protected int rotateSpeed = 15;
    public bool useable = false;

    public void Rotate()
    {
        if (gameObject.GetComponent<Potion>() != null || gameObject.GetComponent<Gun>() != null)
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    public void Delete(bool useable)
    {
        if (useable)
        {
            Destroy(gameObject);
        }
    }


}


