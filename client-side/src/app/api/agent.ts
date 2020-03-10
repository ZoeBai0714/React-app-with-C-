import axios, { AxiosResponse } from "axios";
import { IActivity } from "../models/activity";

axios.defaults.baseURL = "http://localhost:5000/api"; // this will be added to all the url

const responseBody = (response: AxiosResponse) => response.data;

// we can pass in multiple argument as a sequence of functions, make nested call functions
const sleep = (ms: number) => (response: AxiosResponse) =>
  new Promise<AxiosResponse>(resolve =>
    setTimeout(() => resolve(response), ms)
  );
// There are two then in fetch, we deal with the first one here which returns a promise, and we deal with the other one on the container side
const request = {
  get: (url: string) =>
    axios
      .get(url)
      .then(sleep(1000))
      .then(responseBody),
  post: (url: string, body: {}) =>
    axios
      .post(url, body)
      .then(sleep(1000))
      .then(responseBody),
  put: (url: string, body: {}) =>
    axios
      .put(url, body)
      .then(sleep(1000))
      .then(responseBody),
  delete: (url: string) =>
    axios
      .delete(url)
      .then(sleep(1000))
      .then(responseBody)
};

const Activities = {
  list: (): Promise<IActivity[]> => request.get("/activities"), // make sure we return the type Activity for promise, so the next then we get activity type
  details: (id: string) => request.get(`/activities/${id}`),
  create: (activity: IActivity) => request.post(`/activities`, activity), // pass in parameter string and {}
  update: (activity: IActivity) =>
    request.put(`/activities/${activity.id}`, activity),
  delete: (id: string) => request.delete(`/activities/${id}`) //resontating with ActivityController, it is passing id there for delete
};

export default {
  Activities
};
