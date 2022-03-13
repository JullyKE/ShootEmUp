using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
	public float speedX;
	
	RawImage background;
	
    // Start is called before the first frame update
	void Awake()
    {
	    background = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
	    float finalSpeed = speedX * Time.deltaTime;
	    background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f,1f,1f);
    }
}
