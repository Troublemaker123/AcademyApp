import { SubCategory } from './sub-category';

export class Category {
    id:number;
    name:string;
    subcategories?:SubCategory[];
}
