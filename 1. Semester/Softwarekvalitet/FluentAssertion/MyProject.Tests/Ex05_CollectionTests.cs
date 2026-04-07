using System;
using FluentAssertions;
using Xunit;

namespace MyProject.Tests;

public class Ex05_CollectionTests
{
    [Fact]
    public void Sortedness()
    {
        // result should be sorted in ascending order

        // Arrange
        var result = new[] { 41, 42, 43 };

        // Assert
        result.Should().BeInAscendingOrder();
    }

    [Fact]
    public void CollectionEquality()
    {
        // The two collections should be identical,
        // i.e. contain the same members in the same order

        // Arrange
        var expected = new[] { 41, 42, 43 };

        // Act
        var result = new[] { 41, 42, 43 };

        // Assert
        result.Should().BeEqualTo(expected);
    }

    [Fact]
    public void GetObjects_has_exactly_2_items()
    {
        // Arrange
        int expectedCount = 2;

        // Act
        object[] objects = GetObjects();

        // Assert
        objects.Should().HaveCount(expectedCount);
    }

    [Fact]
    public void GetObjects_SatisfyRespectively()
    {
        // * The first item should be a string of length 2
        // * The second item should be equal to 42
        // See example of SatisfyRespectively on https://fluentassertions.com/collections/

        // Arrange
        int expectedLength = 2;
        int expectedNumber = 42;

        // Act
        object[] objects = GetObjects();

        // Assert
        objects.Should().SatisfyRespectively(
            first =>
            {
                var str = first as string;
                str.Should().HaveLength(expectedLength);
            },
            second =>
            {
                var number = second as int?;
                number.Should().Be(expectedNumber);
            });

    }

    [Fact]
    public void BeEquivalentTo_WithoutOrder()
    {
        // Arrange
        var expected = new object[] { 42, "42" };

        // Act
        object[] objects = GetRandomObjects();

        // Assert
        objects.Should().BeEquivalentTo(expected, options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void BeEquivalentTo_WithStrictOrder()
    {
        // Arrange
        object[] expectedNumbers = ["42", 42];

        // Act
        object[] objects = GetObjects();

        // Assert
        objects.Should().BeEquivalentTo(expectedNumbers, options => options.WithStrictOrdering());
    }

    #region Helpers

    private class Person
    {
        public string Name { get; set; }

        public string Company { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Person person
                && Name == person.Name
                && Company == person.Company;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Company);
    }

    private static object[] GetObjects() => ["42", 42];

    private static object[] GetRandomObjects() => new Random().Next(0, 1) > 0
        ? ["42", 42]
        : [42, "42"];
    #endregion
}