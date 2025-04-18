using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CatEnergyDrainAT : ActionTask {

		public BBParameter<float> energy;
		public float energyDrain;
		public BBParameter<bool> sleeping;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// if the cat is awake, the cat will slowly lose energy and need to nap eventually
			if (!sleeping.value)
			energy.value = Mathf.Clamp(energy.value - (energyDrain * Time.deltaTime), 0, 100);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}