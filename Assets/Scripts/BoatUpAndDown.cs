using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatUpAndDown : MonoBehaviour
{

    private bool isAnimated = false;

    private Vector3 originalPos;

    // Use this for initialization
    void Start()
    {

        originalPos = this.transform.localPosition;

        isAnimated = true;

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 newLocalPos = originalPos + new Vector3(0, Mathf.Sin(Time.time) * 0.15f, 0);
        //Debug.Log (Mathf.Sin(Time.deltaTime));
        this.transform.localPosition = newLocalPos;




    }




}
