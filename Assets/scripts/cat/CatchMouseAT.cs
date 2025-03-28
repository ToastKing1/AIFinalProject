using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class CatchMouseAT : ActionTask {


		public BBParameter<GameObject> mouse;
        public BBParameter<bool> catching;
        public BBParameter<bool> chasingMouse;
		public BBParameter<NavMeshAgent> navAgent;
        Vector3 acceleration = new Vector3(0, 1f, 0);

		public float jumpTime = 1f;
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
            navAgent.value.enabled = false;
            //agent.transform.position += acceleration * Time.deltaTime * 3;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
            agent.transform.position += acceleration * Time.deltaTime * 3;
			

			if (timer > jumpTime)
			{
				chasingMouse.value = false;
                mouse.value.SetActive(false);
                catching.value = false;
                mouse.value = null;
                navAgent.value.enabled = true;
                navAgent.value.isStopped = false;
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