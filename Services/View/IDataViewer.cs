using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Services.View
{
	internal interface IDataViewer<T>
	{
		public void Display(T data);
	}
}
