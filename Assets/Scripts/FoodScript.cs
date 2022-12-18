using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodBar;
    public float bobbingHeight = 0.5f;
    public float bobbingRate = 0.05f;
    //public AudioSource source;

    private Vector3 startPos;
    private Vector3 topPos;
    private Vector3 currDestination;
    
    void Start()
    {
        //need to add section to where the object moves up and down;
        startPos = transform.position;
        topPos = startPos;
        topPos.y += bobbingHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPos) currDestination = topPos;
        if (transform.position == topPos) currDestination = startPos;

        transform.position = Vector3.MoveTowards(transform.position, currDestination, bobbingRate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            foodBar.GetComponent<FoodBar>().increaseByFood();

            FindObjectOfType<AudioManager>().Play("collectSound");
            //source.Play();
            Destroy(gameObject);
        }
    }
}
