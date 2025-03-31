import { describe, it, expect, vi, beforeEach, afterEach } from 'vitest';

import VersionService from '../../src/services/version.service';
import { vol } from 'memfs';

vi.mock('node:fs')
vi.mock('node:fs/promises')

describe('when calling the version service', () => {
  describe('and all is well', () => {
    beforeEach(() => {
      vol.fromJSON({
        'package.json': JSON.stringify({
          name: 'test',
          version: '1.0.0'
        }),
      });
    });

    afterEach(() => {
      vi.restoreAllMocks();
      vol.reset();
    });


    it('should return the version number', async () => {
      // Arrange
      const versionService = new VersionService();

      // Act
      const version = await versionService.getVersion();

      // Assert
      expect(version).toBe('1.0.0');
    });
  });

  describe('and the file is unreadable', () => {
    beforeEach(() => {
      vol.fromJSON({
        'package-jkasdlf.json': JSON.stringify(''),
      });
    });

    afterEach(() => {
      vi.restoreAllMocks();
      vol.reset();
    });

    it('should return the default version number', async () => {
      // Arrange
      const versionService = new VersionService();

      // Act
      const version = await versionService.getVersion();

      // Assert
      expect(version).toBe('0.0.0');
    });
  });
});