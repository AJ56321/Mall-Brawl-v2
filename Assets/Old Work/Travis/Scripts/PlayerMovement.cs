using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 3.0f;
	public int jump = 200;
	public bool isGrounded = false;
	public GameObject baton;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Ground")
			{
				isGrounded = true;
			}
		}
	void OnCollisionExit(Collision other){
		if(other.gameObject.tag == "Ground")
			{
				isGrounded = false;
			}
		}

	void Update () {

		if(Input.GetKey (KeyCode.W) && isGrounded==true)
			{
				GetComponent<Rigidbody>().AddForce (Vector2.up * jump);
			}
		if (Input.GetKey (KeyCode.A)) 
		    {
				transform.Translate (Vector2.right * speed * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,180); //flip the character on its x axis to change animation easily
			}
		if (Input.GetKey (KeyCode.D)) 
			{
				transform.Translate (Vector2.right * speed * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,0); 
			}
		//working on an instantiate baton collider
		/*if (Input.GetKey (KeyCode.Space))
			{
				Instantiate(baton, transform.position, transform.rotation);
				int t = 0;
				while(t!=10000)
				{
				t++;
				}
				Destroy(baton);

			}*/
	}
}
