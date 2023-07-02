using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{    
    [SerializeField] float _restartDelay = 1.0f;
    [SerializeField] ParticleSystem _victoryParticle;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Invoke("ReloadScene", _restartDelay);
            _victoryParticle.Play();
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
