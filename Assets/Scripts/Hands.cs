using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Moveable holding;
    public Animator toolTipAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Pickup(Moveable item)
    {
        if(!holding)
        {
            holding = item;
            holding.GetComponent<Rigidbody>().useGravity = false;
            holding.GetComponent<BoxCollider>().isTrigger = true;
            holding.transform.SetParent(transform);
            holding.transform.localPosition = Vector3.zero;
            holding.gameObject.layer = 9;
        }
        
    }

    public void Place(Transform target)
    {
        if(holding)
        {
            Transform holdTransform = holding.transform;
            //holdTransform.parent = target; //THIS IS A PROBLEM. WHAT IF THE ROOMS MOVE, THIS STUFF WILL FALL DOWN. GOTTA SET THE PARENT AS THE CURRENT ROOM.
            holdTransform.GetComponent<Moveable>().Dropped();
            holdTransform.position = target.position + new Vector3(0f, 2f, 0f);
            holding.GetComponent<Rigidbody>().useGravity = true;
            holding.GetComponent<BoxCollider>().isTrigger = false;
            holding.gameObject.layer = 0;
            holding = null;
        }
        else
        {
            toolTipAnimator.SetTrigger("CantPlace");
        }
    }

    public void Drop()
    {
        if(holding)
        {
            holding.GetComponent<Moveable>().Dropped();
            holding.GetComponent<Rigidbody>().useGravity = true;
            holding.GetComponent<BoxCollider>().isTrigger = false;
            holding.gameObject.layer = 0;
            holding = null;
        }
    }
}
