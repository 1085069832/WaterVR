using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public float boatFwdSpeed = 5f;
    [SerializeField] Transform targetTransf;
    public bool startMove;
    public CameraFollow cameraFollow;
    [SerializeField] GameObject[] tails;
    TargetRotate targetRotate;
    bool doRotate;
    [SerializeField] Transform endTransf;
    [SerializeField] GameObject startPoint;

    private void Awake()
    {
        targetTransf.position = new Vector3(targetTransf.position.x, transform.position.y, targetTransf.position.z);
        endTransf.position = new Vector3(endTransf.position.x, transform.position.y, endTransf.position.z);
        targetRotate = targetTransf.GetComponent<TargetRotate>();
    }

    private void Update()
    {
        transform.LookAt(targetTransf);

        if (startMove && cameraFollow)
        {
            var dis = Vector3.Distance(transform.position, targetTransf.position);

            if (dis < 10)
            {
                doRotate = true;
            }

            if (doRotate)
            {
                if (Vector3.Distance(endTransf.position, targetTransf.position) > 20)
                {
                    targetRotate.DoRotate();
                }
                else
                {
                    //停止
                    ShowBoatTail(false);
                    startPoint.SetActive(true);
                }
            }

            if (dis > 0.1f)
            {
                transform.Translate(Vector3.forward * boatFwdSpeed * Time.deltaTime, Space.Self);
            }
        }
    }

    public void ShowBoatTail(bool isShow)
    {
        for (int i = 0; i < tails.Length; i++)
        {
            tails[i].SetActive(isShow);
        }
    }
}
