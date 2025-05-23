using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public float countdownTime = 10f; // �J�E���g�_�E���̕b��
    public Text timerText; // �^�C�}�[�\���p
    public Text messageText; // �u�I���I�v�\���p
    public Image fadeImage; // �Ó]�p��UI Image
    public string nextSceneName = "NextScene"; // �J�ڐ�̃V�[����
    public int _score;

    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _backPanel;

    private bool isEnding = false;

    void Start()
    {
        Time.timeScale = 1;
        _score = 0;
        _backPanel.SetActive(false);
        _scorePanel.SetActive(false);
        messageText.text = "";
        fadeImage.color = new Color(0, 0, 0, 0); // �����͓���
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        float timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        timerText.text = "0";
        messageText.text = "�I���I";
        isEnding = true;

        yield return new WaitForSeconds(1.5f); // �I���I�\���̎���

        // �t�F�[�h�A�E�g
        yield return StartCoroutine(FadeToBlack());

        fadeImage.color = new Color(0, 0, 0, 0);
        timerText.text = "";
        messageText.text = "";
        _backPanel.SetActive(true);
        _scorePanel.SetActive(true);

        Time.timeScale = 0;

        // �V�[���J��
        //SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeToBlack()
    {
        float duration = 1.5f;
        float time = 0;
        Color color = fadeImage.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(0, 1, time / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1);
    }
}
