export interface Config {
  backendURL: string;
  issuer: string,
  strictDiscoveryDocumentValidation: boolean,
  redirectUri: string,
  clientId: string,
  scope: string
}
