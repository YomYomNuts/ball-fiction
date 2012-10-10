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
		LevelProto,
		LevelDemo,
		Menu,
		Quitter
	}
	
	/// <summary>
	/// Constantes pour pouvoir modifier le nom des scènes facilement
	/// </summary>
	public const string SceneLevelProto = "LevelProto";
	public const string SceneLevelDemo = "LevelDemo";
	public const string SceneLevelSolved = "LevelSolved";
	public const string SceneLevelAbandoned = "LevelAbandoned";
	public const string SceneMenu = "Menu";
}