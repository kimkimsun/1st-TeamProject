using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreasureBox : MonoBehaviour
{
    private Item item;
    public Animator ani;
    GameObject copy;

/*    [SerializeField]
    private string openBox;*/

    private void Awake()
    {
        ani = GetComponent<Animator>();
        item = GetComponent<Item>();
    }

    public void OpenBox()
    {
        ani.SetTrigger("open");
        StartCoroutine(DropItem());
    }
    IEnumerator DropItem()
    {
        yield return new WaitForSeconds(2f);
        int random;
        random = Random.Range(0, 12);
        Debug.Log(random);
        if(random > 6)
            Destroy(gameObject);
        else
        { 
            copy = Instantiate(item.items[random]);
            copy.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }
}