using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
   [SerializeField] float mainThrust = 100;
   [SerializeField] float rotationThrust = 1f;
   [SerializeField] AudioClip mainEngine;
   [SerializeField] ParticleSystem mainEngineParticles;
   [SerializeField] ParticleSystem leftThrusterParticles;
   [SerializeField] ParticleSystem rightThrusterParticles;
   Rigidbody rb;
   AudioSource audioSource;
      
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
          
             ProcessThrust();
             ProcessRotation();
    }      

    void ProcessThrust()
    {
          if (Input.GetKey(KeyCode.Space))
            {
                StartThrusting(); 
            }
            else
            {
                StopThrusting();
            }

            if (Input.GetKey(KeyCode.S))
             {
                    rb.AddRelativeForce(Vector3.down * mainThrust * Time.deltaTime);
             }       
    }

         void ProcessRotation()
        {
              
        if (Input.GetKey(KeyCode.A))
            {
                    ApplyRotation(rotationThrust);
                    if (!rightThrusterParticles.isPlaying)
                  {
                    rightThrusterParticles.Play();
                  }

                }
            else if (Input.GetKey(KeyCode.D))
          {
                ApplyRotation(-rotationThrust);
          
                if(!leftThrusterParticles.isPlaying)
                  {
                    leftThrusterParticles.Play();
                  }
          }
            else
                {
                    StopRotating();
                }
        }  

         void StopRotating()
      {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
      }
      void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();

        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }
    


        void ApplyRotation(float rotationThisFrame)
    {
       rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation =false; //unfreezing rotation so the physics system can take over
    }

       

     
    }

    





   


    
