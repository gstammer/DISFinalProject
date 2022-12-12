using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    /*
     * Health and percent 
     * Each heart is equal to 25 (as default value)
     * To do this, we will divide the current health to the max health of 100, and get the lower bound
     * Ex: Mathf.floor(curr / max) -> fill this 
     * Fill the current by: (curr % maxBar) / maxBar)
     */

    public Image[] bars;
    public  float currVal, maxVal = 100f;
    public float damagePerSecond = 1.5f;
    private float maxBarVal = 25; //Max health for each bar
    private int getCurrentBarIdx() => Mathf.FloorToInt(currVal / maxVal * bars.Length);
    private float getCurrentBarHealth() => currVal % maxBarVal / maxBarVal;
    

    void Start()
    {
        maxBarVal = maxVal / bars.Length;
        currVal = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currVal <= 0) {
           GameManager.instance.restartScene();
        }
        currVal -= Mathf.Max(0, damagePerSecond * Time.deltaTime);
        currVal = Mathf.Min(Mathf.Max(0, currVal), maxVal);
        FillHealthBar();
    }

    /**
     * This method should fill up whatever the current bar is
     * and fill up also the next bar. It can increase at max < 2 bars
     */
    public void increaseByFood()
    {
        int newHealthBar = getCurrentBarIdx() + 1;
        newHealthBar    += getCurrentBarHealth() > 0 ? 1 : 0;
        setHealth(newHealthBar * maxBarVal);
    }



    public void setHealth(float health)
    {
        currVal = Mathf.Min(Mathf.Max(0, health), maxVal); //Clamp the health
        FillHealthBar();
    }


    private void FillHealthBar()
    {
        foreach (var bar in bars) bar.fillAmount = 0; //Delete the previous health
        int i = 0; //Current index of the bar that needs to be filled
        for (i = 0; i < getCurrentBarIdx(); i++) bars[i].fillAmount = 1;
        //Fill the residual of the current bar
        if (i < bars.Length) bars[i].fillAmount = getCurrentBarHealth();
    }

}
