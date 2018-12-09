﻿using System;
using DotRas.Devices;
using NUnit.Framework;
using DotRas.Internal.Factories;
using Moq;

namespace DotRas.Tests.Internal.Factories
{
    [TestFixture]
    public class DeviceTypeFactoryTests
    {
        [Test]
        public void ThrowsAnExceptionWhenTheServiceLocatorIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unused = new DeviceTypeFactory(null);
            });
        }

        [Test]
        public void ReturnsAnUnknownDeviceWhenNotExpected()
        {
            var serviceLocator = new Mock<IServiceProvider>();

            var target = new DeviceTypeFactory(serviceLocator.Object);
            var result = target.Create("unknown-name", "unknown-device");

            Assert.IsInstanceOf<Unknown>(result);

            var device = (Unknown)result;
            Assert.AreEqual("unknown-name", device.Name);
            Assert.AreEqual("unknown-device", device.DeviceType);
        }
    }
}