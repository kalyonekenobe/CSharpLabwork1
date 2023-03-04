using KMA.ProgrammingInCSharp.ViewModels;
using Microsoft.VisualBasic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp.Views
{
    public partial class DatePickerView : UserControl
    {
        private DatePickerViewModel _viewModel;

        public DatePickerView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DatePickerViewModel();
        }

		private void DpwcBirthDate_OnDateChanged(object sender, RoutedEventArgs e)
		{
			((DatePickerViewModel)DataContext).Date = DpwcBirthDate.SelectedDate;
			DateTime? senderSelectedDate = ((DatePicker)sender).SelectedDate;
			try
			{
				DateTime newSelectedDate = DateTime.Parse(senderSelectedDate?.ToString() ?? string.Empty);
				int yearsDifference = _viewModel.CalculateUserAge(newSelectedDate);
				if (yearsDifference > 135)
				{
					throw new ArgumentOutOfRangeException();
				}
				DpwcBirthDate.SelectedDate = newSelectedDate;
			}
			catch (Exception)
			{
				DpwcBirthDate.SelectedDate = null;
				MessageBox.Show("You've picked incorrect date! Try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
