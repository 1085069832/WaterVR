using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform boat;

    public void DoFollow()
    {
        transform.position = boat.position;
    }
}
