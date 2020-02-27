// <copyright file="P15Tests.cs" company="Berkeleybross">
// Copyright (c) Berkeleybross. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace EulerTests
{
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// Lattice paths
    ///
    /// Problem 15
    /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
    ///
    /// How many such routes are there through a 20×20 grid?
    /// </summary>
    public class P15Tests
    {
        public class Solution
            : P15Tests
        {
            [Fact]
            public void CalculatesExample()
            {
                var sut = new P15();
                sut.CountRoutesThroughLattice(2, 2).Should().Be(6);
            }

            [Fact]
            public void CalculatesSolution()
            {
                var sut = new P15();
                sut.CountRoutesThroughLattice(20, 20).Should().Be(137846528820L); // 63ms
            }
        }
    }
}