using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CreatePotionAT : ActionTask {

        public BBParameter<GameObject> potionToTravelTo;
		public BBParameter<bool> hasPotions;
		public BBParameter<int> amountOfPotions;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			// this is to place potions onto the pedestals

			if (amountOfPotions.value != 0)
			{
				amountOfPotions.value = Mathf.Clamp(amountOfPotions.value - 1, 0, 3);
				potionToTravelTo.value.SetActive(true);
				potionToTravelTo.value = null;
			}

			if (amountOfPotions.value <= 0)
			{
				hasPotions.value = false;
			}

            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}