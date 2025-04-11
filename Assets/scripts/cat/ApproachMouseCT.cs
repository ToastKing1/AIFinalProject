using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ApproachMouseCT : ConditionTask {

		public BBParameter<GameObject> mouse;
		public BBParameter<bool> chasingMouse;
		public BBParameter<bool> catchingMouse;
		public BBParameter<Animator> animator;
		public GameObject dialogText;

		public BBParameter<bool> sleeping;
		public BBParameter<GameObject> potionToTravelTo; 

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


			if (mouse.value != null && mouse.value.activeInHierarchy) // this is to check if the mouse exists
			{
				if (chasingMouse.value || catchingMouse.value || potionToTravelTo.value != null)
				{
					return false;
				}

				float distance = (agent.transform.position - mouse.value.transform.position).magnitude;

				if (distance < 7.5f && !sleeping.value) // the cat's distance to check for the mouse
				{
					dialogText.GetComponent<TextMeshPro>().text = "Meow! (A mouse!)";
					chasingMouse.value = true;
					return true;
				}
				else if (distance < 4f && sleeping.value) // if the cat is asleep, the checking distance is lower
				{
					sleeping.value = false;
                    dialogText.GetComponent<TextMeshPro>().text = "Meow! (A mouse!)";
                    chasingMouse.value = true;
                    return true;
                }
				else
				{
					chasingMouse.value = false;
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