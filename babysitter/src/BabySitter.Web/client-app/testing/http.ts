import xhrMock from 'xhr-mock';

export const mockHttpGet = <T>(url: string, model: T) => {
  xhrMock.get(url, {
    body: JSON.stringify(model)
  })
};