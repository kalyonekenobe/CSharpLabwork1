using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp.Tools.Controls
{
	public partial class DatePickerWithCaption : UserControl
	{
		public event Action<object, RoutedEventArgs>? OnDateChanged;

		public void RaiseOnSelectedDateChanged(object sender, RoutedEventArgs e)
		{
			DpDate.SelectedDateChanged -= RaiseOnSelectedDateChanged!; // To avoid the double call of this method when user types the date in date picker textbox
			OnDateChanged?.Invoke(sender, e);
			DpDate.SelectedDateChanged += RaiseOnSelectedDateChanged!;
		}

		public string Caption
		{
			get { return TbCaption.Text; }
			set { TbCaption.Text = value; }
		}

		public DateTime? SelectedDate
		{
			get { return (DateTime?)GetValue(DateProperty); }
			set { SetValue(DateProperty, value); }
		}

		public static readonly DependencyProperty DateProperty = DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(DatePickerWithCaption), new PropertyMetadata(null));

		public DatePickerWithCaption()
		{
			InitializeComponent();
		}
	}
}
