import { ajax as rxjsAjax } from 'rxjs/ajax';

const post = <T>(url: string, data: T) => {
  return rxjsAjax.post(url, JSON.stringify(data), { 'Content-Type': 'application/json' });
};

const get = <T>(url: string) => {
  return rxjsAjax.getJSON<T>(url);
};

const put = <T>(url: string, data: T) => {
  return rxjsAjax.put(url, JSON.stringify(data), { 'Content-Type': 'application/json' });
};

export const ajax = {
  post,
  put,
  get,
};
