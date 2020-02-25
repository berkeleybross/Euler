// Largest palindrome product

// Problem 4
// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

// Find the largest palindrome made from the product of two 3-digit numbers.

function isPalindrome(value) {
  const reverse = value
    .split('')
    .reverse()
    .join('')
  return reverse === value
}

// TODO: Could optimize here and not generate the same product twice
function* generateProducts(start, end) {
  for (let x = start; x <= end; x++) {
    for (let y = start; y <= end; y++) {
      yield x * y
    }
  }
}

function maxPalindrome(start, end) {
  let max = 0
  for (const product of generateProducts(start, end)) {
    if (product > max) {
      if (isPalindrome(product.toString(10))) {
        max = product
      }
    }
  }

  return max
}

describe('isPalindrome', () => {
  it('returns true when given empty string', () => {
    expect(isPalindrome('')).toBe(true)
  })

  it.each(['ab', 'abb', 'abcaa'])(
    'returns false when first character is not equal to last character',
    () => {
      expect(isPalindrome('ab')).toBe(false)
    }
  )

  it.each(['a', 'aa', 'aba', 'abcba'])(
    'returns true when given string equal to its reverse',
    value => {
      expect(isPalindrome(value)).toBe(true)
    }
  )
})

describe('generateProducts', () => {
  it('Does not exceed end', () => {
    const result = generateProducts(0, 0)
    expect(Array.from(result)).toEqual([0])
  })

  it('includes start and end points', () => {
    const result = generateProducts(0, 1)
    expect(Array.from(result)).toEqual([0, 0, 0, 1])
  })

  it('generates products', () => {
    const result = generateProducts(11, 12)
    expect(Array.from(result)).toEqual([121, 132, 132, 144])
  })
})

describe('maxPalindrome', () => {
  it('calculates largest palindrome of 2 digits', () => {
    const result = maxPalindrome(10, 99)
    expect(result).toBe(9009)
  })

  it('calculates largest palindrome of 3 digits', () => {
    const result = maxPalindrome(100, 999)
    expect(result).toBe(906609) // Takes ~50ms, fast enough!
  })
})
