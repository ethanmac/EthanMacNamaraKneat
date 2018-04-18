using EthanMacNamaraKneat.Enums;
using EthanMacNamaraKneat.Interfaces;
using SharpTrooper.Core;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EthanMacNamaraKneat
{
    public class StarShipService : IResourceService<Starship>
    {
        private readonly CommandLineService _commandLineService;
        private readonly SharpTrooperCore _core;

        public StarShipService(CommandLineService commandLineService, SharpTrooperCore core)
        {
            _commandLineService = commandLineService;
            _core = core;
        }

        //get all ships.
        /// <summary>
        /// Getes all ships from API
        /// </summary>
        public List<Starship> getAllResource()
        {
            //Since API only returns one page at a time we need to keep going until next page == null
            var tempList = new List<Starship>();
            var pageIsNotNull = true;
            var currentpage = "1";
            SharpEntityResults<Starship> tempStarEntity;
            try
            {
                while (pageIsNotNull)
                {
                    tempStarEntity = _core.GetAllStarships(currentpage);
                    tempList.AddRange(tempStarEntity.results.ToList());
                    if (tempStarEntity.next == null) pageIsNotNull = false;
                    else currentpage = tempStarEntity.nextPageNo;
                }
                return tempList.OrderBy(x => x.name).ToList();
            }
            catch (Exception ex)
            {
                _commandLineService.WriteLineToConsole($"Error retrieveing StarShips.Error Message {ex.Message}");
                return tempList;
            }
        }

        /// <summary>
        /// Getes hours from the consumbles Duration of a ship
        /// </summary>
        /// <param name="consumablesDuration">ngth of time that starship can provide consumables for its entire crew without having to resupply.</param>
        /// <returns>hours</returns>
        public int HoursFromTimeDurationDesc(string consumablesDuration)
        {
            //extract first char for time duration eg 2 from '2 weeks' then compare rest to enum to get hours
            try
            {
                var numberduration = consumablesDuration.Substring(0, 1);
                if (!Int32.TryParse(numberduration, out var noTimePeriod))
                {
                    _commandLineService.WriteLineToConsole($"Error parsing noOfTimePeriods for input string {consumablesDuration}");
                    return -1;
                }
                var timeduration = consumablesDuration.Substring(1).Trim().ToUpper();

                //could have used  return(int)Enum.Parse(typeof(DurationInHours), Enum.GetName(typeof(DurationInHours), DurationInHours.Day));
                //to get the enum mumber but since we know DurationInHours is an num I will use the more readable (int)DurationInHours.Day;
                //could have used Enum.GetName(typeof(DurationInHours), DurationInHours.DAYS).Contains(timeduration) but wanted to keep
                //Enum Singular

                if (timeduration.Contains(Enum.GetName(typeof(DurationInHours), DurationInHours.DAY)))
                {
                    // Enum.GetName(typeof(DurationInHours), DurationInHours.DAYS).Contains(timeduration)
                    return (int)DurationInHours.DAY * noTimePeriod;
                }
                else if (timeduration.Contains(Enum.GetName(typeof(DurationInHours), DurationInHours.WEEK)))
                {
                    return (int)DurationInHours.WEEK * noTimePeriod;
                }
                else if (timeduration.Contains(Enum.GetName(typeof(DurationInHours), DurationInHours.MONTH)))
                {
                    return (int)DurationInHours.MONTH * noTimePeriod;
                }
                else if (timeduration.Contains(Enum.GetName(typeof(DurationInHours), DurationInHours.YEAR)))
                {
                    return (int)DurationInHours.YEAR * noTimePeriod;
                }
                return 0;
            }
            catch (Exception e)
            {
                _commandLineService.WriteLineToConsole($"Error Converting description to hrs .Error:{e.Message}");
                throw;
            }
        }

        /// <summary>
        /// Calculates number of stops for a ship over a given MGLT length
        /// </summary>
        /// <param name="journeylength">Journey length in MGLT.</param>
        /// <param name="perHourSpeed">MLGT per hour.</param>
        /// <param name="consumablesDuration"></param>
        /// <returns>number of stops needed</returns>
        public int CalStopsForJourney(int journeylength, int perHourSpeed, string consumablesDuration)
        {
            //first step is to figure out total hrs taken if consumbles were infinite
            //then we take that result and we will divide it by consumble consumption

            try
            {
                var hours = HoursFromTimeDurationDesc(consumablesDuration);

                var timetakenDur = journeylength / perHourSpeed;
                var hrstaken = (timetakenDur / hours);
                return hrstaken;
            }
            catch (Exception ex)
            {
                _commandLineService.WriteLineToConsole($"Error calculating journey stops.");
                _commandLineService.WriteLineToConsole($"Ex {ex}");
                throw ex;
            }
        }

        /// <summary>
        /// Calculates number of stops each ship in the list will need for the specified jounrey length
        /// </summary>
        /// <param name="journeyLength">Journey length in MGLT.</param>
        /// <param name="starships">List of Starships.</param>
        /// <returns>Dictionary of ship name and number of stops required,-1 if Stops couldnt be calculated </returns>
        public Dictionary<string, int?> NoStopsForShips(int journeyLength, List<Starship> starships)
        {
            try
            {
                Dictionary<string, int?> shipJourneyDict = new Dictionary<string, int?>();
                var journeystops = 0;
                var MGLT = 0;
                foreach (var starship in starships)
                {
                    if (Int32.TryParse(starship.MGLT, out MGLT) == false)
                    {  //uncooment if desired to see ships that dont have a valid MGLT value
                       // _commandLineService.WriteLineToConsole($"MGLT couldnt be found for {starship.name}");
                        shipJourneyDict.Add(starship.name, null);
                    }
                    else
                    {
                        journeystops = CalStopsForJourney(journeyLength, MGLT, starship.consumables);
                        shipJourneyDict.Add(starship.name, journeystops);
                    }
                }
                return shipJourneyDict;
            }
            catch (Exception ex)
            {
                _commandLineService.WriteLineToConsole($"Error calculating journey stops for list. ErrorMessage;{ex.Message}");
                throw;
            }
        }
    }
}