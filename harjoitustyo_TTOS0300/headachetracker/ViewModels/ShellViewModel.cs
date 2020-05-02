using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Threading.Tasks;

namespace headachetracker.ViewModels
{
    class ShellViewModel : Screen
    {
		private string username;

		public string Username
		{
			get 
			{ 
				return username; 
			}
			
			set 
			{ 
				username = value; 
			}
		}


	}
}
