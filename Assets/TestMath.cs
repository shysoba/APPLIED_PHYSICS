using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMath : MonoBehaviour
{

    public Slider lerpSlider;
    public Slider moveTowards;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        lerpSlider.value = Mathf.Lerp(lerpSlider.value, lerpSlider.maxValue, speed*Time.deltaTime);
        moveTowards.value = Mathf.MoveTowards(moveTowards.value, moveTowards.maxValue, speed*Time.deltaTime);

        float absolute = Mathf.Abs(-8.5f);
        Debug.Log(absolute);
        // >0.5
        float roundToInt = Mathf.RoundToInt(8.5f);
        Debug.Log(roundToInt);
        // 9
        float CeilToInt = Mathf.CeilToInt(8.4f); 
        Debug.Log("Ceil to Int : " + CeilToInt);
        // kahit 8.9, 8 paren
        float FloorToInt = Mathf.CeilToInt(8.5f); 
        Debug.Log("Floor to Int : " + FloorToInt);


    }
}
