public abstract class PanelUI : GameUI
{
	protected virtual void ShowPanel()
	{
		_childGameObject.SetActive(true);
	}
	
	protected virtual void HidePanel()
	{
		_childGameObject.SetActive(false);
	}
}
