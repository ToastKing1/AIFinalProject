using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SleepingAT : ActionTask {

		public BBParameter<bool> sleeping;
        public BBParameter<Animator> animator;
		public BBParameter<float> energy;
		public float energyCharge;
        public GameObject dialogText;
		public string text;

		public float sleepTimer;
		public float sleepTimeMax;
		public float sleepTimeMin;
		float sleepTimeLimit;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            animator.value.SetBool("Sleeping", true);
            sleeping.value = true;
			dialogText.GetComponent<TextMeshPro>().text = text;

            sleepTimer = 0f;
            sleepTimeLimit = Random.Range(sleepTimeMin + 1, sleepTimeMax + 1);
			
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (sleepTimer > sleepTimeLimit)
			{
				sleeping.value = false;
				EndAction(true);
			}

			energy.value = Mathf.Clamp(energy.value + energyCharge * Time.deltaTime, 0, 100);

			sleepTimer += 1 * Time.deltaTime;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}