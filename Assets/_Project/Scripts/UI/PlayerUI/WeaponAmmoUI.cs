using UnityEngine;
using TMPro;

public sealed class WeaponAmmoUI : GameUI
{
	[Header("Text")]
	[SerializeField] private TMP_Text _weaponAmmoText;

	protected override void SubscribeEvents()
	{
		base.SubscribeEvents();

		_localGameEvents.OnAmmoChanged += OnPlayerShot_UpdateWeaponAmmoText;
	}

	protected override void UnsubscribeEvents()
	{
		base.UnsubscribeEvents();

		_localGameEvents.OnAmmoChanged -= OnPlayerShot_UpdateWeaponAmmoText;
	}

	private void OnPlayerShot_UpdateWeaponAmmoText(int currentWeaponAmmo)
	{
		_weaponAmmoText.text = $"Ammo: {currentWeaponAmmo}";

		UpdateWeaponAmmoTextColor(currentWeaponAmmo);
	}

	private void UpdateWeaponAmmoTextColor(int currentWeaponAmmo)
	{
		if (currentWeaponAmmo <= 0)
		{
			_weaponAmmoText.color = Color.red;
		}
		else
		{
			_weaponAmmoText.color = Color.white;
		}
	}
}
