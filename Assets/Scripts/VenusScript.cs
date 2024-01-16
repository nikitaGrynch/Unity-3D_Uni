using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusScript : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;
    private GameObject surface;
    private GameObject atmosphere;
    private float dayPeriod = 48f / 360f;
    private float skyPeriod = 72f / 360f;
    private float yearPeriod = 62f / 360f;

    void Start()
    {
        surface = GameObject.Find("VenusSurface");
        atmosphere = GameObject.Find("VenusAtmosphere");
    }

    void Update()
    {
        surface.transform.Rotate(Vector3.up, -(Time.deltaTime / dayPeriod), Space.Self);
        atmosphere.transform.Rotate(Vector3.up, -(Time.deltaTime / skyPeriod));
        this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);

    }
}
