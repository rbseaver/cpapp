import { readFileSync } from 'fs';
import { readFile } from 'fs/promises';
import path from 'path';

class VersionService {
  private cachedVersion: string = '';

  getVersion = async (): Promise<string> => {
    if (this.cachedVersion) {
      return this.cachedVersion;
    }

    try {
      const packagePath = path.resolve('.', 'package.json');
      const data = await readFile(packagePath, 'utf8');
      const packageJson = JSON.parse(data);
      this.cachedVersion = packageJson.version;
      return this.cachedVersion!;
    } catch (error) {
      console.error('Error reading version:', error);
      return '0.0.0';
    }
  }
}


export default VersionService;