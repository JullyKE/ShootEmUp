using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamageSEU : MonoBehaviour
{
	public float totalHealth;
	public float timeHurt;
	public float timeDie;
	public GameObject explocion;
	int totalEnemy;
	public int enemyFin;
	public Image healthBar;
	public AudioSource hitSound;
	
	float health = 10;
	
	bool isHealth;
	SpriteRenderer sr;
	CapsuleCollider2D capsulCol;
	
	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		capsulCol = GetComponent<CapsuleCollider2D>();
	}
	
    void Start()
    {
	    explocion.SetActive(false);
    }
    
	public void Damage(int ammount)
	{
		if (!isHealth)
		{
			StartCoroutine(VisualDamage());
			health -= ammount;
			healthBar.fillAmount = health/totalHealth;
			hitSound.Play();
			if (health <= 0)
			{
				StartCoroutine(VisualMuerte());
			 	health = 0;
			}
		}
	}
	
	IEnumerator VisualDamage()
	{
		isHealth = true;
		sr.color = Color.red;
		yield return new WaitForSeconds(timeHurt);
		sr.color = Color.white;
		isHealth = false;
	}
	IEnumerator VisualMuerte()
	{
		sr.enabled = false;
		capsulCol.enabled = false;
		explocion.SetActive(true);
		yield return new WaitForSeconds(timeDie);
		SceneManager.LoadScene("2DShootEmUp");
	}
	
	public void AddEnemy()
	{
		totalEnemy++;
		if (totalEnemy >= enemyFin)
		{
			SceneManager.LoadScene("Win");
		}
	}
}
