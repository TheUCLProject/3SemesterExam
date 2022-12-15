using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.DomainServices;
using Xunit;
using Moq;

namespace MedarbejderKompetencer.Domain.Test;

public class MedarbejderCreateTests
{

    public void Given_Medarbejder_Already_Exists_When_Create_Medarbejder_Then_Throw_Exception()
    {
        // Arrange
        var domainService = new Mock<IDomainServiceMedarbejder>();
        domainService.Setup(x => x.AlreadyExists(It.IsAny<string>())).Returns(true);

        // Act
        var exception = Assert.Throws<System.ArgumentException>(() => new MedarbejderEntity(domainService.Object, "USERID", "Test", "Sælger", 20202020, "test@test.test"));

        // Assert
        Assert.Equal("Medarbejder already exists", exception.Message);
    }

    // Test for valid input on PhoneNr
    [Theory]
    [InlineData(22334455)]
    [InlineData(66314890)]
    [InlineData(21289027)]
    [InlineData(82663235)]
    public void Given_PhoneNr_Is_Valid_Then_MedarbejderEntity_Is_Created(int phoneNr)
    {
        var mock = new Mock<IDomainServiceMedarbejder>();

        var sut = new MedarbejderEntity(mock.Object, "USERID", "Test", "Sælger", phoneNr, "test@mail.test");
    }

    // Test for invalid input on PhoneNr
    [Theory]
    [InlineData(223344)]
    [InlineData(0)]
    [InlineData(212890272)]
    [InlineData(111111111111111)]
    public void Given_PhoneNr_Is_InValid_Then_ArgumentException_Is_Thrown(int phoneNr)
    {
        var mock = new Mock<IDomainServiceMedarbejder>();
        
        Assert.Throws<System.ArgumentException>(() => new MedarbejderEntity(mock.Object, "USERID", "Test", "Sælger", phoneNr, "test@test.test"));
    }

    // Test for valid input on Email
    [Theory]
    [InlineData("test@test.test")]
    [InlineData("m@m.m")]
    [InlineData("te@st.test")]
    [InlineData("navn@firma.countrycode")]
    public void Given_Email_Is_Valid_Then_MedarbejderEntity_Is_Created(string email)
    {
        var mock = new Mock<IDomainServiceMedarbejder>();
        
        var sut = new MedarbejderEntity(mock.Object, "USERID", "Test", "Sælger", 22334455, email);
    }

    // Test for invalid input on Email
    [Theory]
    [InlineData("test.test.test")]
    [InlineData("test@testteset")]
    [InlineData("test")]
    [InlineData("@.")]      // THIS SHOULD BE INVALID, BUT IS VALID
    public void Given_Email_Is_InValid_Then_ArgumentException_Is_Thrown(string email)
    {
        var mock = new Mock<IDomainServiceMedarbejder>();
        Assert.Throws<System.ArgumentException>(() => new MedarbejderEntity(mock.Object, "USERID", "Test", "Sælger", 22334455, email));
    }

    // Test for valid input on ProcessRole
    [Theory]
    [InlineData("Sælger")]
    [InlineData("Tekniker")]
    [InlineData("Konverter")]
    [InlineData("Konsulent")]
    public void Given_ProcessRole_Is_Valid_Then_MedarbejderEntity_Is_Created(string processRole)
    {
        var mock = new Mock<IDomainServiceMedarbejder>();
        
        var sut = new MedarbejderEntity(mock.Object, "USERID", "Test", processRole, 22334455, "test@test.com");
    }

    // Test for invalid input on ProcessRole
    [Theory]
    [InlineData("Maler")]
    [InlineData("Chef")]
    [InlineData("Sekretær")]
    [InlineData(" ")]
    public void Given_ProcessRole_Is_InValid_Then_ArgumentException_Is_Thrown(string processRole)
    {
        var mock = new Mock<IDomainServiceMedarbejder>();
        
        Assert.Throws<System.ArgumentException>(() => new MedarbejderEntity(mock.Object, "USERID", "Test", processRole, 22334455, "test@test.com"));
    }
}