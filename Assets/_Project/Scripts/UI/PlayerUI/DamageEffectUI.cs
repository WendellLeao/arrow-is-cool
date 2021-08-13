using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public sealed class DamageEffectUI : GameUI
{
	[Header("UI")]
	[SerializeField] private Image _damageEffectImage;

	[Header("Damage Effect")]
	private Color _startImageColor;

	private float _imageAlpha = 100f;

	private bool _canHideDamageEffect = false;

	protected override void SubscribeEvents()
	{
		_localGameEvents.OnPlayerIsDamaged += OnPlayerIsDamaged_ShowDamageEffect;
	}

	protected override void UnsubscribeEvents()
	{
		_localGameEvents.OnPlayerIsDamaged -= OnPlayerIsDamaged_ShowDamageEffect;
	}
	
	protected override void Initialize()
	{
		base.Initialize();
		
		SetStartColor(_damageEffectImage.color);
		
		ResetImageColor();
	}

	private void Update()
	{
		if (_canHideDamageEffect)
		{
			HandleDamageImageEffect();
		}
	}

	private void OnPlayerIsDamaged_ShowDamageEffect()
	{
		ResetImageColor();

		_damageEffectImage.enabled = true;

		StartCoroutine(TimeToHideDamageEffect());
	}

	private IEnumerator TimeToHideDamageEffect()
	{
		float timeToStartRoutine = 0.5f;

		yield return new WaitForSeconds(timeToStartRoutine);

		_canHideDamageEffect = true;
	}

	private void HandleDamageImageEffect()
	{
		if (_damageEffectImage.color.a > 0f)
		{
			float speedToHide = 30f;

			_imageAlpha -= Time.deltaTime * speedToHide;

			Color newColor = new Color(_startImageColor.r, _startImageColor.g, _startImageColor.b, _imageAlpha * 0.01f);

			_damageEffectImage.color = newColor;
		}
		else
		{
			ResetImageColor();

			_canHideDamageEffect = false;
		}
	}

	private void ResetImageColor()
	{
		_imageAlpha = 100f;

		_damageEffectImage.enabled = false;

		_damageEffectImage.color = _startImageColor;
	}

	private void SetStartColor(Color startColor)
	{
		_startImageColor = startColor;
	}
}
