using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float initialTime = 150.0f; // 2 minutos e 30 segundos em segundos
    private float currentTime;
    private bool isCounting = true;

    private void Start()
    {
        currentTime = initialTime;
        UpdateTimerText();
    }

    private void Update()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isCounting = false;
            }

            UpdateTimerText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("finish"))
        {
            isCounting = false;
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);


        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}



