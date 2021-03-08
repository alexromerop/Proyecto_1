using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElevatorButton : MonoBehaviour
{
	public Elevator Elevator;

	void OnTriggerEnter(Collider collider)
	{
		var go = collider.gameObject;
		var prota_0 = go.GetComponent<porta_0>();

		if (prota_0 != null && Elevator != null)
		{
			Elevator.CallElevator();
		}
	}
}