import axios, { AxiosError, AxiosResponse } from 'axios';
import { toast } from 'react-toastify';
import { history } from '../..';
import { ErrorResponse } from '../../models/response';

axios.defaults.baseURL = 'http://localhost:5000/api/';

const responseBody = (response: AxiosResponse) => response.data;
// eslint-disable-next-line @typescript-eslint/no-explicit-any
const sleep = () => new Promise((resolve: any) => setTimeout(resolve, 500));

axios.interceptors.response.use(
  async response => {
    await sleep();
    return response;
  },
  (error: AxiosError) => {
    const { data, status } = <ErrorResponse>error.response;
    switch (status) {
      case 400:
        if (data.errors) {
          const modelStateErrors: string[] = [];
          for (const key in data.errors) {
            if (data.errors[key]) {
              modelStateErrors.push(data.errors[key]);
            }
          }
          throw modelStateErrors.flat();
        }
        toast.error(data.title);
        break;
      case 401:
        toast.error(data.title);
        break;
      case 404:
        toast.error(data.title);
        break;
      case 500:
        history.push('/server-error', { error: data });
        break;

      default:
        break;
    }
    return Promise.reject(error.response);
  }
);

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: object) => axios.post(url, body).then(responseBody),
  put: (url: string, body: object) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Catalog = {
  list: () => requests.get('products'),
  details: (id: number) => requests.get(`products/${id}`),
};

const TestErrors = {
  get400Error: () => requests.get('buggy/bad-request'),
  get401Error: () => requests.get('buggy/unauthorized'),
  get404Error: () => requests.get('buggy/not-found'),
  get500Error: () => requests.get('buggy/server-error'),
  getValidationError: () => requests.get('buggy/validation-error'),
};

const agent = {
  Catalog,
  TestErrors,
};

export default agent;
