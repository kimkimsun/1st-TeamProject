using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class SniferGun : Gun
{
    public Camera snCamera;

    private void Awake()
    {
        snCamera = Camera.main;
    }
    protected override void Start()
    {
        base.Start();
        maxBullet = 12;
        curBullet = 12;
        fireRate = 1.2f;
        damage = 50f;
        items[1] = gameObject;
        snCamera.GetComponent<Camera>();
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

    public override void ZoomCamera()
    {
        snCamera.fieldOfView = 15;
    }

    public override void ZoomReturn()
    {
        snCamera.fieldOfView = 60;
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