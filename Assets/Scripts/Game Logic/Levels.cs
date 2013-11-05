using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {
	
	public const string levelSelect = "LevelSelect";
	
	public const string level1 = "L1";
	public const string level2 = "L2";
	public const string level3 = "L3";
	public const string level4 = "L4";
	public const string level5 = "L5";
	public const string level6 = "L6";
	public const string level7 = "L7";
	public const string level8 = "L8";
	public const string level9 = "L9";
	public const string level10 = "L10";
	public const string level11 = "L11";
	public const string level12 = "L12";
	public const string level13 = "L13";
	public const string level14 = "L14";
	public const string level15 = "L15";
	public const string level16 = "L16";
	public const string level17 = "L17";
	public const string level18 = "L18";
	
	public const int count = 18;
	
	public static string GetLevelName(int levelNumber){
		return "L" + levelNumber.ToString();
	}
}
