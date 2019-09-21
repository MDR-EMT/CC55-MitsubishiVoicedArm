using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointData : MonoBehaviour
{
    public float Max;
    public float Min;
    public Text textBox;


    public void Rotate(bool way){
        if(way){
            if(this.gameObject.transform.rotation.y + 5f > Max) return;
            this.gameObject.transform.Rotate(0f, 5f, 0f, Space.Self);
        }
        if(this.gameObject.transform.rotation.y - 5f > Min) return;
        this.gameObject.transform.Rotate(0f, -5f, 0f, Space.Self);
    }

    public void UpdateTextBox(){
        textBox.text = this.gameObject.transform.rotation.y.ToString();
    }
}
