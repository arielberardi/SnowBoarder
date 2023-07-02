using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 3.0f;
    [SerializeField] ParticleSystem _diedParticle;
    
    Rigidbody2D _rigidBody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        if (!_rigidBody2D) 
        {
            Debug.LogError("Missing game component: RigidBody2D");
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            _rigidBody2D.AddTorque(_rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            _rigidBody2D.AddTorque(-_rotationSpeed);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ground"))
        {
            _diedParticle.Play();
            Invoke("ReloadScene", 1.0f);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
