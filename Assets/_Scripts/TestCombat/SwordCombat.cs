using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordCombat : MonoBehaviour {
	public Combat Combat;
	public Scrollbar HealthBar;
	public Text Character_lifetext;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Wolf") || other.gameObject.CompareTag("Bandit"))
		{
			HealthBar.enabled = true;
			Character_lifetext.enabled = true;
			Combat.CombatSword(other.gameObject);
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Wolf") || other.gameObject.CompareTag("Bandit"))
		{
			Combat.CombatSword(other.gameObject);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Wolf") || other.gameObject.CompareTag("Bandit"))
		{
			Combat.CombatSword(other.gameObject);
		}
	}
}
