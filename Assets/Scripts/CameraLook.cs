using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 50f;
    public float interactDistance = 5f;
    public GameObject defaultCursor, interactableCursor;
    public Hands hands;
    public LayerMask holdingMask;

    float mouseX = 0;
    float rotX;
    float mouseY = 0;
    float rotY;
    
    bool canInteract = false, canPlace = false, canMove = false;
    GameObject interactTarget;

    public float xRotation;
    public float yRotation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Turning();
        InteractCast();

        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.timeScale == 1)
                Cursor.lockState = CursorLockMode.Locked;

            if(canInteract)
            {
                interactTarget.transform.GetComponent<Interactable>().Interact();
            }
            else if(canPlace)
            {
                hands.Place(interactTarget.transform);
            }
            else if(canMove)
            {
                hands.Pickup(interactTarget.transform.GetComponent<Moveable>());
            }
            else
            {
                hands.Drop();
            }
            
        }
    }

    void InteractCast()
    {
        RaycastHit hit; 

        if(Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, ~holdingMask))
        {
            
            if(hit.transform.gameObject.CompareTag("Interactable"))
            {
                interactableCursor.SetActive(true);
                defaultCursor.SetActive(false);
                canInteract = true;
                canPlace = false;
                canMove = false;
                interactTarget = hit.transform.gameObject;
            }
            else if(hit.transform.gameObject.CompareTag("Moveable"))
            {
                interactableCursor.SetActive(true);
                defaultCursor.SetActive(false);
                canInteract = false;
                canPlace = false;
                canMove = true;
                interactTarget = hit.transform.gameObject;
            }
            else if(hit.transform.gameObject.CompareTag("Placeable"))
            {
                interactableCursor.SetActive(true);
                defaultCursor.SetActive(false);
                canInteract = false;
                canMove = false;
                canPlace = true;
                interactTarget = hit.transform.gameObject;
            }
            else
            {
                interactableCursor.SetActive(false);
                defaultCursor.SetActive(true);
                canInteract = false;
                canPlace = false;
                canMove = false;
                interactTarget = null;
            }
        }
        else
        {
            interactableCursor.SetActive(false);
            defaultCursor.SetActive(true);
            canInteract = false;
            canPlace = false;
            canMove = false;
            interactTarget = null;
        }
    }

    void Turning()
    {
        mouseX = Input.GetAxis("Mouse X");
        rotY = Mathf.Lerp(rotY, mouseX, sensitivity * Time.deltaTime);

        mouseY = Input.GetAxis("Mouse Y");
        rotX = Mathf.Lerp(rotX, -mouseY, sensitivity * Time.deltaTime);
        Vector3 headRot = new Vector3(0f, 0f, 0f);
        Vector3 bodyRot = new Vector3(0f, 0f, 0f);


        if(mouseY > 0)
        {
            headRot.x = -1;
        }
        else if(mouseY < 0)
        {
            headRot.x = 1;
        }

        if(mouseX > 0)
        {
            bodyRot.y = 1;
        }
        else if(mouseX < 0)
        {
            bodyRot.y = -1;
        }

        //transform.Rotate(rot, lookSensitivity * Time.deltaTime);
        //transform.Rotate(headRot * sensitivity * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(rotX, 0f, 0f), Space.Self);

        xRotation = transform.localRotation.x;
        yRotation = transform.localRotation.y;
        
        if(transform.localRotation.x > .68)
        {
            transform.localRotation = Quaternion.Euler(85, transform.localRotation.y, transform.localRotation.z);
        }

        if(transform.localRotation.x < -.68)
        {
            transform.localRotation = Quaternion.Euler(-85, transform.localRotation.y, transform.localRotation.z);
        } 

        //transform.parent.Rotate(bodyRot * sensitivity * Time.deltaTime, Space.World);
        transform.parent.Rotate(new Vector3(0f, rotY, 0f), Space.World);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * interactDistance);
    }
}
