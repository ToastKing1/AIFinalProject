using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckPotionCT : ConditionTask {

		public GameObject potion1;
        public GameObject potion2;
        public GameObject potion3;
        public GameObject potion4;
        public GameObject potion5;

		public BBParameter<GameObject> potionToTravelTo;
		public BBParameter<NavMeshAgent> navAgent;

		public bool creatingPotions;

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
			// If any potions are missing/placed, this conditions checks if either AI needs to act upon that

			// this is for the cat who checks for potions that are placed
			if (!creatingPotions)
			{
				if (potion1.activeInHierarchy || potion2.activeInHierarchy || potion3.activeInHierarchy || potion4.activeInHierarchy || potion5.activeInHierarchy)
				{
					if (potion1.activeInHierarchy)
					{
						potionToTravelTo.value = potion1;
					}
					else if (potion2.activeInHierarchy)
					{
						potionToTravelTo.value = potion2;
					}
					else if (potion3.activeInHierarchy)
					{
						potionToTravelTo.value = potion3;
					}
					else if (potion4.activeInHierarchy)
					{
						potionToTravelTo.value = potion4;
					}
					else if (potion5.activeInHierarchy)
					{
						potionToTravelTo.value = potion5;
					}

					if (potionToTravelTo.value != null)
					{
						navAgent.value.SetDestination(potionToTravelTo.value.transform.position);

						return true;
					}
					else
					{
						return false;
					}
				}
			}
			// this is for the sorcerer who checks for missing potions
			else if (creatingPotions)
			{
				if (!potion1.activeInHierarchy || !potion2.activeInHierarchy || !potion3.activeInHierarchy || !potion4.activeInHierarchy || !potion5.activeInHierarchy)
				{
					if (!potion1.activeInHierarchy)
					{
						potionToTravelTo.value = potion1;
					}
					else if (!potion2.activeInHierarchy)
					{
						potionToTravelTo.value = potion2;
					}
					else if (!potion3.activeInHierarchy)
					{
						potionToTravelTo.value = potion3;
					}
					else if (!potion4.activeInHierarchy)
					{
						potionToTravelTo.value = potion4;
					}
					else if (!potion5.activeInHierarchy)
					{
						potionToTravelTo.value = potion5;
					}

					if (potionToTravelTo.value != null)
					{
						navAgent.value.SetDestination(potionToTravelTo.value.transform.position);

						return true;
					}
					else
					{
						return false;
					}
				}
			}

            return false;
            
				
			
		}
	}
}