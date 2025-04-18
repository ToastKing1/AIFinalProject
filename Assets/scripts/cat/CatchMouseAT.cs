using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class CatchMouseAT : ActionTask {


		public BBParameter<GameObject> mouse;
        public BBParameter<bool> catching;
        public BBParameter<Animator> animator;
        public BBParameter<bool> chasingMouse;
		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<GameObject> catchCollision;
        Vector3 acceleration = new Vector3(0, 1f, 0);
		public GameObject dialogText;

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
			leapDestination = mouse.value.transform.position;
            navAgent.value.isStopped = false;
			// the catch collision is the collision to destroy the mouse
            catchCollision.value.SetActive(true);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            animator.value.SetBool("Leaping", true);

			// the cat will leap extremely fast but in a very short duration
			navAgent.value.speed = 12.5f;
			navAgent.value.acceleration = 80f;
            navAgent.value.SetDestination(leapDestination);

			

            if (timer > jumpTime)
			{
				// reset all variables when the leap is finished
                dialogText.GetComponent<TextMeshPro>().text = "";
                catchCollision.value.SetActive(false);
                chasingMouse.value = false;
                catching.value = false;
                navAgent.value.enabled = true;
                navAgent.value.isStopped = false;
				navAgent.value.velocity = new Vector3(0,0,0);
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