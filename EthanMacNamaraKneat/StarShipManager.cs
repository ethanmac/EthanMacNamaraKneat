using EthanMacNamaraKneat.Enums;
using EthanMacNamaraKneat.Interfaces;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace EthanMacNamaraKneat
{
    public class StarShipManager : IManager
    {
        //services and mem variables
        private readonly CommandLineService _commandLineService;

        private readonly StarShipService _starShipService;
        public List<Starship> StarShips { get; set; }

        public StarShipManager()
        {
            _commandLineService = new CommandLineService();
            // show factory dp
            _starShipService = new StarShipServiceFactory().CreateInstance();
            StarShips = new List<Starship>();
        }

        public StarShipManager(StarShipService starShipService, List<Starship> s)
        {
            _starShipService = starShipService;
            StarShips = s;
            _commandLineService = new CommandLineService();
        }

        /// <summary>
        /// Get Star Ships
        /// </summary>
        public void init()
        {
            StarShips = _starShipService.getAllResource();
        }

        /// <summary>
        /// method responsible for running the programs calculations or gove input back to the user
        /// </summary>
        public void Run()
        {
            var userINput = "";
            var programrunning = true;
            init();
            //until programrunning is set to false keep the command window open
            //depending on UserInput give the relevant feedback to the user
            while (programrunning)
            {
                //get user input,parse and perform action depending on State Response
                userINput = _commandLineService.ReadConsolesLineWithPrompt("Please enter MGLT distance as an Integer value : ");
                UserInputParseResponse e = ParseUserInput(userINput);
                switch (e)
                {
                    case UserInputParseResponse.VALIDNUMBER:
                        var ships = _starShipService.NoStopsForShips(Int32.Parse(userINput), StarShips);
                        PrintResult(ships);

                        break;

                    case UserInputParseResponse.HELP:
                        PrintHelp();
                        break;

                    case UserInputParseResponse.EXIT:
                        programrunning = false;
                        break;

                    case UserInputParseResponse.CLEAR:
                        _commandLineService.ClearConsole();
                        break;

                    default:
                        _commandLineService.WriteLineToConsole("Invalid command.Please try again");
                        break;
                }
            }
        }

        public void PrintHelp()
        {
            _commandLineService.WriteLineToConsole($"This program calculates for  Star Wars ships the amount of stops required to make the" +
                            $"journey between a given MGLT distance. {Environment.NewLine}" +
                            $"If the journey stops cant be calculated due to an error or missing information a message will be returned {Environment.NewLine}" +
                            $"Please enter the Journey length,HELP for more information,CLEAR to clear the window or type EXIT to finish");
        }

        /// <summary>
        /// Prints Result of the Star Ships calculations in the form of Ship Name: number of stops
        /// If MGLT was missing a error message replaces the number of stops
        /// </summary>
        public void PrintResult(Dictionary<string, int?> starShipStops)
        {
            foreach (KeyValuePair<string, int?> kvp in starShipStops)
            {
                if (kvp.Value == null)
                {
                    _commandLineService.WriteLineToConsole($"{kvp.Key}: { (ConfigurationManager.AppSettings["unknownMGLT"]).ToString()}");
                }
                else
                {
                    _commandLineService.WriteLineToConsole($"{kvp.Key}: {kvp.Value}");
                }
            }
        }

        /// <summary>
        /// Takes inout string from user and determines the state parse response
        /// Check that input contains the state text because this will work for singular(Day,Month) or multiple (Days,Months)
        /// </summary>
        /// <param name="input">Input from the user.</param>
        /// <returns>Dictionary of ship name and number of stops required,-1 if Stops couldnt be calculated </returns>
        public UserInputParseResponse ParseUserInput(string input)
        {
            //first check if valid int
            //if this fails see if the input matches one of the other states
            if (_commandLineService.IsInputValidInt(input))
            {
                return UserInputParseResponse.VALIDNUMBER;
            }
            else if (input.ToUpper().Trim().Contains(UserInputParseResponse.HELP.ToString()))
                return UserInputParseResponse.HELP;
            else if (input.ToUpper().Trim().Contains(UserInputParseResponse.EXIT.ToString()))
                return UserInputParseResponse.EXIT;
            else if (input.ToUpper().Trim().Contains(UserInputParseResponse.CLEAR.ToString()))
                return UserInputParseResponse.CLEAR;
            else
                return UserInputParseResponse.INVALID;
        }
    }
}