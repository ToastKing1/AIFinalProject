using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class TravelToAT : ActionTask {

		public BBParameter<Transform> sleepingSpot;
		public BBParameter<NavMeshAgent> navAgent;
		public GameObject dialogText;
		public string text;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// this is to set the cat to travel to its bed, but it can be used to any location
				if (navAgent.value.destination != sleepingSpot.value.position)
				{
					navAgent.value.SetDestination(sleepingSpot.value.position);
				}
				dialogText.GetComponent<TextMeshPro>().text = text;
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}