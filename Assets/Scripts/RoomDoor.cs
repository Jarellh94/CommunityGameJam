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
    AudioSource mySource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mySource = GetComponent<AudioSource>();
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
        mySource.Play();
    }

    public void Close() 
    {
        anim.SetTrigger("Close");
        mySource.Play();
    }

    public void SwitchDoor()
    {
        manager.SwitchDoors(type);
    }
}
