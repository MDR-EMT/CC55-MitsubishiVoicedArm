using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditorController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TextBox;
    public Text WaistText;
    public Text ShoulderText;
    public Text ElbowText;
    public Text TwistText;
    public Text PitchText;
    public Text RollText;

    public enum commandLines {SAVE, LOAD, MOV, ROT, WHILE, WEND, OVRD, DEF,POS};
    public enum movParts {WAIST, SHOUDLER, ELBOW, TWIST, PITCH, ROLL};

    void Start()
    {
        TextBox.text ="";

        WaistText.text ="";
        ShoulderText.text ="";
        ElbowText.text ="";
        TwistText.text ="";
        PitchText.text ="";
        RollText.text ="";
    }

    public void WriteCommands(commandLines order, GameObject mobile){
        TextBox.text += order.ToString() +mobile.transform.position.ToString("F2") + mobile.transform.eulerAngles.ToString("F2") + "\n";
    }
}
