using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hp"))
        {
            Destroy(this.gameObject);
        }
    }
}
