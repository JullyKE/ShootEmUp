using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSEUShoot : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform[] firePoint;
	public float fireDelay = 0.25f;
	
	[Header("Control Bala")]
	[Tooltip("Funciona para poder disparra arriba y abajo junto con isDR")]
	public bool isRotar;
	[Tooltip("Funciona para poder disparra izquierda y abajo junto con isRotar")]
	public bool isDR;
	
	float coolTime = 0;
	
	public PlayerController playerController;
	private InputAction disparar;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		playerController = new PlayerController();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		disparar = playerController.PlayerC.Fire;
		disparar.Enable();
	}
	
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		disparar.Disable();
	}
	
	void Start()
	{
		bulletPrefab.GetComponent<BulletSEU>().isRotate = isRotar;
		bulletPrefab.GetComponent<BulletSEU>().isDown = isDR;
	}
	
    void Update()
    {
	    coolTime = -Time.deltaTime;
	    //if ((Input.GetMouseButtonDown(0)) && coolTime <= 0)
	    if (disparar.triggered && coolTime <= 0)
	    {
	    	coolTime = fireDelay;
	    	foreach(Transform fire in firePoint)
	    	{
		     	Instantiate(bulletPrefab,fire.position,Quaternion.identity);
	    	}
	    }
    }
}
