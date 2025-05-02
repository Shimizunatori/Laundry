using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float initialTimeInSeconds = 300f; // 5分の初期時間（秒）
    private float currentTimeInSeconds;
    private TextMeshProUGUI timerText;

    private Coroutine _startTimer;
    //public bool isTimerRunning = true;

    private void Start()
    {
        // TextMeshProUGUIコンポーネントを取得
        timerText = GetComponent<TextMeshProUGUI>();

        // 初期時間を設定
        currentTimeInSeconds = initialTimeInSeconds;

        // タイマーを開始
        _startTimer = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (currentTimeInSeconds > 0)
        {
            // タイマーの表示を更新
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTimeInSeconds);
            timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

            // 1秒待機
            yield return new WaitForSeconds(1f);

            // 残り時間を減少させる
            currentTimeInSeconds -= 1f;
            //Debug.Log(currentTimeInSeconds);
        }
    }

    public void TimerStop()
    {
        StopCoroutine(_startTimer);
    }

}
