export interface ErrorResponse {
  data: {
    title: string;
    status: number;
    detail: string;
    errors: [];
  };
  status: number;
}
