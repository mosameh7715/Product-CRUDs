import { Product } from '../models/Product';

export interface Result {
  statusCode: number;
  isSuccess: boolean;
  errorMessages: string;
  result: {
    count: number;
    resultSet: Product[];
  };
}
