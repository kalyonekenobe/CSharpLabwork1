using System;

namespace KMA.ProgrammingInCSharp.Models
{
    class DatePickerModel
    {
		private DateTime? _date;

		public DateTime? Date
		{
			get { return _date; }
			set { _date = value; }
		}
	}
}
