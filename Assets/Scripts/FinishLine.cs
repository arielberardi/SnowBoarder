using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{    
    [SerializeField] private float _restartDelay = 1.0f;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Invoke("ReloadScene", _restartDelay);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
