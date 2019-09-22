using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public TextEditorController textScript;

    public void RotLeft(GameObject mobile){
        JointData jointScript = mobile.GetComponent<JointData>();
        jointScript.Rotate(false);

        /*Transform mobileRotation = mobile.GetComponent<Transform>();
        float minAngle = mobile.GetComponent<JointData>().Min;
        if(mobileRotation.eulerAngles.y - 5f < minAngle) return;
        mobileRotation.Rotate(0f, -5f, 0f, Space.World);
        textScript.WriteCommands(TextEditorController.commandLines.ROT, mobile);
        mobile.GetComponent<JointData>().UpdateTextInput();*/

    }
    public void RotRight(GameObject mobile){
        JointData jointScript = mobile.GetComponent<JointData>();
        jointScript.Rotate(true);
        /*Transform mobileRotation = mobile.GetComponent<Transform>();
        float maxAngle = mobile.GetComponent<JointData>().Max;
        if(mobileRotation.eulerAngles.y + 5f > maxAngle) return;
        mobileRotation.Rotate(0f, 5f, 0f, Space.World);
        textScript.WriteCommands(TextEditorController.commandLines.ROT, mobile);
        mobile.GetComponent<JointData>().UpdateTextInput();*/
    }
}
