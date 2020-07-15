using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DateTimeInput.Models
{
    public class SampleModel : INotifyPropertyChanged
    {
        private DateTime _theDateTime;
        private DateTime _theDate;

        public DateTime TheDateTime
        {
            get => _theDateTime;
            set
            {
                _theDateTime = value;
                NotifyPropertyChanged();
                _theDate = GetDateOnly(value);
                NotifyPropertyChanged(nameof(TheDate));
            }
        }

        public DateTime TheDate
        {
            get => _theDate;
            set
            {
                _theDate = GetDateOnly(value);
                NotifyPropertyChanged();
                _theDateTime = new DateTime(
                    _theDate.Year,
                    _theDate.Month,
                    _theDate.Day,
                    TheDateTime.Hour,
                    TheDateTime.Minute,
                    0,
                    0,
                    DateTimeKind.Unspecified);
                NotifyPropertyChanged(nameof(TheDateTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime GetDateOnly(DateTime value)
        {
            return new DateTime(
                    value.Year,
                    value.Month, 
                    value.Day);           
        }

    }
}
