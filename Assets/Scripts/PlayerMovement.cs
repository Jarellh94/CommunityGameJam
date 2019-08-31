using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;

    float currSpeed = 0f;
    public LayerMask groundMask;
    public float jumpStrength;

    bool isGrounded = false;
    Rigidbody rig;

    public float walkTimeBetweenSteps = .8f;
    public float runTimeBetweenSteps = .2f;
    float stepTimer = 0;
    float stepInterval = 0;
    AudioSource mySource;

    // Start is called before the first frame update
    void Start()
    {
        currSpeed = walkSpeed;
        stepInterval = walkTimeBetweenSteps;
        rig = GetComponent<Rigidbody>();
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currSpeed = sprintSpeed;
            stepInterval = runTimeBetweenSteps;
        }
        else
        {
            currSpeed = walkSpeed;
            stepInterval = walkTimeBetweenSteps;
        }

        float xAxis = Input.GetAxis("Horizontal") * currSpeed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * currSpeed * Time.deltaTime;

        transform.Translate(xAxis, 0, yAxis);

        if(xAxis > 0 || yAxis > 0)
        {
            stepTimer += Time.deltaTime;

            if(stepTimer > stepInterval)
            {
                mySource.Play();
                stepTimer = 0;
            }
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position - transform.up * 1f, transform.up * -1f, out hit, .04f, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
    private void Update() {
        /* if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector3.up * jumpStrength);
            isGrounded = false;
        }*/
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position - transform.up * 1f, transform.position - transform.up * 1.04f);
    }

}
