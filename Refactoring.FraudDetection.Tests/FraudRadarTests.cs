// <copyright file="FraudRadarTests.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Application.FraudResults.Responses;
using Refactoring.FraudDetection.Application.Orders.Contracts;
using Refactoring.FraudDetection.Application.Orders.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class FraudRadarTests
    {
        private readonly IGetOrdersFromFile _getOrdersFromFile;

        public FraudRadarTests()
        {
            _getOrdersFromFile = new GetOrdersFromFile();
        }

        [TestMethod]
        [DeploymentItem(TestConstants.BaseRoute + TestConstants.OneLineFile, TestConstants.Files)]
        public void CheckFraud_OneLineFile_NoFraudExpected()
        {
            var result = ExecuteTest(Path.Combine(Environment.CurrentDirectory, TestConstants.Files, TestConstants.OneLineFile));

            result.Should().NotBeNull(TestConstants.NullError);
            result.Should().HaveCount(0, "The result should not contains fraudulent lines");
        }

        [TestMethod]
        [DeploymentItem(TestConstants.BaseRoute + TestConstants.TwoLines_FraudulentSecond, TestConstants.Files)]
        public void CheckFraud_TwoLines_SecondLineFraudulent()
        {
            var result = ExecuteTest(Path.Combine(Environment.CurrentDirectory, TestConstants.Files, TestConstants.TwoLines_FraudulentSecond));

            result.Should().NotBeNull(TestConstants.NullError);
            result.Should().HaveCount(1, TestConstants.NumberOfLinesError);
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        [DeploymentItem(TestConstants.BaseRoute + TestConstants.ThreeLines_FraudulentSecond, TestConstants.Files)]
        public void CheckFraud_ThreeLines_SecondLineFraudulent()
        {
            var result = ExecuteTest(Path.Combine(Environment.CurrentDirectory, TestConstants.Files, TestConstants.ThreeLines_FraudulentSecond));

            result.Should().NotBeNull(TestConstants.NullError);
            result.Should().HaveCount(1, TestConstants.NumberOfLinesError);
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        [DeploymentItem(TestConstants.BaseRoute + TestConstants.FourLines_MoreThanOneFraudulent, TestConstants.Files)]
        public void CheckFraud_FourLines_MoreThanOneFraudulent()
        {
            var result = ExecuteTest(Path.Combine(Environment.CurrentDirectory, TestConstants.Files, TestConstants.FourLines_MoreThanOneFraudulent));

            result.Should().NotBeNull(TestConstants.NullError);
            result.Should().HaveCount(2, TestConstants.NumberOfLinesError);
        }

      
        
        private List<FraudResult> ExecuteTest(string filePath)
        {
            var fraudRadar = new FraudRadar();
            var orders = _getOrdersFromFile.GetOrders(filePath);

            return fraudRadar.Check(orders).ToList();
        }        
    }
}