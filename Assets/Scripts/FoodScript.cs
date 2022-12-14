using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodBar;
    public float bobbingHeight = 0.5f;
    public float bobbingRate = 0.05f;

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
        Debug.Log("Burger collided with something " + collision.gameObject);
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Fund the player");
            foodBar.GetComponent<FoodBar>().increaseByFood();
            Destroy(gameObject);
        }
    }
}
