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
		public bool windup;
		public float windupTimer;
		public float windupTimeLimit;
		public bool leaping;
		public BBParameter<bool> catching;
		public BBParameter<GameObject> mouse;

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

			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 3 && leaping == false && catching.value == false && windup == false)
			{
				windup = true;
                leaping = true;
            }

			if (windup)
			{
				//navAgent.value.Move(-mouse.value.transform.position);
				//navAgent.value.speed = -3f;

				// make the cat move backwards while also looking at mouse
				Vector3 directionFromMouse = agent.transform.position - mouse.value.transform.position;
				Vector3 newDirection = agent.transform.position + directionFromMouse.normalized;
				navAgent.value.SetDestination(newDirection);

				//navAgent.value.updateRotation = Vector3.

				
				

				windupTimer += 1 * Time.deltaTime;

				if (windupTimer > windupTimeLimit)
				{
					windup = false;
					windupTimer = 0f;
					navAgent.value.isStopped = true;
					navAgent.value.speed = 3.5f;
                    
                }
            }
			Debug.Log(navAgent.value.remainingDistance);
			if (leaping)
			{

                //update rotation

                Vector3 directionFromMouse = agent.transform.position - mouse.value.transform.position;
                Quaternion rotation = Quaternion.LookRotation(-directionFromMouse);
                agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, 1f);

                //agent.transform.position = new Vector3(agent.transform.position.x, -0.2f, agent.transform.position.z);
                animator.value.SetBool("CatchingMouse", true);
                if (navAgent.value.remainingDistance > 9f)
				{
					leaping = false;
                    leapTimer = 0;
                }
				leapTimer += 1 * Time.deltaTime;

				if (leapTimer > leapTimeLimit)
				{
                    //agent.transform.position = new Vector3(agent.transform.position.x, 0f, agent.transform.position.z);
                    catching.value = true;
					leaping = false;
                    animator.value.SetBool("CatchingMouse", false);
                    return true;
				}
			}
			else
			{
                animator.value.SetBool("CatchingMouse", false);
            }



			return false;
		}
	}
}