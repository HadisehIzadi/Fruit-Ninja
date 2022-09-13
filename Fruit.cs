using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	//variables
	public GameObject whole;
	public GameObject sliced;
	
	private Rigidbody fruitRigidbody;
	private Collider fruitCollider;
	
	private ParticleSystem juiceParticle;
	
	
	//******************************************
	
	void Awake()
	{
		fruitRigidbody = GetComponent<Rigidbody>();
		fruitCollider = GetComponent<Collider>();
		juiceParticle = GetComponentInChildren<ParticleSystem>();
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "Player")
    	{
    		Blade blade = other.GetComponent<Blade>();
    		Slice(blade.direction , blade.transform.position , 5f);
    		
    	}
    	

    }
    
    
    
    private void Slice(Vector3 direction , Vector3 position , float force)
    {
    	FindObjectOfType<GameManager>().IncreaseScore();
    	fruitCollider.enabled = false;
    	whole.SetActive(false);
    	sliced.SetActive(true);
    	juiceParticle.Play();
    	
    	fruitCollider.enabled = false;
    	
    	
    	float angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;
    	
    	sliced.transform.rotation = Quaternion.Euler(0f,0f,angle);
    	
    	Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
    	
    	foreach(Rigidbody slice in slices)
    	{
    		slice.velocity = fruitRigidbody.velocity;
    		slice.AddForceAtPosition(direction*force , position , ForceMode.Impulse);
    	}
    }
}
