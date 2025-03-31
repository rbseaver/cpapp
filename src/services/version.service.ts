import { readFile } from 'fs/promises';
import path from 'path';

class VersionService {
  private cachedVersion: string = '';
  private readonly defaultVersion = '0.0.0';

  getVersion = async (): Promise<string> => {
    if (this.cachedVersion) {
      return this.cachedVersion;
    }

    try {
      const packageJson = await this.fetchPackageJson();
      this.cachedVersion = packageJson.version;
      return this.cachedVersion!;
    } catch (error) {
      console.error('Error reading version:', error);
      return this.defaultVersion;
    }
  }

  private fetchPackageJson = async () => {
    const packagePath = path.resolve('.', 'package.json');
    const data = await readFile(packagePath, 'utf8');
    const packageJson = JSON.parse(data);
    return packageJson;
  }
}


export default VersionService;