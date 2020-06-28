import {IPosts} from './posts';

export interface IPaging {
  pageIndex: number;
  pageSize: number;
  count: number;
  blogList: IPosts[];
}
