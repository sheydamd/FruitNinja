using UnityEngine;

public class Blade : MonoBehaviour
{
    private Collider bladeCollider;
    private bool slicing;
    private Camera mainCamera;
    public float minSliceVelocity=0.01f;
    public  AudioClip bladeSound;
    private AudioSource audioSource;
    public Vector3 direction{get; private set;}
    private  TrailRenderer bladeTrail;
    public float sliceForce=5f;
    private void Awake(){
        mainCamera=Camera.main;
        bladeCollider=GetComponent<Collider>();
        bladeTrail=GetComponentInChildren<TrailRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip=bladeSound;
        audioSource.playOnAwake=false;
    }
    private void OnEnable(){
        StopSlicing();
    }
    private void OnDisable(){
        StopSlicing();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartSlicing();

        }
        else if (slicing)
        {
            CountinueSlicing();
        }
    }
    private void StartSlicing(){
        Vector3 newPosition=mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z=0f;
        transform.position=newPosition;
        slicing=true;
        bladeCollider.enabled=true;
        bladeTrail.enabled=true;
        audioSource.Play();
        bladeTrail.Clear();
    }
    private void StopSlicing(){
    slicing=false;
    bladeCollider.enabled=false;
    bladeTrail.enabled=false;
    }
    private void CountinueSlicing(){
        Vector3 newPosition=mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z=0f;

        direction=newPosition - transform.position;
        float velocity= direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity> minSliceVelocity;
        transform.position=newPosition;
    }

}
