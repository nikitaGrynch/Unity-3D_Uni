using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobosScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mars;
    [SerializeField]
    private GameObject sun;

    private float dayPeriod = 14f / 360f;
    private float monthPeriod = 14f / 360f;
    private float yearPeriod = 146f / 360f;

    private Vector3 phobosAxis = Quaternion.Euler(0, 0, -30) * Vector3.up;

    void Update()
    {
        this.transform.Rotate(phobosAxis, Time.deltaTime / dayPeriod);
        this.transform.RotateAround(mars.transform.position, phobosAxis, Time.deltaTime / monthPeriod);
        this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);

    }
}
