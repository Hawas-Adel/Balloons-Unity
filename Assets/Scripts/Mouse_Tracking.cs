using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Tracking : MonoBehaviour
{
	Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
		Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 Mouse_POS = Cam.ScreenToWorldPoint(Input.mousePosition);
		Mouse_POS.z = 0;
		gameObject.transform.LookAt(Mouse_POS, Vector3.back);
    }
}
