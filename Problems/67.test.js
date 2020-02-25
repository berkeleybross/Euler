import { readFile } from 'fs-extra'
import { maximumPath } from './67'

async function readTriangle() {
  const rawTriangle = await readFile('./Problems/p067_triangle.txt', 'utf8')
  return rawTriangle
    .trim()
    .split('\n')
    .map(line =>
      line
        .trim()
        .split(' ')
        .map(v => parseInt(v, 10))
    )
}

it('works on huge triangle', async () => {
  const triangle = await readTriangle()
  expect(maximumPath(triangle)).toBe(7273) // 23ms
})
