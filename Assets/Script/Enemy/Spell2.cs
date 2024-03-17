using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spell2 : MonoBehaviour
{
    public Player player;
    public GameObject spell2;

    public int spellDamge;

    public Transform[] areaPoint;

    public bool isTrigger;
    public int skillCount = 8;

    // Start is called before the first frame update
    void Start()
    {
        spellDamge = 10;
        isTrigger = false;
        player = FindObjectOfType<Player>();
    }

    IEnumerator Summon()
    {
        //yield return new WaitForSeconds(2);     //시작한 후 2초 뒤에 시작하게 설정

        while (skillCount > 0)
        {
            skillCount--;
            SpellArea(skillCount);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpellArea(int skillCount)
    {
        Instantiate(spell2, areaPoint[skillCount].position, areaPoint[skillCount].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger == true)
        {
            StartCoroutine(Summon());
            isTrigger = false;
            skillCount = 8;
        }
    }
}
