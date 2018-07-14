export interface Config {
  baseUrl: string;
}
const devConfig: Config = {
  baseUrl: 'https://localhost:5001',
};
export const getConfig = (): Config => {
  return devConfig;
};
