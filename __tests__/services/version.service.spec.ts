import { describe, it, expect } from 'vitest';

import VersionService from '../../src/services/version.service';

describe('when calling the version service', () => {
  it('should return the version number', () => {
    // Arrange
    const versionService = new VersionService();

    // Act
    const version = versionService.getVersion();

    // Assert
    expect(version).toBe('1.0.0');
  });
});