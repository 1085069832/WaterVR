using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    [SerializeField] Transform centerTransf;

    public void DoRotate()
    {
        transform.RotateAround(centerTransf.position, transform.up, -Time.deltaTime * 5.5f);
    }
}
