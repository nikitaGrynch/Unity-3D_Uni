using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyCameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraAnchor;
    [SerializeField]
    private GameObject cameraAnchor1;   // firest person anchor
    private float camEulerX;
    private float camEulerY;
    private float ancEulerX;
    private float ancEulerY;
    private Vector3 rod;
    private float sensitivityHorizontal = 4f;
    private float sensitivityVertical = 3f;
    void Start()
    {
        camEulerX = this.transform.eulerAngles.x;
        camEulerY = this.transform.eulerAngles.y;
        ancEulerX = 0;
        ancEulerY = 0;
        rod = this.transform.position - cameraAnchor.transform.position;
        LabyState.firstPersonView = false;
    }


    void Update()
    {
        if (LabyState.isPaused) return;
        float mh = sensitivityHorizontal * Input.GetAxis("Mouse X");
        float mv = sensitivityVertical * Input.GetAxis("Mouse Y");

        camEulerY += mh;
        ancEulerY += mh;
        float minVAngel = LabyState.firstPersonView ? 5 : 35;
        float maxVAngel = LabyState.firstPersonView ? 45 : 85;

        if (camEulerX - mv >= minVAngel && camEulerX - mv <= maxVAngel)
        {
            camEulerX -= mv;
            ancEulerX -= mv;
        }
        else
        {
            if(camEulerX - mv < minVAngel)
            {
                ancEulerX += (minVAngel - camEulerX);
                camEulerX = minVAngel;
            }
            else
            {
                ancEulerX -= (camEulerX - maxVAngel);
                camEulerX = maxVAngel;
            }
            //camEulerX = camEulerX - mv < minVAngel ? minVAngel : 85;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            LabyState.firstPersonView = !LabyState.firstPersonView;
        }
    }

    private void LateUpdate()
    {
        this.transform.eulerAngles = new Vector3(camEulerX, camEulerY, 0);
        if (LabyState.firstPersonView)
        {
            this.transform.position = cameraAnchor1.transform.position;
        }
        else
        {
            this.transform.position = cameraAnchor.transform.position +
                Quaternion.Euler(ancEulerX, ancEulerY, 0) * rod;
        }

    }
}
