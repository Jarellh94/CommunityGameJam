using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;
    public float scroll = 0;

    int currSlot = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SwitchLeft();
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SwitchRight();
        }
    }

    void SwitchLeft()
    {
        if(currSlot < inventory.Count)
        {
            currSlot++;
        }
    }

    void SwitchRight()
    {
        if(currSlot > 1)
        {
            currSlot--;
        }
    }
}
