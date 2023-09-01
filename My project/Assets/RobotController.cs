using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for sending commands to the robot
public class RobotController : MonoBehaviour
{
    public void ControlGripper()
    {
        SocketController.SendCommand("gripper");
    }
    public void moveJoints()
    {
        SocketController.SendCommand(ConfirmBehaviour.jointVals);
    }
}
