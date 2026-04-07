using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace MyProject.Tests;

public class Ex07_ObjectTests
{
    [Fact]
    public void BeEquivalentTo_Exclusion()
    {
        // 'expectedInstance' and 'instance' should be equivalent,
        // without taking the 'Id' property into account.

        // Arrange
        var expectedInstance = new Machine
        {
            Name = "HAL"
        };

        // Act
        Machine instance = GetInstance();

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void BeEquivalentTo_AnonymousType_OnlyMatchOn42()
    {
        // Arrange
        object expected = new
        {
            // Fill out this anonymous type, to match
            // Inner.Inner.MyProperty = 42
            
        };

        // Act
        Nested complexResult = GetNested();

        // Assert
        //complexResult.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Including()
    {
        // 'expected' and 'result' should be equivalent,
        // but only include the field 'name'.

        // Arrange
        var expected = new AnnoyingClass
        {
            name = "John"
        };

        // Act
        AnnoyingClass result = GetResult();

        // Assert

        result.name.Should().BeEquivalentTo(expected.name);
    }

    [Fact]
    public void Using_WhenTypeIs()
    {
        // The model and its mapped version should be equivalent 
        // and any DateTime may vary up to 1 second.

        // Arrange
        var dasModel = GetModel();

        // Act
        object mappedModel = ModelMapper.Map(dasModel);

        // Assert
        throw new NotImplementedException();
    }

    [Fact]
    public void Using_When()
    {
        // The model and its mapped version should be equivalent 
        // and the 'Created' property may vary up to 1 second.
        // As 'mappedModel' is non-generic, we cannot use a predicate
        // as a path to 'Created'

        // Arrange
        var dasModel = GetModel();

        // Act
        object mappedModel = ModelMapper.Map(dasModel);

        // Assert
        throw new NotImplementedException();
    }

    #region Helpers
    private AnnoyingClass GetResult() => new() { id = new Random().Next(), name = "John" };

    private Person GetPerson() => new() { Name = "John" };

    private class Person
    {
        public string Name { get; set; }

        public override bool Equals(object obj) => false;

        public override int GetHashCode() => 0;
    }

    private Machine GetInstance() => new() { Name = "HAL", Id = 9000 };

    private class Machine
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    private class Nested
    {
        public int MyProperty { get; set; }

        public Nested Inner { get; set; }
    }

    private static Nested GetNested()
    {
        var random = new Random();
        return new()
        {
            MyProperty = random.Next(),
            Inner = new()
            {
                MyProperty = random.Next(),
                Inner = new()
                {
                    MyProperty = 42
                }
            }
        };
    }

    private class AnnoyingClass
    {
        public int id;

        public string name;
    }

    private class Model
    {
        public DateTime Created { get; set; }
    }

    private class ModelDto
    {
        public DateTime Created { get; set; }
    }

    private static class ModelMapper
    {
        public static Model Map(ModelDto m) =>
            new() { Created = m.Created + TimeSpan.FromMilliseconds(new Random().Next(1, 42)) };

        public static ModelDto Map(Model m) =>
            new() { Created = m.Created + TimeSpan.FromMilliseconds(new Random().Next(1, 42)) };
    }

    private static Model GetModel() => new() { Created = 19.May(1978) };
    #endregion
}