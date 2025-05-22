using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryHp : MonoBehaviour
{
    private float _hp = 1;
    [SerializeField]
    private SpriteRenderer _laundryRen;
    [SerializeField]
    private TimerController _point;

    // Start is called before the first frame update
    void Start()
    {
        //_laundryRen.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet") && _hp != 0)
        {
            _hp--;
            _laundryRen.color = Color.HSVToRGB(114, 58, 0);
            _point.GetComponent<TimerController>()._score += 1;
        }
    }
}
