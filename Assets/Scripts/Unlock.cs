using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public List<Placement> triggers;
    public Interactable door;

    bool unlocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckUnlocked()
    {
        bool check = true;
        foreach (var trigger in triggers)
        {
            if(!trigger.IsActivated())
            {
                check = false;
            }
        }

        if(check)
        {
            if(!unlocked)
            {
                unlocked = true;
                door.Interact();
            }
        }
        else
        {
            if(unlocked)
            {
                unlocked = false;
                door.DeInteract();
            }
        }
    }
}
