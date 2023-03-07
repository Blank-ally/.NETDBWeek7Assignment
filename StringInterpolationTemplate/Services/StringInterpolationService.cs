using System;
using Microsoft.Extensions.Logging;
using StringInterpolationTemplate.Utils;

namespace StringInterpolationTemplate.Services;

public class StringInterpolationService : IStringInterpolationService
{
    private readonly ISystemDate _date;
    private readonly ILogger<IStringInterpolationService> _logger;

    public StringInterpolationService(ISystemDate date, ILogger<IStringInterpolationService> logger)
    {
        _date = date;
        _logger = logger;
        _logger.Log(LogLevel.Information, "Executing the StringInterpolationService");
    }

    //1. January 22, 2019 (right aligned in a 40 character field)
    public string Number01()
    {
        var date = _date.Now.ToString("MMMM dd, yyyy");
        var answer = $"{date,40}";
        Console.WriteLine(answer);

        return answer;
    }
    //2.2019.01.22
    public string Number02()
    {
        var day = _date.Now;
        return $"{day:yyyy.MM.dd}";
    }
    //3.Day 22 of January, 2019
    public string Number03()
    {
        var day = _date.Now;
        return$"Day {day:dd} of {day:MMMM, yyyy}";
    }
    //4.Year: 2019, Month: 01, Day: 22
    public string Number04()
    {
        var day = _date.Now;
        return$"Year:{day: yyyy}, Month:{day: MM}, Day:{day: dd}";
    }
    //5.            Tuesday (10 spaces total, right aligned)
    public string Number05()
    {
        var day = _date.Now;
        return$"{day,10:ddddd}";
    }
    //6.     11:01 PM             Tuesday (10 spaces total for each including the day-of-week, both right-aligned)
    public string Number06()
    {
        var day = _date.Now;
        return$"{day,10:t}{day,10:ddddd}";
    }
    //7.h:11, m:01, s:27
    public string Number07()
    {
        var day = _date.Now;
        return$"h:{day:hh}, m:{day:mm}, s:{day:ss}";
    }
    //8.2019.01.22.11.01.27
    public string Number08()
    {
        var day = _date.Now;
        return$"{day:yyyy.MM.dd.hh.mm.ss}";
    }
    //1. Output as currency
    public string Number09()
    {
        var pi = Math.PI;
        return$"{pi:c2}";
    }
    //2. Output as right-aligned (10 spaces), number with 3 decimal places
    public string Number10()
    {
        var pi = Math.PI;
        return $"{pi,10:N3}";
    }
    //2023 as hex
    public string Number11()
    {
        var day = 2023;
        return$"{Convert.ToString(day, 16).ToUpper()}";
    }
    //2.2019.01.22
}
