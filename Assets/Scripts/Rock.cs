using UnityEngine;
using System.Collections;

public class Rock : Weapon {

	public Rigidbody2D r2d;
	public Vector2 force;
	public override void Move ()
	{
		r2d.AddForce( force );
	}

	public override void OnHitWith (Character obj)
	{
		if ( obj is Player )
			obj.SubtractHealth( this.damage );
	}

	void Start(){
		r2d = GetComponent<Rigidbody2D>();
		damage = 40;
		force = new Vector2( GetShootDirection() * 90, 400 );
		Move();
	}
}
