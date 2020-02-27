// <copyright file="P15.cs" company="Berkeleybross">
// Copyright (c) Berkeleybross. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace EulerTests
{
    using System.Collections.Generic;

    public class P15
    {
        private readonly Dictionary<(int, int), long> cache = new Dictionary<(int, int), long>();

        public long CountRoutesThroughLattice(int width, int height)
        {
            if (width == 0 && height == 0)
            {
                return 1;
            }

            var key = (width, height);
            if (this.cache.TryGetValue(key, out var result))
            {
                return result;
            }

            result = 0;

            if (width > 0)
            {
                result += this.CountRoutesThroughLattice(width - 1, height);
            }

            if (height > 0)
            {
                result += this.CountRoutesThroughLattice(width, height - 1);
            }

            this.cache[key] = result;

            return result;
        }
    }
}