﻿// The MIT License (MIT)

// Copyright (c) 2017 Ben Abelshausen

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using NUnit.Framework;
using OsmSharp.Complete;
using System;

namespace OsmSharp.Test.Complete
{
    /// <summary>
    /// Contains tests for the complete way class.
    /// </summary>
    [TestFixture]
    public class CompleteWayTests
    {
        /// <summary>
        /// Tests to simple.
        /// </summary>
        [Test]
        public void TestToSimple()
        {
            var completeWay = new CompleteWay()
            {
                ChangeSetId = 1,
                Id = 10,
                Nodes = new Node[]
                {
                    new Node()
                    {
                        Id = 1
                    },
                    new Node()
                    {
                        Id = 2
                    },
                    new Node()
                    {
                        Id = 3
                    }
                },
                Tags = new Tags.TagsCollection(
                    new Tags.Tag("tag1", "value1"),
                    new Tags.Tag("tag2", "value2")),
                TimeStamp = DateTime.Now,
                UserName = "Ben",
                UserId = 1,
                Version = 23,
                Visible = true
            };

            var osmGeo = completeWay.ToSimple();
            Assert.IsNotNull(osmGeo);
            Assert.IsInstanceOf<Way>(osmGeo);

            var way = osmGeo as Way;
            Assert.AreEqual(completeWay.Id, way.Id);
            Assert.AreEqual(completeWay.ChangeSetId, way.ChangeSetId);
            Assert.AreEqual(completeWay.TimeStamp, way.TimeStamp);
            Assert.AreEqual(completeWay.UserName, way.UserName);
            Assert.AreEqual(completeWay.UserId, way.UserId);
            Assert.AreEqual(completeWay.Version, way.Version);
            Assert.AreEqual(completeWay.Visible, way.Visible);
            Assert.IsNotNull(way.Nodes);
            Assert.AreEqual(completeWay.Nodes.Length, way.Nodes.Length);
            for (var i = 0; i < completeWay.Nodes.Length; i++)
            {
                Assert.AreEqual(completeWay.Nodes[i].Id, way.Nodes[i]);
            }
        }
    }
}