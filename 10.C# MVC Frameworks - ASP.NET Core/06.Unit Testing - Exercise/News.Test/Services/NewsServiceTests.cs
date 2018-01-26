namespace News.Test.Services
{
    using AutoMapper;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using News.Api.Infrastructures.Mapper;
    using News.Data;
    using News.Data.Models;
    using News.Service.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Xunit;

    public class NewsServiceTests
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
        public void NewsServiceAllShouldReturnAllNewsOrdered()
        {
            // Arrange
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            // Act
            var result = newsService.All();

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == 1
                            && r.ElementAt(1).Id == 3
                            && r.ElementAt(2).Id == 2)
                .And
                .HaveCount(3);
        }

        [Fact]
        public void NewsServiceCreateShouldReturnCreatedNewsId()
        {
            // Arrange
            var db = this.Context;

            var newsService = new NewsService(db);

            // Act
            var result = newsService.Create(
                "Big news",
                "Something happend wast day.",
                DateTime.ParseExact("03/12/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            // Assert
            result
                .Should()
                .Be(2);
        }

        [Fact]
        public void NewsServiceEditShouldReturnEditedNewsId()
        {
            // Arrange
            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            // Act
            var result = newsService.Edit(
                1,
                "Hello",
                "Very good one",
                DateTime.ParseExact("04/12/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture));

            // Assert
            result
                .Should()
                .Be(1);
        }

        [Fact]
        public void NewsServiceDeleteShouldReturnDeletedNewsId()
        {
            // Arrange
            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            // Act
            var result = newsService.Delete(1);

            // Assert
            result
                .Should()
                .Be(1);
        }

        [Fact]
        public void NewsServiceExistsShouldReturnIfItExists()
        {
            // Arrange
            var db = this.Context;
            this.PopulateData(db);

            var newsService = new NewsService(db);

            // Act
            var result = newsService.Exists(1);

            // Assert
            result
                .Should()
                .Be(true);
        }
    }
}