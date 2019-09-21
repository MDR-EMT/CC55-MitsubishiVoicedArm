using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointData : MonoBehaviour
{
    public float Max;
    public float Min;
    public float initAngle;
    public enum AngleAxis{X,Y,Z};
    public Text textBox;
    public TextEditorController textEditor;

    public TextEditorController.movParts movePart;


    public void Rotate(int way){
        float rotMove = Mathf.Pow(-1,way)*5f;
        if(this.gameObject.transform.eulerAngles.y + rotMove > Max) return;
        if(this.gameObject.transform.eulerAngles.y + rotMove < Min) return;
        this.gameObject.transform.Rotate(0f, rotMove, 0f, Space.Self);
        UpdateTextBox();
        UpdateTextInput();
    }

    //Imprimir en la sección de Script
    public void UpdateTextBox(){
        textBox.text = this.gameObject.transform.eulerAngles.y.ToString();
        textEditor.WriteCommands(TextEditorController.commandLines.ROT, this.gameObject);
    }

    //Imprimir en la sección de GUI
    public void UpdateTextInput(){
        textEditor.UpdateText(movePart, this.gameObject);
    }
}
