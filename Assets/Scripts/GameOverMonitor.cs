using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverMonitor : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Moniter_GameOver());
		float n = DefaultValues.borders.Upper_Limit.y - (DefaultValues.Diameter * (DefaultValues.Rows_4_GameOver - 0.5f));
		Debug.Log(n);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private IEnumerator Moniter_GameOver()
	{
		for (; ; )
		{
			yield return new WaitForSecondsRealtime(5);
			List<Collider> Balloons = Physics.OverlapSphere(new Vector3(0, 0, 0), (float)(DefaultValues.borders.Upper_Limit.magnitude + 1), LayerMask.GetMask("Balloon")).ToList();
			if (Balloons.Count == 0)
			{
				DefaultValues.IsGameOver = true;
				StopCoroutine(Moniter_GameOver());
				yield return null;
			}
			else
			{
				Balloons.Sort(new System.Comparison<Collider>((x, y) => Mathf.FloorToInt(x.transform.position.y - y.transform.position.y)));
				Debug.Log(Balloons[0].transform.position.y);

				
			}
		}
	}
}
