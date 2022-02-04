using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    private float currentDrift;

    private Rigidbody rb;
    private Vector3 forceEQ;
    private ForceMode force;
    public float forceScale;

    private bool reverse;

    [SerializeField]
    [Header("Forces")]
    private float movementSpeed;
    private Vector3 directionalForce;

    [Header("Mins & Maxes")]
    public float maxRotation;
    public float minRotation;
    public float maxAcceptableDrift;
    public float minAcceptableDrift;

    // Start is called before the first frame update
    void Start()
    {
        force = ForceMode.Force;
        rb = GetComponent<Rigidbody>();
        reverse = false;

        //apply initial force
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        physicsHandler();
        centerOnTrack();
        keepCarUpright();
    }

    void centerOnTrack()
    {
        currentDrift = this.transform.localPosition.z;
        if (currentDrift > maxAcceptableDrift)
        {
            //Debug.Log("applying force - max");
            forceEQ = -transform.forward * forceScale;
            rb.AddForceAtPosition(forceEQ, this.transform.position, force);
        }
        if (currentDrift < minAcceptableDrift)
        {
            //Debug.Log("applying force + min");
            forceEQ = transform.forward * forceScale;
            rb.AddForceAtPosition(forceEQ, this.transform.position, force);
        }
    }
    
    void keepCarUpright()
    {
        Quaternion xRotation = transform.rotation;
        xRotation.x = Mathf.Clamp(xRotation.x, minRotation, maxRotation);
        this.transform.rotation = xRotation;
    }

    void moveTrain(Vector3 forceDirection)
    {
        rb.AddForce(directionalForce, force);
    }

    void physicsHandler()
    {
        float centerCar = GetComponent<BoxCollider>().bounds.size.x / 2;
        float maxX = TrainTrack.getTrackEnd();
        float minX = TrainTrack.getTrackStart();

        if (this.transform.position.x >= maxX && reverse == false)
        {
            //Debug.Log("reversing movement");
            reverse = true;
            haltMovement();
            moveTrain(chooseDirectionalForce());
        }
        if (this.transform.position.x <= minX && reverse == true)
        {
            //Debug.Log("going back forward");
            reverse = false;
            haltMovement();
            moveTrain(chooseDirectionalForce());
        } else
        {
            moveTrain(chooseDirectionalForce());
        }
    }

    void haltMovement()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private Vector3 chooseDirectionalForce()
    {
        if (reverse == false)
        {
            directionalForce = transform.right * movementSpeed;
            return directionalForce;
        } else
        {
            directionalForce = -transform.right * movementSpeed;
            return directionalForce;
        }
    }
}
