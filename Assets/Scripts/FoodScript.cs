using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodBar;
    
    void Start()
    {
        //need to add section to where the object moves up and down;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Burger collided with something " + collision.gameObject);
        if (collision.gameObject.CompareTag("Player")) {
            foodBar.GetComponent<FoodBar>().increaseByFood();
            Destroy(gameObject);
            

        }
    }
}
