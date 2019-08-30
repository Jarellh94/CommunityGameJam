using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    EXIT, ENTRANCE
}
public class RoomDoor : Interactable
{
    Animator anim;
    public DoorType type;
    public RoomManager manager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Interact()
    {
        Open();
    }

    public void Open()
    {
        manager.SetTempDoor(type);
        anim.SetTrigger("Open");
    }

    public void Close() 
    {
        anim.SetTrigger("Close");
    }

    public void SwitchDoor()
    {
        manager.SwitchDoors(type);
    }
}
