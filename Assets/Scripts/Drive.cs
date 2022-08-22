using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public GameObject leftHub;
    public GameObject rightHub;
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion leftTurn = Quaternion.Euler(0, -20, 0);
            rightHub.transform.localRotation = Quaternion.RotateTowards(rightHub.transform.localRotation, leftTurn, 1.1f);
            leftHub.transform.localRotation = Quaternion.RotateTowards(leftHub.transform.localRotation, leftTurn, 1.1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Quaternion rightTurn = Quaternion.Euler(0, 20, 0);
            rightHub.transform.localRotation = Quaternion.RotateTowards(rightHub.transform.localRotation, rightTurn, 1.1f);
            leftHub.transform.localRotation = Quaternion.RotateTowards(leftHub.transform.localRotation, rightTurn, 1.1f);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Quaternion leftTurn = Quaternion.Euler(0, 0, 0);
            rightHub.transform.localRotation = Quaternion.RotateTowards(rightHub.transform.localRotation, leftTurn, 1.1f);
            leftHub.transform.localRotation = Quaternion.RotateTowards(leftHub.transform.localRotation, leftTurn, 1.1f);
        }
    }
}


[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
