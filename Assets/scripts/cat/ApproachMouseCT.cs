using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ApproachMouseCT : ConditionTask {

		public BBParameter<GameObject> mouse;
		public BBParameter<bool> chasingMouse;
		public BBParameter<bool> catchingMouse;

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


			if (mouse.value != null && mouse.value.activeInHierarchy)
			{
				if (catchingMouse.value)
				{
					return true;
				}

				float distance = (agent.transform.position - mouse.value.transform.position).magnitude;

				if (distance < 10)
				{
					chasingMouse.value = true;
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			
		}
	}
}