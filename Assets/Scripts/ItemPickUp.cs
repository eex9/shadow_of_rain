using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public string item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        HasInventory inv = (HasInventory) other.gameObject.GetComponent("HasInventory");
        if(inv == null) return;
        inv.add(item);
        Destroy(this.gameObject);
    }

}
