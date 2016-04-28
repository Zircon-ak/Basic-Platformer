using UnityEngine;
using System.Collections;

public class Ant : Enemy {

	public Vector2 velocity;
	public Transform[] movePoints;

	public override void Behaviour ()
	{
		r2d.MovePosition( r2d.position + velocity * Time.fixedDeltaTime );

		if( r2d.position.x <= movePoints[0].position.x && velocity.x < 0){
			Flip();
		}
		if( r2d.position.x >= movePoints[1].position.x && velocity.x > 0){
			Flip();
		}
	}

	void Flip(){
		velocity.x *= -1; 
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void FixedUpdate(){
		Behaviour();
	}

	void Start(){
		base.Init( 20 );
		velocity = new Vector2(-1.0f, 0.0f );
		damageHit = 20;
	}
}
