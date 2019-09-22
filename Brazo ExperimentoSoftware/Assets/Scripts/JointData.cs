using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointData : MonoBehaviour
{
    public float Max;
    public float Min;
    public float initAngle;
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
        JointTextBox.text = initAngle.ToString("F2");
    }


    public void Rotate(bool way){
        switch(angleWay){
            case AngleAxis.X:
                if(way){
                    if(this.gameObject.transform.eulerAngles.x + 5f > Max)return;
                    this.gameObject.transform.Rotate(5f, 0f, 0f, Space.Self);
                }else{
                    if(this.gameObject.transform.eulerAngles.x - 5f < Min)return;
                    this.gameObject.transform.Rotate(-5f, 0f, 0f, Space.Self);
                }
                JointTextBox.text = this.gameObject.transform.eulerAngles.x.ToString("F2");
                break;
            case AngleAxis.Y:
                if(way){
                    if(this.gameObject.transform.eulerAngles.y + 5f > Max)return;
                    this.gameObject.transform.Rotate(0f, 5f, 0f, Space.Self);
                }else{
                    if(this.gameObject.transform.eulerAngles.y - 5f < Min)return;
                    this.gameObject.transform.Rotate(0f, -5f, 0f, Space.Self);
                }
                JointTextBox.text = this.gameObject.transform.eulerAngles.y.ToString("F2");
                break;
            case AngleAxis.Z:
                if(way){
                    if(this.gameObject.transform.eulerAngles.z + 5f > Max)return;
                    this.gameObject.transform.Rotate(0f, 0f, 5f, Space.Self);
                }else{
                    if(this.gameObject.transform.eulerAngles.z - 5f < Min)return;
                    this.gameObject.transform.Rotate(0f, 0f, -5f, Space.Self);
                }
                JointTextBox.text = this.gameObject.transform.eulerAngles.z.ToString("F2");
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
