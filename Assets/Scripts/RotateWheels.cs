using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] private HingeJoint leftSteerJoint;
    [SerializeField] private HingeJoint rightSteerJoint;
    private JointMotor leftSteer;
    private JointMotor rightSteer;
    //private HingeJoint backJoint;
    //private JointMotor backSteer;
    //private HingeJoint forwardDrive;
    //private JointMotor forwardMotor;
    [SerializeField] private HingeJoint rightDrive;
    //[SerializeField] private HingeJoint leftDrive;
    private JointMotor leftMotor;
    private JointMotor rightMotor;
    private void Start()
    {
        //leftMotor = leftDrive.motor;
        rightMotor = rightDrive.motor;
        leftSteer = leftSteerJoint.motor;
        rightSteer = rightSteerJoint.motor;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //leftDrive.useMotor = true;
            rightDrive.useMotor = true;
            //leftMotor.targetVelocity = 500f;
            rightMotor.targetVelocity = 2000f;
            //leftDrive.motor = leftMotor;
            rightDrive.motor = rightMotor;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //leftDrive.useMotor = true;
            rightDrive.useMotor = true;
            rightMotor.targetVelocity = -1000f;
            //leftMotor.targetVelocity = -500f;
            //leftDrive.motor = leftMotor;
            rightDrive.motor = rightMotor;
        }
        else
        {
            //leftDrive.useMotor = false;
            rightDrive.useMotor = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            leftSteerJoint.useMotor = true;
            leftSteer.targetVelocity = -200f;
            leftSteerJoint.motor = leftSteer;
            rightSteerJoint.useMotor = true;
            rightSteer.targetVelocity = -200f;
            rightSteerJoint.motor = rightSteer;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            leftSteerJoint.useMotor = true;
            leftSteer.targetVelocity = 200f;
            leftSteerJoint.motor = leftSteer;
            rightSteerJoint.useMotor = true;
            rightSteer.targetVelocity = 200f;
            rightSteerJoint.motor = rightSteer;
        }
        else
        {
            leftSteerJoint.useMotor = false;
            rightSteerJoint.useMotor = false;
        }
    }
}
