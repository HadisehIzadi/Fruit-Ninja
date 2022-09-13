using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
	// variables
	private bool slicing;
	private Collider bladeCollider;
	private Camera mainCamera;
	public Vector3 direction {get; private set;}
	public float minSliceVelocity = 0.01f;
	
	private TrailRenderer bladeTrail;
	
	//*************************************
	
	void Awake()
	{
		bladeCollider = GetComponent<Collider>();
		mainCamera = Camera.main;
		bladeTrail = GetComponentInChildren<TrailRenderer>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetMouseButtonDown(0)) // left click
    	{
    		StartSlicing();
    	}
    	
    	else if(Input.GetMouseButtonDown(1)) // right click
    	{
    		StopSlicing();
    	}
        
    	else if(slicing)
    	{
    		ContinueSlicing();
    	}
    }
    
    
    
    private void StartSlicing()
    {
    	
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
    	
    	transform.position = newPosition;
    	
    	slicing = true;
    	bladeCollider.enabled = true;
    	bladeTrail.enabled = true;
    }
    private void StopSlicing()
    {
    	slicing = false;
    	bladeCollider.enabled = false;
    	bladeTrail.enabled = false;
    	bladeTrail.Clear();
    }
    
    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
    	
    	direction = newPosition - transform.position;
    	
    	float velocity = direction.magnitude/Time.deltaTime;
    	
    	bladeCollider.enabled = velocity > minSliceVelocity ;
    	transform.position = newPosition;
    }
    
    
    private void OnEnable()
    {
    	StopSlicing();
    }
    private void OnDisable()
    {
    	StopSlicing();
    }
    
}
