using ImmoBooking.Data.Enum;
using ImmoBooking.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmoBooking.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Agencie
                if (!context.Agencies.Any())
                {
                    context.Agencies.AddRange(new List<Agencie>() {
                        new Agencie()
                    {
                        LogoURL = "file:///C:/Users/21623/Desktop/Agencies%20Logos/Agencie%20Logo%201.jpg",
                        Name = "Agencie 1",
                        Email = "Agencie1@gmail.com",
                        Description = "This is my first agencie description"

                    },
                    new Agencie()
                    {
                        LogoURL = "file:///C:/Users/21623/Desktop/Agencies%20Logos/Agencie%20Logo%202.jpg",
                        Name = "Agencie 2",
                        Email = "Agencie2@gmail.com",
                        Description = "This is my second agencie description"

                    },
                    new Agencie()
                    {
                        LogoURL = "file:///C:/Users/21623/Desktop/Agencies%20Logos/Agencie%20Logo%203.jpg",
                        Name = "Agencie 3",
                        Email = "Agencie3@gmail.com",
                        Description = "This is my third agencie description"

                    },
                    new Agencie()
                    {
                        LogoURL = "file:///C:/Users/21623/Desktop/Agencies%20Logos/Agencie%20Logo%204.jpg",
                        Name = "Agencie 4",
                        Email = "Agencie4@gmail.com",
                        Description = "This is my forth agencie description"

                    },
                    new Agencie()
                    {
                        LogoURL = "file:///C:/Users/21623/Desktop/Agencies%20Logos/Agencie%20Logo%205.jpg",
                        Name = "Agencie 5",
                        Email = "Agencie5@gmail.com",
                        Description = "This is my fifth agencie description"

                    }

                });
                    context.SaveChanges();

                }

                //Owner
                if (!context.Owners.Any())
                {
                    context.Owners.AddRange(new List<Owner>()
                    {
                        new Owner()
                        {
                            FullName = "Owner1",
                            ProfilePictureURL = "file:///C:/Users/21623/Desktop/Owners%20Images/Owner%201.jpg"
                        },
                        new Owner()
                        {
                            FullName="Owner2",
                            ProfilePictureURL = "file:///C:/Users/21623/Desktop/Owners%20Images/Owner%202.jpg"
                        },
                        new Owner()
                        {
                            FullName = "Owner3",
                            ProfilePictureURL="file:///C:/Users/21623/Desktop/Owners%20Images/Owner%203.jpg"
                        },
                        new Owner()
                        {
                            FullName="Owner4",
                            ProfilePictureURL="file:///C:/Users/21623/Desktop/Owners%20Images/Owner%204.jpg"
                        },
                        new Owner()
                        {
                            FullName="Owner5",
                            ProfilePictureURL="file:///C:/Users/21623/Desktop/Owners%20Images/Owner%205.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                //Property
                if (!context.Properties.Any())
                {
                    context.Properties.AddRange(new List<Property>()
                    {
                        new Property()
                        {
                            Name ="Property1",
                            Description="this is my first property description",
                            Price = 250.0,
                            MainImageURL = "file:///C:/Users/21623/Desktop/Properties%20Images/Villas/Villa%201%20S2.jpg",
                            AvailableStart = DateTime.Now.AddDays(1),
                            AvailableEnd = DateTime.Now.AddDays(20),
                            AgencieId = 1,
                            OwnerId = 2,
                            PropertyCategorie = PropertyCategorie.Villa
                        },
                        new Property()
                        {
                            Name = "Property2",
                            Description = "this is my second property description",
                            Price = 350.0,
                            MainImageURL = "file:///C:/Users/21623/Desktop/Properties%20Images/Villas/Villa%202%20S3.jpeg",
                            AvailableStart = DateTime.Now.AddDays(-5),
                            AvailableEnd = DateTime.Now.AddDays(10),
                            AgencieId = 2,
                            OwnerId = 4,
                            PropertyCategorie = PropertyCategorie.Villa
                        },
                        new Property()
                        {
                            Name = "Property3",
                            Description = "this is my third property description",
                            Price = 59.50,
                            MainImageURL = "file:///C:/Users/21623/Desktop/Properties%20Images/Appartements/Appart%201%20S1.jpeg",
                            AvailableStart = DateTime.Now.AddDays(-20),
                            AvailableEnd = DateTime.Now.AddDays(30),
                            AgencieId = 3,
                            OwnerId = 3,
                            PropertyCategorie = PropertyCategorie.Appartement
                        },
                        new Property()
                        {
                            Name = "Property4",
                            Description = "this is my forth property description",
                            Price = 49.50,
                            MainImageURL = "file:///C:/Users/21623/Desktop/Properties%20Images/Appartements/Appart%202%20S2.jpeg",
                            AvailableStart = DateTime.Now.AddDays(5),
                            AvailableEnd = DateTime.Now.AddDays(35),
                            AgencieId = 4,
                            OwnerId = 1,
                            PropertyCategorie = PropertyCategorie.Appartement
                        },
                        new Property()
                        {
                            Name = "Property5",
                            Description = "this is my fifth property description",
                            Price = 39.50,
                            MainImageURL = "file:///C:/Users/21623/Desktop/Properties%20Images/Appartements/Appart%203%20S3.jpg",
                            AvailableStart = DateTime.Now.AddDays(-25),
                            AvailableEnd = DateTime.Now.AddDays(50),
                            AgencieId = 5,
                            OwnerId = 5,
                            PropertyCategorie = PropertyCategorie.Appartement
                        }
                    });
                }

                //Agent
                if (!context.Agents.Any())
                {
                    context.Agents.AddRange(new List<Agent>()
                   {
                       new Agent()
                       {
                           ProfilePictureURL ="file:///C:/Users/21623/Desktop/Agents/Agent%201.jpg",
                           FullName ="Agent1",
                           Email="Agent1@gmail.com",
                           Contact="+216 00 00 00 00"
                       },
                       new Agent()
                       {
                           ProfilePictureURL ="file:///C:/Users/21623/Desktop/Agents/Agent%202.jpg",
                           FullName ="Agent2",
                           Email="Agent2@gmail.com",
                           Contact="+216 00 00 00 00"

                       },
                       new Agent()
                       {
                           ProfilePictureURL ="file:///C:/Users/21623/Desktop/Agents/Agent%203.jpg",
                           FullName ="Agent3",
                           Email="Agent3@gmail.com",
                           Contact="+216 00 00 00 00"

                       },
                       new Agent()
                       {
                           ProfilePictureURL ="file:///C:/Users/21623/Desktop/Agents/Agent%204.jpg",
                           FullName ="Agent4",
                           Email="Agent4@gmail.com",
                           Contact="+216 00 00 00 00"

                       },
                       new Agent()
                       {
                           ProfilePictureURL ="file:///C:/Users/21623/Desktop/Agents/Agent%205.jpg",
                           FullName ="Agent5",
                           Email="Agent5@gmail.com",
                           Contact="+216 00 00 00 00"

                       }
                   });

                    context.SaveChanges();

                }

                //Agents & Properties
                if (!context.Properties_Agents.Any())
                {
                    context.Properties_Agents.AddRange(new List<Property_Agent>
                    {
                        new Property_Agent()
                        {
                            AgentId=1,
                            PropertyId=1,
                           
                        },
                        new Property_Agent()
                        {
                            AgentId=5,
                            PropertyId=1,
                        },
                        new Property_Agent()
                        {
                            AgentId=2,
                            PropertyId=2,
                        },
                        new Property_Agent()
                        {
                            AgentId=3,
                            PropertyId=2,
                        },
                        new Property_Agent()
                        {
                            AgentId=4,
                            PropertyId=2,
                        },
                        new Property_Agent()
                        {
                            AgentId=4,
                            PropertyId=3,
                        },
                        new Property_Agent()
                        {
                            AgentId=1,
                            PropertyId=4,
                        },
                        new Property_Agent()
                        {
                            AgentId=3,
                            PropertyId=4,
                        },
                        new Property_Agent()
                        {
                            AgentId=2,
                            PropertyId=5,
                        },
                        new Property_Agent()
                        {
                            AgentId=4,
                            PropertyId=5,
                        },
                        new Property_Agent()
                        {
                            AgentId=3,
                            PropertyId=6,
                        },
                        new Property_Agent()
                        {
                            AgentId=5,
                            PropertyId=6,
                        },
                        new Property_Agent()
                        {
                            AgentId=3,
                            PropertyId=7,
                        },
                        new Property_Agent()
                        {
                            AgentId=4,
                            PropertyId=7,
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
