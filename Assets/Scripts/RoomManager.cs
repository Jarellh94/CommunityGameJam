using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject entryDoor, exitDoor, tempDoor;

    public List<GameObject> rooms;
    public List<GameObject> currentRoomRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchDoors(DoorType type)
    {

        if(type == DoorType.EXIT)
        {
            //entryDoor.GetComponentInChildren<Animator>().SetTrigger("Cancel");

            entryDoor.transform.position = exitDoor.transform.position;
            exitDoor.transform.position = tempDoor.transform.position;
            tempDoor.transform.position = new Vector3(0, 50, 0);

        }
        else if(type == DoorType.ENTRANCE)
        {
            //exitDoor.GetComponentInChildren<Animator>().SetTrigger("Cancel");

            exitDoor.transform.position = entryDoor.transform.position;
            entryDoor.transform.position = tempDoor.transform.position;
            tempDoor.transform.position = new Vector3(0, 50, 0);
        }

    }

    public void SetTempDoor(DoorType type)
    {
        if(type == DoorType.EXIT)
        {
            tempDoor.transform.position = exitDoor.transform.position + new Vector3(0, 0, 70);
        }
        else if(type == DoorType.ENTRANCE)
        {
            tempDoor.transform.position = entryDoor.transform.position - new Vector3(0, 0, 70);
        }
    }
}
