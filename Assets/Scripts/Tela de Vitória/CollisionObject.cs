using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    public FinishLineManager FinishLineManager; // Refer�ncia para o FinishLineManager

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishLineManager.ShowVictoryScreen(); // Ativa o Canvas da Vit�ria
            FinishLineManager.HideTimerScreen();//Desativa o Canvas do Timer
        }
    }

}
