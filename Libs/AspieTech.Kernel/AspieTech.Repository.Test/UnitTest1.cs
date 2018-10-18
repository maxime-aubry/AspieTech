using AspieTech.Repository.Attributes;
using System.Data.SqlClient;
using Xunit;

namespace AspieTech.Repository.Test
{
    public class UnitTest1
    {
        //[Fact]
        //public void Test1()
        //{
        //    //Mock<IRepositoryProvider> repositoryProvider = new Mock<IRepositoryProvider>();
        //    //repositoryProvider.Setup(_ => _.Provide<EntityTest>("")).Returns(new SqlRepository<EntityTest>(null));

        //    //IRepository<EntityTest> repository = repositoryProvider.Object.Provide<EntityTest>("");

        //    IQueryable<SuperHero> results = new List<SuperHero>()
        //    {
        //        new SuperHero("Peter", "Parker", "Spiderman"),
        //        new SuperHero("Tony", "Stark", "Iron-man"),
        //        new SuperHero("Clark", "Kent", "Superman"),
        //        new SuperHero("Bruce", "Wayne", "Batman")
        //    }.AsQueryable<SuperHero>();

        //    Mock<SqlRepository<SuperHero>> repository = new Mock<SqlRepository<SuperHero>>();

        //    repository.Setup(_ => _.Read()).Returns(Task.FromResult(results));
        //}

        [Fact]
        public void Test()
        {
            string name = null;
            SqlParameter[] parameters = null;
            StoredProcedureAttribute attribute = new StoredProcedureAttribute("[maprocedurestockee] @p1 XML INPUT, @p2 BIT OUTPUT");
            attribute.GenerateStoredProcedure(out name, out parameters);
        }
    }
}
