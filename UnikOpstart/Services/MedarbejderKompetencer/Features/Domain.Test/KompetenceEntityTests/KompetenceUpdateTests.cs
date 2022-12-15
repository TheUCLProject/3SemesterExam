// using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
// using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
// using Xunit;
// using Moq;
// using System;

// namespace MedarbejderKompetencer.Domain.Test
// {
//     public class KompetenceUpdateTest
//     {   
//         [Theory]
//         [InlineData(99, 87, "Server Opsætning")]
//         [InlineData(1, 1, "Oplæring omkring brug af Bolig System")]
//         [InlineData(999, 872, "Konvertering af data fra gamle systemer")]
//         [InlineData(93909, 87, "Opsætning af nye servere")]
//         public void Given_Kompetence_Does_Not_Exist_In_Db_And_Medarbejder_Is_Valid_Then_Entity_Is_Updated(int id, int medarbejderId, string egenskab)
//         {
//             var mock = new Mock<IDomainServiceKompetence>();

//             mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(false);
//             mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(true);
            
//             var sut = new KompetenceEntity(mock.Object, medarbejderId, "Test Kompetance");

//             sut.Update(medarbejderId, egenskab);

//             Assert.Equal(medarbejderId, sut.MedarbejderId);
//             Assert.Equal(egenskab, sut.Egenskab);
            
//         }

//         [Theory]
//         [InlineData(99, 87, "Server Opsætning")]
//         [InlineData(1, 1, "Oplæring omkring brug af Bolig System")]
//         [InlineData(999, 872, "Konvertering af data fra gamle systemer")]
//         [InlineData(93909, 87, "Opsætning af nye servere")]
//         public void Given_Kompetence_Does_Exist_In_Db_And_Medarbejder_Is_Valid_Then_ArgumentException_Is_Thrown(int id, int medarbejderId, string egenskab)
//         {
//             var mock = new Mock<IDomainServiceKompetence>();
            
//             // Simulate that the kompetance already exists in the database
//             mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(true);
//             mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(true);

//             var sut = new KompetenceEntity(mock.Object, medarbejderId, "Test Kompetance");
            
//             Assert.Throws<ArgumentException>(() => sut.Update(medarbejderId, egenskab));
//         }

//         [Theory]
//         [InlineData(99, 87, "Server Opsætning")]
//         [InlineData(1, 1, "Oplæring omkring brug af Bolig System")]
//         [InlineData(999, 872, "Konvertering af data fra gamle systemer")]
//         [InlineData(93909, 87, "Opsætning af nye servere")]
//         public void Given_Kompetence_Does_Not_Exist_In_Db_But_Medarbejder_Is_Invalid_Then_ArgumentException_Is_Thrown(int id, int medarbejderId, string egenskab)
//         {
//             var mock = new Mock<IDomainServiceKompetence>();

//             mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(false);
//             mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(true);
            
//             var sut = new KompetenceEntity(mock.Object, medarbejderId, "Test Kompetance");

//             // Simulate that the kompetance does not exist in the database
//             mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(false);
//             // Simulates that MedarbejderId is invalid
//             mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(false);
            
//             Assert.Throws<ArgumentException>(() => sut.Update(medarbejderId, egenskab));
//         }

//         [Theory]
//         [InlineData(99, 87, "Server Opsætning")]
//         [InlineData(1, 1, "Oplæring omkring brug af Bolig System")]
//         [InlineData(999, 872, "Konvertering af data fra gamle systemer")]
//         [InlineData(93909, 87, "Opsætning af nye servere")]
//         public void Given_Kompetence_Does_Exist_In_Db_And_Medarbejder_Is_Invalid_Then_ArgumentException_Is_Thrown(int id, int medarbejderId, string egenskab)
//         {
//             var mock = new Mock<IDomainServiceKompetence>();
            
//             mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(false);
//             mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(true);

//             var sut = new KompetenceEntity(mock.Object, medarbejderId, "Test Kompetance");


//             // Simulate that the kompetance already exists in the database
//             mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(true);

//             // Simulates that MedarbejderId is invalid
//             mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(false);
            
//             Assert.Throws<ArgumentException>(() => sut.Update(medarbejderId, egenskab));
//         }
//     }
// }