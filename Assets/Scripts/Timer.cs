using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timeText;
    

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0){
            timeValue -= Time.deltaTime;

        }
        else{
            timeValue = 90;
            SceneManager.LoadScene(0);
        }   
        Showtime(timeValue);
    }

    void Showtime(float time){
        if(time<0){
            time = 0;
        }
        float minutos = Mathf.FloorToInt(time / 60);
        float segundos = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutos,segundos);

    }
}
