using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class CatchMouseAT : ActionTask {


		public BBParameter<GameObject> mouse;
        public BBParameter<bool> catching;
        public BBParameter<Animator> animator;
        public BBParameter<bool> chasingMouse;
		public BBParameter<NavMeshAgent> navAgent;
        Vector3 acceleration = new Vector3(0, 1f, 0);

		Vector3 leapDestination;

		public float jumpTime = 0.75f;
		float timer = 0;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//navAgent.value.enabled = false;
			leapDestination = mouse.value.transform.position;
            navAgent.value.isStopped = false;
            
            //agent.transform.position += acceleration * Time.deltaTime * 3;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            animator.value.SetBool("Leaping", true);

			/*if (timer < jumpTime / 2)
			{
				agent.transform.position += acceleration * Time.deltaTime * 3;
			}
			else
			{
                agent.transform.position += acceleration * Time.deltaTime * -3;
            }*/
			navAgent.value.speed = 10f;
			navAgent.value.acceleration = 80f;
            navAgent.value.SetDestination(leapDestination);

            if (timer > jumpTime)
			{
				chasingMouse.value = false;
                mouse.value.SetActive(false);
                catching.value = false;
                mouse.value = null;
                navAgent.value.enabled = true;
                navAgent.value.isStopped = false;
                navAgent.value.speed = 3.5f;
                navAgent.value.acceleration = 8f;
                animator.value.SetBool("Leaping", false);
                EndAction(true);
            }

			timer += 1 * Time.deltaTime;
            
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}