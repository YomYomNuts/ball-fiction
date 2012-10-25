using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement du navigateur de page (qui permet de naviguer d'une page à l'autre dans la vue Info)
/// </summary>
public class PagesNavigatorScript : MonoBehaviour {
	private static PagesNavigatorScript _instance;
	
	public static PagesNavigatorScript Instance {
		get {
			if(PagesNavigatorScript._instance == null) {
				PagesNavigatorScript._instance = new PagesNavigatorScript();
			}
			return PagesNavigatorScript._instance;
		}
	}
	
	private int _currentPage = 1;
	
	public int CurrentPage {
		get {
			return this._currentPage;
		}
		private set {
			if(value >= 0 && value < this._pages.Length) {
				if(this._previousButton != null) {
					if(this.CurrentPage == 0 && value > 0) {
						Utils.ShowObject(this._previousButton);
					} else if(this.CurrentPage > 0 && value == 0) {
						Utils.HideObject(this._previousButton);
					}
				}
				if(this._nextButton != null) {
					if(this.CurrentPage == this._pages.Length - 1 && value < this._pages.Length - 1) {
						Utils.ShowObject(this._nextButton);
					} else if(this.CurrentPage < this._pages.Length - 1 && value == this._pages.Length - 1) {
						Utils.HideObject(this._nextButton);
					}
				}
				this._currentPage = value;
				if(this._textMesh != null) {
					this._textMesh.text = string.Format("{0}/{1}", this.CurrentPage+1, this._pages.Length);
				}
			}
		}
	}
	public GameObject[] _pages;
	public GameObject _nextButton;
	public GameObject _previousButton;
	public GameObject _textPageNumber;
	private TextMesh _textMesh;
	
	void Awake() {
		// Unity créera l'objet même si le constructeur est privé donc on doit initialiser l'instance de notre singleton ici
        if (PagesNavigatorScript._instance == null) {
            PagesNavigatorScript._instance = this;
			if(this._nextButton == null) {
				Utils.WarningMessageWhenNoGameObjectAssigned("next button", this.GetType().ToString(), this.gameObject.name);
			}
			if(this._previousButton == null) {
				Utils.WarningMessageWhenNoGameObjectAssigned("previous button", this.GetType().ToString(), this.gameObject.name);
			}
			if(this._textPageNumber == null || this._textPageNumber.GetComponent<TextMesh>() == null) {
				Utils.WarningMessageWhenNoGameObjectAssigned("text for page number", this.GetType().ToString(), this.gameObject.name);
			} else {
				this._textMesh = this._textPageNumber.GetComponent<TextMesh>();
			}
			if(this._pages == null || this._pages.Length == 0) {
				Utils.WarningMessageWhenNoGameObjectAssigned("pages", this.GetType().ToString(), this.gameObject.name);
			} else {
				this.HideAllPages();
				this.CurrentPage = 0;
				this.ShowCurrentPage();
			}
        } else if (PagesNavigatorScript._instance != this) {
            Destroy(this.gameObject);
        }
	}
	
	private bool ShowPage(int index) {
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		if(index < 0 || index >= this._pages.Length) {
			Debug.LogError("Trying to access out of bounds");
			return false;
		}
		if(this._pages[index] == null) {
			Debug.LogError("Trying to show an nonexistent page");
			return false;
		}
		Utils.ShowObject(this._pages[index]);
		return true;
	}
	
	private bool HidePage(int index) {
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		if(index < 0 || index >= this._pages.Length) {
			Debug.LogError("Trying to access out of bounds");
			return false;
		}
		if(this._pages[index] == null) {
			Debug.LogError("Trying to show an nonexistent page");
			return false;
		}
		Utils.HideObject(this._pages[index]);
		return true;
	}
	
	private bool HideAllPages() {
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		bool isSuccess = true;
		for(int i = 0; i < this._pages.Length; i++) {
			isSuccess = isSuccess && this.HidePage(i);
		}
		return isSuccess;
	}
	
	private bool ShowCurrentPage() {
		return this.ShowPage(this.CurrentPage);
	}
	
	private bool HideCurrentPage() {
		return this.HidePage(this.CurrentPage);
	}
	
	public bool NextPage() {
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		if(this.CurrentPage < 0 || this.CurrentPage >= this._pages.Length) {
			Debug.LogError("Current page out of bounds");
			return false;
		}
		if(this.CurrentPage == this._pages.Length-1) {
			return false;
		}
		this.HideCurrentPage();
		this.CurrentPage++;
		this.ShowCurrentPage();
		return true;
	}
	
	public bool PreviousPage() {
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		if(this.CurrentPage < 0 || this.CurrentPage >= this._pages.Length) {
			Debug.LogError("Current page out of bounds");
			return false;
		}
		if(this.CurrentPage == 0) {
			return false;
		}
		this.HideCurrentPage();
		this.CurrentPage--;
		this.ShowCurrentPage();
		return true;
	}
}




























