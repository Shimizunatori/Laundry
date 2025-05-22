using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TimerController _timeCon;
    [SerializeField, Header("ÉXÉRÉA")] private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Duration());
    }

    private void Score()
    {
        if (_timeCon.GetComponent<TimerController>()._score <= 0)
        {
            _text.text = "S";
        }
        if (_timeCon.GetComponent<TimerController>()._score > 0 && _timeCon.GetComponent<TimerController>()._score <= 2)
        {
            _text.text = "A";
        }
        if (_timeCon.GetComponent<TimerController>()._score > 2 && _timeCon.GetComponent<TimerController>()._score <= 4)
        {
            _text.text = "B";
        }
        if (_timeCon.GetComponent<TimerController>()._score > 4 && _timeCon.GetComponent<TimerController>()._score <= 6)
        {
            _text.text = "C";
        }
        if (_timeCon.GetComponent<TimerController>()._score > 6)
        {
            _text.text = "D";
        }
    }

    private IEnumerator Duration()
    {
        yield return new WaitForSeconds(1.5f);
        Score();
    }
}
