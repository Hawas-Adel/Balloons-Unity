using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefaultValues
{
	public static readonly Camera Cam = Camera.main;
	public static readonly List<Color> Colors = new List<Color>
	{
		new Color(0,0,0,1),
		new Color(1,0,0,1),
		new Color(0,1,0,1),
		new Color(0,0,1,1),
		new Color(1,1,0,1),
		new Color(0,1,1,1),
		new Color(1,0,1,1),
		new Color(1,1,1,1)
	};
	public static readonly int Ballons_per_Row = 20;
	public static readonly int Starting_Rows = 3;
	public static readonly int Rows_4_GameOver = 7;
	public static readonly float Time_4_new_Row = 10; //20;
	public static readonly float Ball_Speed = 10;
	public static readonly int BalloonScore = 10;
	public static readonly int DepthScore = 5;

	public static readonly bool DEBUG = true;

	// Values handeled somwhere else, Do not change
	public static float Diameter;
	public static border borders;
	public static int Score = 0;
	public static bool IsGameOver = false;

	static DefaultValues()
	{
		borders = new border(Camera.main);

		Diameter = borders.Size.x / Ballons_per_Row;
	}
}

public struct border
{
	public Vector2 Upper_Limit;
	public Vector2 Lower_Limit;
	public Vector2 Size;

	public border(Camera Cam)
	{
		Lower_Limit = Cam.ScreenToWorldPoint(new Vector3(0, 0));
		Upper_Limit = Cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
		Size.x = Upper_Limit.x - Lower_Limit.x;
		Size.y = Upper_Limit.y - Lower_Limit.y;
	}
}

public static class Extention
{
	public static void AddUnique<T>(this List<T> List, T Ob)
	{
		if (!List.Contains(Ob))
			List.Add(Ob);
	}

	public static void Display(this List<GameObject> List, string Name)
	{
		string Str = Name + ": ";
		foreach (GameObject GO in List)
		{
			Str += GO.transform.Path() + ", ";
		}
		Debug.Log(Str);
	}

	public static string Path(this Transform TR)
	{
		if (TR.parent == null)
			return "/" + TR.name;
		return TR.parent.Path() + "/" + TR.name;
	}
}