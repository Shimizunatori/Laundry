using UnityEngine;

public class Item : MonoBehaviour
{
    public enum EffectType { Enlarge, Shrink }

    public EffectType effectType;
    public float effectDuration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScale scaler = other.GetComponent<PlayerScale>();
            if (scaler != null)
            {
                scaler.ApplyEffect(effectType.ToString(), effectDuration);
            }
            Destroy(gameObject); // ÉAÉCÉeÉÄÇÕè¡Ç¶ÇÈ
        }
    }
}
