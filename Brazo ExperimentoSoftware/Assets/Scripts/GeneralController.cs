using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public TextEditorController textScript;
    public void RotLeft(GameObject mobile){
        Transform mobileRotation = mobile.GetComponent<Transform>();
        float minAngle = mobile.GetComponent<JointData>().Min;
        if(mobileRotation.rotation.y - 5f < minAngle) return;
        mobileRotation.Rotate(0f, -5f, 0f, Space.Self);
        textScript.WriteCommands(TextEditorController.commandLines.ROT, mobile);
    }
    public void RotRight(GameObject mobile){
        Transform mobileRotation = mobile.GetComponent<Transform>();
        float maxAngle = mobile.GetComponent<JointData>().Max;
        if(mobileRotation.rotation.y + 5f > maxAngle) return;
        mobileRotation.Rotate(0f, 5f, 0f, Space.Self);
        textScript.WriteCommands(TextEditorController.commandLines.ROT, mobile);
    }
}
