using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public Transform CubePosition;
    public Text showText;

    List<Transform> listPosiciones;

    Vector3 LastSavedPosition;
    Quaternion LastSavedRotation;

    private enum commandType {MOV, ROT, SAVE, LOAD};

    // Start is called before the first frame update
    void Start()
    {
        showText.text = "Línea de Comandos: \n";
    }

    public void MoverDerecha()
    {
        CubePosition.position = new Vector3(CubePosition.position.x + 0.5f, CubePosition.position.y, CubePosition.position.z);
        ActualizarTexto(commandType.MOV);
    }

    public void MoverIzquierda()
    {
        CubePosition.position = new Vector3(CubePosition.position.x - 0.5f, CubePosition.position.y, CubePosition.position.z);
        ActualizarTexto(commandType.MOV);
    }

    public void MoverArriba()
    {
        CubePosition.position = new Vector3(CubePosition.position.x, CubePosition.position.y + 0.5f, CubePosition.position.z);
        ActualizarTexto(commandType.MOV);
    }

    public void MoverAbajo()
    {
        CubePosition.position = new Vector3(CubePosition.position.x, CubePosition.position.y - 0.5f, CubePosition.position.z);
        ActualizarTexto(commandType.MOV);
    }

    public void RotarIzquierda()
    {
        CubePosition.Rotate(0f, -5f, 0f, Space.Self);
        ActualizarTexto(commandType.ROT);
    }

    public void RotarDerecha()
    {
        CubePosition.Rotate(0f, 5f, 0f, Space.Self);
        ActualizarTexto(commandType.ROT);
    }

    public void RotarAbajo()
    {
        CubePosition.Rotate(0f, 0f, -5f, Space.Self);
        ActualizarTexto(commandType.ROT);
    }

    public void RotarArriba()
    {
        CubePosition.Rotate(0f, 0f, 5f, Space.Self);
        ActualizarTexto(commandType.ROT);
    }

    public void SavePosition()
    {

        LastSavedPosition = this.CubePosition.position;
        LastSavedRotation = this.CubePosition.rotation;
        ActualizarTexto(commandType.SAVE);
    }

    public void LoadPosition()
    {
        this.CubePosition.position = LastSavedPosition;
        this.CubePosition.rotation = LastSavedRotation;
        ActualizarTexto(commandType.LOAD);
    }

    void ActualizarTexto( commandType typeMovement)
    {
        showText.text += typeMovement.ToString() + " " + CubePosition.position.ToString() + "\n";
    }
}
