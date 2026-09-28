#!/usr/bin/env node
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { measureUiDescriptors } from './lib/ui-descriptors.mjs';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
console.log(JSON.stringify(measureUiDescriptors(root), null, 2));
