using UnityEngine;
using System.Collections;

public class Banana : Weapon {

	public float speed;

	public override void Move ()
	{
		float newX = transform.position.x + speed*Time.fixedDeltaTime;
		float newY = transform.position.y;
		Vector2 newPosition = new Vector2(newX, newY);
		transform.position = newPosition;
	}

	public override void OnHitWith (Character obj)
	{
		if ( obj is Enemy )
			obj.SubtractHealth( this.damage );
	}

	void FixedUpdate(){
		Move();
	}

	void Start(){
		speed = 4.0f*GetShootDirection();
		damage = 30;
	}
}
