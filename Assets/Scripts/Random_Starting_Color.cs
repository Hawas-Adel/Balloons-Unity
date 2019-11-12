using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Starting_Color : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		gameObject.GetComponent<Renderer>().material.color = DefaultValues.Colors[Random.Range(0, DefaultValues.Colors.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
