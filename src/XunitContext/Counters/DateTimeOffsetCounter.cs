﻿using System;

namespace Xunit
{
    public class DateTimeOffsetCounter :
        Counter<DateTimeOffset>
    {
        static DateTimeOffset Start = new DateTimeOffset(2000, 1, 1, 1, 1, 1, TimeSpan.Zero);

        protected override DateTimeOffset Convert(int i)
        {
            return Start.AddDays(i);
        }
    }
}