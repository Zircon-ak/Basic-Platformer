using UnityEngine;
using System.Collections;

public class Player : Character, IShooter {

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
		if( Input.GetButtonDown("Fire1") && (WaitTime >= ReloadTime) ) {
			GameObject obj = Instantiate( Bullet, Spawner.position, Quaternion.identity ) as GameObject;
			Banana banana = obj.GetComponent<Banana>();
			banana.Init(20, this);
			WaitTime = 0;
		}
	}

	public void OnHitWith( Enemy obj ){
		SubtractHealth( obj.damageHit );
	}
	void Update(){
		Shoot();
	}
	void FixedUpdate(){
		WaitTime += Time.fixedDeltaTime;
	}
	void Start(){
		base.Init( 100 );
		WaitTime = 0.0f;
		ReloadTime = 1.0f;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Enemy obj = coll.gameObject.GetComponent<Enemy>();
		if(obj != null)
			OnHitWith( obj );
	}
}
