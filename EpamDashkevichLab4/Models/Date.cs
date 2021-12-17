using System;

namespace EpamDashkevichLab4.Models
{
    class Date
    {
        private int[] _DaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private int _Day;
        private int _Month;
        private int _Year;

        public int Day
        {
            get
            {
                return _Day;
            }
            set
            {
                try
                {
                    bool isValid = IsDayValid(value, Month);
                    _Day = value;
                }
                catch
                {
                    throw;
                }
            }
        }
        public int Month
        {
            get
            {
                return _Month;
            }
            set
            {
                try
                {
                    bool isValid = IsMonthValid(value);
                    _Month = value;
                }
                catch
                {
                    throw;
                }
            }

        }
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                try
                {
                    bool isValid = IsYearValid(value);
                    _Year = value;
                }
                catch
                {
                    throw;
                }
            }
        }

        public Date(int day, int month, int year)
        {
            try
            {
                Month = month;
                Day = day;
                Year = year;
            }
            catch
            {
                throw;
            }
        }

        public override string ToString()
        {
            string day;
            string month;
            string year;
            if (Day < 10)
            {
                day = "0" + Day.ToString();
            }
            else
            {
                day = Day.ToString();
            }

            if (Month < 10)
            {
                month = "0" + Month.ToString();
            }
            else
            {
                month = Month.ToString();
            }

            if (Year > 0)
            {
                year = Year.ToString();
            }
            else
            {
                year = (-Year).ToString() + " BC";
            }

            //хотя весь I/O на английском, оставил тут dd/mm/yyyy для удобства 
            string date = $"{day}.{month}.{year}";
            return date;
        }

        #region date shift calcs
        public void Shift(bool isForward, int days, int months, int years)
        {
            bool isDaysNormalized = false;
            bool isMonthsNormalized = false;
            NormalizeShift(ref isForward, ref days, ref months, ref years,
                ref isDaysNormalized, ref isMonthsNormalized);
            if (isForward)
            {
                if (Year < 0 && years >= -Year)
                {
                    Year = Year + years + 1;
                }
                else
                {
                    Year = Year + years;
                }
                if (isMonthsNormalized)
                {
                    Month = 1;
                    months -= 1;
                }
                Month += months;
                if (isDaysNormalized)
                {
                    Day = 1;
                    days -= 1;
                }
                Day += days;
            }
            else
            {
                if (years >= Year && Year > 0)
                {
                    Year = Year - years - 1;
                }
                else
                {
                    Year = Year - years;
                }

                if (isMonthsNormalized)
                {
                    Month = 12;
                }
                Month -= months;

                if (isDaysNormalized)
                {
                    Day = _DaysInMonth[Month - 1];
                }
                Day -= days;
            }
        }

        private void NormalizeShift(
            ref bool isForward, ref int days, ref int months, ref int years,
            ref bool isDaysNormalized, ref bool isMonthsNormalized)
        {
            if (isForward)
            {
                years += days / 365;
                days = days % 365;
                int monthIndex = _Month - 1;
                if (days > _DaysInMonth[monthIndex] - Day)
                {
                    days -= (_DaysInMonth[monthIndex] - Day);
                    months += 1;
                    if (monthIndex == 11)
                    {
                        monthIndex = 0;
                    }
                    else
                    {
                        monthIndex++;
                    }
                    isDaysNormalized = true;
                }
                while (days >= _DaysInMonth[monthIndex])
                {
                    days -= _DaysInMonth[monthIndex];
                    months += 1;
                    if (monthIndex == 11)
                    {
                        monthIndex = 0;
                    }
                    else
                    {
                        monthIndex++;
                    }
                    isDaysNormalized = true;
                }
                if (months > 12 - Month)
                {
                    years += 1;
                    months -= (12 - Month);
                    isMonthsNormalized = true;
                }

                years += months / 12;
                months = months % 12;
            }
            else
            {
                years += days / 365;
                days = days % 365;
                int monthIndex = _Month - 1;
                if (days >= Day)
                {
                    days = days - Day;
                    months += 1;
                    if (monthIndex == 0)
                    {
                        monthIndex = 11;
                    }
                    else
                    {
                        monthIndex--;
                    }
                    isDaysNormalized = true;
                }
                while (days >= _DaysInMonth[monthIndex])
                {
                    days -= _DaysInMonth[monthIndex];
                    months += 1;
                    if (monthIndex == 0)
                    {
                        monthIndex = 11;
                    }
                    else
                    {
                        monthIndex--;
                    }
                    isDaysNormalized = true;
                }

                if (months >= Month)
                {
                    years += 1;
                    months -= Month;
                    isMonthsNormalized = true;
                }

                years += months / 12;
                months = months % 12;
            }

        }
        #endregion


        #region methods for props
        private bool IsDayValid(int day, int month)
        {
            month -= 1;
            if (day <= _DaysInMonth[month] && day > 0)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid day");
            }
        }

        private bool IsMonthValid(int month)
        {
            if (month >= 1 && month <= 12)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid month");
            }
        }
        private bool IsYearValid(int year)
        {
            if (year != 0)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid year");
            }
        }
        #endregion
    }
}
