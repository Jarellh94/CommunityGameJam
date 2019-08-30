using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    public GameObject target;
    public GameObject regTop;
    public GameObject actTop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        target.GetComponent<RoomDoor>().Open();
        regTop.SetActive(false);
        actTop.SetActive(true);
        StartCoroutine(TurnOffButton());
    }  

    IEnumerator TurnOffButton()
    {
        yield return new WaitForSeconds(1);
        regTop.SetActive(true);
        actTop.SetActive(false);
    }
}
