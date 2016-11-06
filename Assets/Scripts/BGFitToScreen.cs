using UnityEngine;
using System.Collections;

public class BGFitToScreen : MonoBehaviour {

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();


		if(sr == null) return;

		transform.localScale = new Vector3(1,1,1);

		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;


		float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		Vector3 spriteSize = new Vector3(1,1,1);
		spriteSize.x = worldScreenWidth / width;
		spriteSize.y = worldScreenHeight / height;
		transform.localScale = spriteSize;
	}
	
	// Update is called once per frame
	void Update () {




	
	}
		
}
