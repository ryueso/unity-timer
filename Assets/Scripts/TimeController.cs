using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Image clock;
    public AudioSource alarm;

    private Text text;
    private double restTime;
    private int state;
    private DateTime last;

    void Start()
    {
        text = GetComponent<Text>();
        clock.gameObject.SetActive(false);
    }

    void Update()
    {
        if (state == 1) {
            DateTime now = DateTime.Now;
            TimeSpan span = now - last;
            last = now;
            restTime -= span.TotalSeconds;
            if (restTime <= 0) {
                alarm.Play();
                restTime = 0;
                state = 0;
                clock.gameObject.SetActive(false);
            }
            clock.transform.Rotate(0, 0, 3.0f);
            drawTime();
        }
    }

    private void drawTime()
    {
        double time = Math.Ceiling(restTime);
        text.text = Math.Floor((float)(time / 60)).ToString("00") + ":" + (time % 60).ToString("00");
    }

    private void AddTime(int t)
    {
        restTime += t;
        if (restTime > 3600) {
            restTime = 3600;
        }
    }

    public void StartCount()
    {
        if (restTime <= 0) { return; }
        clock.gameObject.SetActive(true);
        last = DateTime.Now;
        state = 1;
    }

    public void AddMinutes()
    {
        AddTime(60);
        drawTime();
    }

    public void Add10Minutes()
    {
        AddTime(600);
        drawTime();
    }

    public void AddSecounds()
    {
        AddTime(10);
        drawTime();
    }

    public void Clear()
    {
        alarm.Stop();
        clock.gameObject.SetActive(false);
        state = 0;
        restTime = 0;
        drawTime();
    }

    public void Pause()
    {
        state = 0;
    }

}