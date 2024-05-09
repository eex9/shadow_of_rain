using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasInventory : MonoBehaviour
{
    public List<string> inv;
    // Start is called before the first frame update
    void Start()
    {
        inv = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool add(string item)
    {
        inv.Add(item);
        return true;
    }
}
