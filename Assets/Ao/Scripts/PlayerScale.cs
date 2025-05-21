using System.Collections;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    private Coroutine activeCoroutine;
    private Vector3 originalScale;

    private enum ScaleState { Normal, Enlarged, Shrunk }

    public float effectDuration = 10f;
    public float enlargedScale = 2f;
    public float shrunkScale = 0.5f;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void ApplyEffect(string effectType, float duration)
    {
        if (activeCoroutine != null)
            StopCoroutine(activeCoroutine);

        activeCoroutine = StartCoroutine(EffectRoutine(effectType, duration));
    }

    private IEnumerator EffectRoutine(string effectType, float duration)
    {
        float scaleX = originalScale.x;

        if (effectType == "Enlarge")
        {
            scaleX = originalScale.x * 2f;
        }
        else if (effectType == "Shrink")
        {
            scaleX = originalScale.x * 0.5f;
        }

        transform.localScale = new Vector3(scaleX, originalScale.y, originalScale.z);

        float timer = duration;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
        activeCoroutine = null;
    }
}
