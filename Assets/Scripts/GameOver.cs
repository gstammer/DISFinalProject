using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodBar;
    private float health;
    void Start()
    {
        health = foodBar.GetComponent<FoodBar>().getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
