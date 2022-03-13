using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySEU : MonoBehaviour
{
	public GameObject enemyPref;
	public bool canSpawn = true;
	
	public float spawnTime = 0.5f;
	public float startPocition = 25f;
	public bool verticalDown;
	public bool upRight;
	
	Transform limitUp;
	Transform limitDown;
	Vector2 minimo;
	Vector2 maximo;
	EnemySEU enemyB;
	
    // Start is called before the first frame update
    void Start()
    {
	    limitUp = GameObject.Find("LimitUp").transform;
	    limitDown = GameObject.Find("LimitDown").transform;
	    minimo = limitDown.position;
	    maximo = limitUp.position;
	    enemyB = enemyPref.GetComponent<EnemySEU>();
	    
	    StartCoroutine(spawnEnemyTime());
    }
	
	IEnumerator spawnEnemyTime()
	{
		while(canSpawn)
		{
			spawnE();
			yield return new WaitForSeconds(spawnTime);
		}
	}
	
	void spawnE()
	{
		float randomT;
		if (verticalDown)
		{
			if (upRight)
			{
				enemyB.isD = false;
			 	enemyB.isU = true;
			 	enemyB.isR = false;
			 	enemyB.isL = false;
				randomT = Random.Range(minimo.x,maximo.x);
				Instantiate(enemyPref,new Vector3(randomT,-startPocition,0),Quaternion.identity);
			}
			else
			{
			 	enemyB.isD = true;
			 	enemyB.isU = false;
			 	enemyB.isR = false;
			 	enemyB.isL = false;
			 	randomT = Random.Range(minimo.x,maximo.x);
			 	Instantiate(enemyPref,new Vector3(randomT,startPocition,0),Quaternion.identity);
			}
		}
		else
		{
			if (upRight)
			{
				enemyB.isD = false;
			  	enemyB.isU = false;
			 	enemyB.isR = true;
				enemyB.isL = false;
				randomT = Random.Range(minimo.y,maximo.y);
				Instantiate(enemyPref,new Vector3(-startPocition,randomT,0),Quaternion.identity);
			}
			else
			{
				enemyB.isD = false;
			  	enemyB.isU = false;
			 	enemyB.isR = false;
			 	enemyB.isL = true;
			 	randomT = Random.Range(minimo.y,maximo.y);
				Instantiate(enemyPref,new Vector3(startPocition,randomT,0),Quaternion.identity);
			}
		}
	}
}
