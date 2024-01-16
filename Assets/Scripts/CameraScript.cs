using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    private float camAngleX;
    private float camAngleY;
    private float camSunAngleX;
    private float camSunAngleY;
    private float sensitivityHorizontal = 4f;
    private float sensitivityVertical = 3f;
    private Vector3 camSun;
    private Camera _camera;

    private float initialCamAngleX;
    private float initialCamAngleY;
    private float initialCamSunAngleX;
    private float initialCamSunAngleY;
    private Vector3 initialCamSun;
    private float initialFieldOfView;



    void Start()
    {
        camAngleX = transform.eulerAngles.x;
        camAngleY = transform.eulerAngles.y;
        camSun = this.transform.position - sun.transform.position;
        camSunAngleX = camSunAngleY = 0f;
        _camera = GetComponent<Camera>();

        initialCamAngleX = camAngleX;
        initialCamAngleY = camAngleY;
        initialCamSunAngleX = camSunAngleX;
        initialCamAngleY = camSunAngleY;
        initialCamSun = camSun;
        initialFieldOfView = _camera.fieldOfView;
    }
    void Update()
    {
        float my = sensitivityVertical * Input.GetAxis("Mouse Y"); 
        float mx = sensitivityHorizontal * Input.GetAxis("Mouse X"); 
        camAngleX -= my;
        camAngleY += mx;
        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            camSunAngleX -= my;
            camSunAngleY += mx;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            camAngleX = initialCamAngleX;
            camAngleY = initialCamAngleY;
            camSunAngleX = initialCamSunAngleX;
            camSunAngleY = initialCamSunAngleY;
            camSun = initialCamSun;
            _camera.fieldOfView = initialFieldOfView;

        }

        this.transform.eulerAngles = new Vector3(camAngleX, camAngleY, 0);
        this.transform.position = sun.transform.position +
            Quaternion.Euler(camSunAngleX, camSunAngleY, 0) * camSun;
        Vector2 wheel = Input.mouseScrollDelta;
        if(wheel != Vector2.zero)
        {
            float fieldOfViewTemp = _camera.fieldOfView - wheel.y;
            if(fieldOfViewTemp <= 5)
            {
                fieldOfViewTemp = 5;
            }
            if(fieldOfViewTemp >= 120)
            {
                fieldOfViewTemp = 120;
            }
            _camera.fieldOfView = fieldOfViewTemp;
        }
        if(Input.GetMouseButton((int)MouseButton.Right))
        {
            this.transform.Translate(
                Time.deltaTime * Input.GetAxis("Vertical") * this.transform.forward +
                Time.deltaTime * Input.GetAxis("Horizontal") *  this.transform.right);
            camSun = this.transform.position - sun.transform.position;
        }
    }
}
