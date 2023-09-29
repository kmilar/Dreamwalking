using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    public FinishLineManager FinishLineManager; // Referência para o FinishLineManager

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishLineManager.ShowVictoryScreen(); // Ativa o Canvas da Vitória
            FinishLineManager.HideTimerScreen();//Desativa o Canvas do Timer
        }
    }

}
