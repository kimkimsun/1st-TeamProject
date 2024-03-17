using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Rifer : Gun
{
    protected override void Start()
    {
        base.Start();
        maxBullet = 50;
        curBullet = 50;
        fireRate = 0.01f;
        damage = 12f;
        items[0] = gameObject;
        bulletRb = bul.GetComponent<Rigidbody>();
        StartCoroutine(FireSpeedCo());
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
            isCool = true;
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