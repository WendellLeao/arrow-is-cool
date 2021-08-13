public sealed class WeaponAmmo
{
	private LocalGameEvents _localGameEvents;

	private int _currentAmmoAmount;

	public WeaponAmmo(int startAmmoAmount, LocalGameEvents localGameEvents)
	{
		_currentAmmoAmount = startAmmoAmount;

		_localGameEvents = localGameEvents;

		RaiseOnAmmoChangedEvent();
	}

	public void Decrease()
	{
		_currentAmmoAmount--;

		if (_currentAmmoAmount <= 0)
		{
			_currentAmmoAmount = 0;
		}

		RaiseOnAmmoChangedEvent();
	}

	public void AddAmmo(int ammoAmount)
	{
		_currentAmmoAmount += ammoAmount;
		
		RaiseOnAmmoChangedEvent();
	}

	private void RaiseOnAmmoChangedEvent()
	{
		_localGameEvents.OnAmmoChanged?.Invoke(_currentAmmoAmount);
	}

	public int GetCurrentAmmo()
	{
		return _currentAmmoAmount;
	}
}
