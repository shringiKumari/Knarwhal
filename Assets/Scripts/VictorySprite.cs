using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictorySprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void SpriteUpdate(Sprite winner) {
		this.GetComponent<Image> ().sprite = winner;
		Debug.Log ("update sprite");
	}
}
