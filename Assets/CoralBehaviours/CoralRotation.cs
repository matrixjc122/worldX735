using UnityEngine;
using System.Collections;

public class CoralRotation : CoralBase {


	public float timeLeft = 25;

	// Use this for initialization
	void Start () {

		/*
		 Transform[] transforms = gameObject.GetComponentsInChildren <Transform> ();

		origin = new Transform[transforms.Length];
				
		for(int i = 0 ; i < transforms.Length; i++){
					origin[i] = Transform.Instantiate(transforms[i]) as Transform;
			}
		*/
		Transform[] transforms = gameObject.GetComponentsInChildren <Transform> ();
		for (int i = 0; i < transforms.Length; i++) {
			

			//SCALE	
				transforms [i].localScale = new Vector3 (
					Random.Range (0.90f, 0.995f) * transforms [i].localScale.x,
					Random.Range (0.75f, 0.99f) * transforms [i].localScale.y,
					Random.Range (0.90f, 0.995f) * transforms [i].localScale.z);

			//POSITION
			if (transforms [i].gameObject.name == "TrichterC3" || transforms [i].gameObject.name == "TrichterC4") {
				transforms [i].localPosition = new Vector3 (
					Random.Range (-0.1f, 0.1f) + transforms [i].localPosition.x,
					Random.Range (-0.1f, 0.1f) + transforms [i].localPosition.y,
					Random.Range (0.0f, 0.0f) + transforms [i].localPosition.z);
			}

			//ROTATION
				transforms [i].localRotation = Quaternion.Euler (
					transforms [i].localRotation.x,
					Random.Range (0.0f, 360.0f) + transforms [i].localRotation.y,
					transforms [i].localRotation.z);
		
			//SET BACK ROTATION OF "BODEN"
			/*
			if(transforms [i].gameObject.name == "Terrain_Boden"){
				transforms [i].localRotation = Quaternion.Euler (
					transforms [i].localRotation.x - transforms [i].localRotation.x,
					transforms [i].localRotation.y - transforms [i].localRotation.y,
					transforms [i].localRotation.z - transforms [i].localRotation.z);
			}
			*/
	}
}


#region implemented abstract members of CoralBase

public override CoralBase CopyOf (CoralBase other)
{
	return this;
}

#endregion
}
