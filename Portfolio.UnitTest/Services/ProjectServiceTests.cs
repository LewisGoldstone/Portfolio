using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Portfolio.Service;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;

namespace Portfolio.UnitTest.Services
{
    [TestClass]
    public class ProjectServiceTests
    {
        private readonly Mock<IRepository<Project>> _mockProjectRepo;

        public ProjectServiceTests()
        {
            _mockProjectRepo = new Mock<IRepository<Project>>();
        }

        [TestMethod]
        public void Ordered_Visible_Projects_OrderBy_Then_Created()
        {
            // Arrange
            var orderedProjects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    OrderBy = 1,
                    Created = new DateTime(1999, 11, 02),
                },
                new Project
                {
                    Id = 2,
                    OrderBy = 3,
                    Created = new DateTime(1980, 02, 02)
                },
                new Project
                {
                    Id = 3,
                    OrderBy = null,
                    Created = new DateTime(2017, 01, 11)
                },
                new Project
                {
                    Id = 4,
                    OrderBy = null,
                    Created = new DateTime(2018, 03, 07)
                }
            };

            var unOrderedProjects = new List<Project>
            {
                orderedProjects[2], orderedProjects[0], orderedProjects[3], orderedProjects[1]
            };

            _mockProjectRepo.Setup(m => m.Get(It.IsAny<Expression<Func<Project, bool>>>(), null, false))
                .Returns(unOrderedProjects);

            // Act
            var results = new ProjectService(_mockProjectRepo.Object)
                .GetOrderedVisibleProjects(1);

            // Assert
            Assert.IsTrue(results.SequenceEqual(orderedProjects));

            orderedProjects.Reverse();
            Assert.IsFalse(results.SequenceEqual(orderedProjects));
        }
    }
}
