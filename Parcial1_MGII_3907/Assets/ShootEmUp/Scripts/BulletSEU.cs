using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSEU : MonoBehaviour
{
	public float speed = 5f;
	public float timer = 3f;
	public bool isRotate;
	public bool isDown;
	
	[HideInInspector]
	public Vector3 velocity;
	
    // Update is called once per frame
    void Update()
    {
	    Vector3 pos = transform.position;
	    if (!isRotate && !isDown)
	    {
	    	velocity = new Vector3(speed * Time.deltaTime, 0,0);
	    }
	    else if (isRotate && !isDown)
	    {
	    	velocity = new Vector3(0,speed * Time.deltaTime,0);
	    }
	    else if (!isRotate && isDown)
	    {
	    	velocity = new Vector3(-speed * Time.deltaTime,0,0);
	    }
	    else
	    {
	    	velocity = new Vector3(0,-speed * Time.deltaTime,0);
	    }
	    
	    pos += transform.rotation * velocity;
	    transform.position = pos;
	    
	    timer -= Time.deltaTime;
	    if (timer <= 0)
	    {
	    	Destroy(gameObject);
	    }   
    }
}
