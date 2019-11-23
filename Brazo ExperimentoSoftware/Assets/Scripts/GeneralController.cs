using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System.IO;

public class GeneralController : MonoBehaviour
{
    public TextEditorController textScript;
    public GameObject Arm;

    public GameObject[] PartsArm;
    public List<List<Vector3>> Positions;
    public List<List<Quaternion>> Rotations;
    public List<Vector3> RealPositions;
    public List<Vector3> RealAngles;

    public string POS_script;
    public int N_pos;

    int timesScriptsText = 0;

    void Start() {
        Positions = new List<List<Vector3>>();
        Rotations = new List<List<Quaternion>>();
        POS_script = "";
        N_pos = 1;
    }

    public void RotLeft(GameObject mobile){
        JointData jointScript = mobile.GetComponent<JointData>();
        jointScript.Rotate(true);
    }
    public void RotRight(GameObject mobile){
        JointData jointScript = mobile.GetComponent<JointData>();
        jointScript.Rotate(false);
    }

    public void SavePosition(){
        if(!textScript.WritePositions(Arm)) return;
        SaveTransforms();
        textScript.WriteCommands(TextEditorController.commandLines.SAVE, null," P"+(Positions.Count).ToString());
    }

    public void LoadPosition(){
        if(Positions.Count == 0 || Rotations.Count == 0) return;
        string variable;
        if(int.Parse(textScript.nPos.text) == 0){
            LoadTransforms(Positions.Count-1);
            variable = " P"+(Positions.Count).ToString();
        }else{
            LoadTransforms(int.Parse(textScript.nPos.text)-1);
            variable = " P"+textScript.nPos.text;
        }
        textScript.WriteCommands(TextEditorController.commandLines.LOAD, null,variable);
        
    }
//Posicion: distancia entre el vértice final al centro del brazo

//Posicion y orientacion en un vector de 6
//P1 =(0,0,0,0,0,0) -180.0.180
//DEF POS P1
//P1 = (x,y,z)(7.0)
//archiv.mb5
    public void ExportText(){
        if(textScript.TextBox.text.Length == 0 && textScript.PosTextBox.text.Length == 0) {return;}
        
        string mainScript = Application.dataPath + "/Script_"+timesScriptsText+".mb5";
        if(!File.Exists(mainScript)){
            File.WriteAllText(mainScript,"\n");
            timesScriptsText++;
        }
        Debug.Log("Data exported");
        File.AppendAllText(mainScript,POS_script);
    }

    void SaveTransforms(){
        List<Vector3> temPos = new List<Vector3>();
        List<Quaternion> tempRos = new List<Quaternion>();
        foreach(GameObject part in PartsArm){
            temPos.Add(part.transform.localPosition);
            //Debug.Log(temPos[temPos.Count-1]);
            tempRos.Add(part.transform.localRotation);
            //Debug.Log(tempRos[tempRos.Count-1]);
        }
        RealPositions.Add(PositionToSave());
        SavePosition_String();
        RealAngles.Add(PartsArm[PartsArm.Length - 1].transform.eulerAngles);
        
        Positions.Add(temPos);
        Rotations.Add(tempRos);
    }

    void LoadTransforms(int n){
        Debug.Log("llegada");
        List<Vector3> temPos = new List<Vector3>(Positions[n]);
        List<Quaternion> tempRos = new List<Quaternion>(Rotations[n]);
        for(int i=0; i<PartsArm.Length;i++){
            PartsArm[i].transform.localPosition = temPos[i];
            PartsArm[i].transform.localRotation = tempRos[i];
        }
    }

    public void SavePosition_String(){
        POS_script += "DEF POS P" + N_pos+"\n";
        POS_script += RealPositions[RealPositions.Count - 1].ToString("F2") + "(7.0)\n";
        POS_script += "MOV P"+N_pos++;
        POS_script += "\n";
    }

    Vector3 PositionToSave(){
        Vector3 tempVecPos = PartsArm[PartsArm.Length - 1].transform.position - Arm.transform.position;
        tempVecPos = new Vector3 (NormalizePos(tempVecPos.x,5,400),NormalizePos(tempVecPos.y,5,400),NormalizePos(tempVecPos.z,6,865));
        return tempVecPos;
    }

    float NormalizePos(float posActual, float unityMaxValue, float realMaxValue){
        return posActual*realMaxValue/unityMaxValue;
    }
}
