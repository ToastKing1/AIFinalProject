using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class PotionDistanceCT : ConditionTask {


		public BBParameter<GameObject> potionToTravelTo;

		public BBParameter<NavMeshAgent> navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (potionToTravelTo.value != null)
			{
				if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 1.5f)
				{
					return true;
				}
			}
			
			return false;
		}
	}
}