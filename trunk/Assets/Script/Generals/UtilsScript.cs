using UnityEngine;
using System;

/// <summary>
/// Classe permettant de centraliser les méthodes, constantes, énumération, etc... utiles au projet
/// </summary>
public class UtilsScript {
	/// <summary>
	/// La constant définissant de combien doivent être décalés les éléments à désactiver
	/// </summary>
	private const float DecalageToHide = 50f;
	
	#region Attributes
	/// <summary>
	/// Constantes pour pouvoir modifier le nom des scènes facilement
	/// </summary>
	public const string SceneLevel1 = "Level1-tutorial";
	public const string SceneLevel2 = "Level2";
	public const string SceneLevel3 = "Level3";
	public const string SceneLevelDemo = "LevelDemo";
	public const string SceneLevelPlayerName = "LevelPlayerName";
	public const string SceneLevelSolved = "LevelSolved";
	public const string SceneLevelAbandoned = "LevelAbandoned";
	public const string SceneLevelLost = "LevelLost";
	public const string SceneMenu = "Menu";
	public const string SceneInfo = "Info";
	public const string SceneCredits = "Credits";
	/// <summary>
	/// L'alphabet utilisé pour le nom du joueur
	/// </summary>
	public const string LetterPlayerName = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
	#endregion
	
	#region Enumerations
	/// <summary>
	/// Enumération des directions possible pour les tapis roulants et les portes
	/// </summary>
	public enum Direction {
		Forward,
		Back,
		Left,
		Right,
		Up,
		Down
	}
	/// <summary>
	/// Les différents boutons du menu
	/// </summary>
	public enum MenuButton {
		Menu,
		RestartLevel,
		Quit,
		LevelDemo,
		Level1,
		Level2,
		Level3,
		Info,
		Credits,
		LevelSolved,
		letterUp,
		letterDown
	}
	#endregion
	
	#region Methods
	/// <summary>
	/// Affiche un warning dans la console disant que "missingObjectName" n'est pas assigné dans le script "scriptName" de "objectName"
	/// </summary>
	/// <param name='missingObjectName'>
	/// Le nom de l'objet manquant (qui n'a pas été assigné)
	/// </param>
	/// <param name='scriptName'>
	/// Le nom du script dans lequel l'objet est manquant
	/// </param>
	/// <param name='objectName'>
	/// Le nom de l'objet contenant le script
	/// </param>
	public static void WarningMessageWhenNoGameObjectAssigned(string missingObjectName, string scriptName, string objectName) {
		Debug.LogWarning(string.Format("There is no {0} assigned to the {1} of {2}", missingObjectName, scriptName, objectName));
	}
	
	/// <summary>
	/// Définit comment le temps est formatté
	/// </summary>
	/// <returns>
	/// Le temps formatté en "HH:MM:SS.SSS"
	/// </returns>
	/// <param name='theTime'>
	/// Le temps à convertir
	/// </param>
	public static string FormatTime(float theTime) {
		float sec = theTime;
		int hours = (int)sec/3600;
		sec -= hours*3600;
		int min = (int)sec/60;
		sec -= min*60;
		string minuts = string.Format("{0}",min);
		if(min < 10) {
			minuts = string.Concat("0",minuts);
		}
		string seconds = string.Format("{0}",Math.Round(sec,3));
		if(sec < 10) {
			seconds = string.Concat("0",seconds);
		}
		if(seconds.Contains(".")) {
			while(seconds.Length < 6) {
				seconds = string.Concat(seconds,"0");
			}
		} else {
			seconds = string.Concat(seconds,".000");
		}
		return string.Format("{0}:{1}:{2}",hours, minuts, seconds);
	}
	
	/// <summary>
	/// Définit comment le score est formatté
	/// </summary>
	/// <returns>
	/// Le score en string
	/// </returns>
	/// <param name='theScore'>
	/// Le score à convertir
	/// </param>
	public static string FormatScore(int theScore) {
			return string.Format("{0}",theScore);
	}
	
	/// <summary>
	/// Permet de "cacher" un objet
	/// </summary>
	/// <param name='objectToHide'>
	/// L'objet à cacher
	/// </param>
	public static void HideObject(GameObject objectToHide) {
		objectToHide.transform.localPosition += new Vector3(UtilsScript.DecalageToHide, 0, 0);
	}
	
	/// <summary>
	/// Permet d'"afficher" un objet
	/// </summary>
	/// <param name='objectToShow'>
	/// L'objet à afficher
	/// </param>
	public static void ShowObject(GameObject objectToShow) {
		objectToShow.transform.localPosition -= new Vector3(UtilsScript.DecalageToHide, 0, 0);
	}
	#endregion
}