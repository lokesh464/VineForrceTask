import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'VineForceAPI',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44392/',
    redirectUri: baseUrl,
    clientId: 'VineForceAPI_App',
    responseType: 'code',
    scope: 'offline_access VineForceAPI',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44392',
      rootNamespace: 'VineForceAPI',
    },
  },
} as Environment;
