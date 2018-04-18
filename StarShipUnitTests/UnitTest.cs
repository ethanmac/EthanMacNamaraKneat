using EthanMacNamaraKneat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace StarShipUnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void IntegrationTest()
        {
            try
            {
                //simple integration test..using test data from word doc
                var testData = new Dictionary<string, int?>();
                testData.Add("Y-wing", 74);
                testData.Add("Millennium Falcon", 9);
                testData.Add("Rebel Transport", 11);
                var service = new StarShipServiceFactory().CreateInstance();
                var starShips = service.getAllResource();
                var res = service.NoStopsForShips(1000000, starShips);
                var integrationPassed = false;
                //if all three keys in test data find same value the the test passes
                foreach (KeyValuePair<string, int?> kvp in testData)
                {
                    integrationPassed = res[kvp.Key] == kvp.Value;
                }

                Assert.IsTrue(integrationPassed);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //some unit tests to test the main logic of the code
        [TestMethod]
        public void TestNoOfStopsCal()
        {
            try
            {
                var service = new StarShipServiceFactory().CreateInstance();
                var totalJourney = 1000000;
                var speedPerHour = 80;
                var consumablelength = "1 week";
                var result = service.CalStopsForJourney(totalJourney, speedPerHour, consumablelength);
                Console.WriteLine($"Number of stops {result}");
                Assert.IsTrue(result > 0);
            }
            catch (Exception ex)
            {
                Console.Write($"Error in Unit Test TestNoOfStopsCal {ex.Message}");
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestNoOfStopsCal2()
        {
            try
            {
                var service = new StarShipServiceFactory().CreateInstance();
                var totalJourney = 1000000;
                var speedPerHour = 75;
                var consumablelength = "2 Months";
                var result = service.CalStopsForJourney(totalJourney, speedPerHour, consumablelength);
                Console.WriteLine($"Number of stops {result}");
                Assert.IsTrue(result > 0);
            }
            catch (Exception ex)
            {
                Console.Write($"Error in Unit Test TestNoOfStopsCal {ex.Message}");
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestStopsForList()
        {
            var service = new StarShipServiceFactory().CreateInstance();
            var totalJourney = 1000000;
            var ships = service.getAllResource();

            var dict = service.NoStopsForShips(totalJourney, ships);
        }

        [TestMethod]
        public void DurationToHourConversionTest()
        {
            try
            {
                var service = new StarShipServiceFactory().CreateInstance();
                var totalJourney = "2 Days";
                var ships = service.HoursFromTimeDurationDesc(totalJourney);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DurationToHourConversion {ex.Message}");
            }
        }

        [TestMethod]
        public void NumOfStopsForShipTest()
        {
            try
            {
                var service = new StarShipServiceFactory().CreateInstance();
                //example of some of the ships in a list
                var ships = new System.Collections.Generic.List<SharpTrooper.Entities.Starship>
                {
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "40",
                    cargo_capacity = "250000000",
                    consumables = "6 years",
                    cost_in_credits = "1143350000",
                    created = "2014-12-15T12:31:42.547000Z",
                    crew = "279144",
                    edited = "2017-04-19T10:56:06.685592Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/"
                    },
                    length = "19000",
                    manufacturer = "Kuat Drive Yards, Fondor Shipyards",
                    max_atmosphering_speed = "n/a",
                    model = "Executor-class star dreadnought",
                    name = "Executor",
                    passengers = "38000",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/15/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "70",
                    cargo_capacity = "180000",
                    consumables = "1 month",
                    cost_in_credits = "240000",
                    created = "2014-12-10T15:48:00.586000Z",
                    crew = "5",
                    edited = "2014-12-22T17:35:44.431407Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/1/"
                    },
                    length = "38",
                    manufacturer = "Sienar Fleet Systems, Cyngus Spaceworks",
                    max_atmosphering_speed = "1000",
                    model = "Sentinel-class landing craft",
                    name = "Sentinel-class landing craft",
                    passengers = "75",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/5/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "10",
                    cargo_capacity = "1000000000000",
                    consumables = "3 years",
                    cost_in_credits = "1000000000000",
                    created = "2014-12-10T16:36:50.509000Z",
                    crew = "342953",
                    edited = "2014-12-22T17:35:44.452589Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/1/"
                    },
                    length = "120000",
                    manufacturer = "Imperial Department of Military Research, Sienar Fleet Systems",
                    max_atmosphering_speed = "n/a",
                    model = "DS-1 Orbital Battle Station",
                    name = "Death Star",
                    passengers = "843342",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/9/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "75",
                    cargo_capacity = "100000",
                    consumables = "2 months",
                    cost_in_credits = "100000",
                    created = "2014-12-10T16:59:45.094000Z",
                    crew = "4",
                    edited = "2014-12-22T17:35:44.464156Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/7/",
                        "https://swapi.co/api/films/3/",
                        "https://swapi.co/api/films/1/"
                    },
                    length = "34.37",
                    manufacturer = "Corellian Engineering Corporation",
                    max_atmosphering_speed = "1050",
                    model = "YT-1300 light freighter",
                    name = "Millennium Falcon",
                    passengers = "6",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/13/",
                        "https://swapi.co/api/people/14/",
                        "https://swapi.co/api/people/25/",
                        "https://swapi.co/api/people/31/"
                    },
                    url = "https://swapi.co/api/starships/10/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "80",
                    cargo_capacity = "110",
                    consumables = "1 week",
                    cost_in_credits = "134999",
                    created = "2014-12-12T11:00:39.817000Z",
                    crew = "2",
                    edited = "2014-12-22T17:35:44.479706Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/",
                        "https://swapi.co/api/films/1/"
                    },
                    length = "14",
                    manufacturer = "Koensayr Manufacturing",
                    max_atmosphering_speed = "1000km",
                    model = "BTL Y-wing",
                    name = "Y-wing",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/11/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "100",
                    cargo_capacity = "110",
                    consumables = "1 week",
                    cost_in_credits = "149999",
                    created = "2014-12-12T11:19:05.340000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:44.491233Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/",
                        "https://swapi.co/api/films/1/"
                    },
                    length = "12.5",
                    manufacturer = "Incom Corporation",
                    max_atmosphering_speed = "1050",
                    model = "T-65 X-wing",
                    name = "X-wing",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/1/",
                        "https://swapi.co/api/people/9/",
                        "https://swapi.co/api/people/18/",
                        "https://swapi.co/api/people/19/"
                    },
                    url = "https://swapi.co/api/starships/12/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "105",
                    cargo_capacity = "150",
                    consumables = "5 days",
                    cost_in_credits = "unknown",
                    created = "2014-12-12T11:21:32.991000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:44.549047Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/1/"
                    },
                    length = "9.2",
                    manufacturer = "Sienar Fleet Systems",
                    max_atmosphering_speed = "1200",
                    model = "Twin Ion Engine Advanced x1",
                    name = "TIE Advanced x1",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/4/"
                    },
                    url = "https://swapi.co/api/starships/13/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "70",
                    cargo_capacity = "70000",
                    consumables = "1 month",
                    cost_in_credits = "unknown",
                    created = "2014-12-15T13:00:56.332000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:44.716273Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/5/"
                    },
                    length = "21.5",
                    manufacturer = "Kuat Systems Engineering",
                    max_atmosphering_speed = "1000",
                    model = "Firespray-31-class patrol and attack",
                    name = "Slave 1",
                    passengers = "6",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/22/"
                    },
                    url = "https://swapi.co/api/starships/21/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "50",
                    cargo_capacity = "80000",
                    consumables = "2 months",
                    cost_in_credits = "240000",
                    created = "2014-12-15T13:04:47.235000Z",
                    crew = "6",
                    edited = "2014-12-22T17:35:44.795405Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/"
                    },
                    length = "20",
                    manufacturer = "Sienar Fleet Systems",
                    max_atmosphering_speed = "850",
                    model = "Lambda-class T-4a shuttle",
                    name = "Imperial shuttle",
                    passengers = "20",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/1/",
                        "https://swapi.co/api/people/13/",
                        "https://swapi.co/api/people/14/"
                    },
                    url = "https://swapi.co/api/starships/22/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "40",
                    cargo_capacity = "6000000",
                    consumables = "2 years",
                    cost_in_credits = "8500000",
                    created = "2014-12-15T13:06:30.813000Z",
                    crew = "854",
                    edited = "2014-12-22T17:35:44.848329Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/"
                    },
                    length = "300",
                    manufacturer = "Kuat Drive Yards",
                    max_atmosphering_speed = "800",
                    model = "EF76 Nebulon-B escort frigate",
                    name = "EF76 Nebulon-B escort frigate",
                    passengers = "75",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/23/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "60",
                    cargo_capacity = "unknown",
                    consumables = "2 years",
                    cost_in_credits = "104000000",
                    created = "2014-12-18T10:54:57.804000Z",
                    crew = "5400",
                    edited = "2014-12-22T17:35:44.957852Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/3/"
                    },
                    length = "1200",
                    manufacturer = "Mon Calamari shipyards",
                    max_atmosphering_speed = "n/a",
                    model = "MC80 Liberty type Star Cruiser",
                    name = "Calamari Cruiser",
                    passengers = "1200",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/27/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "120",
                    cargo_capacity = "40",
                    consumables = "1 week",
                    cost_in_credits = "175000",
                    created = "2014-12-18T11:16:34.542000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:44.978754Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/3/"
                    },
                    length = "9.6",
                    manufacturer = "Alliance Underground Engineering, Incom Corporation",
                    max_atmosphering_speed = "1300",
                    model = "RZ-1 A-wing Interceptor",
                    name = "A-wing",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/29/"
                    },
                    url = "https://swapi.co/api/starships/28/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "91",
                    cargo_capacity = "45",
                    consumables = "1 week",
                    cost_in_credits = "220000",
                    created = "2014-12-18T11:18:04.763000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:45.011193Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/3/"
                    },
                    length = "16.9",
                    manufacturer = "Slayn & Korpil",
                    max_atmosphering_speed = "950",
                    model = "A/SF-01 B-wing starfighter",
                    name = "B-wing",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/29/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "unknown",
                    consumables = "unknown",
                    cost_in_credits = "unknown",
                    created = "2014-12-19T17:01:31.488000Z",
                    crew = "9",
                    edited = "2014-12-22T17:35:45.027308Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/4/"
                    },
                    length = "115",
                    manufacturer = "Corellian Engineering Corporation",
                    max_atmosphering_speed = "900",
                    model = "Consular-class cruiser",
                    name = "Republic Cruiser",
                    passengers = "16",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/31/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "65",
                    consumables = "7 days",
                    cost_in_credits = "200000",
                    created = "2014-12-19T17:39:17.582000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:45.079452Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/5/",
                        "https://swapi.co/api/films/4/"
                    },
                    length = "11",
                    manufacturer = "Theed Palace Space Vessel Engineering Corps",
                    max_atmosphering_speed = "1100",
                    model = "N-1 starfighter",
                    name = "Naboo fighter",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/11/",
                        "https://swapi.co/api/people/60/",
                        "https://swapi.co/api/people/35/"
                    },
                    url = "https://swapi.co/api/starships/39/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "unknown",
                    consumables = "unknown",
                    cost_in_credits = "unknown",
                    created = "2014-12-19T17:45:03.506000Z",
                    crew = "8",
                    edited = "2014-12-22T17:35:45.091925Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/4/"
                    },
                    length = "76",
                    manufacturer = "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives",
                    max_atmosphering_speed = "920",
                    model = "J-type 327 Nubian royal starship",
                    name = "Naboo Royal Starship",
                    passengers = "unknown",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/39/"
                    },
                    url = "https://swapi.co/api/starships/40/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "2500000",
                    consumables = "30 days",
                    cost_in_credits = "55000000",
                    created = "2014-12-20T09:39:56.116000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:45.105522Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/4/"
                    },
                    length = "26.5",
                    manufacturer = "Republic Sienar Systems",
                    max_atmosphering_speed = "1180",
                    model = "Star Courier",
                    name = "Scimitar",
                    passengers = "6",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/44/"
                    },
                    url = "https://swapi.co/api/starships/41/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "unknown",
                    consumables = "1 year",
                    cost_in_credits = "2000000",
                    created = "2014-12-20T11:05:51.237000Z",
                    crew = "5",
                    edited = "2014-12-22T17:35:45.124386Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/5/"
                    },
                    length = "39",
                    manufacturer = "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives",
                    max_atmosphering_speed = "2000",
                    model = "J-type diplomatic barge",
                    name = "J-type diplomatic barge",
                    passengers = "10",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/43/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "unknown",
                    consumables = "unknown",
                    cost_in_credits = "unknown",
                    created = "2014-12-20T17:24:23.509000Z",
                    crew = "unknown",
                    edited = "2014-12-22T17:35:45.135987Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/5/"
                    },
                    length = "390",
                    manufacturer = "Botajef Shipyards",
                    max_atmosphering_speed = "unknown",
                    model = "Botajef AA-9 Freighter-Liner",
                    name = "AA-9 Coruscant freighter",
                    passengers = "30000",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/47/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "60",
                    consumables = "7 days",
                    cost_in_credits = "180000",
                    created = "2014-12-20T17:35:23.906000Z",
                    crew = "1",
                    edited = "2014-12-22T17:35:45.147746Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/5/",
                        "https://swapi.co/api/films/6/"
                    },
                    length = "8",
                    manufacturer = "Kuat Systems Engineering",
                    max_atmosphering_speed = "1150",
                    model = "Delta-7 Aethersprite-class interceptor",
                    name = "Jedi starfighter",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/10/",
                        "https://swapi.co/api/people/58/"
                    },
                    url = "https://swapi.co/api/starships/48/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "unknown",
                    consumables = "unknown",
                    cost_in_credits = "unknown",
                    created = "2014-12-20T17:46:46.847000Z",
                    crew = "4",
                    edited = "2014-12-22T17:35:45.158969Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/5/"
                    },
                    length = "47.9",
                    manufacturer = "Theed Palace Space Vessel Engineering Corps",
                    max_atmosphering_speed = "8000",
                    model = "H-type Nubian yacht",
                    name = "H-type Nubian yacht",
                    passengers = "unknown",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/35/"
                    },
                    url = "https://swapi.co/api/starships/49/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "60",
                    cargo_capacity = "36000000",
                    consumables = "2 years",
                    cost_in_credits = "150000000",
                    created = "2014-12-10T15:08:19.848000Z",
                    crew = "47060",
                    edited = "2014-12-22T17:35:44.410941Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/",
                        "https://swapi.co/api/films/1/"
                    },
                    length = "1,600",
                    manufacturer = "Kuat Drive Yards",
                    max_atmosphering_speed = "975",
                    model = "Imperial I-class Star Destroyer",
                    name = "Star Destroyer",
                    passengers = "0",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/3/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "50000000",
                    consumables = "4 years",
                    cost_in_credits = "125000000",
                    created = "2014-12-20T19:40:21.902000Z",
                    crew = "600",
                    edited = "2014-12-22T17:35:45.195165Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/6/"
                    },
                    length = "1088",
                    manufacturer = "Rendili StarDrive, Free Dac Volunteers Engineering corps.",
                    max_atmosphering_speed = "1050",
                    model = "Providence-class carrier/destroyer",
                    name = "Trade Federation cruiser",
                    passengers = "48247",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/10/",
                        "https://swapi.co/api/people/11/"
                    },
                    url = "https://swapi.co/api/starships/59/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "50000",
                    consumables = "56 days",
                    cost_in_credits = "1000000",
                    created = "2014-12-20T19:48:40.409000Z",
                    crew = "5",
                    edited = "2014-12-22T17:35:45.208584Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/6/"
                    },
                    length = "18.5",
                    manufacturer = "Cygnus Spaceworks",
                    max_atmosphering_speed = "2000",
                    model = "Theta-class T-2c shuttle",
                    name = "Theta-class T-2c shuttle",
                    passengers = "16",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/61/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "unknown",
                    consumables = "unknown",
                    cost_in_credits = "unknown",
                    created = "2015-04-17T06:58:50.614475Z",
                    crew = "1",
                    edited = "2015-04-17T06:58:50.614528Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/7/"
                    },
                    length = "unknown",
                    manufacturer = "Incom",
                    max_atmosphering_speed = "unknown",
                    model = "T-70 X-wing fighter",
                    name = "T-70 X-wing fighter",
                    passengers = "unknown",
                    pilots = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/people/86/"
                    },
                    url = "https://swapi.co/api/starships/77/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "20",
                    cargo_capacity = "19000000",
                    consumables = "6 months",
                    cost_in_credits = "unknown",
                    created = "2014-12-15T12:34:52.264000Z",
                    crew = "6",
                    edited = "2014-12-22T17:35:44.680838Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/2/",
                        "https://swapi.co/api/films/3/"
                    },
                    length = "90",
                    manufacturer = "Gallofree Yards, Inc.",
                    max_atmosphering_speed = "650",
                    model = "GR-75 medium transport",
                    name = "Rebel transport",
                    passengers = "90",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/17/",
                    vehicle_class = null
                },
                new SharpTrooper.Entities.Starship
                {
                    MGLT = "unknown",
                    cargo_capacity = "4000000000",
                    consumables = "500 days",
                    cost_in_credits = "unknown",
                    created = "2014-12-19T17:04:06.323000Z",
                    crew = "175",
                    edited = "2014-12-22T17:35:45.042900Z",
                    films = new System.Collections.Generic.List<string>
                    {
                        "https://swapi.co/api/films/5/",
                        "https://swapi.co/api/films/4/",
                        "https://swapi.co/api/films/6/"
                    },
                    length = "3170",
                    manufacturer = "Hoersch-Kessel Drive, Inc.",
                    max_atmosphering_speed = "n/a",
                    model = "Lucrehulk-class Droid Control Ship",
                    name = "Droid control ship",
                    passengers = "139000",
                    pilots = new System.Collections.Generic.List<string>
                    {
                    },
                    url = "https://swapi.co/api/starships/32/",
                    vehicle_class = null
                }
               };
                var totalJourney = 1000000;
                var result = service.NoStopsForShips(totalJourney, ships);
                Assert.IsTrue(result.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DurationToHourConversion {ex.Message}");
            }
        }

        [TestMethod]
        public void ParseConsoleInputTest()
        {
            try
            {
                var starShipManager = new StarShipManager();
                var totalJourney = "1000000";
                var state = starShipManager.ParseUserInput(totalJourney);
                Assert.IsTrue(state.ToString().Length > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ParseConsoleInputTest {ex.Message}");
            }
        }
    }
}