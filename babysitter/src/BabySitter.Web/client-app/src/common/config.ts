export interface Config {
  baseUrl: string;
}
const devConfig: Config = {
  baseUrl: process.env['NODE_ENV'] === 'production' ? '' : 'https://localhost:5001',
};
export const getConfig = (): Config => {
  return devConfig;
};
