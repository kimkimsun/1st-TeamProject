using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Shotgun : Gun
{
    public  GameObject fierPos0;
    public  GameObject fierPos1;
    public  GameObject fierPos2;
    public  GameObject fierPos3;
    public  GameObject fierPos4;
    public  GameObject fierPos5;
    public  GameObject fierPos6;



    protected override void Start()
    {
        base.Start();
        maxBullet = 8;
        curBullet = 8;
        fireRate = 0.7f;
        damage = 5f;
        items[3] = gameObject;
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
            isCool = true;
            Bullet instantBullet = Instantiate(bul, fierPos.transform.position, fierPos.transform.rotation);
            Bullet instantBullet1 = Instantiate(bul, fierPos0.transform.position, fierPos.transform.rotation);
            Bullet instantBullet2 = Instantiate(bul, fierPos1.transform.position, fierPos.transform.rotation);
            Bullet instantBullet3 = Instantiate(bul, fierPos2.transform.position, fierPos.transform.rotation);
            Bullet instantBullet4 = Instantiate(bul, fierPos3.transform.position, fierPos.transform.rotation);
            Bullet instantBullet5 = Instantiate(bul, fierPos4.transform.position, fierPos.transform.rotation);
            Bullet instantBullet6 = Instantiate(bul, fierPos5.transform.position, fierPos.transform.rotation);
            Bullet instantBullet7 = Instantiate(bul, fierPos6.transform.position, fierPos.transform.rotation);
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