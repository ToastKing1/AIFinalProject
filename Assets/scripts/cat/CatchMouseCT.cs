using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class CatchMouseCT : ConditionTask {

		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<Animator> animator;
		public float leapTimer = 0;
		public float leapTimeLimit = 2;
		public BBParameter<bool> windup;
		public float windupTimer;
		public float windupTimeLimit;
		public bool primed;
		public BBParameter<bool> catching;
		public BBParameter<GameObject> mouse;
		public BBParameter<bool> chasingMouse;

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

			// if the cat is already trying to leap at the mouse, return true
			if (catching.value)
			{
				return true;
			}

			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 3f && primed == false && windup.value == false)
			{
				// if the mouse is close enough, the cat will wind up
				windup.value = true;
            }

			if (windup.value && !primed)
			{
				// make the cat move backwards while also looking at mouse
				Vector3 directionFromMouse = agent.transform.position - mouse.value.transform.position;
				Vector3 newDirection = agent.transform.position + directionFromMouse.normalized;
				navAgent.value.SetDestination(newDirection);


				// rotate the cat towards the mouse
                Quaternion rotation = Quaternion.LookRotation(-directionFromMouse);
                agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, 1f);

                windupTimer += 1 * Time.deltaTime;

				if (windupTimer > windupTimeLimit)
				{
					windupTimer = 0f;
					navAgent.value.isStopped = true;
					navAgent.value.speed = 3.5f;
					primed = true;
                }
            }
			if (primed)
			{
				//update rotation
				if (!catching.value)
				{
					Vector3 directionFromMouse = agent.transform.position - mouse.value.transform.position;
					Quaternion rotation = Quaternion.LookRotation(-directionFromMouse);
					agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, 1f);
				}


				// a timer to build up while the cat is primed to leap at mouse
				leapTimer += 1 * Time.deltaTime;

				if (leapTimer > leapTimeLimit)
				{
					// cat is no longer winding up and is launching
					leapTimer = 0;
                    catching.value = true;
                    windup.value = false;
                    primed = false;
                    return true;
				}
			}



			return false;
		}
	}
}