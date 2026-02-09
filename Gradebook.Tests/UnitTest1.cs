using System;
using System.Collections.Generic;
using Xunit;
using GradebookApp; // Adjust this namespace to where your Gradebook class is

namespace Gradebook.Tests
{
    public class GradebookTests
    {
        [Fact]
        public void AddGrade_AddsValidGrade()
        {
            // Arrange
            var book = new Gradebook();

            // Act
            book.AddGrade(85);

            // Assert
            Assert.Equal(85, book.GetGrades()[0]);
        }

        [Fact]
        public void GetAverage_ReturnsCorrectValue()
        {
            // Arrange
            var book = new Gradebook();
            book.AddGrade(80);
            book.AddGrade(90);
            book.AddGrade(100);

            // Act
            var average = book.GetAverage();

            // Assert
            Assert.Equal(90, average, 2); // 2 decimal places
        }

        [Fact]
        public void GetHighestAndLowest_WorkCorrectly()
        {
            // Arrange
            var book = new Gradebook();
            book.AddGrade(70);
            book.AddGrade(85);
            book.AddGrade(95);

            // Act
            var (highest, lowest) = book.GetHighestAndLowest();

            // Assert
            Assert.Equal(95, highest);
            Assert.Equal(70, lowest);
        }
    }
}

