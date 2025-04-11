using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AnimationControlAT : ActionTask {

		public BBParameter<Animator> animator;

		public BBParameter<bool> catchingMouse;
		public BBParameter<bool> leaping;
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

			// instead of scripts individually setting the animation bools, I personally found it easier to set the all here
			if (catchingMouse.value)
			{
                animator.value.SetBool("Windup", true);
            }
			else
			{
                animator.value.SetBool("Windup", false);
            }
			if (leaping.value)
			{
                animator.value.SetBool("Leaping", true);
            }
			else
			{
                animator.value.SetBool("Leaping", false);
            }
			if (sleeping.value)
			{
                animator.value.SetBool("Sleeping", true);
            }
			else
			{
                animator.value.SetBool("Sleeping", false);
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