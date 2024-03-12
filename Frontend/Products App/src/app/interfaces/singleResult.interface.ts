import { Category } from '../models/category';
import { Product } from '../models/Product';

export interface SingleResult {
  statusCode: number;
  isSuccess: boolean;
  errorMessages: string[];
  result: Product | Category;
}
