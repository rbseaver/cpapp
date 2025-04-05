/// <reference types="vitest/config" />

import { defineConfig, configDefaults } from 'vitest/config';

export default defineConfig({
  test: {
    globals: true,
    environment: 'node',
    include: ['**/*.spec.ts'],
    coverage: {
      reporter: ['text', 'json', 'html'],
      exclude: [
        '**/__tests__/**',
        '**/__mocks__/**',
        '**/node_modules/**',
        '**/.github/**',
        '*.config.js',
        '**/*.spec.ts'
      ],
      provider: 'v8',
      all: true
    },
  }
});