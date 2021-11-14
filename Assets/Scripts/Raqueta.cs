using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Raqueta : MonoBehaviour {

//Velocidad
public float velocidad = 50.0f;
//Eje horizontal
public string ejeX;
// Es llamado una vez cada fixed frame
void FixedUpdate () {
//Capto el valor del eje horizontal de la raqueta
float h = Input.GetAxisRaw(ejeX);
//Modifico la velocidad de la raqueta
GetComponent<Rigidbody2D>().velocity = new Vector2(h*velocidad, 0* velocidad);
}
}