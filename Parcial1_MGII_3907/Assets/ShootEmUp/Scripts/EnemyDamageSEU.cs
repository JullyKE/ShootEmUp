using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSEU : MonoBehaviour
{
	public int damage;
	GameObject player;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Bullet"))
		{
			Destroy(gameObject);
			Destroy(other);
			player.GetComponent<PlayerDamageSEU>().AddEnemy();
		}
		
		if (other.CompareTag("Player"))
		{
			Destroy(gameObject);
			other.SendMessage("Damage", damage);
		}
	}
}
