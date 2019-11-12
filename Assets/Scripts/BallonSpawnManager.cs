using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawnManager : MonoBehaviour
{
	public GameObject Balloon;

	private GameObject Grid;
	private int RowNO = 0;
	// Start is called before the first frame update
	void Start()
	{
		Grid = new GameObject("Grid");

		for (int j = 0; j < DefaultValues.Starting_Rows; j++)
		{
			for (int i = 0; i < DefaultValues.Ballons_per_Row; i++)
			{
				GameObject Baloon_i = Instantiate(Balloon, new Vector3(
					DefaultValues.borders.Upper_Limit.x - ((i + 0.5f) * DefaultValues.Diameter),
					DefaultValues.borders.Upper_Limit.y - ((j + 0.5f) * DefaultValues.Diameter)), Quaternion.identity, Grid.transform);
				Baloon_i.transform.name = $"Balloon ({j.ToString("00")}, {i.ToString("00")})";
				Baloon_i.transform.localScale = Baloon_i.transform.localScale * DefaultValues.Diameter;
			}
		}
		RowNO = DefaultValues.Starting_Rows;

		StartCoroutine(TimedSpawn());
	}

	// Update is called once per frame
	void Update()
	{
		if (DefaultValues.IsGameOver)
		{
			StopCoroutine(TimedSpawn());
		}
	}

	private IEnumerator TimedSpawn()
	{
		for (; ; )
		{
			yield return new WaitForSecondsRealtime(DefaultValues.Time_4_new_Row);

			for (int i = 0; i < DefaultValues.Ballons_per_Row; i++)
			{
				GameObject Baloon_i = Instantiate(Balloon, new Vector3(
					DefaultValues.borders.Upper_Limit.x - ((i + 0.5f) * DefaultValues.Diameter),
					DefaultValues.borders.Upper_Limit.y + (0.5f * DefaultValues.Diameter)), Quaternion.identity, Grid.transform);
				Baloon_i.transform.name = $"Balloon ({RowNO.ToString("00")}, {i.ToString("00")})";
				Baloon_i.transform.localScale = Baloon_i.transform.localScale * DefaultValues.Diameter;
			}
			RowNO++;
			StartCoroutine(MoveDown());
		}
	}
	private IEnumerator MoveDown()
	{
		float Step = DefaultValues.Diameter / 10;
		for (float i = 0.0f; i < DefaultValues.Diameter; i += Step)
		{
			Grid.transform.Translate(Vector3.down * Step);
			yield return new WaitForSeconds(0.05f);
		}
		yield return null;
	}
}
