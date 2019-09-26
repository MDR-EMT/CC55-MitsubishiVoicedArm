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
    public List<Vector3> armPosition;
    public List<Quaternion> armRotation;

    int timesGeneralText = 0;
    int timesPosText = 0;

    void Start() {
        Positions = new List<List<Vector3>>();
        Rotations = new List<List<Quaternion>>();
    }

    public void RotLeft(GameObject mobile){
        JointData jointScript = mobile.GetComponent<JointData>();
        jointScript.Rotate(false);
    }
    public void RotRight(GameObject mobile){
        JointData jointScript = mobile.GetComponent<JointData>();
        jointScript.Rotate(true);
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

    public void ExportText(){
        if(textScript.TextBox.text.Length == 0 && textScript.PosTextBox.text.Length == 0) {return;}
        
        string pathEjecucion = Application.dataPath + "/Ejecución_"+timesGeneralText+".txt";
        string pathPos = Application.dataPath + "/Posn_"+timesPosText+".txt";
        if(!File.Exists(pathEjecucion)){
            File.WriteAllText(pathEjecucion,"\n");
            timesGeneralText++;
        }
        File.AppendAllText(pathEjecucion,textScript.TextBox.text);
        if(!File.Exists(pathPos)){
            File.WriteAllText(pathPos,"\n");
            timesPosText++;
        }
        Debug.Log("Data exported");
        File.AppendAllText(pathPos,textScript.PosTextBox.text);
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

    public void ImportText(){

    }
}
