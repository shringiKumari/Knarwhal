using UnityEngine;
using System.Collections;

public class SpriteInformation : MonoBehaviour {

     [SerializeField]
     private SpriteRenderer spriteBody;

     public Bounds GetBodyBounds(){
          return spriteBody.bounds;
     }
}
