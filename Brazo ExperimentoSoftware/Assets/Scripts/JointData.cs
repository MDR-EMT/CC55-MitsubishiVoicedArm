using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointData : MonoBehaviour
{
    public float Max;
    public float Min;
    public float currentAngle;
    public JointData.AngleAxis angleWay;
    public Text JointTextBox;
    public TextEditorController textEditor;
    public TextEditorController.movParts movePart;

    public enum AngleAxis{X,Y,Z};

    private void Start() {
        switch(angleWay){
            case AngleAxis.X:
                JointTextBox.text = this.gameObject.transform.eulerAngles.x.ToString("F2");
                break;
            case AngleAxis.Y:
                JointTextBox.text = this.gameObject.transform.eulerAngles.y.ToString("F2");
                break;
            case AngleAxis.Z:
                JointTextBox.text = this.gameObject.transform.eulerAngles.z.ToString("F2");
                break;
            default:
                break;
        }
        JointTextBox.text = currentAngle.ToString("F2");
        Debug.Log(transform.eulerAngles);
    }


    public void Rotate(bool way){
        int p = way ? 1 : -1;
        float tempAngle = this.currentAngle + p*5f;
        Debug.Log(tempAngle);
        if(tempAngle > Max || tempAngle < Min) return;

        switch(angleWay){
            case AngleAxis.X:
                this.gameObject.transform.Rotate(p*5f,0f,0f,Space.Self);
                this.currentAngle = tempAngle;
                JointTextBox.text = currentAngle.ToString("F2");
                break;
            case AngleAxis.Y:
                this.gameObject.transform.Rotate(0f,p*5f,0f,Space.Self);
                this.currentAngle = tempAngle;
                JointTextBox.text = currentAngle.ToString("F2");
                break;
            case AngleAxis.Z:
                this.gameObject.transform.Rotate(0f,0f,p*5f,Space.Self);
                this.currentAngle = tempAngle;
                JointTextBox.text = currentAngle.ToString("F2");
                break;
            default:
                break;
        }
        UpdateTextBox();
        //UpdateTextInput();
    }

    //Imprimir en la sección de Script
    public void UpdateTextBox(){
        textEditor.WriteCommands(TextEditorController.commandLines.POS, this.gameObject);
    }
}
