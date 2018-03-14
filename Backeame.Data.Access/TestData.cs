using Backeame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Data.Access
{
    public static class TestData
    {
        public static void Create(BackeameContext context)
        {
            #region Schema
            context.Database.ExecuteSqlCommand(@"CREATE TABLE [dbo].[Log] (
                                            [Id] [int] IDENTITY (1, 1) NOT NULL,
                                            [Date] [datetime] NOT NULL,
                                            [Thread] [varchar] (255) NOT NULL,
                                            [Level] [varchar] (50) NOT NULL,
                                            [Logger] [varchar] (255) NOT NULL,
                                            [Message] [varchar] (4000) NOT NULL,
                                            [Exception] [varchar] (2000) NULL
                                        )");
            #endregion
            #region Category
            List<Category> categories = new List<Category>();
            categories.Add(new Category { Name = "Arte" });
            categories.Add(new Category { Name = "Diseno" });
            categories.Add(new Category { Name = "Moda" });
            categories.Add(new Category { Name = "Peliculas y Series" });
            categories.Add(new Category { Name = "Comida" });
            categories.Add(new Category { Name = "Juegos" });
            categories.Add(new Category { Name = "Editorial y Periodismo" });
            categories.Add(new Category { Name = "Eventos" });
            categories.Add(new Category { Name = "Innovacion y Tecnologia" });
            categories.Add(new Category { Name = "Solo para ninos" });
            categories.Add(new Category { Name = "Espectaculos/Musica" });
            categories.Add(new Category { Name = "Viajes" });
            categories.Add(new Category { Name = "Planificacion Urbana" });
            categories.Add(new Category { Name = "Artes Visuales" });
            categories.Add(new Category { Name = "Conmemoraciones" });
            categories.Add(new Category { Name = "Animales" });
            categories.Add(new Category { Name = "Celebraciones" });
            categories.Add(new Category { Name = "Cultura" });
            categories.Add(new Category { Name = "Educacion" });
            categories.Add(new Category { Name = "Emergencia" });
            categories.Add(new Category { Name = "Medio Ambiente" });
            categories.Add(new Category { Name = "Fe y Espiritualidad" });
            categories.Add(new Category { Name = "Derechos Humanos" });
            categories.Add(new Category { Name = "Medicinal" });
            categories.Add(new Category { Name = "Beneficio Publico" });
            categories.Add(new Category { Name = "Deportes" });
            categories.Add(new Category { Name = "Voluntariado" });

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
                context.SaveChanges();
            }
            #endregion

            #region Backer
            var backers = new List<Backer>()
            {
                new Backer()
                {
                    UserName = "jbheber",
                    Email = "juanbheber@outlook.com",
                    Address = "French 2395",
                    PhoneNumber = "+598 98 643 493",
                    FirstName = "Juan Bautista",
                    LastName = "Heber",
                    //Password = Prueba.1
                    PasswordHash = "ALqKeZt+VboYw08UmYrNqvpUuw/yoRes07+sIllNk6tIkyDXqZaKiZARpw9ZHKjwhw==",
                    SecurityStamp = "19efde21-e2d3-4619-a7a1-c137c5e3b555"
                }
            };
            backers.ForEach(u => context.Backers.Add(u));
            context.SaveChanges();
            #endregion

            #region Projects
            List<Project> projects = new List<Project>();

            Project p1 = new Project()
            {
                AmountPledged = "50000",
                BriefDesc = "Economia colaborativa",
                DaysToGo = 90,
                Entrepreneur = "Juan",
                IsDeleted = false,
                Location = "Mdeo",
                PercentageFunded = 0,
                Title = "Backeame",
                StartDate = new DateTime(2017, 07, 03),
                FinishDate = new DateTime(2017, 08, 03),
                Categories = new List<Category> { categories.Where(c => c.Id == 1).SingleOrDefault() },
                UrlComponent = "BackeameURLComponent",
                Type = ProjectType.Comercial
            };          
           
            Project p2 = new Project()
            {
                AmountPledged = "80000",
                BriefDesc = "Proyecto numero 2",
                DaysToGo = 20,
                Entrepreneur = "Ale",
                IsDeleted = false,
                Location = "BSAS",
                PercentageFunded = 30,
                Title = "Backer Project",
                StartDate = new DateTime(2017, 01, 03),
                FinishDate = new DateTime(2017, 02, 03),
                Categories = new List<Category> { categories.Where(c => c.Id == 2).SingleOrDefault() },
                UrlComponent = "BackerProject",
                Type = ProjectType.Comercial
            };
            
            Project p3 = new Project()
            {
                AmountPledged = "10000",
                BriefDesc = "Proyecto numero 3",
                DaysToGo = 45,
                Entrepreneur = "Jero",
                IsDeleted = false,
                Location = "Colonia",
                PercentageFunded = 66,
                Title = "Bjorn Watches",
                StartDate = new DateTime(2017, 04, 03),
                FinishDate = new DateTime(2017, 06, 03),
                Categories = new List<Category> { categories.Where(c => c.Id == 3).SingleOrDefault(), categories.Where(c => c.Id == 4).SingleOrDefault() },
                UrlComponent = "BjornWatches",
                Type = ProjectType.Comercial
            };
            
            Project p4 = new Project()
            {
                AmountPledged = "5000",
                BriefDesc = "My Project",
                DaysToGo = 50,
                Entrepreneur = "Jero",
                IsDeleted = false,
                Location = "Pitt",
                PercentageFunded = 0,
                Title = "ChillTravel",
                StartDate = new DateTime(2017, 03, 20),
                FinishDate = new DateTime(2017, 05, 20),
                Categories = new List<Category> { categories.Where(c => c.Id == 6).SingleOrDefault(), categories.Where(c => c.Id == 7).SingleOrDefault() },
                UrlComponent = "chilltravel",
                Type = ProjectType.Comercial
            };

            Project p5 = new Project()
            {
                AmountPledged = "4000",
                BriefDesc = "Backemae ONG",
                DaysToGo = 5,
                Entrepreneur = "Corcho",
                IsDeleted = false,
                Location = "El Pinar",
                PercentageFunded = 70,
                Title = "Merendero",
                StartDate = new DateTime(2017, 07, 01),
                FinishDate = new DateTime(2017, 09, 10),
                Categories = new List<Category> { categories.Where(c => c.Id == 12).SingleOrDefault() },
                UrlComponent = "ongMerendero",
                Type = ProjectType.ONG
            };

            Project p6 = new Project()
            {
                AmountPledged = "300",
                BriefDesc = "Cuota toro",
                DaysToGo = 25,
                Entrepreneur = "Tutu",
                IsDeleted = false,
                Location = "Jacksonville",
                PercentageFunded = 30,
                Title = "Il Toro",
                StartDate = new DateTime(2017, 06, 03),
                FinishDate = new DateTime(2017, 08, 03),
                Categories = new List<Category> { categories.Where(c => c.Id == 1).SingleOrDefault(), categories.Where(c => c.Id == 3).SingleOrDefault(), categories.Where(c => c.Id == 8).SingleOrDefault() },
                UrlComponent = "ilToro",
                Type = ProjectType.Comercial
            };

            Project p7 = new Project()
            {
                AmountPledged = "80000",
                BriefDesc = "Master",
                DaysToGo = 0,
                Entrepreneur = "Tommy",
                IsDeleted = false,
                Location = "Pitt",
                PercentageFunded = 100,
                Title = "Pitt University",
                StartDate = new DateTime(2017, 06, 20),
                FinishDate = new DateTime(2017, 07, 10),
                Categories = new List<Category> { categories.Where(c => c.Id == 6).SingleOrDefault(), categories.Where(c => c.Id == 9).SingleOrDefault() },
                UrlComponent = "PittUniversity",
                Type = ProjectType.Comercial
            };
            Project p8 = new Project()
            {
                AmountPledged = "6000",
                BriefDesc = "Tristeza",
                DaysToGo = 20,
                Entrepreneur = "Nacho",
                IsDeleted = false,
                Location = "Carrasco",
                PercentageFunded = 0,
                Title = "Triste Project",
                StartDate = new DateTime(2017, 05, 30),
                FinishDate = new DateTime(2017, 07, 20),
                Categories = new List<Category> { categories.Where(c => c.Id == 10).SingleOrDefault(), categories.Where(c => c.Id == 13).SingleOrDefault() },
                UrlComponent = "nachoTriste",
                Type = ProjectType.ONG
            };

            projects.Add(p1);
            projects.Add(p2);
            projects.Add(p3);
            projects.Add(p4);
            projects.Add(p5);
            projects.Add(p6);
            projects.Add(p7);
            projects.Add(p8);


            #endregion

            #region Rewards
            Reward r1 = new Reward
            {
                Title = "Viaje a Montevideo",
                Message = "Ganate un viaje a montevideo y conoce la casa del heby",
                Stock = 100,
                Price = 100,
                ShipsTo = "Anywhere",
                BackerAmount = "",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p1              
            };
            Reward r11 = new Reward
            {
                Title = "Viaje a Cancún",
                Message = "Sabelo, sale playa!",
                Stock = 20,
                Price = 600,
                ShipsTo = "Anywhere",
                BackerAmount = "0",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p1
            };
            Reward r12 = new Reward
            {
                Title = "Viaje a El Pinar",
                Message = "Un asadito con el negro! vapee",
                Stock = 1,
                Price = 9000,
                ShipsTo = "Anywhere",
                BackerAmount = "0",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p1
            };

            p1.Rewards.Add(r1);
            p1.Rewards.Add(r11);
            p1.Rewards.Add(r12);
            Reward r2 = new Reward
            {
                Title = "Un perro callejero",
                Message = "Backeame con este rope de la calle",
                Stock = 1,
                Price = 50,
                ShipsTo = "Anywhere",
                BackerAmount = "1",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p2
            };
            p2.Rewards.Add(r2);
            Reward r3 = new Reward
            {
                Title = "Plato de comida",
                Message = "Guiso de lentejas",
                Stock = 100,
                Price = 70,
                ShipsTo = "Anywhere",                
                BackerAmount = "6",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p3
            };
            p3.Rewards.Add(r3);
            Reward r4 = new Reward
            {
                Title = "Iphone 4s",
                Message = "El del Dano Yek Vida",
                Stock = 1,
                Price = 6,
                ShipsTo = "Anywhere",
                BackerAmount = "0",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p4
            };
            p4.Rewards.Add(r4);
            Reward r5 = new Reward
            {
                Title = "Yatch Week",
                Message = "A ponerla en un catamarán!",
                Stock = 2,
                Price = 10000,
                ShipsTo = "Anywhere",
                BackerAmount = "1",
                EstimatedDelivery = DateTime.Now.AddDays(10),
               //Project = p5
            };
            p5.Rewards.Add(r5);
            Reward r6 = new Reward
            {
                Title = "Un reloj Bjorn!",
                Message = "Suerte empila cobrando esto",
                Stock = 6,
                Price = 100,
                ShipsTo = "Anywhere",
                BackerAmount = "2",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p6
            };
            p6.Rewards.Add(r6);
            Reward r7 = new Reward
            {
                Title = "Un reloj Bjorn!",
                Message = "Suerte empila cobrando esto",
                Stock = 6,
                Price = 500,
                ShipsTo = "Anywhere",
                BackerAmount = "2",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p7
            };
            p7.Rewards.Add(r7);
            Reward r8 = new Reward
            {
                Title = "Un reloj Bjorn!",
                Message = "Suerte empila cobrando esto",
                Stock = 50,
                Price = 350,
                ShipsTo = "Anywhere",
                BackerAmount = "2",
                EstimatedDelivery = DateTime.Now.AddDays(10),
                //Project = p8
            };
            p8.Rewards.Add(r8);
            #endregion

            foreach (Project p in projects)
            {
                context.Projects.Add(p);
                context.SaveChanges();
            }
        }
    }
}
