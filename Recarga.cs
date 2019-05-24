using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recarga : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            DestroySelf();
        }
    }
}
