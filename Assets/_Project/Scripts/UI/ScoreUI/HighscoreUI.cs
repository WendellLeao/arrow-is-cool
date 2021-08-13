using UnityEngine;
using TMPro;

public sealed class HighscoreUI : GameUI
{
	[Header("UI Text")]
	[SerializeField] private TMP_Text _highScoreText;

	protected override void SubscribeEvents()
	{
		
	}

	protected override void UnsubscribeEvents()
	{
		
	}

	protected override void Initialize()
	{
		base.Initialize();

		SetHighscoreTextUI();
	}

	private void SetHighscoreTextUI()
	{
		_highScoreText.text = $"Highscore: {SaveSystem.GetLocalGameData().Highscore}";
	}
}
