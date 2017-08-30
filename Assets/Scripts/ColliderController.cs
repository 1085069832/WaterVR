using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    RaycastHit raycastHit;
    [SerializeField]
    GameObject[] points;
    [SerializeField] BoatController boatController;

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
                if (rayTransf.tag == "PointCollider")
                {
                    SetPointColliderDisEnable(rayTransf.gameObject);
                    BoatPointManager boatPointManager;
                    if (rayTransf.GetComponent<BoatPointManager>())
                    {
                        boatPointManager = rayTransf.GetComponent<BoatPointManager>();
                    }
                    else
                    {
                        boatPointManager = rayTransf.GetComponentInParent<BoatPointManager>();
                    }

                    //移动游艇
                    if (boatPointManager.isBoatPoint)
                    {
                        boatController.startMove = true;
                    }
                }
            }
        }
    }

    void SetPointColliderDisEnable(GameObject collider)
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (!points[i].activeSelf)
            {
                points[i].SetActive(true); break;
            }
        }

        GameObject point;
        if (collider.name == "PointCollider")
        {
            point = collider.transform.parent.gameObject;
        }
        else
        {
            point = collider.transform.Find("Point").gameObject;
        }
        point.SetActive(false);
    }
}
