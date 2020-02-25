export function maximumPath(triangle) {
  const memo = {}

  return memoize(0, 0)

  function memoize(row, col) {
    const key = `${row}_${col}`

    if (!(key in memo)) {
      memo[key] = subPath(row, col)
    }

    return memo[key]
  }

  function subPath(row, col) {
    const value = triangle[row][col]

    if (row == triangle.length - 1) {
      return value
    }

    return value + Math.max(memoize(row + 1, col), memoize(row + 1, col + 1))
  }
}
