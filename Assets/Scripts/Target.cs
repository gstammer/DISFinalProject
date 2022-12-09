using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody targetRb;
    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 4), -6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.health == 3)
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        gameManager.UpdateHealth(1);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
    }
}
