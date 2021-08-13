using UnityEngine.UI;
using UnityEngine;

public sealed class HealthBarUI : GameUI
{
	[Header("UI")]
	[SerializeField] private Image _healthBarAmountImage;

	protected override void SubscribeEvents()
	{
		base.SubscribeEvents();

		_localGameEvents.OnHealthChanged += OnHealthChanged_UpdateHealthBar;
	}

	protected override void UnsubscribeEvents()
	{
		base.UnsubscribeEvents();

		_localGameEvents.OnHealthChanged -= OnHealthChanged_UpdateHealthBar;
	}

	private void OnHealthChanged_UpdateHealthBar(int currentHealthAmount, int maxHealthAmount)
	{
		float healthPercent = (float) currentHealthAmount / maxHealthAmount;

		_healthBarAmountImage.fillAmount = healthPercent;
	}
}
