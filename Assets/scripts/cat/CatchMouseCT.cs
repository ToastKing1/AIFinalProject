using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class CatchMouseCT : ConditionTask {

		public BBParameter<NavMeshAgent> navAgent;
		public float leapTimer = 0;
		public float leapTimeLimit = 2;
		public bool leaping;
		public BBParameter<bool> catching;

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

			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 3 && leaping == false && catching.value == false)
			{
				
				navAgent.value.isStopped = true;
				leaping = true;
				
			}

			if (leaping)
			{
                agent.transform.position = new Vector3(agent.transform.position.x, -0.2f, agent.transform.position.z);
                if (navAgent.value.remainingDistance > 3)
				{
					leaping = false;
                    leapTimer = 0;
                }
				leapTimer += 1 * Time.deltaTime;

				if (leapTimer > leapTimeLimit)
				{
                    agent.transform.position = new Vector3(agent.transform.position.x, 0f, agent.transform.position.z);
                    catching.value = true;
					leaping = false;
					return true;
				}
			}



			return false;
		}
	}
}