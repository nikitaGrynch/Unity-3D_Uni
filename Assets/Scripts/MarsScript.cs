using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;
    private GameObject surface;
    private GameObject atmosphere;
    private float dayPeriod = 22f / 360f;
    private float skyPeriod = 34f / 360f;
    private float yearPeriod = 146 / 360f;

    void Start()
    {
        surface = GameObject.Find("MarsSurface");
        atmosphere = GameObject.Find("MarsAtmosphere");
    }

    void Update()
    {
        surface.transform.Rotate(Vector3.up, -(Time.deltaTime / dayPeriod), Space.Self);
        atmosphere.transform.Rotate(Vector3.up, -(Time.deltaTime / skyPeriod));
        this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);

    }
}
