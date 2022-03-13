using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSEU : MonoBehaviour
{
	public float speed;
	
	Rigidbody2D rb;
	Animator anim;
	Transform limitUp;
	Transform limitDown;
	
	Vector2 move;
	Vector2 minimo;
	Vector2 maximo;
	
	public PlayerController playerC;
	private InputAction movement;
	
	void Awake()
	{
		playerC = new PlayerController();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		movement = playerC.PlayerC.Move;
		movement.Enable();
	}
	
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		movement.Disable();
	}
	
    // Start is called before the first frame update
    void Start()
    {
	    limitUp = GameObject.Find("LimitUp").transform;
	    limitDown = GameObject.Find("LimitDown").transform;
	    minimo = limitDown.position;
	    maximo = limitUp.position;
    }

    // Update is called once per frame
    void Update()
    {
	    //float horizontalInput = Input.GetAxisRaw("Horizontal");
	    //float verticarInput = Input.GetAxisRaw("Vertical");
	    //move = new Vector2(horizontalInput, verticarInput);
	    move = movement.ReadValue<Vector2>();
    }
    
	void FixedUpdate()
	{
		rb.velocity = new Vector2(move.x,move.y) * speed;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x,minimo.x,maximo.x),
			Mathf.Clamp(transform.position.y, minimo.y, maximo.y),transform.position.z);
	}
	
	void LateUpdate()
	{
		if (transform.rotation.z == 0)
		{
			anim.SetFloat("Move", rb.velocity.y);
		}
		else if(transform.rotation.z != 0)
		{
			anim.SetFloat("Move", -rb.velocity.x);
		}
	}
}
