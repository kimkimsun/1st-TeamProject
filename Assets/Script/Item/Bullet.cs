using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class Bullet : MonoBehaviour
{
    private float damage;


    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    void Start()
    {
        //Damage = 10;
        StartCoroutine(DestroyBullet());
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(Damage);
        Debug.Log(collision.gameObject.name);
        Debug.Log("콜리전충돌");
        if (collision.gameObject.tag != "Gun")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.GetComponent<Monster>() != null)
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("트리거충돌");
        if (other.gameObject.tag != "Gun")
        {
            //Destroy(gameObject);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}