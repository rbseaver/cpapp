/// <reference types="vitest/config" />

import { defineConfig, configDefaults } from 'vitest/config';

export default defineConfig({
  test: {
    globals: true,
    environment: 'node',
    dir: './__tests__',
    coverage: {
      reporter: ['text', 'json', 'html'],
      exclude: [
        '**/__tests__/**',
        '**/__mocks__/**',
        '**/node_modules/**',
        '**/.github/**',
        '*.config.js'
      ],
      provider: 'v8',
      all: true
    },
  }
});