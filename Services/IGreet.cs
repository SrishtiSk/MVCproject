using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Services
{
    public interface IGreet
    {
        string Greet(string name);
    }

    public class Greeter2020 :IGreet

    {
        IConfiguration config;

        public Greeter2020(IConfiguration con)
        {
            config = con;
        }
        public string Greet(string name)
        {
            return $"HELLO {name},{config["GreetingMessage"]}";
        }


    }
}
