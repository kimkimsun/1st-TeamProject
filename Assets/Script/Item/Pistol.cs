using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Pistol : Gun
{


    protected override void Start()
    {
        maxBullet = 12;
        curBullet = 12;
        fireRate = 0.5f;
        damage = 10f;

        items[2] = gameObject;
        bulletRb = bul.GetComponent<Rigidbody>();
    }



    IEnumerator FireSpeedCo() //연사속도
    {
        while (true)
        {
            if (isCool)
            {
                yield return new WaitForSeconds(fireRate);
                isCool = false;
            }
            yield return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
    }

    public override void Shoot()
    {
        if (curBullet > 0 && isCool == false)
        {
            //SoundManager.instance.PlaySE(shotSound);
            Bullet instantBullet = Instantiate(bul, fierPos.transform.position, fierPos.transform.rotation);
            instantBullet.Damage = damage;
            Rigidbody bulletRb = instantBullet.GetComponent<Rigidbody>();
            bulletRb.AddRelativeForce(Vector3.forward * fireSpeed * Time.deltaTime, ForceMode.Impulse);
            curBullet--;
            isCool = true;
            StartCoroutine(FireSpeedCo());
        }
        if (curBullet <= 0)
            StartCoroutine(Reload());
    }


    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        curBullet = maxBullet;
    }
}