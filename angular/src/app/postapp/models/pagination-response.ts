export interface PaginationResponse<T>
{
  content: T[];
  totalItems: number;
  lastPage: number;
  currentPage: number;
  pageSize: number;
}
