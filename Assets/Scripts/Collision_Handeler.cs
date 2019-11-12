using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collision_Handeler : MonoBehaviour
{
	

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.name.Contains("Balloon")) { return; }

		Color Col = other.gameObject.GetComponent<Renderer>().material.color;
		Destroy(other.gameObject);

		if (GetComponent<Renderer>().material.color == Col)
		{
			OnHitByBall(gameObject, Col, 0);
			//Same_Color_balloons.Display("Same_Color_balloons");

			//Destroy(gameObject.GetComponent<Collider>());
			//List<Collider> Adj = Physics.OverlapSphere(transform.position, (float)(1.1 * (DefaultValues.Diameter / 2)), LayerMask.GetMask("Balloon")).ToList();
			//Adj.RemoveAll(x => x.gameObject.GetComponent<Renderer>().material.color != Col);
			////Adj.Remove(gameObject.GetComponent<Collider>());
			//foreach (var item in Adj)
			//{
			//	Debug.Log(item.gameObject.transform.name);
			//}
		}
	}

	public void OnHitByBall(GameObject Caller_GO, Color Col, int Depth)
	{
		// Neighboring balloons with same color
		List<Collider> Adj = Physics.OverlapSphere(gameObject.transform.position, (float)(1.1 * (DefaultValues.Diameter / 2)), LayerMask.GetMask("Balloon")).ToList();
		Adj.RemoveAll(x => x.gameObject.GetComponent<Renderer>().material.color != Col);
		Adj.Remove(gameObject.GetComponent<Collider>());

		// remove Caller to avoid a stackoverflow
		Adj.Remove(Caller_GO.GetComponent<Collider>());


		// Rebeat for Neighboring balloons
		foreach (var item in Adj)
		{
			item.GetComponent<Collision_Handeler>().OnHitByBall(gameObject, Col, Depth + 1);
		}

		// Calculate Score
		DefaultValues.Score += DefaultValues.BalloonScore + (Depth * DefaultValues.DepthScore);
		Camera.main.GetComponent<ScoreUpdate>().UpdateScore();
		//Debug.Log($"{gameObject.transform.name} adding Score ==>{DefaultValues.Score}");

		// Destroy This GO
		Destroy(gameObject);
	}

	
}
