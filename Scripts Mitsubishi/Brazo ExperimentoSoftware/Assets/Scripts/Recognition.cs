using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Recognition : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    public GameObject piceSent;
    public GeneralController generalController;
    public bool direction;
    Dictionary<string, System.Action> keyWords = new Dictionary<string, System.Action>();
    
    // Start is called before the first frame update
    void Start()
    {
        keyWords.Add("waist", () => { SelectPiece(0); });
        keyWords.Add("shoulder", () => { SelectPiece(1); });
        keyWords.Add("elbow", () => { SelectPiece(2); });
        keyWords.Add("twist", () => { SelectPiece(3); });
        keyWords.Add("pitch", () => { SelectPiece(4); });
        keyWords.Add("roll", () => { SelectPiece(5); });

        keyWords.Add("left", () => { SelectDir(true); });
        keyWords.Add("right", () => { SelectDir(false); });
        keyWords.Add("go",() => {RunCommand();});

        keyWords.Add("position",() => {SavePosition();});
        keyWords.Add("export",() => {ExportCode();});

        keywordRecognizer = new KeywordRecognizer(keyWords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args){
        System.Action keyWordAction;

        if(keyWords.TryGetValue(args.text, out keyWordAction)){
            keyWordAction.Invoke();
        }
    }

    void SelectPiece(int i){
        piceSent = generalController.PartsArm[i];
    }

    void SelectDir(bool d){
        direction = d;
    }

    public void RunCommand(){
        if(direction){
            generalController.RotLeft(piceSent);
        }else{
            generalController.RotRight(piceSent);
        }
    }

    public void SavePosition(){
        generalController.SavePosition();
    }

    public void ExportCode(){
        generalController.ExportText();
    }
}
