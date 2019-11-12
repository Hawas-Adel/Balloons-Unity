using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
	public TextMeshProUGUI Score;

	// Start is called before the first frame update
	void Start()
    {
		UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void UpdateScore()
	{
		Score.text = $"Score: {DefaultValues.Score}";
	}
}
