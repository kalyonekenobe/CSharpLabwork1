using KMA.ProgrammingInCSharp.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KMA.ProgrammingInCSharp.ViewModels
{
    class DatePickerViewModel : INotifyPropertyChanged
    {
        private DatePickerModel _datePicker = new DatePickerModel();

		private enum WesternAstrologyZodiacSigns
		{
			Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn, Aquarius, Pisces
		}

		private enum ChineseAstrologyZodiacSigns
		{
			Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey, Rooster, Dog, Pig
		}

		public string UserAgeInfo
        {
            get { return GetUserAgeInfo(); }
        }

		public string UserWesternAstrologyZodiacSign
		{
			get { return GetUserWesternAstrologyZodiacSign(); }
		}

		public string UserChineseAstrologyZodiacSign
		{
			get { return GetUserChineseAstrologyZodiacSign(); }
		}

		public DateTime? Date
        {
            get { return _datePicker.Date; }
            set
            {
                _datePicker.Date = value;
				NotifyPropertyChanged(nameof(UserAgeInfo));
				NotifyPropertyChanged(nameof(UserWesternAstrologyZodiacSign));
				NotifyPropertyChanged(nameof(UserChineseAstrologyZodiacSign));
				NotifyPropertyChanged(nameof(Date));
			}
        }

		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public int CalculateUserAge(DateTime? date)
		{
			if (date == null)
				throw new ArgumentOutOfRangeException();
			DateTime now = DateTime.Now;
			DateTime zeroDate = DateTime.MinValue;
			TimeSpan timeDifference = now - (date ?? now);
			return (zeroDate + timeDifference).Year - 1;
		}

		private string GetUserAgeInfo()
		{
			string defaultValue = $"User age: unknown";
			try
			{
				int userAge = CalculateUserAge(_datePicker.Date);
				string userAgeInfo = (userAge < 0 || userAge > 135) ? defaultValue : $"User age: {userAge} y.o";
				if (_datePicker.Date?.Day == DateTime.Now.Day && _datePicker.Date?.Month == DateTime.Now.Month)
				{
					userAgeInfo = $"{userAgeInfo}\nHappy birthday!";
				}
				return userAgeInfo;
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		private string GetUserWesternAstrologyZodiacSign()
		{
			string defaultValue = $"Western astrology zodiac sign:\nunknown";
			if (_datePicker.Date is null)
				return defaultValue;
			string zodiacSignName = "unknown";
			int dateYear = _datePicker.Date.Value.Year;
			if ((_datePicker.Date >= new DateTime(dateYear, 12, 22) && _datePicker.Date <= new DateTime(dateYear, 12, 31)) || (_datePicker.Date >= new DateTime(dateYear, 1, 1) && _datePicker.Date <= new DateTime(dateYear, 1, 20)))
				zodiacSignName = WesternAstrologyZodiacSigns.Capricorn.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 1, 21) && _datePicker.Date <= new DateTime(dateYear, 2, 19))
				zodiacSignName = WesternAstrologyZodiacSigns.Aquarius.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 2, 20) && _datePicker.Date <= new DateTime(dateYear, 3, 20))
				zodiacSignName = WesternAstrologyZodiacSigns.Pisces.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 3, 21) && _datePicker.Date <= new DateTime(dateYear, 4, 20))
				zodiacSignName = WesternAstrologyZodiacSigns.Aries.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 4, 20) && _datePicker.Date <= new DateTime(dateYear, 5, 20))
				zodiacSignName = WesternAstrologyZodiacSigns.Taurus.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 5, 21) && _datePicker.Date <= new DateTime(dateYear, 6, 21))
				zodiacSignName = WesternAstrologyZodiacSigns.Gemini.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 6, 22) && _datePicker.Date <= new DateTime(dateYear, 7, 22))
				zodiacSignName = WesternAstrologyZodiacSigns.Cancer.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 7, 23) && _datePicker.Date <= new DateTime(dateYear, 8, 22))
				zodiacSignName = WesternAstrologyZodiacSigns.Leo.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 8, 23) && _datePicker.Date <= new DateTime(dateYear, 9, 22))
				zodiacSignName = WesternAstrologyZodiacSigns.Virgo.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 9, 23) && _datePicker.Date <= new DateTime(dateYear, 10, 22))
				zodiacSignName = WesternAstrologyZodiacSigns.Libra.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 10, 23) && _datePicker.Date <= new DateTime(dateYear, 11, 22))
				zodiacSignName = WesternAstrologyZodiacSigns.Scorpio.ToString();
			else if (_datePicker.Date >= new DateTime(dateYear, 11, 23) && _datePicker.Date <= new DateTime(dateYear, 12, 21))
				zodiacSignName = WesternAstrologyZodiacSigns.Sagittarius.ToString();
			return $"Western astrology zodiac sign:\n{zodiacSignName}";
		}

		private string GetUserChineseAstrologyZodiacSign()
		{
			string defaultValue = $"Chinese astrology zodiac sign:\nunknown";
			int? userBirthDateYear = _datePicker.Date?.Year;
			return userBirthDateYear is null ? defaultValue : $"Chinese astrology zodiac sign:\n{(ChineseAstrologyZodiacSigns)((userBirthDateYear - 4) % 12)}";
		}
	}
}
