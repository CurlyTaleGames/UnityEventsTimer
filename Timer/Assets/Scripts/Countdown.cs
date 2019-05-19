using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class GameOverEvent : UnityEvent{}

public class Countdown : MonoBehaviour
{

    public float maxTime = 9f;
    public TextMeshProUGUI timeText;
    public Slider timeSlider;

    public GameOverEvent gameOverEvent;

    float timer;

    bool hasLost = false;

    // Start is called before the first frame update
    void Start(){
        timer = maxTime;
    }

    // Update is called once per frame
    void Update(){
        if(!hasLost){
            if(timer > 0f){
                timer -= Time.deltaTime;
            }
            else{
                Debug.Log("Game Over");
                hasLost = true;
                timer = 0f;
                gameOverEvent.Invoke();
            }

            timeSlider.value = timer/maxTime;
            timeText.text = TimeFormat(timer);

        }
    }

    string TimeFormat(float time){
        string min = ((int)time / 60).ToString();
        string sec = ((int)time % 60).ToString();
        if(sec.Length == 1){
            sec = "0" + sec;
        }
        return min + ":" + sec;
    }
}
