using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBuff : Potion
{
    new int hpBuff= 30; //체력회복

    public void Use() //포션 사용시
    {
        GameObject target;
        target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();
        player.Hp += hpBuff;     

        this.useable = true; //이 템 사용되었음
        Debug.Log(name + " 을 사용 하였습니다.");
        Debug.Log("현재체력" + player.Hp); //변하는지 확인용
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Use();
        }
    }
    void Start()
    {
        items[4] = gameObject;
    }
    void Update()
    {
        Rotate();
    }
}
