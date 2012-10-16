using UnityEngine;

/// <summary>
/// Classe permettant de centraliser les méthodes, constantes, énumération, etc... utiles au projet
/// </summary>
public class Utils {
	/// <summary>
	/// Enumération des directions possible pour les tapis roulants
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
	/// Les différents bouton du menu
	/// </summary>
	public enum MenuButton {
		Menu,
		RestartLevel,
		Quitter,
		LevelDemo,
		Level1,
		Level2,
		Level3
	}
	
	/// <summary>
	/// Constantes pour pouvoir modifier le nom des scènes facilement
	/// </summary>
	public const string SceneLevel1 = "Level1-tutorial";
	public const string SceneLevel2 = "Level2";
	public const string SceneLevel3 = "Level3-todo";
	public const string SceneLevelDemo = "LevelDemo";
	public const string SceneLevelSolved = "LevelSolved";
	public const string SceneLevelAbandoned = "LevelAbandoned";
	public const string SceneLevelLost = "LevelLost";
	public const string SceneMenu = "Menu";
	
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
}