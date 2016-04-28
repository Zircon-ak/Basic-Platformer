using UnityEngine;
using System.Collections;

public class Crocodile : Enemy, IShooter {

	public float detectRange;
	public Player player;

	public Transform spawner;
	public Transform Spawner{
		get { return spawner; }
		set { spawner = value; }
	}

	public GameObject bullet;
	public GameObject Bullet { 
		get { return bullet; } 
		set { bullet = value; } 
	}

	public float ReloadTime { get; set; }
	public float WaitTime { get; set; }

	public void Shoot(){
		if (WaitTime >= ReloadTime){
			anim.SetTrigger("Shoot");
			GameObject obj = Instantiate( Bullet, Spawner.position, Quaternion.identity ) as GameObject;
			Rock rock = obj.GetComponent<Rock>();
			rock.Init(30, this);
			WaitTime = 0;
		}
	}

	public override void Behaviour ()
	{
		Vector2 distance = player.transform.position - transform.position;
		if ( distance.magnitude <= detectRange )
			Shoot();
	}

	void FixedUpdate(){
		WaitTime += Time.fixedDeltaTime;
		Behaviour();
	}

	void Start(){
		base.Init( 30 );
		WaitTime = 0.0f;
		ReloadTime = 5.0f;
		damageHit = 30;
		detectRange = 6.0f;
		player = GameObject.FindObjectOfType<Player>();
	}

}
