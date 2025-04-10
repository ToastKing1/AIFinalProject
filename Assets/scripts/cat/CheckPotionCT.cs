using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckPotionCT : ConditionTask {

		public GameObject potion1;
        public GameObject potion2;
        public GameObject potion3;
        public GameObject potion4;
        public GameObject potion5;

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

			if (potion1.activeInHierarchy || potion2.activeInHierarchy || potion3.activeInHierarchy || potion4.activeInHierarchy || potion5.activeInHierarchy)
			{
                return true;
            }
			else
			{
				return false;
			}
			
		}
	}
}