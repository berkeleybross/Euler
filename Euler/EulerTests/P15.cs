using System.Collections.Generic;

namespace EulerTests
{
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
            if (cache.TryGetValue(key, out var result))
            {
                return result;
            }
            
            result = 0;

            if (width > 0)
            {
                result += CountRoutesThroughLattice(width - 1, height);
            }

            if (height > 0)
            {
                result += CountRoutesThroughLattice(width, height - 1);
            }
                
            cache[key] = result;

            return result;
        }
    }
}