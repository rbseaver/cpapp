import { expect, use } from 'chai';
import { describe, it } from 'mocha';
import VersionService from '../../src/services/version.service';
import chaiAsPromised from 'chai-as-promised';
describe('when calling the version service', () => {
  use(chaiAsPromised);
  it('should return the version number', () => {
    // Arrange
    const versionService = new VersionService();

    // Act
    const version = versionService.getVersion();

    // Assert
    expect(version).to.be('1.0.0');
  });
});