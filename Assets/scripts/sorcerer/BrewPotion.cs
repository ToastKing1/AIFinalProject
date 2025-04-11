using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class BrewPotion : ActionTask {

		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<bool> hasPotion;
		public BBParameter<Transform> brewingStation;
		public BBParameter<int> amountOfPotions;

		public float timer;
		public float timeLimit;
		public float timeLimitMin;
		public float timeLimitMax;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			navAgent.value.SetDestination(brewingStation.value.position);
			timer = 0f;
			timeLimit = Random.Range(timeLimitMin, timeLimitMax + 1);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 0.5f)
			{
				timer += 1 * Time.deltaTime;


				if (timer > timeLimit)
				{
					amountOfPotions.value = 3;
					hasPotion.value = true;
					EndAction(true);
				}
			}
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}