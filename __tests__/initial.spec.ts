import { describe, it, expect } from 'vitest';

describe('when checking for proper jest functioning', () => {
  it('1 should be 1 and pass', () => {
    expect(1).toEqual(1);
  });
});