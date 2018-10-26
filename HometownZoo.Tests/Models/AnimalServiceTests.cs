using Microsoft.VisualStudio.TestTools.UnitTesting;
using HometownZoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;

namespace HometownZoo.Models.Tests
{
    [TestClass()]
    public class AnimalServiceTests
    {
        private IQueryable<Animal> animals;

        [TestInitialize] // runs before each test
        public void BeforeTest()
        {
            animals = new List<Animal>()
            {
                new Animal(){AnimalID=1, Name="Zebra"},
                new Animal(){AnimalID=2, Name="Bat"}
            }.AsQueryable();
        }

        [TestMethod]
        public void GetAnimals_ShouldReturnAllAnimalsSortedByName()
        {
            // Set up Mock database and mock animal table

            // create a Mock of Animals
            Mock<ApplicationDbContext> mockDb = GetMockDbWithAnimals();

            //ACT
            IEnumerable<Animal> allAnimals =
                AnimalService.GetAnimals(mockDb.Object);

            // ASSERT all animals are returned
            Assert.AreEqual(2, allAnimals.Count());

            // Assert animals are sorted by name (ascending)
            Assert.AreEqual("Bat", allAnimals.ElementAt(0).Name);
            Assert.AreEqual("Zebra", allAnimals.ElementAt(1).Name);
        }

        private Mock<ApplicationDbContext> GetMockDbWithAnimals()
        {
            Mock<DbSet<Animal>> mockAnimals = GetMockAnimalsDbSet();
            var mockDb = GetMockDB(mockAnimals);
            return mockDb;
        }

        [TestMethod]
        public void AddAnimal_NewAnimalShouldCallAllAndSaveChanges()
        {
            //ARRANGE
            Mock<DbSet<Animal>> mockAnimals = GetMockAnimalsDbSet();
            Mock<ApplicationDbContext> mockDb = GetMockDB(mockAnimals);

            Animal a = new Animal() { Name = "Elephant" };

            //ACT
            AnimalService.AddAnimal(a, mockDb.Object);

            //ASSERT
            mockAnimals.Verify(m => m.Add(a), Times.Once);
            mockDb.Verify(m => m.SaveChanges(), Times.Once);
        }

        private static Mock<ApplicationDbContext> GetMockDB(Mock<DbSet<Animal>> mockAnimals)
        {
            var mockDb = new Mock<ApplicationDbContext>();
            mockDb.Setup(db => db.Animals)
                .Returns(mockAnimals.Object);
            return mockDb;
        }

        [TestMethod]
        public void AddAnimal_NullAnimal_ShouldThrowNullArgumentException()
        {
            Animal a = null;

            var mockDb = GetMockDbWithAnimals();
            //ASSERT => ACT
            Assert.ThrowsException<ArgumentNullException>
                (() => AnimalService.AddAnimal(a, mockDb.Object));
        }

        private Mock<DbSet<Animal>> GetMockAnimalsDbSet()
        {
            var mockAnimals = new Mock<DbSet<Animal>>();

            mockAnimals.As<IQueryable<Animal>>()
                .Setup(m => m.Provider)
                .Returns(animals.Provider);

            mockAnimals.As<IQueryable<Animal>>()
                .Setup(m => m.Expression)
                .Returns(animals.Expression);

            mockAnimals.As<IQueryable<Animal>>()
                .Setup(m => m.GetEnumerator())
                .Returns(animals.GetEnumerator());
            return mockAnimals;
        }
    }
}