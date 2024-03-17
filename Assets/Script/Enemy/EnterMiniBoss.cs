using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMiniBoss : MonoBehaviour
{
    public GameObject MiniBoss;
    MeshRenderer mesh;
    BoxCollider col;
    Player player;

    public Transform movePoint;

    bool isOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        mesh=gameObject.GetComponent<MeshRenderer>();
        col=gameObject.GetComponent<BoxCollider>();
        player=FindObjectOfType<Player>();

        mesh.enabled=false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"&&isOnce==true)
        {
            //col.isTrigger = true;
            Instantiate(MiniBoss, movePoint.position, movePoint.rotation);
            isOnce = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
