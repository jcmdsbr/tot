using NUnit.Framework;
using FluentAssertions;
using Tot.Shared.Models;
using System;

namespace UnitTests
{
    public class FeedbackTests
    {
        [Test]
        public void IsUnique() => Feedback.CreateNewFeedback("Teste", default).Id.Should().NotBeEmpty();

        [Test]
        public void IsCurrentDate() => Feedback.CreateNewFeedback("Teste", default).Creation.Date.Should().Be(DateTime.Now.Date);
    }
}