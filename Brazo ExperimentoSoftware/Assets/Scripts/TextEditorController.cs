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

    public enum commandLines {SAVE, LOAD, MOV, ROT, WHILE, WEND, OVRD};
    public enum movParts {WAIST, SHOUDLER, ELBOW, TWIST, PITCH, ROLL};

    void Start()
    {
        TextBox = GetComponent<Text>();
        WaistText.text ="";
        ShoulderText.text ="";
        ElbowText.text ="";
        TwistText.text ="";
        PitchText.text ="";
        RollText.text ="";
    }

    public void WriteCommands(commandLines order, GameObject mobile){
        TextBox.text += order.ToString() + mobile.transform.position.ToString() + "\n";
    }

    public void UpdateText(movParts option, GameObject mobile){
        switch(option){
            case movParts.WAIST:
                WaistText.text = mobile.transform.rotation.y.ToString();
                break;
            case movParts.SHOUDLER:
                ShoulderText.text = mobile.transform.rotation.y.ToString();
                break;
            case movParts.ELBOW:
                ElbowText.text = mobile.transform.rotation.y.ToString();
                break;
            case movParts.TWIST:
                TwistText.text = mobile.transform.rotation.y.ToString();
                break;
            case movParts.PITCH:
                PitchText.text = mobile.transform.rotation.y.ToString();
                break;
            case movParts.ROLL:
                RollText.text = mobile.transform.rotation.y.ToString();
                break;
            default:
                break;
        }
    }
}
