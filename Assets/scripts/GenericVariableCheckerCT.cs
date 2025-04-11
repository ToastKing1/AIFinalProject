using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class GenericVariableCheckerCT : ConditionTask {

		public BBParameter<bool> GenericVariable;

		public bool checkVariable;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			// this exists to check bools
            if (GenericVariable.value == checkVariable)
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