// using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
// using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
// using Xunit;
// using Moq;
// using System;

// namespace MedarbejderKompetencer.Domain.Test;

// public class KompetenceCreateTests
// {
//     [Theory]
//     [InlineData(87, "Server Opsætning")]
//     [InlineData(1, "Oplæring omkring brug af Bolig System")]
//     [InlineData(872, "Konvertering af data fra gamle systemer")]
//     [InlineData(87, "Opsætning af nye servere")]
//     public void Given_Kompetence_Does_Not_Exist_In_Db_And_Medarbejder_Is_Valid_Then_Entity_Is_Created(int medarbejderId, string egenskab)
//     {
//         var mock = new Mock<IDomainServiceKompetence>();

//         // Simulate that the kompetance does not exist in the database
//         mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(false);

//         // Simulate that the medarbejderId is valid
//         mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(true);
        
//         var sut = new KompetenceEntity(mock.Object, medarbejderId, egenskab);
//     }

//     [Theory]
//     [InlineData(87, "Server Opsætning")]
//     [InlineData(1, "Oplæring omkring brug af Bolig System")]
//     [InlineData(872, "Konvertering af data fra gamle systemer")]
//     [InlineData(87, "Opsætning af nye servere")]
//     public void Given_Kompetence_Does_Exist_In_Db_And_Medarbejder_Is_Valid_Then_ArgumentException_Is_Thrown(int medarbejderId, string egenskab)
//     {
//         var mock = new Mock<IDomainServiceKompetence>();
        
//         // Simulate that the kompetance already exists in the database
//         mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(true);
//         mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(true);

//         Assert.Throws<ArgumentException>(() => new KompetenceEntity(mock.Object, medarbejderId, egenskab));
//     }

//     [Theory]
//     [InlineData(87, "Server Opsætning")]
//     [InlineData(1, "Oplæring omkring brug af Bolig System")]
//     [InlineData(872, "Konvertering af data fra gamle systemer")]
//     [InlineData(87, "Opsætning af nye servere")]
//     public void Given_Kompetence_Does_Not_Exist_In_Db_But_Medarbejder_Is_Invalid_Then_ArgumentException_Is_Thrown(int medarbejderId, string egenskab)
//     {
//         var mock = new Mock<IDomainServiceKompetence>();
        
//         // Simulate that the kompetance does not already exist in the database
//         mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(false);

//         // Simulates that MedarbejderId is invalid
//         mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(false);

//         Assert.Throws<ArgumentException>(() => new KompetenceEntity(mock.Object, medarbejderId, egenskab));
//     }

//     [Theory]
//     [InlineData(87, "Server Opsætning")]
//     [InlineData(1, "Oplæring omkring brug af Bolig System")]
//     [InlineData(872, "Konvertering af data fra gamle systemer")]
//     [InlineData(87, "Opsætning af nye servere")]
//     public void Given_Kompetence_Exist_In_Db_And_Medarbejder_Is_Invalid_Then_ArgumentException_Is_Thrown(int medarbejderId, string egenskab)
//     {
//         var mock = new Mock<IDomainServiceKompetence>();
        
//         // Simulate that the kompetance already exists in the database
//         mock.Setup(x => x.AlreadyExistsForMedarbejder(medarbejderId, egenskab)).Returns(true);
//         mock.Setup(x => x.ValidMedarbejderId(medarbejderId)).Returns(false);

//         Assert.Throws<ArgumentException>(() => new KompetenceEntity(mock.Object, medarbejderId, egenskab));
//     }
// }