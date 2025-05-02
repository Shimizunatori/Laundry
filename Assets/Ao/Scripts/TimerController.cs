using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float initialTimeInSeconds = 300f; // 5���̏������ԁi�b�j
    private float currentTimeInSeconds;
    private TextMeshProUGUI timerText;

    private Coroutine _startTimer;
    //public bool isTimerRunning = true;

    private void Start()
    {
        // TextMeshProUGUI�R���|�[�l���g���擾
        timerText = GetComponent<TextMeshProUGUI>();

        // �������Ԃ�ݒ�
        currentTimeInSeconds = initialTimeInSeconds;

        // �^�C�}�[���J�n
        _startTimer = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (currentTimeInSeconds > 0)
        {
            // �^�C�}�[�̕\�����X�V
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTimeInSeconds);
            timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

            // 1�b�ҋ@
            yield return new WaitForSeconds(1f);

            // �c�莞�Ԃ�����������
            currentTimeInSeconds -= 1f;
            //Debug.Log(currentTimeInSeconds);
        }
    }

    public void TimerStop()
    {
        StopCoroutine(_startTimer);
    }

}
