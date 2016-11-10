using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarReset : MonoBehaviour {

     public Image healthBar;
     // Use this for initialization
	void Start () {
	
	}
     void OnEnable () {
          healthBar.fillAmount = 1.0f;
     }
	// Update is called once per frame
	void Update () {
	
	}
}
