import { Test, TestingModule } from '@nestjs/testing';
import { VersionService } from './version.service';
import { afterEach, afterAll, beforeEach, beforeAll, describe, expect, it, vi } from 'vitest';
import { vol } from 'memfs';

vi.mock('node:fs');
vi.mock('node:fs/promises');

describe('VersionService', () => {
  let service: VersionService;

  beforeAll(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [VersionService],
    }).compile();
    service = module.get<VersionService>(VersionService);
  });

  afterAll(() => {
    vi.clearAllMocks();
  });

  describe('and all is well', () => {
    beforeEach(async () => {
      vol.fromJSON({
        'package.json': JSON.stringify({
          name: 'test',
          version: '1.0.0'
        })
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
