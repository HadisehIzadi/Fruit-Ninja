using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	//variables
	private Collider SpawnArea;
	public GameObject[] fruitPrefabs;
	public float minDelay = 0.25f;
	public float maxDelay = 1f;
	public float minAngle = -15f;
	public float maxAngle = 15f;
	public float minForce = 18f;
	public float maxForce = 22f;
	public float maxLifeTime = 5f;
	
	
	
	
	
	//********************************************
	void Awake()
	{
		SpawnArea = GetComponent<Collider>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnEnable()
    {
    	StartCoroutine(Spawn());
    }
    
    private void OnDisable()
    {
    	StopAllCoroutines();
    }
    
    private IEnumerator Spawn()
    {
    	yield return new WaitForSeconds(2f);
    	
    	while(enabled)
    	{
    		GameObject Prefab = fruitPrefabs[Random.Range(0,fruitPrefabs.Length)];
    		
    		Vector3 position = new Vector3();
    		
    		position.x = Random.Range(SpawnArea.bounds.min.x , SpawnArea.bounds.max.x);
    		position.y = Random.Range(SpawnArea.bounds.min.y , SpawnArea.bounds.max.y);
    		position.z = Random.Range(SpawnArea.bounds.min.z , SpawnArea.bounds.max.z);
    		
    		
    		Quaternion rotation = Quaternion.Euler(0f,0f , Random.Range(minAngle,maxAngle));
    		
    		GameObject fruit = Instantiate(Prefab , position , rotation);
    		Destroy(fruit , maxLifeTime);
    		
    		
    		float force = Random.Range(minForce , maxForce);
    	
    		fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force , ForceMode.Impulse);
    		
    		yield return new WaitForSeconds(Random.Range(minDelay , maxDelay));
    	}
    }
}
