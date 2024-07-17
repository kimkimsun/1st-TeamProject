using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int hp;
    private readonly int maxHp = 1000;

    public GameObject[] itemSlot = new GameObject[5];
    // 인벤토리
    public TextMeshProUGUI curHpTxt;
    // hp 텍스트
    public GameObject hitEffect;
    // 맞을 때 빨갛게 되는 것
    public Image weaponImage;

    public int Hp
    {
        get { return hp; }
        set
        { 
            if(hp >= maxHp)
                hp = maxHp;
            hp = value;
            curHpTxt.text = hp.ToString();
        }
    }

    private void Start()
    {
        hp = maxHp;
        hitEffect.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Monster>() != null)
        {
            Hp -= collision.gameObject.GetComponent<Monster>().atk;
            StartCoroutine(PlayerHitEffect());
        }
    }
    IEnumerator PlayerHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}