export const environment = {
  production: true,
  application: {
    name: 'EasyComment',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44315',
    clientId: 'EasyComment_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'EasyComment',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44337',
    },
  },
};
