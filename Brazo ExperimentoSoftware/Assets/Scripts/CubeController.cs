using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public Transform CubePosition;
    public Text showText;
    public float Max;
    public float Min;

    private enum commandType {MOV, ROT, SAVE, LOAD};
    public enum extension {Waist,Shoulder,Elbow,Twist,Pitch,Roll};

    // Start is called before the first frame update
    void Start()
    {
        showText.text = CubePosition.rotation.y.ToString();
    }

    public void RotarIzquierda()
    {
        CubePosition.Rotate(0f, -5f, 0f, Space.Self);
        ActualizarTexto(commandType.ROT);
    }

    public void RotarDerecha(GameObject arm)
    {
        CubePosition.Rotate(0f, 5f, 0f, Space.Self);
        ActualizarTexto(commandType.ROT);
    }

    void ActualizarTexto( commandType typeMovement)
    {
        showText.text = CubePosition.rotation.y.ToString();
    }
}
