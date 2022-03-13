using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySEU : MonoBehaviour
{
	public float enemySpeed = 0.5f;
	[HideInInspector]
	public bool isL;
	[HideInInspector]
	public bool isD;
	[HideInInspector]
	public bool isR;
	[HideInInspector]
	public bool isU;
	
	public float livingTime = 3f;
	
    // Start is called before the first frame update
    void Start()
    {
	    Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
	{
		Direccion();
	}
	
	void Direccion()
	{
		if (isL && !isD && !isR && !isU)
		{
			transform.Translate(-enemySpeed,0,0);
		}
		else if (!isL && !isD && isR && !isU)
		{
			transform.Translate(enemySpeed,0,0);
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (!isL && isD && !isR && !isU)
		{
			transform.Translate(-enemySpeed,0,0);
			transform.rotation = Quaternion.AngleAxis(90,Vector3.forward);
		}
		else if (!isL && !isD && !isR && isU)
		{
			transform.Translate(-enemySpeed,0,0);
			transform.rotation = Quaternion.AngleAxis(90,Vector3.back);
		}
		else
		{
			transform.Translate(-enemySpeed,0,0);
		}
	}
}
