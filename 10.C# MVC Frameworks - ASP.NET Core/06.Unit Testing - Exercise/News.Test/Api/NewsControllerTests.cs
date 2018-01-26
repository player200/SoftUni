namespace News.Test.Api
{
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using News.Api.Controllers;
    using News.Api.Infrastructures.Mapper;
    using News.Api.Models.News;
    using News.Data;
    using News.Data.Models;
    using News.Service.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Xunit;

    public class NewsControllerTests
    {
        private NewsDbContext Context
        {
            get
            {
                var dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new NewsDbContext(dbOptions);
            }
        }

        private IEnumerable<News> GetTestData()
        {
            return new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title ="Mnogo dobur",
                    Content ="REeeeeeee",
                    PublishDate =DateTime.ParseExact("06/02/2016","dd/MM/yyyy",CultureInfo.InvariantCulture)
                },
                new News()
                {
                    Id =2,
                    Title ="Mnogo doburs",
                    Content ="REeeeeeeeggg",
                    PublishDate =DateTime.ParseExact("06/10/2016","dd/MM/yyyy",CultureInfo.InvariantCulture)
                },
                new News()
                {
                    Id =3,
                    Title ="Mnogo doburt",
                    Content ="REeeeeeeettt",
                    PublishDate =DateTime.ParseExact("08/02/2016","dd/MM/yyyy",CultureInfo.InvariantCulture)
                }
            };
        }

        private void PopulateData(NewsDbContext db)
        {
            db.AddRange(this.GetTestData());
            db.SaveChanges();
        }

        [Fact]
        public void NewsControllerGetShouldReturnOkResult()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            // Act
            var result = newsController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NewsControllerCreateNewsShouldReturnCreatedRequest()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            // Act
            var result = newsController.Post(new CreateNewsRequestModel
            {
                Title = "Mnogo dobur",
                Content = "REeeeeeee",
                PublishDate = DateTime.ParseExact("06/02/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void NewsControllerCreateIncorrectNewsShouldReturnBadRequest()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            newsController.ModelState.AddModelError("Invalid Data", "Invalid Data");

            // Act
            var result = newsController.Post(new CreateNewsRequestModel
            {
                Title = "Mnogo dobur",
                Content = null,
                PublishDate = DateTime.ParseExact("06/02/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NewsControllerEditShouldReturnOkStatus()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            // Act
            var result = newsController.Put(
                1,
                new EditNewsRequestModel
                {
                    Id = 1,
                    Title = "Mnogo dobursssss",
                    Content = "SSssssssssss",
                    PublishDate = DateTime.ParseExact("06/02/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                });

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NewsControllerEditIncorrectNewsShouldReturnBadRequest()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            newsController.ModelState.AddModelError("Invalid Data", "Invalid Data");

            // Act
            var result = newsController.Put(
                1,
                new EditNewsRequestModel
                {
                    Id = 1,
                    Title = "Mnogo dobur",
                    Content = null,
                    PublishDate = DateTime.ParseExact("06/02/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NewsControllerEditNonExistingNewsShouldReturnBadRequest()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            newsController.ModelState.AddModelError("Invalid Data", "Invalid Data");

            // Act
            var result = newsController.Put(
                4,
                new EditNewsRequestModel
                {
                    Id = 4,
                    Title = "Mnogo dobur",
                    Content = null,
                    PublishDate = DateTime.ParseExact("06/02/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void NewsControllerDeleteShouldReturnOkStatus()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            // Act
            var result = newsController.Delete(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NewsControllerDeleteNonExistingNewsShouldReturnBadRequest()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            var newsController = new NewsController(newsService);

            // Act
            var result = newsController.Delete(4);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}