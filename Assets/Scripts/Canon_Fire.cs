using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Fire : MonoBehaviour
{
	public GameObject Ball;
	public GameObject Current_ball;
	public GameObject Next_ball;

	Renderer Current_Ball_Rend;
	Renderer Next_Ball_Rend;

    // Start is called before the first frame update
    void Start()
    {
		Current_Ball_Rend = Current_ball.GetComponent<Renderer>();
		Next_Ball_Rend = Next_ball.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire2"))
		{
			Color C = Current_Ball_Rend.material.color;
			Current_Ball_Rend.material.color = Next_Ball_Rend.material.color;
			Next_Ball_Rend.material.color = C;
		}
    }

	void FixedUpdate()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			GameObject Fired_Ball = Instantiate(Ball, transform.position, transform.rotation);
			Fired_Ball.transform.name = "Fired Ball";
			Fired_Ball.transform.localScale = Current_ball.transform.localScale;
			Fired_Ball.GetComponent<Renderer>().material.color = Current_Ball_Rend.material.color;
			Fired_Ball.GetComponent<Rigidbody>().velocity = DefaultValues.Ball_Speed * Fired_Ball.transform.forward.normalized;
			Destroy(Fired_Ball, DefaultValues.Ball_Speed / 5);

			Current_Ball_Rend.material.color = Next_Ball_Rend.material.color;
			Next_Ball_Rend.material.color = DefaultValues.Colors[Random.Range(0, DefaultValues.Colors.Count)];
		}
	}
}
