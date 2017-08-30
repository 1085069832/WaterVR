using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public float boatFwdSpeed = 5f;
    [SerializeField] Transform targetTransf;
    public bool startMove;
    [SerializeField] CameraFollow cameraFollow;

    private void Awake()
    {
        targetTransf.position = new Vector3(targetTransf.position.x, transform.position.y, targetTransf.position.z);
        transform.LookAt(targetTransf);
    }

    private void Update()
    {
        if (startMove && cameraFollow)
        {
            var dis = Vector3.Distance(transform.position, targetTransf.position);
            if (dis > 0.1f)
            {
                if (dis < 10)
                {
                    boatFwdSpeed -= 0.1f;
                    if (boatFwdSpeed <= 0.1f)
                    {
                        boatFwdSpeed = 0.1f;
                    }
                }
                transform.Translate(Vector3.forward * boatFwdSpeed * Time.deltaTime, Space.Self);
                cameraFollow.DoFollow();
            }
        }
    }
}
