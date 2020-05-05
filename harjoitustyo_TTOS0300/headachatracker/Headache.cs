using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headachatracker
{
    public class Headache
    {
		#region Fields
		private int acheID;
		private string triggers;
		private int userID;
		private string acheType;
		private int painLevel;
		private string medications;
		private string symptoms;
		private string reliefs;
		private string notes;
		#endregion

		#region Properties
		public int AcheID
		{
			get { return acheID; }
			set { acheID = value; }
		}

		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}

		public string AcheType
		{
			get { return acheType; }
			set { acheType = value; }
		}

		public int PainLevel
		{
			get { return painLevel; }
			set { painLevel = value; }
		}

		public string Medications
		{
			get { return medications; }
			set { medications = value; }
		}

		public string Symptoms
		{
			get { return symptoms; }
			set { symptoms = value; }
		}

		public string Reliefs
		{
			get { return reliefs; }
			set { reliefs = value; }
		}

		public string Triggers
		{
			get { return triggers; }
			set { triggers = value; }
		}

		public string Notes
		{
			get { return notes; }
			set { notes = value; }
		}
		#endregion
	}
}
