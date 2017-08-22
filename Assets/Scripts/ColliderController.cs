using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    RaycastHit raycastHit;
    [SerializeField]
    GameObject[] pointColliders;

    // Use this for initialization
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var ray = new Ray(transform.position, transform.forward.normalized);
            Physics.Raycast(ray, out raycastHit);
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var rayTransf = raycastHit.transform;
            if (rayTransf != null)
            {
                if (rayTransf.name == "PointCollider")
                {
                    SetPointColliderDisEnable(rayTransf.gameObject);
                }
            }
        }
    }

    void SetPointColliderDisEnable(GameObject colliderGo)
    {
        for (int i = 0; i < pointColliders.Length; i++)
        {
            var parentGo = pointColliders[i].transform.parent.gameObject;
            if (pointColliders[i] == colliderGo)
            {
                parentGo.SetActive(false);
            }
            else
            {
                parentGo.SetActive(true);
            }
        }
    }
}
