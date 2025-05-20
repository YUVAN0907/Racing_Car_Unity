using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheel Collider")]
    public WheelCollider FrontLeftwheelCollider;
    public WheelCollider BackLeftwheelCollider;
    public WheelCollider BackRightwheelCollider;
    public WheelCollider FrontRightWheelCollider;

    [Header("Wheel Transformer")]
    public Transform FrontLeftwheelTransformer;
    public Transform BackLeftwheelTransformer;
    public Transform BackRightwheelTransformer;
    public Transform FrontRightWheelTransformer;
    [Header("Car Steering")]
    public float wheeltorque = 35f;
    private float presentturnAngle = 0f;

    [Header("Car Engine")]
    public float accelerateforce = 300f;
    public float breakforce = 3000f;
    private float presentbreakforce = 0f;
    private float presentaccelerate = 0f;

    public AudioSource audioSource;
    public AudioClip accesound;
    public AudioClip slowsound;
    public AudioClip stopsound;


    private void MoveCar()
    {
        FrontLeftwheelCollider.motorTorque = presentaccelerate;
        FrontRightWheelCollider.motorTorque = presentaccelerate;
        BackLeftwheelCollider.motorTorque = presentaccelerate;
        BackRightwheelCollider.motorTorque = presentaccelerate;
        presentaccelerate = accelerateforce * SimpleInput.GetAxis("Vertical");

        if(presentaccelerate > 0)
        {
            audioSource.PlayOneShot(accesound, 0.2f);
        }
        else if(presentaccelerate < 0)
        {
            audioSource.PlayOneShot(slowsound, 0.2f);
        }
        else if(presentaccelerate == 0){
            audioSource.PlayOneShot(stopsound, 0.1f);
        }

    }
    private void CarSteering()
    {
        presentturnAngle = wheeltorque * SimpleInput.GetAxis("Horizontal");
        FrontLeftwheelCollider.steerAngle = presentturnAngle;
        FrontRightWheelCollider.steerAngle = presentturnAngle;
    }
    private void Update()
    {
        MoveCar();
        CarSteering();
        SteeringWheels(FrontLeftwheelCollider, FrontLeftwheelTransformer);
        SteeringWheels(FrontRightWheelCollider,FrontRightWheelTransformer);
        SteeringWheels(BackLeftwheelCollider, BackLeftwheelTransformer);
        SteeringWheels(BackRightwheelCollider, BackRightwheelTransformer);
        
    }
    void SteeringWheels(WheelCollider wc,Transform wt)
    {
        Vector3 position;
        Quaternion rotation;

        wc.GetWorldPose(out position, out rotation);

        wt.position = position;
        wt.rotation = rotation;
    }
    public void ApplyBreak()
    {
        StartCoroutine(CarBreaks());
       

    }
    IEnumerator CarBreaks()
    {
        presentbreakforce = breakforce;

        FrontLeftwheelCollider.brakeTorque = presentbreakforce;
        FrontRightWheelCollider.brakeTorque = presentbreakforce;
        BackLeftwheelCollider.brakeTorque = presentbreakforce;
        BackRightwheelCollider.brakeTorque = presentbreakforce;

        yield return new WaitForSeconds(2f);

        presentbreakforce = 0f;

        FrontLeftwheelCollider.brakeTorque = presentbreakforce;
        FrontRightWheelCollider.brakeTorque = presentbreakforce;
        BackLeftwheelCollider.brakeTorque = presentbreakforce;
        BackRightwheelCollider.brakeTorque = presentbreakforce;


    }
}
