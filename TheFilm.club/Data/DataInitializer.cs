using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TheFilm.club.Models;

namespace TheFilm.club.Data
{
    public class DataInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                dbContext.Database.EnsureCreated();

                ////Theaters
                //if (!dbContext.Theaters.Any())
                //{
                //    dbContext.Theaters.AddRange(new List<Theater>()
                //    {
                //        new Theater()
                //        {
                //            Name = "T 1",
                //            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu-SySE2BBMBqY3M_pWegAiKZ39Nu8SkgvU0Ue4HIil1GNaMxW5MsHxi7jnF76_k5gnP0&usqp=CAU",
                //            Description = "This is the description of the first theater"
                //        },
                //        new Theater()
                //        {
                //            Name = "T 2",
                //            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQkiPQVlqyIwRwNbqixEXWfpa8pF6HSg86fw&usqp=CAU",
                //            Description = "This is the description of the second theater"
                //        },
                //        new Theater()
                //        {
                //            Name = "T 3",
                //            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRO1LwyAkrYFRWdCmsIMCX2xNzGsjl0WSUSqA&usqp=CAU",
                //            Description = "This is the description of the third theater"
                //        },
                //        new Theater()
                //        {
                //            Name = "T 4",
                //            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu-SySE2BBMBqY3M_pWegAiKZ39Nu8SkgvU0Ue4HIil1GNaMxW5MsHxi7jnF76_k5gnP0&usqp=CAU",
                //            Description = "This is the description of the fourth Theater"
                //        },
                //        new Theater()
                //        {
                //            Name = "T 5",
                //            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRO1LwyAkrYFRWdCmsIMCX2xNzGsjl0WSUSqA&usqp=CAU",
                //            Description = "This is the description of the fifth theater"
                //        },
                //    });
                //    dbContext.SaveChanges();
                //}
                ////Artists
                //if (!dbContext.Artists.Any())
                //{
                //    dbContext.Artists.AddRange(new List<Artist>()
                //    {
                //        new Artist()
                //        {
                //            Name = "A 1",
                //            Biography = "This is the Bio of the first artist",
                //            Picture = "https://images.all-free-download.com/images/graphicwebp/bruce_willis_celebrity_actor_217250.webp"

                //        },
                //        new Artist()
                //        {
                //            Name = "A 2",
                //            Biography = "This is the Bio of the second artist",
                //            Picture = "https://images.all-free-download.com/images/graphicwebp/jon_stewart_actor_talk_show_host_265525.webp"
                //        },
                //        new Artist()
                //        {
                //            Name = "A 3",
                //            Biography = "This is the Bio of the third artist",
                //            Picture = "https://images.all-free-download.com/images/graphicwebp/robert_patrick_actor_celebrity_219940.webp"
                //        },
                //        new Artist()
                //        {
                //            Name = "A 4",
                //            Biography = "This is the Bio of the fourth artist",
                //            Picture = "https://images.all-free-download.com/images/graphicwebp/gary_sinise_actor_star_216876.webp"
                //        },
                //        new Artist()
                //        {
                //            Name = "A 5",
                //            Biography = "This is the Bio of the fifth artist",
                //            Picture = "https://images.all-free-download.com/images/graphicwebp/rob_lowe_actor_celebrity_227270.webp"
                //        }
                //    });
                //    dbContext.SaveChanges();
                //}
                ////Makers
                //if (!dbContext.Makers.Any())
                //{
                //    dbContext.Makers.AddRange(new List<Maker>()
                //    {
                //        new Maker()
                //        {
                //            Name = "M 1",
                //            Biography = "This is the Bio of the first maker",
                //            Picture = "https://st2.depositphotos.com/5326338/7933/i/600/depositphotos_79331476-stock-photo-director-clint-eastwood.jpg"

                //        },
                //        new Maker()
                //        {
                //            Name = "M 2",
                //            Biography = "This is the Bio of the second maker",
                //            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsVpt9Tgkm1Q7pX-V0nA00SkiTR2Dc5vOMBp8Unzo3L62i6GCTBgZG2XT3mLJrNO-06N0&usqp=CAU"
                //        },
                //        new Maker()
                //        {
                //            Name = "M 3",
                //            Biography = "This is the Bio of the third maker",
                //            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQwzxZO_noi51BMBbDLQ63oFFr8Xu2Joo3gw&usqp=CAU"
                //        },
                //        new Maker()
                //        {
                //            Name = "M 4",
                //            Biography = "This is the Bio of the fourth maker",
                //            Picture = "https://upload.wikimedia.org/wikipedia/commons/0/01/Werner_Herzog_Venice_Film_Festival_2009.jpg"
                //        },
                //        new Maker()
                //        {
                //            Name = "M 5",
                //            Biography = "This is the Bio of the fifth maker",
                //            Picture = "https://miro.medium.com/max/372/1*98h3aln9qaraST6DJx9gFg.jpeg"
                //        }
                //    });
                //    dbContext.SaveChanges();
                //}
                ////Films
                //if (!dbContext.Films.Any())
                //{
                //    dbContext.Films.AddRange(new List<Film>()
                //    {
                //        new Film()
                //        {
                //            Name = "Free Willy",
                //            Description = "This is the Free Willy film description",
                //            Price = 39.50,
                //            Picture = "https://upload.wikimedia.org/wikipedia/en/b/b5/Free_willy.jpg",
                //            StartDate = DateTime.Now.AddDays(-10),
                //            EndDate = DateTime.Now.AddDays(10),
                //            TheaterId = 3,
                //            MakerId = 3,
                //            FilmCategory = FilmCategory.Documentary
                //        },

                //        new Film()
                //        {
                //            Name = "Once upon A time in Hollywood",
                //            Description = "This is the Once Upon A time in Hollywood film description",
                //            Price = 39.50,
                //            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQu87qHuOdz_IEI8J2i5WFaqOhQvclIAwjHBA&usqp=CAU",
                //            StartDate = DateTime.Now,
                //            EndDate = DateTime.Now.AddDays(7),
                //            TheaterId = 4,
                //            MakerId = 4,
                //            FilmCategory = FilmCategory.Horror
                //        },
                //        new Film()
                //        {
                //            Name = "Assassin",
                //            Description = "This is the Assassin film description",
                //            Price = 39.50,
                //           Picture = "https://m.media-amazon.com/images/M/MV5BMTM2Nzc4NjYxMV5BMl5BanBnXkFtZTcwNTM1MTcyMQ@@._V1_.jpg",
                //            StartDate = DateTime.Now.AddDays(-10),
                //            EndDate = DateTime.Now.AddDays(-5),
                //            TheaterId = 1,
                //            MakerId = 2,
                //            FilmCategory = FilmCategory.Documentary
                //        },
                //        new Film()
                //        {
                //            Name = "Team America",
                //            Description = "This is the Team America film description",
                //            Price = 39.50,
                //            Picture = "https://m.media-amazon.com/images/M/MV5BMTM2Nzc4NjYxMV5BMl5BanBnXkFtZTcwNTM1MTcyMQ@@._V1_.jpg",
                //            StartDate = DateTime.Now.AddDays(-10),
                //            EndDate = DateTime.Now.AddDays(-2),
                //            TheaterId = 1,
                //            MakerId = 3,
                //            FilmCategory = FilmCategory.Cartoon
                //        },
                //        new Film()
                //        {
                //            Name = " Live free or die hard",
                //            Description = "This is the Live free or die hard film description",
                //            Price = 39.50,
                //            Picture = "https://i5.walmartimages.com/asr/b34ebe56-a589-4939-abda-7d920d35e5df.6228c72636a5614a9826fb8932f2894f.jpeg",
                //            StartDate = DateTime.Now.AddDays(3),
                //            EndDate = DateTime.Now.AddDays(20),
                //            TheaterId = 1,
                //            MakerId = 5,
                //            FilmCategory = FilmCategory.Drama
                //        },
                //         new Film()
                //         {
                //            Name = "Free Guy",
                //            Description = "This is the Free Guy film description",
                //            Price = 39.50,
                //            Picture = "https://th.bing.com/th/id/OIP.grtiFTgTyUhzn5u8D2XK3wHaLH?w=115&h=180&c=7&r=0&o=5&pid=1.7",
                //            StartDate = DateTime.Now.AddDays(3),
                //            EndDate = DateTime.Now.AddDays(20),
                //            TheaterId = 1,
                //            MakerId = 5,
                //            FilmCategory = FilmCategory.Action
                //         },

                //    });
                //    dbContext.SaveChanges();
                //}
                ////Actors & Movies
                //if (!dbContext.Artist_Films.Any())
                //{
                //    dbContext.Artist_Films.AddRange(new List<Artist_Film>()
                //    {
                //        new Artist_Film()
                //        {
                //            ArtistId = 1,
                //            FilmId = 1
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 3,
                //            FilmId = 1
                //        },

                //         new Artist_Film()
                //         {
                //            ArtistId = 1,
                //            FilmId = 2
                //         },
                //         new Artist_Film()
                //         {
                //           ArtistId = 4,
                //           FilmId= 2
                //         },

                //        new Artist_Film()
                //        {
                //            ArtistId = 1,
                //            FilmId = 3
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 2,
                //            FilmId= 3
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 5,
                //            FilmId = 3
                //        },


                //        new Artist_Film()
                //        {
                //            ArtistId = 2,
                //            FilmId = 4
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 3,
                //            FilmId = 4
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 4,
                //            FilmId = 4
                //        },


                //        new Artist_Film()
                //        {
                //            ArtistId = 2,
                //            FilmId = 5
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 3,
                //            FilmId = 5
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 4,
                //            FilmId = 5
                //        },
                //        new Artist_Film()
                //        {
                //           ArtistId = 5,
                //           FilmId = 5
                //        },


                //        new Artist_Film()
                //        {
                //            ArtistId = 3,
                //            FilmId = 6
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 4,
                //            FilmId = 6
                //        },
                //        new Artist_Film()
                //        {
                //            ArtistId = 5,
                //            FilmId = 6
                //        },
                //    });
                //    dbContext.SaveChanges();
                //}
            }

        }

    }
}
