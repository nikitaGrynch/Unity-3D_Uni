using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyBallScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private GameObject cameraAnchor1;

    private Rigidbody body;
    private Vector3 anchorOffset;

    private AudioSource backgroundMusic;
    private AudioSource collectSoundEffect;

    private static LabyBallScript instance = null!;

    void Start()
    {
        if(instance != null)
        {
            this.transform.position += new Vector3(0, instance.transform.position.y, 0);
            GameObject.Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        _camera = Camera.main.gameObject;
        body = GetComponent<Rigidbody>();
        anchorOffset = cameraAnchor1.transform.position - this.transform.position;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        collectSoundEffect = audioSources[0];
        backgroundMusic = audioSources[1];

        //backgroundMusic.Play();

    }

    void Update()
    {

        float av = Input.GetAxis("Vertical");
        float ah = Input.GetAxis("Horizontal");
        Vector3 right = _camera.transform.right;
        Vector3 forward = _camera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 move = (right * ah + forward * av).normalized;
        body.AddForce(Time.deltaTime * LabyState.ballForceFactor * move);

        cameraAnchor1.transform.position = anchorOffset + this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key")
        {
            collectSoundEffect.Play();
        }
    }
}
