using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyPortalScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            string originalSceneName = SceneManager.GetActiveScene().name;
            Debug.Log(originalSceneName);
            StartCoroutine(SwitchScenes());
        }
    }

    IEnumerator SwitchScenes()
    {
        SceneManager.LoadScene("SampleScene");

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Labyrinth");
    }
}

