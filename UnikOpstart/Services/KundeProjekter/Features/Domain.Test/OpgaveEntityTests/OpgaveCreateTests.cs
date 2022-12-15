using Xunit;
using Moq;
using KundeProjekter.Domain.DomainServices;
using KundeProjekter.Domain.Model;

namespace KundeProjekter.Domain.Test;

public class OpgaveCreateTests
{
    //Test for valid projekt Id
    [Theory]
    [InlineData(1)]
    public void Given_ProjektId_Is_Valid_Then_Opgave_Is_Created(int projektId)
    {
        // Arrange
        var mock = new Mock<IDomainServiceOpgave>();

        // Act
        var sut = new OpgaveEntity( mock.Object, projektId, "Kategori1", "Kompetence1", "Kommentar");

        // Assert
    }

    // Test for invald projekt Id
    [Theory]
    [InlineData(0)]
    public void Given_ProjektID_Is_InValid_Then_ArgumentException_Is_Thrown(int projektId)
    {
        // Arrange
        var mock = new Mock<IDomainServiceOpgave>();
        // Act

        // Assert
        Assert.True(projektId >= 0, "Value isn't greater than 0");
        Assert.Throws<System.ArgumentException>(() => new OpgaveEntity(mock.Object,projektId, "Kategori1", "Kompetence1", "Kommentar"));
    }

    [Theory]
    [InlineData("Kategori1")]
    [InlineData("Kategori2")]
    [InlineData("Kategori3")]
    [InlineData("Kategori4")]
    public void Given_ProcessKategori_Is_Valid_Then_Opgave_Is_Created(string processKategori)
    {
        // Arrange
        var mock = new Mock<IDomainServiceOpgave>();
        // Act
        var sut = new OpgaveEntity( mock.Object, 1, processKategori, "Kompetence1", "Kommentar");

        // Assert
    }

    [Theory]
    [InlineData("IkkeEnKategori")]
    public void Given_ProcessKategori_Is_InValid_Then_ArgumentException_Is_Thrown(string processKategori)
    {
        // Arrangevar
        var mock = new Mock<IDomainServiceOpgave>();
        // Act

        // Assert
        Assert.Throws<System.ArgumentException>(() => new OpgaveEntity(mock.Object, 1, processKategori, "Kompetence1", "Kommentar"));
    }

    [Theory]
    [InlineData("Kompetence1")]
    [InlineData("Kompetence2")]
    [InlineData("Kompetence3")]
    [InlineData("Kompetence4")]
    public void Given_KompetenceBehov_Is_Valid_Then_Opgave_Is_Created(string kompetenceBehov)
    {
        // Arrange
        var mock = new Mock<IDomainServiceOpgave>();

        // Act
        var sut = new OpgaveEntity(mock.Object, 1, "Kategori1", kompetenceBehov, "Kommentar");

        // Assert
    }

    [Theory]
    [InlineData("IkkeEnKompetence")]
    public void Given_KompetenceBehov_Is_InValid_Then_ArgumentException_Is_Thrown(string kompetenceBehov)
    {
        // Arrange
        var mock = new Mock<IDomainServiceOpgave>();

        // Act

        // Assert
        Assert.Throws<System.ArgumentException>(() => new OpgaveEntity(mock.Object, 1, "Kategori1", kompetenceBehov, "Kommentar"));
    }
}