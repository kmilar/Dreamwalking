using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineManager : MonoBehaviour

{
    public GameObject canvasVitoria; // Referência para o Canvas da tela de vitória
    public GameObject canvasTimer;// Referência para o Canvas do Timer

    // Start is called before the first frame update
    public void ShowVictoryScreen()
    {
        canvasVitoria.SetActive(true);
    }
    public void HideTimerScreen()
    {
        canvasTimer.SetActive(false);
    }
}
