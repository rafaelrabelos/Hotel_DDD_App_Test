using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using hotel.infra.ioc;
using hotel.application.services.interfaces;

namespace hotel.presentation.console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            NativeInjector.RegisterServices(Services, Configuration);


            // Regular: 16Mar2020(mon), 17Mar2020(tues), 18Mar2020(wed)
            Console.WriteLine("Informe a busca");
            string search = Console.ReadLine();

            string typeClient = search.Split(':')[0];
            var dates = search.Split(':')[1].Split(',');

            List<DateTime> formatedDates = new List<DateTime>();

            foreach (var date in dates)
                formatedDates.Add(ParseinputDate(date));

            var bar = serviceProvider.GetService<IHotelService>();
        }

        public static DateTime ParseinputDate(string date)
        {
            var provider = CultureInfo.InvariantCulture;
            var cleanDateStr = date.Trim().Split('(')[0];

            var cleanDate = DateTime.ParseExact(cleanDateStr, "ddMMMyyyy", provider);

            return cleanDate;
        }

    }
}
