import { readFile } from 'fs-extra'
import { maximumPath } from './18'

it('works', async () => {
  const rawTriangle = await readFile('./Problems/p067_triangle.txt', 'utf8')
  const triangle = rawTriangle
    .trim()
    .split('\n')
    .map(line =>
      line
        .trim()
        .split(' ')
        .map(v => parseInt(v, 10))
    )

  expect(maximumPath(triangle)).toBe(7273) // 23ms
})
